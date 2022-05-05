using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CurrencyConverter.DAL.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TransactionDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CretationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CurrencyName = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    CurrnecyCode = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    CurrentExchangeRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GivenAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ReceivedAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionDetails", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TransactionDetails");
        }
    }
}
