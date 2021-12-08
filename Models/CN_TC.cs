using System.ComponentModel.DataAnnotations.Schema;

namespace LAB5.Models {

    public class CN_TC {
        public string MaCongNhan { get; set; }
        public string MaTrieuChung { get; set; }

        [ForeignKey("MaCongNhan")]
        public virtual CongNhan CongNhan { get; set; }

        [ForeignKey("MaTrieuChung")]
        public virtual TrieuChung TrieuChung { get; set; }
    }
}