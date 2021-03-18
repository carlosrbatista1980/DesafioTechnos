using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFrameworkCore.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produto_Preco_PrecoId",
                table: "Produto");

            migrationBuilder.DropTable(
                name: "Preco");

            migrationBuilder.DropIndex(
                name: "IX_Produto_PrecoId",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "PrecoId",
                table: "Produto");

            migrationBuilder.AddColumn<decimal>(
                name: "Preco",
                table: "Produto",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Preco",
                table: "Produto");

            migrationBuilder.AddColumn<int>(
                name: "PrecoId",
                table: "Produto",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Preco",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Desconto = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Imposto = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Nome = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    PrecoPadrao = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Preco", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produto_PrecoId",
                table: "Produto",
                column: "PrecoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produto_Preco_PrecoId",
                table: "Produto",
                column: "PrecoId",
                principalTable: "Preco",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
