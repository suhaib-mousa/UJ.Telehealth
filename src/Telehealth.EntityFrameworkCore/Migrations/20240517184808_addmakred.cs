using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Telehealth.Migrations
{
    /// <inheritdoc />
    public partial class addmakred : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CmsKitMarkedEntities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MarkedType = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CmsKitMarkedEntities", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CmsKitMarkedEntities_TenantId_CreatorId_MarkedType_EntityId",
                table: "CmsKitMarkedEntities",
                columns: new[] { "TenantId", "CreatorId", "MarkedType", "EntityId" });

            migrationBuilder.CreateIndex(
                name: "IX_CmsKitMarkedEntities_TenantId_MarkedType_EntityId",
                table: "CmsKitMarkedEntities",
                columns: new[] { "TenantId", "MarkedType", "EntityId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CmsKitMarkedEntities");
        }
    }
}
