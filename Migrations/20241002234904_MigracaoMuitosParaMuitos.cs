using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RpgApi.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoMuitosParaMuitos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_HABILIDADES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "VarChar(200)", maxLength: 200, nullable: false),
                    Dano = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_HABILIDADES", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_PERSONAGENS_HABILIDADES",
                columns: table => new
                {
                    PersonagemId = table.Column<int>(type: "int", nullable: false),
                    HabilidadeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PERSONAGENS_HABILIDADES", x => new { x.PersonagemId, x.HabilidadeId });
                    table.ForeignKey(
                        name: "FK_TB_PERSONAGENS_HABILIDADES_TB_HABILIDADES_HabilidadeId",
                        column: x => x.HabilidadeId,
                        principalTable: "TB_HABILIDADES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_PERSONAGENS_HABILIDADES_TB_PERSONAGENS_PersonagemId",
                        column: x => x.PersonagemId,
                        principalTable: "TB_PERSONAGENS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TB_HABILIDADES",
                columns: new[] { "Id", "Dano", "Nome" },
                values: new object[,]
                {
                    { 1, 39, "Adormecer" },
                    { 2, 41, "Congelar" },
                    { 3, 37, "Hipnotizar" }
                });

            migrationBuilder.UpdateData(
                table: "TB_USUARIOS",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 215, 164, 67, 183, 149, 0, 69, 237, 188, 227, 93, 114, 231, 73, 150, 113, 229, 124, 91, 101, 67, 188, 225, 140, 223, 42, 186, 17, 37, 213, 228, 130, 33, 10, 220, 60, 69, 116, 117, 194, 178, 61, 122, 99, 33, 191, 112, 152, 158, 201, 165, 147, 182, 170, 218, 53, 203, 25, 9, 197, 160, 37, 220, 60 }, new byte[] { 72, 55, 68, 88, 196, 4, 152, 236, 87, 211, 186, 128, 122, 92, 212, 48, 135, 28, 84, 155, 12, 157, 75, 131, 253, 18, 214, 45, 96, 221, 117, 253, 250, 252, 110, 162, 215, 74, 46, 154, 130, 20, 107, 239, 32, 16, 135, 193, 53, 33, 49, 62, 38, 106, 26, 173, 167, 145, 120, 202, 231, 217, 191, 37, 248, 239, 25, 183, 182, 214, 244, 104, 166, 209, 204, 123, 243, 4, 209, 215, 172, 13, 201, 24, 185, 119, 99, 154, 18, 178, 43, 172, 241, 52, 230, 2, 126, 172, 13, 94, 163, 61, 86, 12, 15, 63, 201, 165, 213, 138, 189, 64, 16, 19, 73, 62, 237, 208, 228, 179, 16, 86, 205, 34, 32, 15, 23, 95 } });

            migrationBuilder.InsertData(
                table: "TB_PERSONAGENS_HABILIDADES",
                columns: new[] { "HabilidadeId", "PersonagemId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 2, 2 },
                    { 2, 3 },
                    { 3, 3 },
                    { 3, 4 },
                    { 1, 5 },
                    { 2, 6 },
                    { 3, 7 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_PERSONAGENS_HABILIDADES_HabilidadeId",
                table: "TB_PERSONAGENS_HABILIDADES",
                column: "HabilidadeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_PERSONAGENS_HABILIDADES");

            migrationBuilder.DropTable(
                name: "TB_HABILIDADES");

            migrationBuilder.UpdateData(
                table: "TB_USUARIOS",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 22, 221, 84, 94, 95, 54, 83, 53, 51, 50, 62, 58, 236, 206, 9, 59, 46, 43, 27, 253, 212, 152, 52, 31, 73, 223, 178, 224, 78, 122, 5, 2, 84, 16, 208, 154, 237, 246, 134, 133, 81, 64, 105, 135, 231, 128, 190, 81, 72, 138, 21, 133, 101, 179, 220, 245, 39, 172, 8, 190, 214, 39, 147, 23 }, new byte[] { 177, 80, 246, 231, 141, 204, 201, 131, 198, 159, 237, 62, 59, 109, 24, 232, 165, 135, 170, 27, 138, 42, 203, 146, 142, 141, 89, 182, 200, 78, 25, 232, 64, 227, 206, 245, 123, 11, 196, 186, 7, 215, 185, 186, 93, 196, 224, 93, 200, 61, 158, 78, 142, 197, 49, 222, 38, 32, 2, 242, 185, 241, 12, 191, 54, 225, 171, 138, 147, 173, 135, 219, 2, 232, 24, 16, 91, 117, 169, 11, 121, 120, 84, 199, 57, 33, 124, 142, 78, 157, 66, 26, 202, 106, 8, 183, 32, 47, 68, 41, 44, 0, 186, 117, 92, 61, 29, 32, 23, 171, 224, 104, 242, 202, 168, 3, 250, 190, 204, 80, 13, 26, 198, 204, 27, 210, 182, 22 } });
        }
    }
}
