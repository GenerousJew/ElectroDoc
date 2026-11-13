using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ElectroDoc.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddHistoriesAndRefreshToken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "document_history_action",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_document_history_action", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "permission_history",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    actor_membership_id = table.Column<Guid>(type: "uuid", nullable: false),
                    target_membership_id = table.Column<Guid>(type: "uuid", nullable: false),
                    permission_id = table.Column<int>(type: "integer", nullable: false),
                    is_granted = table.Column<bool>(type: "boolean", nullable: false),
                    happened_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_permission_history", x => x.id);
                    table.ForeignKey(
                        name: "fk_permission_history_membership_actor_membership_id",
                        column: x => x.actor_membership_id,
                        principalTable: "membership",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_permission_history_membership_target_membership_id",
                        column: x => x.target_membership_id,
                        principalTable: "membership",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_permission_history_permission_permission_id",
                        column: x => x.permission_id,
                        principalTable: "permission",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "refresh_token",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    employee_id = table.Column<Guid>(type: "uuid", nullable: false),
                    session_id = table.Column<Guid>(type: "uuid", nullable: false),
                    hash = table.Column<string>(type: "character(64)", fixedLength: true, maxLength: 64, nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    expires_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    revoked_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_refresh_token", x => x.id);
                    table.ForeignKey(
                        name: "fk_refresh_token_employee_employee_id",
                        column: x => x.employee_id,
                        principalTable: "employee",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "document_history",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    actor_membership_id = table.Column<Guid>(type: "uuid", nullable: false),
                    document_id = table.Column<Guid>(type: "uuid", nullable: false),
                    action_id = table.Column<int>(type: "integer", nullable: false),
                    happened_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_document_history", x => x.id);
                    table.ForeignKey(
                        name: "fk_document_history_document_document_id",
                        column: x => x.document_id,
                        principalTable: "document",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_document_history_document_history_action_action_id",
                        column: x => x.action_id,
                        principalTable: "document_history_action",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_document_history_memberships_actor_membership_id",
                        column: x => x.actor_membership_id,
                        principalTable: "membership",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "document_history_action",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "Created" },
                    { 2, "Edited" },
                    { 3, "Sent" },
                    { 4, "Signed" },
                    { 5, "Rejected" },
                    { 6, "Cancelled" }
                });

            migrationBuilder.CreateIndex(
                name: "ix_document_history_action_id",
                table: "document_history",
                column: "action_id");

            migrationBuilder.CreateIndex(
                name: "ix_document_history_actor_membership_id",
                table: "document_history",
                column: "actor_membership_id");

            migrationBuilder.CreateIndex(
                name: "ix_document_history_document_id_happened_at",
                table: "document_history",
                columns: new[] { "document_id", "happened_at" });

            migrationBuilder.CreateIndex(
                name: "ix_document_history_action_name",
                table: "document_history_action",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_permission_history_actor_membership_id",
                table: "permission_history",
                column: "actor_membership_id");

            migrationBuilder.CreateIndex(
                name: "ix_permission_history_permission_id",
                table: "permission_history",
                column: "permission_id");

            migrationBuilder.CreateIndex(
                name: "ix_permission_history_target_membership_id_happened_at",
                table: "permission_history",
                columns: new[] { "target_membership_id", "happened_at" });

            migrationBuilder.CreateIndex(
                name: "ix_refresh_token_employee_id",
                table: "refresh_token",
                column: "employee_id");

            migrationBuilder.CreateIndex(
                name: "ix_refresh_token_hash",
                table: "refresh_token",
                column: "hash",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_refresh_token_session_id",
                table: "refresh_token",
                column: "session_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "document_history");

            migrationBuilder.DropTable(
                name: "permission_history");

            migrationBuilder.DropTable(
                name: "refresh_token");

            migrationBuilder.DropTable(
                name: "document_history_action");
        }
    }
}
