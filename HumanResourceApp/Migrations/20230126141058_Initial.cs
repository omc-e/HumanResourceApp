using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace HumanResourceApp.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "User",
            //    columns: table => new
            //    {
            //        Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_User", x => x.Id);
            //    });

            migrationBuilder.CreateTable(
                name: "Zaposlenici",
                columns: table => new
                {
                    Id = table.Column<short>(type: "smallint", maxLength: 3, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false),
                    Prezime = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false),
                    Pol = table.Column<byte>(type: "tinyint", nullable: false),
                    Grad = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Adresa = table.Column<string>(type: "varchar(70)", maxLength: 70, nullable: false),
                    DatumDodavanja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DatumIzmjene = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zaposlenici", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dogadjaji",
                columns: table => new
                {
                    Id = table.Column<short>(type: "smallint", maxLength: 3, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ZaposleniciId = table.Column<short>(type: "smallint", maxLength: 3, nullable: false),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ime = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dogadjaji", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dogadjaji_Zaposlenici_ZaposleniciId",
                        column: x => x.ZaposleniciId,
                        principalTable: "Zaposlenici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dogadjaji_ZaposleniciId",
                table: "Dogadjaji",
                column: "ZaposleniciId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dogadjaji");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Zaposlenici");
        }
    }
}
