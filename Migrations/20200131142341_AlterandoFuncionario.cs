﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace efcurso.Migrations
{
    public partial class AlterandoFuncionario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cpf",
                table: "Funcionarios",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cpf",
                table: "Funcionarios");
        }
    }
}
