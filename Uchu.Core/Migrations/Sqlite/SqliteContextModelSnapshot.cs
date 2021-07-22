﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Uchu.Core.Providers;

namespace Uchu.Core.Migrations.Sqlite
{
    [DbContext(typeof(SqliteContext))]
    partial class SqliteContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.5");

            modelBuilder.Entity("Uchu.Core.Character", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("INTEGER");

                    b.Property<int>("BaseHealth")
                        .HasColumnType("INTEGER");

                    b.Property<int>("BaseImagination")
                        .HasColumnType("INTEGER");

                    b.Property<long>("Currency")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CurrentArmor")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CurrentHealth")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CurrentImagination")
                        .HasColumnType("INTEGER");

                    b.Property<string>("CustomName")
                        .IsRequired()
                        .HasMaxLength(33)
                        .HasColumnType("TEXT");

                    b.Property<long>("EyeStyle")
                        .HasColumnType("INTEGER");

                    b.Property<long>("EyebrowStyle")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("FreeToPlay")
                        .HasColumnType("INTEGER");

                    b.Property<long>("GuildId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("HairColor")
                        .HasColumnType("INTEGER");

                    b.Property<long>("HairStyle")
                        .HasColumnType("INTEGER");

                    b.Property<int>("InventorySize")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LandingByRocket")
                        .HasColumnType("INTEGER");

                    b.Property<long>("LastActivity")
                        .HasColumnType("INTEGER");

                    b.Property<long>("LastClone")
                        .HasColumnType("INTEGER");

                    b.Property<int>("LastInstance")
                        .HasColumnType("INTEGER");

                    b.Property<int>("LastZone")
                        .HasColumnType("INTEGER");

                    b.Property<int>("LaunchedRocketFrom")
                        .HasColumnType("INTEGER");

                    b.Property<long>("Level")
                        .HasColumnType("INTEGER");

                    b.Property<long>("Lh")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MaximumArmor")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MaximumHealth")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MaximumImagination")
                        .HasColumnType("INTEGER");

                    b.Property<long>("MouthStyle")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(33)
                        .HasColumnType("TEXT");

                    b.Property<bool>("NameRejected")
                        .HasColumnType("INTEGER");

                    b.Property<long>("PantsColor")
                        .HasColumnType("INTEGER");

                    b.Property<long>("Rh")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Rocket")
                        .HasMaxLength(30)
                        .HasColumnType("TEXT");

                    b.Property<long>("ShirtColor")
                        .HasColumnType("INTEGER");

                    b.Property<long>("ShirtStyle")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SpawnLocationName")
                        .HasMaxLength(33)
                        .HasColumnType("TEXT");

                    b.Property<float?>("SpawnPositionX")
                        .HasColumnType("REAL");

                    b.Property<float?>("SpawnPositionY")
                        .HasColumnType("REAL");

                    b.Property<float?>("SpawnPositionZ")
                        .HasColumnType("REAL");

                    b.Property<float?>("SpawnRotationW")
                        .HasColumnType("REAL");

                    b.Property<float?>("SpawnRotationX")
                        .HasColumnType("REAL");

                    b.Property<float?>("SpawnRotationY")
                        .HasColumnType("REAL");

                    b.Property<float?>("SpawnRotationZ")
                        .HasColumnType("REAL");

                    b.Property<long>("TotalArmorPowerUpsCollected")
                        .HasColumnType("INTEGER");

                    b.Property<long>("TotalArmorRepaired")
                        .HasColumnType("INTEGER");

                    b.Property<long>("TotalBricksCollected")
                        .HasColumnType("INTEGER");

                    b.Property<long>("TotalCurrencyCollected")
                        .HasColumnType("INTEGER");

                    b.Property<long>("TotalDamageHealed")
                        .HasColumnType("INTEGER");

                    b.Property<long>("TotalDamageTaken")
                        .HasColumnType("INTEGER");

                    b.Property<long>("TotalDistanceDriven")
                        .HasColumnType("INTEGER");

                    b.Property<long>("TotalDistanceTraveled")
                        .HasColumnType("INTEGER");

                    b.Property<long>("TotalEnemiesSmashed")
                        .HasColumnType("INTEGER");

                    b.Property<long>("TotalFirstPlaceFinishes")
                        .HasColumnType("INTEGER");

                    b.Property<long>("TotalImaginationPowerUpsCollected")
                        .HasColumnType("INTEGER");

                    b.Property<long>("TotalImaginationRestored")
                        .HasColumnType("INTEGER");

