using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RpgApi.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoUmParaUm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Derrotas",
                table: "TB_PERSONAGENS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Disputas",
                table: "TB_PERSONAGENS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Vitorias",
                table: "TB_PERSONAGENS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PersonagemId",
                table: "TB_ARMAS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 1,
                column: "PersonagemId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 2,
                column: "PersonagemId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 3,
                column: "PersonagemId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 4,
                column: "PersonagemId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 5,
                column: "PersonagemId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 6,
                column: "PersonagemId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 7,
                column: "PersonagemId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_USUARIOS",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 22, 221, 84, 94, 95, 54, 83, 53, 51, 50, 62, 58, 236, 206, 9, 59, 46, 43, 27, 253, 212, 152, 52, 31, 73, 223, 178, 224, 78, 122, 5, 2, 84, 16, 208, 154, 237, 246, 134, 133, 81, 64, 105, 135, 231, 128, 190, 81, 72, 138, 21, 133, 101, 179, 220, 245, 39, 172, 8, 190, 214, 39, 147, 23 }, new byte[] { 177, 80, 246, 231, 141, 204, 201, 131, 198, 159, 237, 62, 59, 109, 24, 232, 165, 135, 170, 27, 138, 42, 203, 146, 142, 141, 89, 182, 200, 78, 25, 232, 64, 227, 206, 245, 123, 11, 196, 186, 7, 215, 185, 186, 93, 196, 224, 93, 200, 61, 158, 78, 142, 197, 49, 222, 38, 32, 2, 242, 185, 241, 12, 191, 54, 225, 171, 138, 147, 173, 135, 219, 2, 232, 24, 16, 91, 117, 169, 11, 121, 120, 84, 199, 57, 33, 124, 142, 78, 157, 66, 26, 202, 106, 8, 183, 32, 47, 68, 41, 44, 0, 186, 117, 92, 61, 29, 32, 23, 171, 224, 104, 242, 202, 168, 3, 250, 190, 204, 80, 13, 26, 198, 204, 27, 210, 182, 22 } });

            migrationBuilder.CreateIndex(
                name: "IX_TB_ARMAS_PersonagemId",
                table: "TB_ARMAS",
                column: "PersonagemId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_ARMAS_TB_PERSONAGENS_PersonagemId",
                table: "TB_ARMAS",
                column: "PersonagemId",
                principalTable: "TB_PERSONAGENS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_ARMAS_TB_PERSONAGENS_PersonagemId",
                table: "TB_ARMAS");

            migrationBuilder.DropIndex(
                name: "IX_TB_ARMAS_PersonagemId",
                table: "TB_ARMAS");

            migrationBuilder.DropColumn(
                name: "Derrotas",
                table: "TB_PERSONAGENS");

            migrationBuilder.DropColumn(
                name: "Disputas",
                table: "TB_PERSONAGENS");

            migrationBuilder.DropColumn(
                name: "Vitorias",
                table: "TB_PERSONAGENS");

            migrationBuilder.DropColumn(
                name: "PersonagemId",
                table: "TB_ARMAS");

            migrationBuilder.UpdateData(
                table: "TB_USUARIOS",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 29, 176, 165, 111, 153, 221, 222, 12, 132, 24, 127, 115, 63, 102, 127, 173, 106, 230, 12, 107, 29, 253, 195, 160, 101, 245, 251, 126, 95, 240, 168, 152, 226, 247, 135, 204, 185, 72, 183, 59, 153, 196, 42, 225, 4, 41, 163, 33, 56, 63, 220, 176, 240, 253, 159, 49, 139, 84, 186, 14, 120, 219, 59, 39 }, new byte[] { 180, 106, 23, 30, 208, 244, 245, 61, 92, 29, 132, 34, 253, 100, 242, 190, 31, 40, 155, 1, 249, 103, 84, 26, 216, 118, 164, 62, 104, 4, 41, 94, 227, 241, 118, 219, 152, 200, 252, 205, 58, 135, 36, 236, 213, 231, 226, 231, 254, 45, 31, 110, 201, 143, 221, 23, 135, 162, 18, 61, 168, 18, 252, 21, 91, 245, 57, 24, 142, 18, 148, 46, 83, 58, 110, 98, 252, 180, 226, 255, 181, 21, 142, 156, 92, 110, 174, 17, 82, 160, 11, 240, 225, 250, 37, 99, 10, 38, 80, 218, 11, 5, 227, 93, 162, 82, 143, 117, 181, 27, 66, 253, 13, 106, 181, 155, 52, 253, 96, 50, 246, 3, 75, 57, 135, 26, 101, 127 } });
        }
    }
}
