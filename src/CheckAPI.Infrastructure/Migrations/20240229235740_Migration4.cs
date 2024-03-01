using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CheckAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Migration4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "configuracoes_inspecao",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    nome = table.Column<string>(type: "varchar(50)", nullable: false),
                    data_cadastro = table.Column<DateTime>(type: "datetime", nullable: false),
                    data_ultima_modificacao = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_configuracoes_inspecao", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "inspecionaveis",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    id_configuracao_inspecao = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    titulo = table.Column<string>(type: "varchar(50)", nullable: false),
                    descricao = table.Column<string>(type: "varchar(256)", nullable: false),
                    tipo_preenchimento = table.Column<byte>(type: "tinyint", nullable: false),
                    data_cadastro = table.Column<DateTime>(type: "datetime", nullable: false),
                    data_ultima_modificacao = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inspecionaveis", x => x.id);
                    table.ForeignKey(
                        name: "FK_inspecionaveis_configuracoes_inspecao_id_configuracao_inspecao",
                        column: x => x.id_configuracao_inspecao,
                        principalTable: "configuracoes_inspecao",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_inspecionaveis_id_configuracao_inspecao",
                table: "inspecionaveis",
                column: "id_configuracao_inspecao");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "inspecionaveis");

            migrationBuilder.DropTable(
                name: "configuracoes_inspecao");
        }
    }
}
