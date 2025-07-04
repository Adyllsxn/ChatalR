using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Kairos.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CREATEMIGRATIONS : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tbl_Perfil",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Perfil", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_TipoEvento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_TipoEvento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    SobreNome = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: false),
                    FotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PerfilID = table.Column<int>(type: "int", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Telefone = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: false),
                    BI = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Usuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Perfil_Usuario",
                        column: x => x.PerfilID,
                        principalTable: "Tbl_Perfil",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Blog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioID = table.Column<int>(type: "int", nullable: false),
                    Titulo = table.Column<string>(type: "VARCHAR(150)", maxLength: 150, nullable: false),
                    Conteudo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagemCapaUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataPublicacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Blog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuario_Blog",
                        column: x => x.UsuarioID,
                        principalTable: "Tbl_Usuario",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Evento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataHoraInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataHoraFim = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Local = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: false),
                    TipoEventoID = table.Column<int>(type: "int", nullable: false),
                    UsuarioID = table.Column<int>(type: "int", nullable: false),
                    StatusAprovacao = table.Column<int>(type: "int", nullable: false),
                    ImagemUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Evento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TipoEvento_Eventos",
                        column: x => x.TipoEventoID,
                        principalTable: "Tbl_TipoEvento",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Usuario_Eventos",
                        column: x => x.UsuarioID,
                        principalTable: "Tbl_Usuario",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Presenca",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioID = table.Column<int>(type: "int", nullable: false),
                    EventoID = table.Column<int>(type: "int", nullable: false),
                    Confirmado = table.Column<bool>(type: "bit", nullable: false),
                    DataHoraCheckin = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Presenca", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Evento_Presenca",
                        column: x => x.EventoID,
                        principalTable: "Tbl_Evento",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Usuario_Presenca",
                        column: x => x.UsuarioID,
                        principalTable: "Tbl_Usuario",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Tbl_Perfil",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Administrador" },
                    { 2, "Organizador" },
                    { 3, "Membro" }
                });

            migrationBuilder.InsertData(
                table: "Tbl_TipoEvento",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Culto" },
                    { 2, "Vigília" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Blog_UsuarioID",
                table: "Tbl_Blog",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Evento_TipoEventoID",
                table: "Tbl_Evento",
                column: "TipoEventoID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Evento_UsuarioID",
                table: "Tbl_Evento",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Presenca_EventoID",
                table: "Tbl_Presenca",
                column: "EventoID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Presenca_UsuarioID",
                table: "Tbl_Presenca",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Usuario_BI",
                table: "Tbl_Usuario",
                column: "BI",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Usuario_Email",
                table: "Tbl_Usuario",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Usuario_PerfilID",
                table: "Tbl_Usuario",
                column: "PerfilID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Usuario_Telefone",
                table: "Tbl_Usuario",
                column: "Telefone",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_Blog");

            migrationBuilder.DropTable(
                name: "Tbl_Presenca");

            migrationBuilder.DropTable(
                name: "Tbl_Evento");

            migrationBuilder.DropTable(
                name: "Tbl_TipoEvento");

            migrationBuilder.DropTable(
                name: "Tbl_Usuario");

            migrationBuilder.DropTable(
                name: "Tbl_Perfil");
        }
    }
}
