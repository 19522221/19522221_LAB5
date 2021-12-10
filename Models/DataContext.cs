
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace _19522221_Lab5.Models
{
    public class DataContext
    {
        public string ConnectionString { get; set; } // Biến thành viên

        public DataContext(string connectionstring)
        {
            this.ConnectionString = connectionstring;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }

        /* -----------------------------
         *  SQL TABLE DIEMCACHLI
         *--------------------------------*/
        public int sqlInsertDCL(DiemCachLiModel diemcachly)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "insert into diemcachly values(@madiemcachli, @tendiemcachli, @diachi)";
                SqlCommand cmd = new SqlCommand(str, conn);
                cmd.Parameters.AddWithValue("madiemcachli", diemcachly.MaDiemCachLi);
                cmd.Parameters.AddWithValue("tendiemcachli", diemcachly.TenDiemCachLi);
                cmd.Parameters.AddWithValue("diachi", diemcachly.DiaChi);
                return (cmd.ExecuteNonQuery());
            }
        }

        public List<DiemCachLiModel> sqlListDiemCachLi()
        {
            List<DiemCachLiModel> list = new List<DiemCachLiModel>();
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                string str = @"SELECT * FROM DIEMCACHLY";
                SqlCommand cmd = new SqlCommand(str, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new DiemCachLiModel()
                        {
                            MaDiemCachLi = reader["MaDiemCachLy"].ToString(),
                            TenDiemCachLi = reader["TenDiemCachLy"].ToString(),
                            DiaChi = reader["DiaChi"].ToString(),
                            
                        });
                    }
                    reader.Close();
                }
                conn.Close();
            }
            return list;
        }

        public List<CongNhanModel> sqlListDiemCachLi_CongNhan(string dcl)
        {
            List<CongNhanModel> list = new List<CongNhanModel>();
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                string str = @"SELECT * FROM congnhan where MaDiemCachLy = @dcl";
                SqlCommand cmd = new SqlCommand(str, conn);
                cmd.Parameters.AddWithValue("@dcl", dcl);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new CongNhanModel()
                        {
                            MaCongNhan = reader["MaCongNhan"].ToString(),
                            TenCongNhan = reader["TenCongNhan"].ToString(),
         
                        });
                    }
                    reader.Close();
                }
                conn.Close();
            }
            return list;
        }


        public List<object> sqlListCongNhanSoLan(int soLan)
        {
            List<object> list = new List<object>();
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                string str = @"select cn.TenCongNhan,cn.NamSinh,cn.NuocVe, count(*) AS SoTrieuChung
                                from congnhan cn join cn_tc on cn.MaCongNhan = cn_tc.MaCongNhan 
                                group by cn.TenCongNhan,cn.NamSinh,cn.NuocVe
                                having count(*) >=@SoLanInput";
                SqlCommand cmd = new SqlCommand(str, conn);
                cmd.Parameters.AddWithValue("SoLanInput", soLan);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new 
                        {
                            TenCN = reader["TenCongNhan"].ToString(),
                            NamSinh = Convert.ToInt32(reader["NamSinh"]),
                            NV = reader["NuocVe"].ToString(),
                            SoLan = Convert.ToInt32(reader["SoTrieuChung"])
                        });
                    }
                    reader.Close();
                }
                conn.Close();
            }
            return list;
        }

        public int sqlDeleteCN(string id)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "delete from CongNhan where MaCongNhan = @macn";
                SqlCommand cmd = new SqlCommand(str, conn);
                cmd.Parameters.AddWithValue("@macn", id);
                return (cmd.ExecuteNonQuery());
            }
        }


        public CongNhanModel sqlViewCN(string Id)
        {
            
            CongNhanModel cn = new CongNhanModel();
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "select * from CongNhan where MaCongNhan=@macn";
                SqlCommand cmd = new SqlCommand(str, conn);
                cmd.Parameters.AddWithValue("@macn", Id);
                using (var reader = cmd.ExecuteReader())
                {
                    reader.Read();
                    cn.MaCongNhan = reader["MaCongNhan"].ToString();
                    cn.TenCongNhan = reader["TenCongNhan"].ToString();
                    cn.GioiTinh = Convert.ToBoolean(reader["GioiTinh"]);
                    cn.NamSinh = Convert.ToInt32(reader["NamSinh"]);
                    cn.NuocVe = reader["NuocVe"].ToString();

                }
            }
            return (cn);
        }



    }
}
