﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Uchu.Core.Providers;

#nullable disable

namespace Uchu.Core.Migrations.MySql
{
    [DbContext(typeof(MySqlContext))]
    partial class MySqlContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Uchu.Core.ActivityScore", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<int>("Activity")
                        .HasColumnType("int");

                    b.Property<int>("BestLapTime")
                        .HasColumnType("int");

                    b.Property<long>("CharacterId")
                        .HasColumnType("bigint");

                    b.Property<long>("LastPlayed")
                        .HasColumnType("bigint");

                    b.Property<int>("NumPlayed")
                        .HasColumnType("int");

                    b.Property<int>("Points")
                        .HasColumnType("int");

                    b.Property<int>("Time")
                        .HasColumnType("int");

                    b.Property<int>("Week")
                        .HasColumnType("int");

                    b.Property<int>("Wins")
                        .HasColumnType("int");

                    b.Property<ushort>("Zone")
                        .HasColumnType("smallint unsigned");

                    b.HasKey("Id");

                    b.ToTable("ActivityScores");
                });

            modelBuilder.Entity("Uchu.Core.Character", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<int>("BaseHealth")
                        .HasColumnType("int");

                    b.Property<int>("BaseImagination")
                        .HasColumnType("int");

                    b.Property<long>("Currency")
                        .HasColumnType("bigint");

                    b.Property<int>("CurrentArmor")
                        .HasColumnType("int");

                    b.Property<int>("CurrentHealth")
                        .HasColumnType("int");

                    b.Property<int>("CurrentImagination")
                        .HasColumnType("int");

                    b.Property<string>("CustomName")
                        .IsRequired()
                        .HasMaxLength(33)
                        .HasColumnType("varchar(33)");

                    b.Property<long>("EyeStyle")
                        .HasColumnType("bigint");

                    b.Property<long>("EyebrowStyle")
                        .HasColumnType("bigint");

                    b.Property<bool>("FreeToPlay")
                        .HasColumnType("tinyint(1)");

                    b.Property<long>("GuildId")
                        .HasColumnType("bigint");

                    b.Property<long>("HairColor")
                        .HasColumnType("bigint");

                    b.Property<long>("HairStyle")
                        .HasColumnType("bigint");

                    b.Property<int>("InventorySize")
                        .HasColumnType("int");

                    b.Property<bool>("LandingByRocket")
                        .HasColumnType("tinyint(1)");

                    b.Property<long>("LastActivity")
                        .HasColumnType("bigint");

                    b.Property<long>("LastClone")
                        .HasColumnType("bigint");

                    b.Property<int>("LastInstance")
                        .HasColumnType("int");

                    b.Property<int>("LastZone")
                        .HasColumnType("int");

                    b.Property<int>("LaunchedRocketFrom")
                        .HasColumnType("int");

                    b.Property<long>("Level")
                        .HasColumnType("bigint");

                    b.Property<long>("Lh")
                        .HasColumnType("bigint");

                    b.Property<int>("MaximumArmor")
                        .HasColumnType("int");

                    b.Property<int>("MaximumHealth")
                        .HasColumnType("int");

                    b.Property<int>("MaximumImagination")
                        .HasColumnType("int");

                    b.Property<long>("MouthStyle")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(33)
                        .HasColumnType("varchar(33)");

                    b.Property<bool>("NameRejected")
                        .HasColumnType("tinyint(1)");

                    b.Property<long>("PantsColor")
                        .HasColumnType("bigint");

                    b.Property<long>("Rh")
                        .HasColumnType("bigint");

                    b.Property<string>("Rocket")
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<int>("SelectedConsumable")
                        .HasColumnType("int");

                    b.Property<long>("ShirtColor")
                        .HasColumnType("bigint");

                    b.Property<long>("ShirtStyle")
                        .HasColumnType("bigint");

                    b.Property<string>("SpawnLocationName")
                        .HasMaxLength(33)
                        .HasColumnType("varchar(33)");

                    b.Property<float?>("SpawnPositionX")
                        .HasColumnType("float");

                    b.Property<float?>("SpawnPositionY")
                        .HasColumnType("float");

                    b.Property<float?>("SpawnPositionZ")
                        .HasColumnType("float");

                    b.Property<float?>("SpawnRotationW")
                        .HasColumnType("float");

                    b.Property<float?>("SpawnRotationX")
                        .HasColumnType("float");

                    b.Property<float?>("SpawnRotationY")
                        .HasColumnType("float");

                    b.Property<float?>("SpawnRotationZ")
                        .HasColumnType("float");

                    b.Property<long>("TotalArmorPowerUpsCollected")
                        .HasColumnType("bigint");

                    b.Property<long>("TotalArmorRepaired")
                        .HasColumnType("bigint");

                    b.Property<long>("TotalBricksCollected")
                        .HasColumnType("bigint");

                    b.Property<long>("TotalCurrencyCollected")
                        .HasColumnType("bigint");

                    b.Property<long>("TotalDamageHealed")
                        .HasColumnType("bigint");

                    b.Property<long>("TotalDamageTaken")
                        .HasColumnType("bigint");

                    b.Property<long>("TotalDistanceDriven")
                        .HasColumnType("bigint");

                    b.Property<long>("TotalDistanceTraveled")
                        .HasColumnType("bigint");

                    b.Property<long>("TotalEnemiesSmashed")
                        .HasColumnType("bigint");

                    b.Property<long>("TotalFirstPlaceFinishes")
                        .HasColumnType("bigint");

                    b.Property<long>("TotalImaginationPowerUpsCollected")
                        .HasColumnType("bigint");

                    b.Property<long>("TotalImaginationRestored")
                        .HasColumnType("bigint");

                    b.Property<long>("TotalImaginationUsed")
                        .HasColumnType("bigint");

                    b.Property<long>("TotalLifePowerUpsCollected")
                        .HasColumnType("bigint");

                    b.Property<long>("TotalMissionsCompleted")
                        .HasColumnType("bigint");

                    b.Property<long>("TotalPetsTamed")
                        .HasColumnType("bigint");

                    b.Property<long>("TotalQuickBuildsCompleted")
                        .HasColumnType("bigint");

                    b.Property<long>("TotalRacecarBoostsActivated")
                        .HasColumnType("bigint");

                    b.Property<long>("TotalRacecarWrecks")
                        .HasColumnType("bigint");

                    b.Property<long>("TotalRacesFinished")
                        .HasColumnType("bigint");

                    b.Property<long>("TotalRacingImaginationCratesSmashed")
                        .HasColumnType("bigint");

                    b.Property<long>("TotalRacingImaginationPowerUpsCollected")
                        .HasColumnType("bigint");

                    b.Property<long>("TotalRacingSmashablesSmashed")
                        .HasColumnType("bigint");

                    b.Property<long>("TotalRocketsUsed")
                        .HasColumnType("bigint");

                    b.Property<long>("TotalSmashablesSmashed")
                        .HasColumnType("bigint");

                    b.Property<long>("TotalSuicides")
                        .HasColumnType("bigint");

                    b.Property<long>("TotalTimeAirborne")
                        .HasColumnType("bigint");

                    b.Property<long>("UniverseScore")
                        .HasColumnType("bigint");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<int>("VaultInventorySize")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("Uchu.Core.CharacterFlag", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long>("CharacterId")
                        .HasColumnType("bigint");

                    b.Property<int>("Flag")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId");

                    b.ToTable("Flags");
                });

            modelBuilder.Entity("Uchu.Core.CharacterMail", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<ushort>("AttachmentCount")
                        .HasColumnType("smallint unsigned");

                    b.Property<ulong>("AttachmentCurrency")
                        .HasColumnType("bigint unsigned");

                    b.Property<int>("AttachmentLot")
                        .HasColumnType("int");

                    b.Property<long>("AuthorId")
                        .HasColumnType("bigint");

                    b.Property<string>("Body")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("ExpirationTime")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("Read")
                        .HasColumnType("tinyint(1)");

                    b.Property<long>("RecipientId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("SentTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Subject")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Mails");
                });

            modelBuilder.Entity("Uchu.Core.CharacterTrade", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long>("CurrencyA")
                        .HasColumnType("bigint");

                    b.Property<long>("CurrencyB")
                        .HasColumnType("bigint");

                    b.Property<long>("PartyA")
                        .HasColumnType("bigint");

                    b.Property<long>("PartyB")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Trades");
                });

            modelBuilder.Entity("Uchu.Core.ChatTranscript", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long>("Author")
                        .HasColumnType("bigint");

                    b.Property<string>("Message")
                        .HasColumnType("longtext");

                    b.Property<long>("Receiver")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("SentTime")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("ChatTranscript");
                });

            modelBuilder.Entity("Uchu.Core.Friend", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<bool>("BestFriend")
                        .HasColumnType("tinyint(1)");

                    b.Property<long>("FriendA")
                        .HasColumnType("bigint");

                    b.Property<long>("FriendB")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Friends");
                });

            modelBuilder.Entity("Uchu.Core.FriendRequest", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<bool>("BestFriend")
                        .HasColumnType("tinyint(1)");

                    b.Property<long>("Receiver")
                        .HasColumnType("bigint");

                    b.Property<long>("Sender")
                        .HasColumnType("bigint");

                    b.Property<bool>("Sent")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.ToTable("FriendRequests");
                });

            modelBuilder.Entity("Uchu.Core.Guild", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<long>("CreatorId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Guilds");
                });

            modelBuilder.Entity("Uchu.Core.GuildInvite", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long>("GuildId")
                        .HasColumnType("bigint");

                    b.Property<long>("RecipientId")
                        .HasColumnType("bigint");

                    b.Property<long>("SenderId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("GuildId");

                    b.ToTable("GuildInvites");
                });

            modelBuilder.Entity("Uchu.Core.InventoryItem", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<long>("CharacterId")
                        .HasColumnType("bigint");

                    b.Property<long>("Count")
                        .HasColumnType("bigint");

                    b.Property<string>("ExtraInfo")
                        .HasColumnType("longtext");

                    b.Property<int>("InventoryType")
                        .HasColumnType("int");

                    b.Property<bool>("IsBound")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsEquipped")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("Lot")
                        .HasColumnType("int");

                    b.Property<long>("ParentId")
                        .HasColumnType("bigint");

                    b.Property<int>("Slot")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId");

                    b.ToTable("InventoryItems");
                });

            modelBuilder.Entity("Uchu.Core.Mission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<long>("CharacterId")
                        .HasColumnType("bigint");

                    b.Property<int>("CompletionCount")
                        .HasColumnType("int");

                    b.Property<long>("LastCompletion")
                        .HasColumnType("bigint");

                    b.Property<int>("MissionId")
                        .HasColumnType("int");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId");

                    b.ToTable("Missions");
                });

            modelBuilder.Entity("Uchu.Core.MissionTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("MissionId")
                        .HasColumnType("int");

                    b.Property<int>("TaskId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MissionId");

                    b.ToTable("MissionTasks");
                });

            modelBuilder.Entity("Uchu.Core.MissionTaskValue", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<int>("MissionTaskId")
                        .HasColumnType("int");

                    b.Property<float>("Value")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("MissionTaskId");

                    b.ToTable("MissionTaskValue");
                });

            modelBuilder.Entity("Uchu.Core.SessionCache", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<long>("CharacterId")
                        .HasColumnType("bigint");

                    b.Property<string>("Key")
                        .HasColumnType("longtext");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<int>("ZoneId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("SessionCaches");
                });

            modelBuilder.Entity("Uchu.Core.TradeTransactionItem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long>("ItemId")
                        .HasColumnType("bigint");

                    b.Property<long>("Party")
                        .HasColumnType("bigint");

                    b.Property<long>("TradeId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("TradeId");

                    b.ToTable("TransactionItems");
                });

            modelBuilder.Entity("Uchu.Core.UnlockedEmote", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long>("CharacterId")
                        .HasColumnType("bigint");

                    b.Property<int>("EmoteId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId");

                    b.ToTable("UnlockedEmote");
                });

            modelBuilder.Entity("Uchu.Core.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<bool>("Banned")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("BannedReason")
                        .HasColumnType("longtext");

                    b.Property<int>("CharacterIndex")
                        .HasColumnType("int");

                    b.Property<string>("CustomLockout")
                        .HasColumnType("longtext");

                    b.Property<bool>("FirstTimeOnSubscription")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("FreeToPlay")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("GameMasterLevel")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.Property<bool>("Sso")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(33)
                        .HasColumnType("varchar(33)");

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
