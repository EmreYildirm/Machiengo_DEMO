using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Machinego_Demo.Migrations
{
    public partial class MachiengoDbMigrationv1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Attachment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MachineType = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attachment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MachineCategory = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Machine",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MachineCategory = table.Column<int>(type: "int", nullable: false),
                    MachineType = table.Column<int>(type: "int", nullable: false),
                    Brand = table.Column<int>(type: "int", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductionYear = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Machine", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MachineCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachineCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MachineType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MachineCategory = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachineType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MachineAttachments",
                columns: table => new
                {
                    MachineId = table.Column<int>(type: "int", nullable: false),
                    AttachmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachineAttachments", x => new { x.MachineId, x.AttachmentId });
                    table.ForeignKey(
                        name: "FK_MachineAttachments_Attachment_AttachmentId",
                        column: x => x.AttachmentId,
                        principalTable: "Attachment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MachineAttachments_Machine_MachineId",
                        column: x => x.MachineId,
                        principalTable: "Machine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Attachment",
                columns: new[] { "Id", "MachineType", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Grapple" },
                    { 2, 1, "Elek Ataşmanı" },
                    { 3, 3, "Diğer" },
                    { 4, 2, "Açılı Süpürge" },
                    { 5, 2, "Beton Kırıcı" }
                });

            migrationBuilder.InsertData(
                table: "Brand",
                columns: new[] { "Id", "MachineCategory", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Mercedes" },
                    { 2, 2, "CAT" },
                    { 3, 1, "BMW" },
                    { 4, 2, "Renault" }
                });

            migrationBuilder.InsertData(
                table: "MachineCategory",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Hafriyat Grubu   " },
                    { 2, "Asfalt ve Yol Makinalari" }
                });

            migrationBuilder.InsertData(
                table: "MachineType",
                columns: new[] { "Id", "MachineCategory", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Ekskavatörler" },
                    { 2, 1, "Bobcat " },
                    { 3, 2, "El Silindiri" },
                    { 4, 2, "Mobil Taş Kırma Makinası" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "Name", "Password" },
                values: new object[] { 1, "admin@mail.com", "Admin", "12345" });

            migrationBuilder.CreateIndex(
                name: "IX_MachineAttachments_AttachmentId",
                table: "MachineAttachments",
                column: "AttachmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Brand");

            migrationBuilder.DropTable(
                name: "MachineAttachments");

            migrationBuilder.DropTable(
                name: "MachineCategory");

            migrationBuilder.DropTable(
                name: "MachineType");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Attachment");

            migrationBuilder.DropTable(
                name: "Machine");
        }
    }
}
