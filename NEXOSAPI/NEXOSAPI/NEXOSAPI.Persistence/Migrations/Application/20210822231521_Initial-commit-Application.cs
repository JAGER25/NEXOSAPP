using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NEXOSAPI.Persistence.Migrations.Application
{
    public partial class InitialcommitApplication : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MaximumBooks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "1, 1"),
                    Total = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaximumBooks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    IdMaximumBooks = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    DateBirth = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    CityOrigin = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    MaximumBooksId = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.IdMaximumBooks);
                    table.ForeignKey(
                        name: "FK_Authors_MaximumBooks_MaximumBooksId",
                        column: x => x.MaximumBooksId,
                        principalTable: "MaximumBooks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    IdAuthor = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "1, 1"),
                    Title = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Year = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Gender = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    NumberPages = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    AuthorIdMaximumBooks = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.IdAuthor);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorIdMaximumBooks",
                        column: x => x.AuthorIdMaximumBooks,
                        principalTable: "Authors",
                        principalColumn: "IdMaximumBooks",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Authors_MaximumBooksId",
                table: "Authors",
                column: "MaximumBooksId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorIdMaximumBooks",
                table: "Books",
                column: "AuthorIdMaximumBooks");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "MaximumBooks");
        }
    }
}
