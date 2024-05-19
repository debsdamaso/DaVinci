using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DaVinci.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_DV_CLIENTE",
                columns: table => new
                {
                    IdCliente = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Sexo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Cidade = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Cpf = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_DV_CLIENTE", x => x.IdCliente);
                });

            migrationBuilder.CreateTable(
                name: "TB_DV_PRODUTO",
                columns: table => new
                {
                    IdProduto = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Valor = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    Categoria = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Modelo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    IdCliente = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ClienteIdCliente = table.Column<int>(type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_DV_PRODUTO", x => x.IdProduto);
                    table.ForeignKey(
                        name: "FK_TB_DV_PRODUTO_TB_DV_CLIENTE_ClienteIdCliente",
                        column: x => x.ClienteIdCliente,
                        principalTable: "TB_DV_CLIENTE",
                        principalColumn: "IdCliente");
                });

            migrationBuilder.CreateTable(
                name: "TB_DV_FEEDBACK",
                columns: table => new
                {
                    IdFeedback = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Comentario = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DataFeedback = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Avaliacao = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    IdCliente = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ClienteIdCliente = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    IdProduto = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ProdutoIdProduto = table.Column<int>(type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_DV_FEEDBACK", x => x.IdFeedback);
                    table.ForeignKey(
                        name: "FK_TB_DV_FEEDBACK_TB_DV_CLIENTE_ClienteIdCliente",
                        column: x => x.ClienteIdCliente,
                        principalTable: "TB_DV_CLIENTE",
                        principalColumn: "IdCliente");
                    table.ForeignKey(
                        name: "FK_TB_DV_FEEDBACK_TB_DV_PRODUTO_ProdutoIdProduto",
                        column: x => x.ProdutoIdProduto,
                        principalTable: "TB_DV_PRODUTO",
                        principalColumn: "IdProduto");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_DV_FEEDBACK_ClienteIdCliente",
                table: "TB_DV_FEEDBACK",
                column: "ClienteIdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_TB_DV_FEEDBACK_ProdutoIdProduto",
                table: "TB_DV_FEEDBACK",
                column: "ProdutoIdProduto");

            migrationBuilder.CreateIndex(
                name: "IX_TB_DV_PRODUTO_ClienteIdCliente",
                table: "TB_DV_PRODUTO",
                column: "ClienteIdCliente");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_DV_FEEDBACK");

            migrationBuilder.DropTable(
                name: "TB_DV_PRODUTO");

            migrationBuilder.DropTable(
                name: "TB_DV_CLIENTE");
        }
    }
}
