using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FireLearn.Models;
using FireLearn.Models.Entity;
using System.IO;
namespace FireLearn.Controllers
{
    public class HomeController : Controller
    {
        fireLearnEntities2 db = new fireLearnEntities2();
        public ActionResult Index()
        {
            Session.Remove("User1");
            return View();
        }
        [HttpGet]
        public ActionResult hesapEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult hesapEkle(tblUsers kullanici)
        {
            db.tblUsers.Add(kullanici);
            db.SaveChanges();
            return RedirectToAction("index", "Home");
        }
        [HttpGet]
        public ActionResult oturumAc()
        {
          




            return View();
        }
        [HttpPost]
        public ActionResult oturumAc(string username, string password)
        {
            Database db = new Database();
            db.connection();
            if (db.usercontrol("select * from tblUsers where username='" + username + "'and password='" + password + "'"))
            {
                Session["User1"] = username;
                return RedirectToAction("Kurslar", "User");
                
            }
            else
            {
                ViewBag.durum = "Kontrol Et";

                return View();
            }
        }
        /*public ActionResult deneme()
        {
            TextToSpeechClient client = TextToSpeechClient.Create();
            SynthesisInput input = new SynthesisInput
            {
                Text = "hello world"
        };
            VoiceSelectionParams voice = new VoiceSelectionParams
            {
                LanguageCode = "tr",
                SsmlGender = SsmlVoiceGender.Neutral

            };
            AudioConfig config = new AudioConfig
            {
                AudioEncoding = AudioEncoding.Mp3
            };
            var response = client.SynthesizeSpeech(new SynthesizeSpeechRequest
            {
                Input = input,
                Voice = voice,
                AudioConfig = config
            });
            using(Stream output = File.Create("sample.mp3"))
            {
                
                response.AudioContent.WriteTo(output);

            }
            return View();
        }*/
    }
}