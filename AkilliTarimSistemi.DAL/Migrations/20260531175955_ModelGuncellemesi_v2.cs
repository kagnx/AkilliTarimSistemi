using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AkilliTarimSistemi.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ModelGuncellemesi_v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_ToprakAnalizleri_Tarlalar_TarlaId", table: "ToprakAnalizleri");
            migrationBuilder.DropForeignKey(name: "FK_ToprakAnalizleri_Tarlalar_TarlaId1", table: "ToprakAnalizleri");
            migrationBuilder.DropIndex(name: "IX_ToprakAnalizleri_TarlaId1", table: "ToprakAnalizleri");
            migrationBuilder.DropColumn(name: "TarlaId1", table: "ToprakAnalizleri");

            // --- EKLEME: Eğer NULL değer varsa, önce bunları geçerli bir Tarla ID'sine (Örn: 1) çekiyoruz ---
            migrationBuilder.Sql("UPDATE ToprakAnalizleri SET TarlaId = 1 WHERE TarlaId IS NULL;");
            // -----------------------------------------------------------------------------------------

            migrationBuilder.AlterColumn<int>(
                name: "TarlaId",
                table: "ToprakAnalizleri",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ToprakAnalizleri_Tarlalar_TarlaId",
                table: "ToprakAnalizleri",
                column: "TarlaId",
                principalTable: "Tarlalar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade); // Tarla silinirse analizi de silinecek
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToprakAnalizleri_Tarlalar_TarlaId",
                table: "ToprakAnalizleri");

            migrationBuilder.AlterColumn<int>(
                name: "TarlaId",
                table: "ToprakAnalizleri",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "TarlaId1",
                table: "ToprakAnalizleri",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ToprakAnalizleri_TarlaId1",
                table: "ToprakAnalizleri",
                column: "TarlaId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ToprakAnalizleri_Tarlalar_TarlaId",
                table: "ToprakAnalizleri",
                column: "TarlaId",
                principalTable: "Tarlalar",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_ToprakAnalizleri_Tarlalar_TarlaId1",
                table: "ToprakAnalizleri",
                column: "TarlaId1",
                principalTable: "Tarlalar",
                principalColumn: "Id");
        }
    }
}
