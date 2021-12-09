namespace _19522221_Lab5.Models
{
    public class CongNhanModel
    {
        private string macongnhan;
        private string tencongnhan;
        private bool gioitinh;
        private int namsinh;
        private string nuocve;
        private string madiemcachli;

        public string MaCongNhan
        {
            get { return macongnhan; }
            set { macongnhan = value; }
        }

        public string TenCongNhan
        {
            get { return tencongnhan; }
            set { tencongnhan = value; }
        }

        public bool GioiTinh
        {
            get { return gioitinh; }
            set { gioitinh = value; }
        }

        public int NamSinh
        {
            get { return namsinh; }
            set { namsinh = value; }
        }

        public string NuocVe
        {
            get { return nuocve; }
            set { nuocve = value; }
        }

        public string MaDiemCachLi
        {
            get { return madiemcachli; }
            set { madiemcachli = value; }
        }

    }
}
