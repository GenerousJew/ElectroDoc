using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElectroDoc.Data.Migrations
{
    /// <inheritdoc />
    public partial class ReplaceStatusesWithDatesAddPermissions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_company_company_statuses_status_id",
                table: "company");

            migrationBuilder.DropForeignKey(
                name: "fk_membership_membership_roles_role_id",
                table: "membership");

            migrationBuilder.DropForeignKey(
                name: "fk_membership_membership_statuses_status_id",
                table: "membership");

            migrationBuilder.DropTable(
                name: "company_status");

            migrationBuilder.DropTable(
                name: "membership_role");

            migrationBuilder.DropTable(
                name: "membership_status");

            migrationBuilder.DropIndex(
                name: "ix_membership_role_id",
                table: "membership");

            migrationBuilder.DropIndex(
                name: "ix_membership_status_id",
                table: "membership");

            migrationBuilder.DropIndex(
                name: "ix_company_status_id",
                table: "company");

            migrationBuilder.DropColumn(
                name: "role_id",
                table: "membership");

            migrationBuilder.DropColumn(
                name: "status_id",
                table: "membership");

            migrationBuilder.DropColumn(
                name: "status_id",
                table: "company");

            migrationBuilder.AddColumn<DateTime>(
                name: "left_at",
                table: "membership",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "closed_at",
                table: "company",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "permission",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_permission", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "membership_permission",
                columns: table => new
                {
                    membership_id = table.Column<Guid>(type: "uuid", nullable: false),
                    permission_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_membership_permission", x => new { x.membership_id, x.permission_id });
                    table.ForeignKey(
                        name: "fk_membership_permission_membership_membership_id",
                        column: x => x.membership_id,
                        principalTable: "membership",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_membership_permission_permissions_permission_id",
                        column: x => x.permission_id,
                        principalTable: "permission",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "ix_membership_permission_permission_id",
                table: "membership_permission",
                column: "permission_id");

            migrationBuilder.CreateIndex(
                name: "ix_permission_name",
                table: "permission",
                column: "name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "membership_permission");

            migrationBuilder.DropTable(
                name: "permission");

            migrationBuilder.DropColumn(
                name: "left_at",
                table: "membership");

            migrationBuilder.DropColumn(
                name: "closed_at",
                table: "company");

            migrationBuilder.AddColumn<int>(
                name: "role_id",
                table: "membership",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "status_id",
                table: "membership",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "status_id",
                table: "company",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "company_status",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_company_status", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "membership_role",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_membership_role", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "membership_status",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_membership_status", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "ix_membership_role_id",
                table: "membership",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "ix_membership_status_id",
                table: "membership",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "ix_company_status_id",
                table: "company",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "ix_company_status_name",
                table: "company_status",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_membership_role_name",
                table: "membership_role",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_membership_status_name",
                table: "membership_status",
                column: "name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "fk_company_company_statuses_status_id",
                table: "company",
                column: "status_id",
                principalTable: "company_status",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_membership_membership_roles_role_id",
                table: "membership",
                column: "role_id",
                principalTable: "membership_role",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_membership_membership_statuses_status_id",
                table: "membership",
                column: "status_id",
                principalTable: "membership_status",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
