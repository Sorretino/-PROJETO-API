using Microsoft.EntityFrameworkCore.Migrations;

namespace AlunosApi.Migrations
{
    public partial class PopulaTabela : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "Email", "Idade", "Imagem", "Nome" },
                values: new object[] { 1, "maria@gmail.com", 23, "https://dowhile.io/_next/image?url=%2Fimages%2Fbuild-the-future-hero.png&w=1920&q=100", "Maria da Penha" });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "Email", "Idade", "Imagem", "Nome" },
                values: new object[] { 2, "fernando@gmail.com", 39, "https://dowhile.io/_next/image?url=%2Fimages%2Fbuild-the-future-hero.png&w=1920&q=100", "Fernando Sorrentino" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Alunos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Alunos",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
