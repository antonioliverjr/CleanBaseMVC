using Microsoft.EntityFrameworkCore.Migrations;

namespace CleanBase.Infra.Data.Migrations
{
    public partial class SeedProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("insert into Products(Name, Description, Price, Stock, Image, CategoryId) "+
                "values('Caderno Espiral', 'Caderno Espiral 80 Folhas', 5.99, 50, 'caderno1.jpg', 1)");
            migrationBuilder.Sql("insert into Products(Name, Description, Price, Stock, Image, CategoryId) " +
                "values('Calculadora escolar', 'Calculadora Simples', 15.99, 20, 'calculadora1.jpg', 2)");
            migrationBuilder.Sql("insert into Products(Name, Description, Price, Stock, Image, CategoryId) " +
                "values('Pendrive 16GB', 'Pendrive de 16GB da Multilaser', 24.99, 100, 'pendrive1.jpg', 3)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("delete from Products");
        }
    }
}
