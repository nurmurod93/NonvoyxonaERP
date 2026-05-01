using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NonvoyxonaERP.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kassalar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nomi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Turi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Qoldiq = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Aktiv = table.Column<bool>(type: "bit", nullable: false),
                    Yaratilganvaqt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kassalar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Maxsulotlar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nomi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kategoryasi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Narxi = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    OlchovBirligi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aktiv = table.Column<bool>(type: "bit", nullable: false),
                    Yaratilganvaqt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maxsulotlar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Taminotchilar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nomi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Manzil = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Qarz = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Aktiv = table.Column<bool>(type: "bit", nullable: false),
                    Yaratilganvaqt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taminotchilar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Xodimlar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FIO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lavozimi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaoshiTuri = table.Column<int>(type: "int", nullable: false),
                    AsosiyMaoshi = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    IshbayNarxi = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    IshgaKirgan = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Aktive = table.Column<bool>(type: "bit", nullable: false),
                    Yaratilganvaqt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Xodimlar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Xomashyolar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nomi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Miqdori = table.Column<decimal>(type: "decimal(18,3)", precision: 18, scale: 3, nullable: false),
                    OlchovBirligi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MinDaraja = table.Column<decimal>(type: "decimal(18,3)", precision: 18, scale: 3, nullable: false),
                    Narxi = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Yaratilganvaqt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Xomashyolar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Davomatlar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    XodimId = table.Column<int>(type: "int", nullable: false),
                    Sana = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KeldiVaqt = table.Column<TimeSpan>(type: "time", nullable: true),
                    KetdiVaqt = table.Column<TimeSpan>(type: "time", nullable: true),
                    Smena = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Izoh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Yaratilganvaqt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Davomatlar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Davomatlar_Xodimlar_XodimId",
                        column: x => x.XodimId,
                        principalTable: "Xodimlar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IshAktlar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    XodimId = table.Column<int>(type: "int", nullable: false),
                    Sana = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Smena = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Holat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Yaratilganvaqt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IshAktlar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IshAktlar_Xodimlar_XodimId",
                        column: x => x.XodimId,
                        principalTable: "Xodimlar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Maoshlar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    XodimId = table.Column<int>(type: "int", nullable: false),
                    Yil = table.Column<int>(type: "int", nullable: false),
                    Oy = table.Column<int>(type: "int", nullable: false),
                    HisoblanganMaosh = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Avans = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Shtraf = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Mukofot = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Tolangan = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    TolashSana = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Yaratilganvaqt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maoshlar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Maoshlar_Xodimlar_XodimId",
                        column: x => x.XodimId,
                        principalTable: "Xodimlar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tochkalar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nomi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Manzil = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MasulId = table.Column<int>(type: "int", nullable: true),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aktiv = table.Column<bool>(type: "bit", nullable: false),
                    Yaratilganvaqt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tochkalar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tochkalar_Xodimlar_MasulId",
                        column: x => x.MasulId,
                        principalTable: "Xodimlar",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Xarajatlar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KassaId = table.Column<int>(type: "int", nullable: false),
                    XodimId = table.Column<int>(type: "int", nullable: true),
                    Kategorya = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Summa = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Izoh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Yaratilganvaqt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Xarajatlar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Xarajatlar_Kassalar_KassaId",
                        column: x => x.KassaId,
                        principalTable: "Kassalar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Xarajatlar_Xodimlar_XodimId",
                        column: x => x.XodimId,
                        principalTable: "Xodimlar",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Retseptlar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaxsulotId = table.Column<int>(type: "int", nullable: false),
                    XomashyoId = table.Column<int>(type: "int", nullable: false),
                    Miqdori = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    OlchovBirligi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Yaratilganvaqt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Retseptlar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Retseptlar_Maxsulotlar_MaxsulotId",
                        column: x => x.MaxsulotId,
                        principalTable: "Maxsulotlar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Retseptlar_Xomashyolar_XomashyoId",
                        column: x => x.XomashyoId,
                        principalTable: "Xomashyolar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IshAktQatorlar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IshAktId = table.Column<int>(type: "int", nullable: false),
                    MaxsulotId = table.Column<int>(type: "int", nullable: false),
                    RejalashMiqdor = table.Column<int>(type: "int", nullable: false),
                    HaqiqiyMiqdor = table.Column<int>(type: "int", nullable: false),
                    BrakMiqdor = table.Column<int>(type: "int", nullable: false),
                    Yaratilganvaqt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IshAktQatorlar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IshAktQatorlar_IshAktlar_IshAktId",
                        column: x => x.IshAktId,
                        principalTable: "IshAktlar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IshAktQatorlar_Maxsulotlar_MaxsulotId",
                        column: x => x.MaxsulotId,
                        principalTable: "Maxsulotlar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Savdolar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TochkaId = table.Column<int>(type: "int", nullable: true),
                    XodimId = table.Column<int>(type: "int", nullable: false),
                    JamiSumma = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    TolovTuri = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Holat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Yaratilganvaqt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Savdolar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Savdolar_Tochkalar_TochkaId",
                        column: x => x.TochkaId,
                        principalTable: "Tochkalar",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Savdolar_Xodimlar_XodimId",
                        column: x => x.XodimId,
                        principalTable: "Xodimlar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transferlar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TochkaId = table.Column<int>(type: "int", nullable: false),
                    XodimId = table.Column<int>(type: "int", nullable: false),
                    Holat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Izoh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Yaratilganvaqt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transferlar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transferlar_Tochkalar_TochkaId",
                        column: x => x.TochkaId,
                        principalTable: "Tochkalar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transferlar_Xodimlar_XodimId",
                        column: x => x.XodimId,
                        principalTable: "Xodimlar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SavdoQatorlar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SavdoId = table.Column<int>(type: "int", nullable: false),
                    MaxsulotId = table.Column<int>(type: "int", nullable: false),
                    Miqdor = table.Column<int>(type: "int", nullable: false),
                    Narx = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Yaratilganvaqt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SavdoQatorlar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SavdoQatorlar_Maxsulotlar_MaxsulotId",
                        column: x => x.MaxsulotId,
                        principalTable: "Maxsulotlar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SavdoQatorlar_Savdolar_SavdoId",
                        column: x => x.SavdoId,
                        principalTable: "Savdolar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransferQatorlar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransferId = table.Column<int>(type: "int", nullable: false),
                    MaxsulotId = table.Column<int>(type: "int", nullable: false),
                    YuborilganMiq = table.Column<int>(type: "int", nullable: false),
                    QabulMiqdor = table.Column<int>(type: "int", nullable: false),
                    Yaratilganvaqt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransferQatorlar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransferQatorlar_Maxsulotlar_MaxsulotId",
                        column: x => x.MaxsulotId,
                        principalTable: "Maxsulotlar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransferQatorlar_Transferlar_TransferId",
                        column: x => x.TransferId,
                        principalTable: "Transferlar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Davomatlar_XodimId",
                table: "Davomatlar",
                column: "XodimId");

            migrationBuilder.CreateIndex(
                name: "IX_IshAktlar_XodimId",
                table: "IshAktlar",
                column: "XodimId");

            migrationBuilder.CreateIndex(
                name: "IX_IshAktQatorlar_IshAktId",
                table: "IshAktQatorlar",
                column: "IshAktId");

            migrationBuilder.CreateIndex(
                name: "IX_IshAktQatorlar_MaxsulotId",
                table: "IshAktQatorlar",
                column: "MaxsulotId");

            migrationBuilder.CreateIndex(
                name: "IX_Maoshlar_XodimId",
                table: "Maoshlar",
                column: "XodimId");

            migrationBuilder.CreateIndex(
                name: "IX_Retseptlar_MaxsulotId",
                table: "Retseptlar",
                column: "MaxsulotId");

            migrationBuilder.CreateIndex(
                name: "IX_Retseptlar_XomashyoId",
                table: "Retseptlar",
                column: "XomashyoId");

            migrationBuilder.CreateIndex(
                name: "IX_Savdolar_TochkaId",
                table: "Savdolar",
                column: "TochkaId");

            migrationBuilder.CreateIndex(
                name: "IX_Savdolar_XodimId",
                table: "Savdolar",
                column: "XodimId");

            migrationBuilder.CreateIndex(
                name: "IX_SavdoQatorlar_MaxsulotId",
                table: "SavdoQatorlar",
                column: "MaxsulotId");

            migrationBuilder.CreateIndex(
                name: "IX_SavdoQatorlar_SavdoId",
                table: "SavdoQatorlar",
                column: "SavdoId");

            migrationBuilder.CreateIndex(
                name: "IX_Tochkalar_MasulId",
                table: "Tochkalar",
                column: "MasulId");

            migrationBuilder.CreateIndex(
                name: "IX_Transferlar_TochkaId",
                table: "Transferlar",
                column: "TochkaId");

            migrationBuilder.CreateIndex(
                name: "IX_Transferlar_XodimId",
                table: "Transferlar",
                column: "XodimId");

            migrationBuilder.CreateIndex(
                name: "IX_TransferQatorlar_MaxsulotId",
                table: "TransferQatorlar",
                column: "MaxsulotId");

            migrationBuilder.CreateIndex(
                name: "IX_TransferQatorlar_TransferId",
                table: "TransferQatorlar",
                column: "TransferId");

            migrationBuilder.CreateIndex(
                name: "IX_Xarajatlar_KassaId",
                table: "Xarajatlar",
                column: "KassaId");

            migrationBuilder.CreateIndex(
                name: "IX_Xarajatlar_XodimId",
                table: "Xarajatlar",
                column: "XodimId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Davomatlar");

            migrationBuilder.DropTable(
                name: "IshAktQatorlar");

            migrationBuilder.DropTable(
                name: "Maoshlar");

            migrationBuilder.DropTable(
                name: "Retseptlar");

            migrationBuilder.DropTable(
                name: "SavdoQatorlar");

            migrationBuilder.DropTable(
                name: "Taminotchilar");

            migrationBuilder.DropTable(
                name: "TransferQatorlar");

            migrationBuilder.DropTable(
                name: "Xarajatlar");

            migrationBuilder.DropTable(
                name: "IshAktlar");

            migrationBuilder.DropTable(
                name: "Xomashyolar");

            migrationBuilder.DropTable(
                name: "Savdolar");

            migrationBuilder.DropTable(
                name: "Maxsulotlar");

            migrationBuilder.DropTable(
                name: "Transferlar");

            migrationBuilder.DropTable(
                name: "Kassalar");

            migrationBuilder.DropTable(
                name: "Tochkalar");

            migrationBuilder.DropTable(
                name: "Xodimlar");
        }
    }
}
