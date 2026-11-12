using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ElectroDoc.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddDocumentsAndReferenceTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "document_status",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_document_status", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "document_type",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_document_type", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "document",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    status_id = table.Column<int>(type: "integer", nullable: false),
                    author_membership_id = table.Column<Guid>(type: "uuid", nullable: false),
                    sender_membership_id = table.Column<Guid>(type: "uuid", nullable: true),
                    type_id = table.Column<int>(type: "integer", nullable: false),
                    recipient_company_id = table.Column<int>(type: "integer", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_document", x => x.id);
                    table.ForeignKey(
                        name: "fk_document_company_recipient_company_id",
                        column: x => x.recipient_company_id,
                        principalTable: "company",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_document_document_statuses_status_id",
                        column: x => x.status_id,
                        principalTable: "document_status",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_document_document_types_type_id",
                        column: x => x.type_id,
                        principalTable: "document_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_document_memberships_author_membership_id",
                        column: x => x.author_membership_id,
                        principalTable: "membership",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_document_memberships_sender_membership_id",
                        column: x => x.sender_membership_id,
                        principalTable: "membership",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "document_file",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    content_type = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    file_name = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    size = table.Column<long>(type: "bigint", nullable: false),
                    sha256 = table.Column<string>(type: "character(64)", fixedLength: true, maxLength: 64, nullable: false),
                    uploaded_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_document_file", x => x.id);
                    table.ForeignKey(
                        name: "fk_document_file_document_id",
                        column: x => x.id,
                        principalTable: "document",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "document_status",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "Draft" },
                    { 2, "Sent" },
                    { 3, "Signed" },
                    { 4, "Rejected" },
                    { 5, "Cancelled" }
                });

            migrationBuilder.InsertData(
                table: "document_type",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "Invoice" },
                    { 2, "Act" },
                    { 3, "Waybill" }
                });

            migrationBuilder.CreateIndex(
                name: "ix_document_author_membership_id",
                table: "document",
                column: "author_membership_id");

            migrationBuilder.CreateIndex(
                name: "ix_document_recipient_company_id_status_id",
                table: "document",
                columns: new[] { "recipient_company_id", "status_id" });

            migrationBuilder.CreateIndex(
                name: "ix_document_sender_membership_id",
                table: "document",
                column: "sender_membership_id");

            migrationBuilder.CreateIndex(
                name: "ix_document_status_id",
                table: "document",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "ix_document_type_id",
                table: "document",
                column: "type_id");

            migrationBuilder.CreateIndex(
                name: "ix_document_status_name",
                table: "document_status",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_document_type_name",
                table: "document_type",
                column: "name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "document_file");

            migrationBuilder.DropTable(
                name: "document");

            migrationBuilder.DropTable(
                name: "document_status");

            migrationBuilder.DropTable(
                name: "document_type");
        }
    }
}
