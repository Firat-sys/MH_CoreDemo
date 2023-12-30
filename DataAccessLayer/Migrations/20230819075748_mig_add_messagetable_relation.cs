using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class mig_add_messagetable_relation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Teams_GuesteamsId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Teams_HomeTeamsId",
                table: "Matches");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Matches",
                table: "Matches");

            migrationBuilder.RenameTable(
                name: "Matches",
                newName: "Match");

            migrationBuilder.RenameIndex(
                name: "IX_Matches_HomeTeamsId",
                table: "Match",
                newName: "IX_Match_HomeTeamsId");

            migrationBuilder.RenameIndex(
                name: "IX_Matches_GuesteamsId",
                table: "Match",
                newName: "IX_Match_GuesteamsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Match",
                table: "Match",
                column: "MatchId");

            migrationBuilder.CreateTable(
                name: "Message2s",
                columns: table => new
                {
                    MessageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SenderId = table.Column<int>(type: "int", nullable: true),
                    ReceiverId = table.Column<int>(type: "int", nullable: true),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MessageDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MessageDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MessageStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message2s", x => x.MessageId);
                    table.ForeignKey(
                        name: "FK_Message2s_Writers_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "Writers",
                        principalColumn: "WriterId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Message2s_Writers_SenderId",
                        column: x => x.SenderId,
                        principalTable: "Writers",
                        principalColumn: "WriterId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Message2s_ReceiverId",
                table: "Message2s",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_Message2s_SenderId",
                table: "Message2s",
                column: "SenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Match_Teams_GuesteamsId",
                table: "Match",
                column: "GuesteamsId",
                principalTable: "Teams",
                principalColumn: "TeanId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Match_Teams_HomeTeamsId",
                table: "Match",
                column: "HomeTeamsId",
                principalTable: "Teams",
                principalColumn: "TeanId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Match_Teams_GuesteamsId",
                table: "Match");

            migrationBuilder.DropForeignKey(
                name: "FK_Match_Teams_HomeTeamsId",
                table: "Match");

            migrationBuilder.DropTable(
                name: "Message2s");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Match",
                table: "Match");

            migrationBuilder.RenameTable(
                name: "Match",
                newName: "Matches");

            migrationBuilder.RenameIndex(
                name: "IX_Match_HomeTeamsId",
                table: "Matches",
                newName: "IX_Matches_HomeTeamsId");

            migrationBuilder.RenameIndex(
                name: "IX_Match_GuesteamsId",
                table: "Matches",
                newName: "IX_Matches_GuesteamsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Matches",
                table: "Matches",
                column: "MatchId");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Teams_GuesteamsId",
                table: "Matches",
                column: "GuesteamsId",
                principalTable: "Teams",
                principalColumn: "TeanId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Teams_HomeTeamsId",
                table: "Matches",
                column: "HomeTeamsId",
                principalTable: "Teams",
                principalColumn: "TeanId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
