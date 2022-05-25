using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorAppQLDT.Server.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SinhvienCD18",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tinh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hoten = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ngaysinh = table.Column<int>(type: "int", nullable: false),
                    Thangsinh = table.Column<int>(type: "int", nullable: false),
                    Namsinh = table.Column<int>(type: "int", nullable: false),
                    IdNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Truong = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lop = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sodienthoai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SinhvienCD18", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SinhvienCD18");

           
        }
    }
}
