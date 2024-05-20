using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Telehealth.Migrations
{
    /// <inheritdoc />
    public partial class addlivecocahingchanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LiveCoachingCheckoutRequests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CheckoutId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CoachId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SkillId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MemberId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<float>(type: "real", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LiveCoachingCheckoutRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LiveCoachingCheckoutRequests_LiveCoachingCoaches_CoachId",
                        column: x => x.CoachId,
                        principalTable: "LiveCoachingCoaches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LiveCoachingCheckoutRequests_LiveCoachingSkills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "LiveCoachingSkills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReservationManagementResources",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationManagementResources", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReservationManagementReservations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResourceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Access = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MembersLimit = table.Column<int>(type: "int", nullable: false),
                    ServiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationManagementReservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReservationManagementReservations_ReservationManagementResources_ResourceId",
                        column: x => x.ResourceId,
                        principalTable: "ReservationManagementResources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReservationManagementResourceSchedules",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResourceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ResourceScheduleSettingsPeriodsInJson = table.Column<string>(name: "ResourceScheduleSettings_PeriodsInJson", type: "nvarchar(max)", nullable: true),
                    ResourceScheduleSettingsExceptionDaysInJson = table.Column<string>(name: "ResourceScheduleSettings_ExceptionDaysInJson", type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationManagementResourceSchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReservationManagementResourceSchedules_ReservationManagementResources_ResourceId",
                        column: x => x.ResourceId,
                        principalTable: "ReservationManagementResources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReservationManagementReservationMembers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReservationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EntityName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationManagementReservationMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReservationManagementReservationMembers_ReservationManagementReservations_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "ReservationManagementReservations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LiveCoachingCheckoutRequests_CoachId",
                table: "LiveCoachingCheckoutRequests",
                column: "CoachId");

            migrationBuilder.CreateIndex(
                name: "IX_LiveCoachingCheckoutRequests_SkillId",
                table: "LiveCoachingCheckoutRequests",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationManagementReservationMembers_ReservationId",
                table: "ReservationManagementReservationMembers",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationManagementReservations_ResourceId",
                table: "ReservationManagementReservations",
                column: "ResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationManagementResourceSchedules_ResourceId",
                table: "ReservationManagementResourceSchedules",
                column: "ResourceId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LiveCoachingCheckoutRequests");

            migrationBuilder.DropTable(
                name: "ReservationManagementReservationMembers");

            migrationBuilder.DropTable(
                name: "ReservationManagementResourceSchedules");

            migrationBuilder.DropTable(
                name: "ReservationManagementReservations");

            migrationBuilder.DropTable(
                name: "ReservationManagementResources");
        }
    }
}
