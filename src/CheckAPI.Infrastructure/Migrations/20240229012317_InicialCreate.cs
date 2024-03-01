using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CheckAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InicialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "funcionarios",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    data_cadastro = table.Column<DateTime>(type: "datetime", nullable: false),
                    data_ultima_modificacao = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_funcionarios", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "inspecoes",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    id_executor = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    conclusao = table.Column<byte>(type: "tinyint", nullable: true),
                    status = table.Column<byte>(type: "tinyint", nullable: false),
                    data_cadastro = table.Column<DateTime>(type: "datetime", nullable: false),
                    data_ultima_modificacao = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inspecoes", x => x.id);
                    table.ForeignKey(
                        name: "FK_inspecoes_funcionarios_id_executor",
                        column: x => x.id_executor,
                        principalTable: "funcionarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "relatorio_inspecao",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    id_inspecao = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    data_cadastro = table.Column<DateTime>(type: "datetime", nullable: false),
                    data_ultima_modificacao = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_relatorio_inspecao", x => x.id);
                    table.ForeignKey(
                        name: "FK_relatorio_inspecao_inspecoes_id_inspecao",
                        column: x => x.id_inspecao,
                        principalTable: "inspecoes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_inspecoes_id_executor",
                table: "inspecoes",
                column: "id_executor");

            migrationBuilder.CreateIndex(
                name: "IX_relatorio_inspecao_id_inspecao",
                table: "relatorio_inspecao",
                column: "id_inspecao");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "relatorio_inspecao");

            migrationBuilder.DropTable(
                name: "inspecoes");

            migrationBuilder.DropTable(
                name: "funcionarios");
        }
    }
}
