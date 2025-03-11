using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Playstation.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Snacks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Snacks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Role = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    FullName = table.Column<string>(type: "text", nullable: false),
                    Lastname = table.Column<string>(type: "text", nullable: false),
                    Firstname = table.Column<string>(type: "text", nullable: false),
                    Salt = table.Column<string>(type: "text", nullable: false),
                    RefreshToken = table.Column<string>(type: "text", nullable: true),
                    RefreshTokenExpireDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlayStationRooms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    LocationId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayStationRooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayStationRooms_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OtpCode",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    UserId1 = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtpCode", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OtpCode_Users_UserId1",
                        column: x => x.UserId1,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserSessions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Token = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSessions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    RoomId = table.Column<Guid>(type: "uuid", nullable: false),
                    GameId = table.Column<Guid>(type: "uuid", nullable: false),
                    StartTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EndTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookings_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookings_PlayStationRooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "PlayStationRooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayStationRoomGames",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PlayStationRoomId = table.Column<Guid>(type: "uuid", nullable: false),
                    GameId = table.Column<Guid>(type: "uuid", nullable: false),
                    PricePerHour = table.Column<decimal>(type: "numeric", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayStationRoomGames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayStationRoomGames_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayStationRoomGames_PlayStationRooms_PlayStationRoomId",
                        column: x => x.PlayStationRoomId,
                        principalTable: "PlayStationRooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookingSnacks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BookingId = table.Column<Guid>(type: "uuid", nullable: false),
                    SnackId = table.Column<Guid>(type: "uuid", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingSnacks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookingSnacks_Bookings_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Bookings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookingSnacks_Snacks_SnackId",
                        column: x => x.SnackId,
                        principalTable: "Snacks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    BookingId = table.Column<Guid>(type: "uuid", nullable: false),
                    Rating = table.Column<int>(type: "integer", nullable: false),
                    Comment = table.Column<string>(type: "text", nullable: true),
                    AverageRating = table.Column<decimal>(type: "numeric", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Bookings_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Bookings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BookingId = table.Column<Guid>(type: "uuid", nullable: true),
                    BookingSnackId = table.Column<Guid>(type: "uuid", nullable: true),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PaymentMethod = table.Column<int>(type: "integer", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_BookingSnacks_BookingSnackId",
                        column: x => x.BookingSnackId,
                        principalTable: "BookingSnacks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Payments_Bookings_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Bookings",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_GameId",
                table: "Bookings",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_RoomId",
                table: "Bookings",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_UserId",
                table: "Bookings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingSnacks_BookingId",
                table: "BookingSnacks",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingSnacks_SnackId",
                table: "BookingSnacks",
                column: "SnackId");

            migrationBuilder.CreateIndex(
                name: "IX_OtpCode_UserId1",
                table: "OtpCode",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_BookingId",
                table: "Payments",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_BookingSnackId",
                table: "Payments",
                column: "BookingSnackId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayStationRoomGames_GameId",
                table: "PlayStationRoomGames",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayStationRoomGames_PlayStationRoomId",
                table: "PlayStationRoomGames",
                column: "PlayStationRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayStationRooms_LocationId",
                table: "PlayStationRooms",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_BookingId",
                table: "Reviews",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserId",
                table: "Reviews",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSessions_UserId",
                table: "UserSessions",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OtpCode");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "PlayStationRoomGames");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "UserSessions");

            migrationBuilder.DropTable(
                name: "BookingSnacks");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Snacks");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "PlayStationRooms");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Locations");
        }
    }
}
