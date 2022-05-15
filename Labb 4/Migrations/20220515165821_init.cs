using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Labb_4.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 50, nullable: false),
                    Author = table.Column<string>(maxLength: 50, nullable: false),
                    BookId = table.Column<int>(nullable: false),
                    BookRating = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 20, nullable: false),
                    LastName = table.Column<string>(maxLength: 20, nullable: false),
                    Adress = table.Column<string>(maxLength: 30, nullable: false),
                    PhoneNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BorrowedBooks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false),
                    ReturnTime = table.Column<DateTime>(nullable: false),
                    BeenReturned = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BorrowedBooks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BorrowedBooks_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BorrowedBooks_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "BookId", "BookRating", "Title" },
                values: new object[,]
                {
                    { 1, "Andy Weir", 10000, 8f, "Project Hail Mary" },
                    { 2, "James Clear", 10001, 7.5f, "Atomic Habits" },
                    { 3, "Donna Tartt", 10002, 7f, "The Secret History" },
                    { 4, "Joe Abercrombie", 10003, 8.35f, "The Blade Itself" },
                    { 5, "Graham Hancock", 10004, 9.5f, "Fingerprints of the Gods" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Adress", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "Hejsanhoppsanstigen 13", "Adam", "Adamsson", "0709-123123" },
                    { 2, "Bamsegatan 37", "Bertil", "Bertilsson", null },
                    { 3, "Ajvarvägen 1", "Ceasar", "Ceasarsson", null },
                    { 4, "Väg 1", "David", "Davidsson", null },
                    { 5, "Skogstråket", "Erik", "Eriksson", null }
                });

            migrationBuilder.InsertData(
                table: "BorrowedBooks",
                columns: new[] { "Id", "BeenReturned", "BookId", "CustomerId", "ReturnTime" },
                values: new object[] { 1, false, 1, 1, new DateTime(2022, 6, 15, 18, 58, 21, 622, DateTimeKind.Local).AddTicks(479) });

            migrationBuilder.InsertData(
                table: "BorrowedBooks",
                columns: new[] { "Id", "BeenReturned", "BookId", "CustomerId", "ReturnTime" },
                values: new object[] { 2, false, 2, 1, new DateTime(2022, 6, 15, 18, 58, 21, 624, DateTimeKind.Local).AddTicks(1102) });

            migrationBuilder.InsertData(
                table: "BorrowedBooks",
                columns: new[] { "Id", "BeenReturned", "BookId", "CustomerId", "ReturnTime" },
                values: new object[] { 3, false, 3, 1, new DateTime(2022, 6, 15, 18, 58, 21, 624, DateTimeKind.Local).AddTicks(1164) });

            migrationBuilder.CreateIndex(
                name: "IX_BorrowedBooks_BookId",
                table: "BorrowedBooks",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BorrowedBooks_CustomerId",
                table: "BorrowedBooks",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BorrowedBooks");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
