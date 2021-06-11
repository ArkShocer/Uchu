using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using InfectedRose.Core;
using RakDotNet.IO;

namespace Uchu.Core
{
    public class PacketProperty : IPacketProperty
    {
        /// <summary>
        /// Property that is read from or read to.
        /// </summary>
        public PropertyInfo Property { get; }

        /// <summary>
        /// Special cases for written property types.
        /// </summary>
        public static Dictionary<Type, Action<BitWriter, object>> CustomWriters = new Dictionary<Type, Action<BitWriter, object>>()
            {
                {
                    typeof(bool), (writer, o) =>
                    {
                        writer.WriteBit((bool) o);
                    }
                },
                {
                    typeof(Quaternion), (writer, o) =>
                    {
                        // Special case for Quaternions where LU works with W,X,Y,Z while
                        // the convention is X,Y,Z,W.
                        writer.WriteNiQuaternion((Quaternion) o);
                    }
                },
            };
        
        /// <summary>
        /// Special cases for read property types.
        /// </summary>
        public static Dictionary<Type, Func<BitReader, object>> CustomReaders = new Dictionary<Type, Func<BitReader, object>>()
        {
            {
                typeof(bool), (reader) =>
                {
                    return reader.ReadBit();
                }
            },
            {
                typeof(Quaternion), (reader) =>
                {
                    // Special case for Quaternions where LU works with W,X,Y,Z while
                    // the convention is X,Y,Z,W.
                    return reader.ReadNiQuaternion();
                }
            },
        };
        
        /// <summary>
        /// Reflection information for the Write<>(object) method in BitWriter.
        /// </summary>
        private static MethodInfo _bitWriterWriteMethod = typeof(BitWriter).GetMethods().FirstOrDefault(newMethod => newMethod.Name == "Write" && newMethod.GetParameters().Length == 1);

        /// <summary>
        /// Reflection information for the Read<>(object) method in BitReader.
        /// </summary>
        private static MethodInfo _bitReaderReadMethod = typeof(BitReader).GetMethods().FirstOrDefault(newMethod => newMethod.Name == "Read" && newMethod.GetParameters().Length == 0);
        
        /// <summary>
        /// Type of the property that is written.
        /// </summary>
        private Type _propertyType;

        /// <summary>
        /// Custom property writer for the type.
        /// </summary>
        private Action<BitWriter, object> _customWriter;

        /// <summary>
        /// Custom property reader for the type.
        /// </summary>
        private Func<BitReader, object> _customReader;
        
        /// <summary>
        /// Creates the packet property.
        /// </summary>
        /// <param name="property">Property to write.</param>
        public PacketProperty(PropertyInfo property)
        {
            // Store the property.
            this.Property = property;
            
            // Get the type to write.
            if (property == null) return;
            this._propertyType = property.PropertyType;
            if (this._propertyType.IsEnum)
            {
                this._propertyType = Enum.GetUnderlyingType(this._propertyType);
            }
            
            // Get the custom writer and reader.
            foreach (var (customWriterType, customWriter) in CustomWriters)
            {
                if (customWriterType == this._propertyType || this._propertyType.IsSubclassOf(customWriterType))
                {
                    this._customWriter = customWriter;
                }
            }
            foreach (var (customReaderType, customReader) in CustomReaders)
            {
                if (customReaderType == this._propertyType || this._propertyType.IsSubclassOf(customReaderType))
                {
                    this._customReader = customReader;
                }
            }
        }

        /// <summary>
        /// Writes the property to the writer.
        /// </summary>
        /// <param name="objectToWrite">Object with the property to write.</param>
        /// <param name="writer">Bit writer to write to.</param>
        /// <param name="writtenProperties">Properties that were previously written.</param>
        public void Write(object objectToWrite, BitWriter writer, Dictionary<string, object> writtenProperties)
        {
            // Write the property.
            var value = this.Property.GetValue(objectToWrite);
            if (this._customWriter != null)
            {
                this._customWriter(writer, value);
            } else {
                _bitWriterWriteMethod.MakeGenericMethod(this._propertyType)
                    .Invoke(writer, new object[] { value });
            }

            // Store the written property.
            if (writtenProperties != null)
            {
                writtenProperties[this.Property.Name] = value;
            }
        }

        /// <summary>
        /// Reads the property to the reader.
        /// </summary>
        /// <param name="objectToWrite">Object with the property to read.</param>
        /// <param name="reader">Bit reader to read to.</param>
        /// <param name="readProperties">Properties that were previously read.</param>
        public void Read(object objectToWrite, BitReader reader, Dictionary<string, object> readProperties)
        {
            // Read the property.
            object value = null;
            if (this._customReader != null)
            {
                value = this._customReader(reader);
            } else
            {
                value = _bitReaderReadMethod.MakeGenericMethod(this._propertyType).Invoke(reader, null);
            }
            this.Property.SetValue(objectToWrite, value);
            
            
            // Store the written property.
            if (readProperties != null)
            {
                readProperties[this.Property.Name] = this.Property.GetValue(objectToWrite);
            }
        }
    }
}