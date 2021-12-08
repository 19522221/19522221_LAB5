using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LAB5.Models {

    public class TrieuChung {

        [Key]
        public string MaTrieuChung { get; set; }

        public string TenTrieuChung { get; set; }
        public virtual ICollection<CN_TC> CN_TCs { get; set; }
    }
}