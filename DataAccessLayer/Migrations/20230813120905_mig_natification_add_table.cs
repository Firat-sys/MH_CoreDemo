using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class mig_natification_add_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Natifications",
                columns: table => new
                {
                    NatificationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Natificationtype = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NatificationTypeSyble = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NatificationDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NatificationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NatificationStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Natifications", x => x.NatificationId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Natifications");
        }
    }
}
