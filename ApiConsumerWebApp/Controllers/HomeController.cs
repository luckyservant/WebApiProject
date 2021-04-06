using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebApi.Models;

namespace ApiConsumerWebApp.Controllers
{
    public class HomeController : Controller
    {
        public Uri apiBaseAddress = new Uri("https://localhost:44312/api/user");
        public HttpClient client = new HttpClient();
        public HomeController()
        {
            this.client.BaseAddress = apiBaseAddress;
        }
        public ActionResult Index()
        {
            HttpResponseMessage resp = this.client.GetAsync(this.client.BaseAddress + "/GetKullanicilar").Result;
            if (resp.IsSuccessStatusCode)
            {
                string kisiRaw = resp.Content.ReadAsStringAsync().Result;
                var kisi = JsonConvert.DeserializeObject<List<Kullanici>>(kisiRaw);
            }
            return View();
        }
        public ActionResult CreateKullanici() 
        {

            return View();
        }
        [HttpPost]
        public ActionResult CreateKullanici(Kullanici user) 
        {
            string postedData = JsonConvert.SerializeObject(user);
            StringContent cont = new StringContent(postedData, Encoding.UTF8, "application/json");
            HttpResponseMessage resp = client.PostAsync(client.BaseAddress + "KullaniciEkle", cont).Result;
            return View();
        }

        public ActionResult EditKullanici(int userId)
        {
            HttpResponseMessage resp = this.client.GetAsync(this.client.BaseAddress + $"/GetKullanici/{userId}").Result;
            string kisiRaw = resp.Content.ReadAsStringAsync().Result;
            var kisi = JsonConvert.DeserializeObject<Kullanici>(kisiRaw);
            return View("EditKullanici",kisi);
        }
        [HttpPost]
        public ActionResult EditKullanici(int userId, Kullanici user)
        {
            string postedData = JsonConvert.SerializeObject(user);  
            StringContent cont = new StringContent(postedData, Encoding.UTF8, "application/json");
            HttpResponseMessage resp = client.PostAsync(client.BaseAddress + "KullaniciEkle", cont).Result;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}