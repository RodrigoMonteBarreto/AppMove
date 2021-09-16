using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AppMove.Persistence.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cartao",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Titular = table.Column<string>(type: "TEXT", nullable: true),
                    Numero = table.Column<int>(type: "INTEGER", nullable: false),
                    DataExpiracao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Bandeira = table.Column<string>(type: "TEXT", nullable: true),
                    CCV = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cartao", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tb_Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    Valor = table.Column<decimal>(type: "TEXT", nullable: false),
                    Estoque = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_Compras",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    produtoId = table.Column<int>(type: "INTEGER", nullable: true),
                    DataCompra = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Quantidade = table.Column<int>(type: "INTEGER", nullable: false),
                    CartaoID = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Compras", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tb_Compras_Cartao_CartaoID",
                        column: x => x.CartaoID,
                        principalTable: "Cartao",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tb_Compras_tb_Product_produtoId",
                        column: x => x.produtoId,
                        principalTable: "tb_Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_Compras_CartaoID",
                table: "tb_Compras",
                column: "CartaoID");

            migrationBuilder.CreateIndex(
                name: "IX_tb_Compras_produtoId",
                table: "tb_Compras",
                column: "produtoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_Compras");

            migrationBuilder.DropTable(
                name: "Cartao");

            migrationBuilder.DropTable(
                name: "tb_Product");
        }
    }
}
