using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CheckAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Migration3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "id_supervisor",
                table: "inspecoes",
                type: "UNIQUEIDENTIFIER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_inspecoes_id_supervisor",
                table: "inspecoes",
                column: "id_supervisor");

            migrationBuilder.AddForeignKey(
                name: "FK_inspecoes_funcionarios_id_supervisor",
                table: "inspecoes",
                column: "id_supervisor",
                principalTable: "funcionarios",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_inspecoes_funcionarios_id_supervisor",
                table: "inspecoes");

            migrationBuilder.DropIndex(
                name: "IX_inspecoes_id_supervisor",
                table: "inspecoes");

            migrationBuilder.DropColumn(
                name: "id_supervisor",
                table: "inspecoes");
        }
    }
}