                    b.Property<long>("TotalImaginationUsed")
                        .HasColumnType("INTEGER");

                    b.Property<long>("TotalLifePowerUpsCollected")
                        .HasColumnType("INTEGER");

                    b.Property<long>("TotalMissionsCompleted")
                        .HasColumnType("INTEGER");

                    b.Property<long>("TotalPetsTamed")
                        .HasColumnType("INTEGER");

                    b.Property<long>("TotalQuickBuildsCompleted")
                        .HasColumnType("INTEGER");

                    b.Property<long>("TotalRacecarBoostsActivated")
                        .HasColumnType("INTEGER");

                    b.Property<long>("TotalRacecarWrecks")
                        .HasColumnType("INTEGER");

                    b.Property<long>("TotalRacesFinished")
                        .HasColumnType("INTEGER");

                    b.Property<long>("TotalRacingImaginationCratesSmashed")
                        .HasColumnType("INTEGER");

                    b.Property<long>("TotalRacingImaginationPowerUpsCollected")
                        .HasColumnType("INTEGER");

                    b.Property<long>("TotalRacingSmashablesSmashed")
                        .HasColumnType("INTEGER");

                    b.Property<long>("TotalRocketsUsed")
                        .HasColumnType("INTEGER");

                    b.Property<long>("TotalSmashablesSmashed")
                        .HasColumnType("INTEGER");

                    b.Property<long>("TotalSuicides")
                        .HasColumnType("INTEGER");

                    b.Property<long>("TotalTimeAirborne")
                        .HasColumnType("INTEGER");

                    b.Property<long>("UniverseScore")
                        .HasColumnType("INTEGER");

