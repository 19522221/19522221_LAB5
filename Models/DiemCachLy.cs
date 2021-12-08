using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LAB5.Models {

    public class DiemCachLy {

        [Key]
        [DisplayName("Mã Điểm Cách Ly")]
        public string MaDiemCachLy { get; set; }

        [DisplayName("Tên Điểm Cách Ly")]
        public string TenDiemCachLy { get; set; }

        [DisplayName("Địa Điểm Cách Ly")]
        public string DiaChi { get; set; }

        public virtual ICollection<CongNhan> CongNhans { get; set; }
    }
}