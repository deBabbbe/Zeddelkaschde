using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KaschdeList",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KaschdeList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZeddelList",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Question = table.Column<string>(type: "TEXT", nullable: false),
                    Answer = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZeddelList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FachData",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Priority = table.Column<int>(type: "INTEGER", nullable: false),
                    ZeddelId = table.Column<Guid>(type: "TEXT", nullable: false),
                    KaschdeId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FachData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FachData_KaschdeList_KaschdeId",
                        column: x => x.KaschdeId,
                        principalTable: "KaschdeList",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FachData_ZeddelList_ZeddelId",
                        column: x => x.ZeddelId,
                        principalTable: "ZeddelList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Topic",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ZeddelId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topic", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Topic_ZeddelList_ZeddelId",
                        column: x => x.ZeddelId,
                        principalTable: "ZeddelList",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_FachData_KaschdeId",
                table: "FachData",
                column: "KaschdeId");

            migrationBuilder.CreateIndex(
                name: "IX_FachData_ZeddelId",
                table: "FachData",
                column: "ZeddelId");

            migrationBuilder.CreateIndex(
                name: "IX_Topic_ZeddelId",
                table: "Topic",
                column: "ZeddelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FachData");

            migrationBuilder.DropTable(
                name: "Topic");

            migrationBuilder.DropTable(
                name: "KaschdeList");

            migrationBuilder.DropTable(
                name: "ZeddelList");
        }
    }
}
