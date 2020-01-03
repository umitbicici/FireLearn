using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.IO;
namespace FireLearn.Models
{
    public class Database
    {
        
        SqlConnection con;
        public SqlCommand yazsil;
        SqlDataAdapter data;
        SqlCommand yaz;

        public void connection()
        {
            string path = "Data Source=DESKTOP-1DMDCN6;Initial Catalog=fireLearn;Integrated Security=True";
            con = new SqlConnection(path);
            con.Open();
        }

        public bool usercontrol(string query)
        {
            bool durum = false;
            yazsil = new SqlCommand(query, con);
            SqlDataReader dr = yazsil.ExecuteReader();

            if (dr.Read())
                durum = true;

            dr.Close();
            return durum;
        }
        public DataTable listeler(string sorgu)
        {
            DataTable dt = new DataTable();
            data = new SqlDataAdapter(sorgu, con);
            data.Fill(dt);

            return dt;
        }
         public List<Kelime> soruListeleri (string sorgu)
         {
             connection();
             DataTable dt = new DataTable();
             dt = listeler(sorgu);
             var liste_kayit = new List<Kelime>();
             for (int i = 0; i < dt.Rows.Count; i++)
             {
                 liste_kayit.Add(new Kelime { 
                     kelime_id = Convert.ToInt32(dt.Rows[i]["kelimeID"].ToString()),
                     KelimeTR=dt.Rows[i]["kelimeTR"].ToString(),
                     KelimeING=dt.Rows[i]["kelimeING"].ToString(),
                     Kelime_Turu=dt.Rows[i]["kelimeTuru"].ToString(),
                     Kelime_video = dt.Rows[i]["kelimevideo"].ToString(),
                 });
                
             }
             return liste_kayit;


         }
        public List<Kurs> kursListeleri(string sorgu)
        {
            connection();
            DataTable dt = new DataTable();
            dt = listeler(sorgu);
            var liste_kayit = new List<Kurs>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                liste_kayit.Add(new Kurs
                {
                    kurs_id = Convert.ToInt32(dt.Rows[i]["kursID"].ToString()),
                    kurs_adi = dt.Rows[i]["kursAdi"].ToString(),
                
                });

            }
            return liste_kayit;


        }
        public void kaydet_sil(string sorgu)
        {

            yaz = new SqlCommand(sorgu, con);
            yaz.ExecuteNonQuery();

        }
        /* public Kelime soruListeleri(int id)
         {
             connection();
             DataTable dt = new DataTable();
             string sorgu = "select * from tblkelime where kelimeDerece=" + id + "";
             dt = listeler(sorgu);
             var kelimeler = new Kelime();
             kelimeler.kelime_id = Convert.ToInt32(dt.Rows[0]["kelimeID"]);
             kelimeler.KelimeTR = dt.Rows[0]["kelimeTR"].ToString();
             kelimeler.KelimeING= dt.Rows[0]["kelimeING"].ToString();
             kelimeler.Kelime_Turu = dt.Rows[0]["kelimeTuru"].ToString();


             return kelimeler;
         }*/


    }
}