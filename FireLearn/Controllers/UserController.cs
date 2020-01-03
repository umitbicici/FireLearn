using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FireLearn.Models;
using FireLearn.Models.Entity;
using PagedList;
using PagedList.Mvc;
using Microsoft.SqlServer;
using System.Data.SqlClient;
using System.Data;

namespace FireLearn.Controllers
{
    public class UserController : Controller
    {
       public  SqlConnection con;
        fireLearnEntities2 db = new fireLearnEntities2();
        public ActionResult Kurslar()
        {
            var kurs = db.tblKurs.ToList();
            return View(kurs);
        }
        public ActionResult yeniKurslar()
        {
            string username = Session["User1"].ToString();
            string ekle_sorgu;

            string path = "Data Source=DESKTOP-1DMDCN6;Initial Catalog=fireLearn;Integrated Security=True";
            con = new SqlConnection(path);
            con.Open();

            SqlCommand useridcek = new SqlCommand("Select userID from tblUsers where username = '" + username + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(useridcek);
            DataTable dt = new DataTable();
            da.Fill(dt);
            int kid = Convert.ToInt32(dt.Rows[0]["userID"]);
            Database db2 = new Database();
            SqlCommand kursidcek = new SqlCommand("select kursID from tblTamamlanan where userID=" + kid + "",con);
            SqlDataAdapter da2 = new SqlDataAdapter(kursidcek);       
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);

            SqlCommand kursidcek2 = new SqlCommand("select kursID from tblkurs",con);
            SqlDataAdapter da3 = new SqlDataAdapter(kursidcek2);
            DataTable dt3 = new DataTable();
            da3.Fill(dt3);
            List<Kurs> degerler = new List<Kurs>();
            
            for (int i = 0; i < dt3.Rows.Count; i++)
            {
                int ilkkursid = Convert.ToInt32(dt2.Rows[i]["kursID"]);
                int ikincikursid = Convert.ToInt32(dt3.Rows[i]["kursID"]);
                
                if (ilkkursid == ikincikursid)
                {

                }
                else
                {
                    degerler = db2.kursListeleri("select * from tblkurs where kursID=" + ikincikursid + "");
                
                    
                }
            }
            
            return View(degerler);


            return View(0);
           
        }





        [HttpGet]
        public ActionResult kelimeEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult kelimeEkle(tblKelime kelime)
        {
            if(ModelState.IsValid)
            {
                return View("kelimeEkle");
            }
            db.tblKelime.Add(kelime);
            db.SaveChanges();
            return RedirectToAction("profilim", "User");
        }
        public ActionResult kelimeSil(int ID)
        {
            var kelime = db.tblKelime.Find(ID);
            db.tblKelime.Remove(kelime);
            db.SaveChanges();
            return RedirectToAction("profilim","User");
        }
        public ActionResult kelimeGuncelle()
        {
            return View();
        }
        

        public ActionResult Sorular(int id , int sayfa=1)
        
        {
            SqlCommand yaz;


            Database db2 = new Database();
            var degerler = db2.soruListeleri("select * from tblkelime where kelimeDerece=" + id + "").ToList().ToPagedList(sayfa, 1);
            if (sayfa==12)
            {
                
                string username = Session["User1"].ToString();
                string ekle_sorgu;

                string path = "Data Source=DESKTOP-1DMDCN6;Initial Catalog=fireLearn;Integrated Security=True";
                con = new SqlConnection(path);
                con.Open();

                SqlCommand  useridcek = new SqlCommand( "Select userID from tblUsers where username = '" + username + "'",con);
                SqlDataAdapter da = new SqlDataAdapter(useridcek);
                DataTable dt = new DataTable();
                da.Fill(dt);
                int kid = Convert.ToInt32(dt.Rows[0]["userID"]);
                ekle_sorgu = "INSERT INTO tblTamamlanan (userID,kursID)"   +"  values  ("+ kid+ "," + id + ")";
                
                db2.connection();
                db2.kaydet_sil(ekle_sorgu);

                return RedirectToAction("Kurslar","User");
            }

            return View(degerler);
           // return View(db2.soruListeleri("select * from tblkelime where kelimeDerece=" + id + ""));
        }



    }
}