using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebAPI.Models
{
    public class DonViVanTai
    {
        [Key]
        public Guid Uuid { get; set; }

        public string IdDonViHanhChinh { get; set; }

        public string MaSoThue { get; set; }

        public string MaDonViVanTai { get; set; }

        public string TenDonVi { get; set; }

        public string ThuTruongDonVi { get;set; }

        public string DiaChi { get; set; }

        public string SoDienThoai { get; set; }

        public string Email { get; set; }

        public string Fax { get; set; }

        public int SoLuongXe { get; set; }

        public int SoLuongXeToiDaTrongBen { get; set; }

        public int TinhTrangHoatDong { get; set; }

        public DateTime ThoiGianBatDauHoatDong { get;set; }

        public DateTime ThoiGianNgungHoatDong { get; set; }

        public IEnumerable<string> Timkiems()
        {
            return new List<string> { "MaSoThue", "MaDonViVanTai", "TenDonVi", "ThuTruongDonVi" };
        }
    }
}
