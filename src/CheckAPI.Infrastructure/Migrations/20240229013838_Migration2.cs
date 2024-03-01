using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CheckAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Migration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_relatorio_inspecao_inspecoes_id_inspecao",
                table: "relatorio_inspecao");

            migrationBuilder.DropPrimaryKey(
                name: "PK_relatorio_inspecao",
                table: "relatorio_inspecao");

            migrationBuilder.RenameTable(
                name: "relatorio_inspecao",
                newName: "relatorios_inspecao");

            migrationBuilder.RenameIndex(
                name: "IX_relatorio_inspecao_id_inspecao",
                table: "relatorios_inspecao",
                newName: "IX_relatorios_inspecao_id_inspecao");

            migrationBuilder.AddColumn<Guid>(
                name: "id_veiculo",
                table: "inspecoes",
                type: "UNIQUEIDENTIFIER",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "observacao",
                table: "relatorios_inspecao",
                type: "varchar(512)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "titulo",
                table: "relatorios_inspecao",
                type: "varchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "valor",
                table: "relatorios_inspecao",
                type: "varchar(512)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_relatorios_inspecao",
                table: "relatorios_inspecao",
                column: "id");

            migrationBuilder.CreateTable(
                name: "veiculo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    marca = table.Column<string>(type: "varchar(50)", nullable: false),
                    modelo = table.Column<string>(type: "varchar(100)", nullable: false),
                    ano = table.Column<short>(type: "smallint", nullable: false),
                    placa = table.Column<string>(type: "char(7)", nullable: false),
                    cor = table.Column<string>(type: "varchar(30)", nullable: false),
                    data_cadastro = table.Column<DateTime>(type: "datetime", nullable: false),
                    data_ultima_modificacao = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_veiculo", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_inspecoes_id_veiculo",
                table: "inspecoes",
                column: "id_veiculo");

            migrationBuilder.AddForeignKey(
                name: "FK_inspecoes_veiculo_id_veiculo",
                table: "inspecoes",
                column: "id_veiculo",
                principalTable: "veiculo",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_relatorios_inspecao_inspecoes_id_inspecao",
                table: "relatorios_inspecao",
                column: "id_inspecao",
                principalTable: "inspecoes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_inspecoes_veiculo_id_veiculo",
                table: "inspecoes");

            migrationBuilder.DropForeignKey(
                name: "FK_relatorios_inspecao_inspecoes_id_inspecao",
                table: "relatorios_inspecao");

            migrationBuilder.DropTable(
                name: "veiculo");

            migrationBuilder.DropIndex(
                name: "IX_inspecoes_id_veiculo",
                table: "inspecoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_relatorios_inspecao",
                table: "relatorios_inspecao");

            migrationBuilder.DropColumn(
                name: "id_veiculo",
                table: "inspecoes");

            migrationBuilder.DropColumn(
                name: "observacao",
                table: "relatorios_inspecao");

            migrationBuilder.DropColumn(
                name: "titulo",
                table: "relatorios_inspecao");

            migrationBuilder.DropColumn(
                name: "valor",
                table: "relatorios_inspecao");

            migrationBuilder.RenameTable(
                name: "relatorios_inspecao",
                newName: "relatorio_inspecao");

            migrationBuilder.RenameIndex(
                name: "IX_relatorios_inspecao_id_inspecao",
                table: "relatorio_inspecao",
                newName: "IX_relatorio_inspecao_id_inspecao");

            migrationBuilder.AddPrimaryKey(
                name: "PK_relatorio_inspecao",
                table: "relatorio_inspecao",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_relatorio_inspecao_inspecoes_id_inspecao",
                table: "relatorio_inspecao",
                column: "id_inspecao",
                principalTable: "inspecoes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
