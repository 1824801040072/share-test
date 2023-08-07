using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class YourMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DonViVanTais",
                columns: table => new
                {
                    Uuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdDonViHanhChinh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaSoThue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaDonViVanTai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenDonVi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThuTruongDonVi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoDienThoai = table.Column<long>(type: "varchar(10)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fax = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoLuongXe = table.Column<int>(type: "int", nullable: false),
                    SoLuongXeToiDaTrongBen = table.Column<int>(type: "int", nullable: false),
                    TinhTrangHoatDong = table.Column<int>(type: "int", nullable: false),
                    ThoiGianBatDauHoatDong = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ThoiGianNgungHoatDong = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonViVanTais", x => x.Uuid);
                });
        }
        /// <inheritdoc />
        /// 
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DonViVanTais");
        }
    }
}