                    b.Property<long>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("VaultInventorySize")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("Uchu.Core.CharacterFlag", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("CharacterId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Flag")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId");

                    b.ToTable("Flags");
                });

            modelBuilder.Entity("Uchu.Core.CharacterMail", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<ushort>("AttachmentCount")
                        .HasColumnType("INTEGER");

                    b.Property<ulong>("AttachmentCurrency")
                        .HasColumnType("INTEGER");

                    b.Property<int>("AttachmentLot")
                        .HasColumnType("INTEGER");

                    b.Property<long>("AuthorId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Body")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ExpirationTime")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Read")
                        .HasColumnType("INTEGER");

                    b.Property<long>("RecipientId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("SentTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("Subject")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Mails");
                });

            modelBuilder.Entity("Uchu.Core.CharacterTrade", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("CurrencyA")
                        .HasColumnType("INTEGER");

                    b.Property<long>("CurrencyB")
                        .HasColumnType("INTEGER");

                    b.Property<long>("PartyA")
                        .HasColumnType("INTEGER");

                    b.Property<long>("PartyB")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Trades");
                });

            modelBuilder.Entity("Uchu.Core.ChatTranscript", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("Author")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Message")
                        .HasColumnType("TEXT");

                    b.Property<long>("Receiver")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("SentTime")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ChatTranscript");
                });

            modelBuilder.Entity("Uchu.Core.Friend", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("BestFriend")
                        .HasColumnType("INTEGER");

                    b.Property<long>("FriendA")
                        .HasColumnType("INTEGER");

                    b.Property<long>("FriendB")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Friends");
                });

            modelBuilder.Entity("Uchu.Core.FriendRequest", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("BestFriend")
                        .HasColumnType("INTEGER");

                    b.Property<long>("Receiver")
                        .HasColumnType("INTEGER");

                    b.Property<long>("Sender")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Sent")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("FriendRequests");
                });

            modelBuilder.Entity("Uchu.Core.Guild", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("INTEGER");

                    b.Property<long>("CreatorId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Guilds");
                });

            modelBuilder.Entity("Uchu.Core.GuildInvite", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("GuildId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("RecipientId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("SenderId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("GuildId");

                    b.ToTable("GuildInvites");
                });

            modelBuilder.Entity("Uchu.Core.InventoryItem", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("INTEGER");

                    b.Property<long>("CharacterId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("Count")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ExtraInfo")
                        .HasColumnType("TEXT");

                    b.Property<int>("InventoryType")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsBound")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsEquipped")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Lot")
                        .HasColumnType("INTEGER");

                    b.Property<long>("ParentId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Slot")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId");

                    b.ToTable("InventoryItems");
                });

            modelBuilder.Entity("Uchu.Core.Mission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("CharacterId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CompletionCount")
                        .HasColumnType("INTEGER");

                    b.Property<long>("LastCompletion")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MissionId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("State")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId");

                    b.ToTable("Missions");
                });

            modelBuilder.Entity("Uchu.Core.MissionTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("MissionId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TaskId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("MissionId");

                    b.ToTable("MissionTasks");
                });

            modelBuilder.Entity("Uchu.Core.MissionTaskValue", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Count")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MissionTaskId")
                        .HasColumnType("INTEGER");

                    b.Property<float>("Value")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("MissionTaskId");

                    b.ToTable("MissionTaskValue");
                });

            modelBuilder.Entity("Uchu.Core.SessionCache", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<long>("CharacterId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Key")
                        .HasColumnType("TEXT");

                    b.Property<long>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ZoneId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("SessionCaches");
                });

            modelBuilder.Entity("Uchu.Core.TradeTransactionItem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("ItemId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("Party")
                        .HasColumnType("INTEGER");

                    b.Property<long>("TradeId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("TradeId");

                    b.ToTable("TransactionItems");
                });

            modelBuilder.Entity("Uchu.Core.UnlockedEmote", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("CharacterId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("EmoteId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId");

                    b.ToTable("UnlockedEmote");
                });

            modelBuilder.Entity("Uchu.Core.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Banned")
                        .HasColumnType("INTEGER");

                    b.Property<string>("BannedReason")
                        .HasColumnType("TEXT");

                    b.Property<int>("CharacterIndex")
                        .HasColumnType("INTEGER");

                    b.Property<string>("CustomLockout")
                        .HasColumnType("TEXT");

                    b.Property<bool>("FirstTimeOnSubscription")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("FreeToPlay")
                        .HasColumnType("INTEGER");

                    b.Property<int>("GameMasterLevel")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Password")
                        .HasMaxLength(60)
                        .HasColumnType("TEXT");

                    b.Property<bool>("Sso")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(33)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Uchu.Core.Character", b =>
                {
                    b.HasOne("Uchu.Core.User", "User")
                        .WithMany("Characters")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Uchu.Core.CharacterFlag", b =>
                {
                    b.HasOne("Uchu.Core.Character", "Character")
                        .WithMany("Flags")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Character");
                });

            modelBuilder.Entity("Uchu.Core.GuildInvite", b =>
                {
                    b.HasOne("Uchu.Core.Guild", "Guild")
                        .WithMany("Invites")
                        .HasForeignKey("GuildId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Guild");
                });

            modelBuilder.Entity("Uchu.Core.InventoryItem", b =>
                {
                    b.HasOne("Uchu.Core.Character", "Character")
                        .WithMany("Items")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Character");
                });

            modelBuilder.Entity("Uchu.Core.Mission", b =>
                {
                    b.HasOne("Uchu.Core.Character", "Character")
                        .WithMany("Missions")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Character");
                });

            modelBuilder.Entity("Uchu.Core.MissionTask", b =>
                {
                    b.HasOne("Uchu.Core.Mission", "Mission")
                        .WithMany("Tasks")
                        .HasForeignKey("MissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Mission");
                });

            modelBuilder.Entity("Uchu.Core.MissionTaskValue", b =>
                {
                    b.HasOne("Uchu.Core.MissionTask", "MissionTask")
                        .WithMany("Values")
                        .HasForeignKey("MissionTaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MissionTask");
                });

            modelBuilder.Entity("Uchu.Core.TradeTransactionItem", b =>
                {
                    b.HasOne("Uchu.Core.CharacterTrade", "Trade")
                        .WithMany("TransactionItems")
                        .HasForeignKey("TradeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Trade");
                });

            modelBuilder.Entity("Uchu.Core.UnlockedEmote", b =>
                {
                    b.HasOne("Uchu.Core.Character", "Character")
                        .WithMany("UnlockedEmotes")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Character");
                });

            modelBuilder.Entity("Uchu.Core.Character", b =>
                {
                    b.Navigation("Flags");

                    b.Navigation("Items");

                    b.Navigation("Missions");

                    b.Navigation("UnlockedEmotes");
                });

            modelBuilder.Entity("Uchu.Core.CharacterTrade", b =>
                {
                    b.Navigation("TransactionItems");
                });

            modelBuilder.Entity("Uchu.Core.Guild", b =>
                {
                    b.Navigation("Invites");
                });

            modelBuilder.Entity("Uchu.Core.Mission", b =>
                {
                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("Uchu.Core.MissionTask", b =>
                {
                    b.Navigation("Values");
                });

            modelBuilder.Entity("Uchu.Core.User", b =>
                {
                    b.Navigation("Characters");
                });
#pragma warning restore 612, 618
        }
    }
}
