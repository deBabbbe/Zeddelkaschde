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
                name: "ZeddelContents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Text = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZeddelContents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Attachments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Data = table.Column<byte[]>(type: "BLOB", nullable: false),
                    ContentType = table.Column<string>(type: "TEXT", nullable: false),
                    ZeddelContentId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attachments_ZeddelContents_ZeddelContentId",
                        column: x => x.ZeddelContentId,
                        principalTable: "ZeddelContents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ZeddelList",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    QuestionId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZeddelList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ZeddelList_ZeddelContents_Id",
                        column: x => x.Id,
                        principalTable: "ZeddelContents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ZeddelList_ZeddelContents_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "ZeddelContents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "Topics",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ZeddelId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Topics_ZeddelList_ZeddelId",
                        column: x => x.ZeddelId,
                        principalTable: "ZeddelList",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_ZeddelContentId",
                table: "Attachments",
                column: "ZeddelContentId");

            migrationBuilder.CreateIndex(
                name: "IX_FachData_KaschdeId",
                table: "FachData",
                column: "KaschdeId");

            migrationBuilder.CreateIndex(
                name: "IX_FachData_ZeddelId",
                table: "FachData",
                column: "ZeddelId");

            migrationBuilder.CreateIndex(
                name: "IX_Topics_ZeddelId",
                table: "Topics",
                column: "ZeddelId");

            migrationBuilder.CreateIndex(
                name: "IX_ZeddelList_QuestionId",
                table: "ZeddelList",
                column: "QuestionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attachments");

            migrationBuilder.DropTable(
                name: "FachData");

            migrationBuilder.DropTable(
                name: "Topics");

            migrationBuilder.DropTable(
                name: "KaschdeList");

            migrationBuilder.DropTable(
                name: "ZeddelList");

            migrationBuilder.DropTable(
                name: "ZeddelContents");
        }
    }
}
