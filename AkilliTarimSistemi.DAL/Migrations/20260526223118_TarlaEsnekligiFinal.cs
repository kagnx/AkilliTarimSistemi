using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AkilliTarimSistemi.DAL.Migrations
{
    /// <inheritdoc />
    public partial class TarlaEsnekligiFinal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SuAnalizleri_Tarlalar_TarlaId",
                table: "SuAnalizleri");

            migrationBuilder.DropForeignKey(
                name: "FK_ToprakAnalizleri_Tarlalar_TarlaId",
                table: "ToprakAnalizleri");

            migrationBuilder.DropForeignKey(
                name: "FK_YaprakAnalizleri_Tarlalar_TarlaId",
                table: "YaprakAnalizleri");

            migrationBuilder.AlterColumn<int>(
                name: "TarlaId",
                table: "YaprakAnalizleri",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "TarlaId1",
                table: "YaprakAnalizleri",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TarlaId1",
                table: "ToprakAnalizleri",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TarlaId",
                table: "SuAnalizleri",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "TarlaId1",
                table: "SuAnalizleri",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_YaprakAnalizleri_TarlaId1",
                table: "YaprakAnalizleri",
                column: "TarlaId1");

            migrationBuilder.CreateIndex(
                name: "IX_ToprakAnalizleri_TarlaId1",
                table: "ToprakAnalizleri",
                column: "TarlaId1");

            migrationBuilder.CreateIndex(
                name: "IX_SuAnalizleri_TarlaId1",
                table: "SuAnalizleri",
                column: "TarlaId1");

            migrationBuilder.AddForeignKey(
                name: "FK_SuAnalizleri_Tarlalar_TarlaId",
                table: "SuAnalizleri",
                column: "TarlaId",
                principalTable: "Tarlalar",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_SuAnalizleri_Tarlalar_TarlaId1",
                table: "SuAnalizleri",
                column: "TarlaId1",
                principalTable: "Tarlalar",
                principalColumn: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_YaprakAnalizleri_Tarlalar_TarlaId",
                table: "YaprakAnalizleri",
                column: "TarlaId",
                principalTable: "Tarlalar",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_YaprakAnalizleri_Tarlalar_TarlaId1",
                table: "YaprakAnalizleri",
                column: "TarlaId1",
                principalTable: "Tarlalar",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SuAnalizleri_Tarlalar_TarlaId",
                table: "SuAnalizleri");

            migrationBuilder.DropForeignKey(
                name: "FK_SuAnalizleri_Tarlalar_TarlaId1",
                table: "SuAnalizleri");

            migrationBuilder.DropForeignKey(
                name: "FK_ToprakAnalizleri_Tarlalar_TarlaId",
                table: "ToprakAnalizleri");

            migrationBuilder.DropForeignKey(
                name: "FK_ToprakAnalizleri_Tarlalar_TarlaId1",
                table: "ToprakAnalizleri");

            migrationBuilder.DropForeignKey(
                name: "FK_YaprakAnalizleri_Tarlalar_TarlaId",
                table: "YaprakAnalizleri");

            migrationBuilder.DropForeignKey(
                name: "FK_YaprakAnalizleri_Tarlalar_TarlaId1",
                table: "YaprakAnalizleri");

            migrationBuilder.DropIndex(
                name: "IX_YaprakAnalizleri_TarlaId1",
                table: "YaprakAnalizleri");

            migrationBuilder.DropIndex(
                name: "IX_ToprakAnalizleri_TarlaId1",
                table: "ToprakAnalizleri");

            migrationBuilder.DropIndex(
                name: "IX_SuAnalizleri_TarlaId1",
                table: "SuAnalizleri");

            migrationBuilder.DropColumn(
                name: "TarlaId1",
                table: "YaprakAnalizleri");

            migrationBuilder.DropColumn(
                name: "TarlaId1",
                table: "ToprakAnalizleri");

            migrationBuilder.DropColumn(
                name: "TarlaId1",
                table: "SuAnalizleri");

            migrationBuilder.AlterColumn<int>(
                name: "TarlaId",
                table: "YaprakAnalizleri",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TarlaId",
                table: "SuAnalizleri",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SuAnalizleri_Tarlalar_TarlaId",
                table: "SuAnalizleri",
                column: "TarlaId",
                principalTable: "Tarlalar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ToprakAnalizleri_Tarlalar_TarlaId",
                table: "ToprakAnalizleri",
                column: "TarlaId",
                principalTable: "Tarlalar",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_YaprakAnalizleri_Tarlalar_TarlaId",
                table: "YaprakAnalizleri",
                column: "TarlaId",
                principalTable: "Tarlalar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
