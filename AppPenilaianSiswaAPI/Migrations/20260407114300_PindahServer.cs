using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppPenilaianSiswaAPI.Migrations
{
    /// <inheritdoc />
    public partial class PindahServer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gurus",
                columns: table => new
                {
                    GuruId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GuruName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gurus", x => x.GuruId);
                });

            migrationBuilder.CreateTable(
                name: "Jurusans",
                columns: table => new
                {
                    JurusanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NamaJurusan = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jurusans", x => x.JurusanId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Mapels",
                columns: table => new
                {
                    MapelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NamaMapel = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    GuruId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mapels", x => x.MapelId);
                    table.ForeignKey(
                        name: "FK_Mapels_Gurus_GuruId",
                        column: x => x.GuruId,
                        principalTable: "Gurus",
                        principalColumn: "GuruId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Kelas",
                columns: table => new
                {
                    KelasId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JurusanId = table.Column<int>(type: "int", nullable: false),
                    NamaKelas = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kelas", x => x.KelasId);
                    table.ForeignKey(
                        name: "FK_Kelas_Jurusans_JurusanId",
                        column: x => x.JurusanId,
                        principalTable: "Jurusans",
                        principalColumn: "JurusanId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    OperatorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Nama = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.OperatorId);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Siswas",
                columns: table => new
                {
                    SiswaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nisn = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    NamaSiswa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    KelasId = table.Column<int>(type: "int", nullable: false),
                    SiswaPicture = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Siswas", x => x.SiswaId);
                    table.ForeignKey(
                        name: "FK_Siswas_Kelas_KelasId",
                        column: x => x.KelasId,
                        principalTable: "Kelas",
                        principalColumn: "KelasId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Nilais",
                columns: table => new
                {
                    NilaiId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SiswaId = table.Column<int>(type: "int", nullable: false),
                    MapelId = table.Column<int>(type: "int", nullable: false),
                    OperatorId = table.Column<int>(type: "int", nullable: false),
                    NilaiSiswa = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nilais", x => x.NilaiId);
                    table.ForeignKey(
                        name: "FK_Nilais_Mapels_MapelId",
                        column: x => x.MapelId,
                        principalTable: "Mapels",
                        principalColumn: "MapelId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Nilais_Siswas_SiswaId",
                        column: x => x.SiswaId,
                        principalTable: "Siswas",
                        principalColumn: "SiswaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Nilais_Users_OperatorId",
                        column: x => x.OperatorId,
                        principalTable: "Users",
                        principalColumn: "OperatorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Kelas_JurusanId",
                table: "Kelas",
                column: "JurusanId");

            migrationBuilder.CreateIndex(
                name: "IX_Mapels_GuruId",
                table: "Mapels",
                column: "GuruId");

            migrationBuilder.CreateIndex(
                name: "IX_Nilais_MapelId",
                table: "Nilais",
                column: "MapelId");

            migrationBuilder.CreateIndex(
                name: "IX_Nilais_OperatorId",
                table: "Nilais",
                column: "OperatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Nilais_SiswaId",
                table: "Nilais",
                column: "SiswaId");

            migrationBuilder.CreateIndex(
                name: "IX_Siswas_KelasId",
                table: "Siswas",
                column: "KelasId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Nilais");

            migrationBuilder.DropTable(
                name: "Mapels");

            migrationBuilder.DropTable(
                name: "Siswas");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Gurus");

            migrationBuilder.DropTable(
                name: "Kelas");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Jurusans");
        }
    }
}
