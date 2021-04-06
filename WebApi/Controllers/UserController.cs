using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class UserController : ApiController
    {
        DatabaseContext db = new DatabaseContext();
        [HttpGet]
        public string Greet(string isim)
        {
            return $"Hello {isim}";
        }
        
        public IEnumerable<Kullanici> GetKullanicilar() 
        {
            return db.Kullanicilar.ToList();
        }

        public Kullanici GetKullanici(int id)
        {
            return db.Kullanicilar.Find(id);
        }
        [HttpPost]
        public HttpResponseMessage AddKullanici(Kullanici user) 
        {
            HttpResponseMessage resp = new HttpResponseMessage(HttpStatusCode.OK);
            try
            {
                db.Kullanicilar.Add(user);
                db.SaveChanges();
                
                return resp;
            }
            catch (Exception)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError); ;
            }
            
           
        }

        [HttpPost]
        public HttpResponseMessage UpdateKullanici(int id,Kullanici user)
        {
            HttpResponseMessage resp = new HttpResponseMessage(HttpStatusCode.OK);
            try
            {
                Kullanici selectedUser = db.Kullanicilar.Find(id);

                if(selectedUser !=null) 
                { 
                    db.Entry(selectedUser).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                return resp;
            }
            catch (Exception)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError); ;
            }


        }

        [HttpPost]
        public HttpResponseMessage DeleteKullanici(int id)
        {
            HttpResponseMessage resp = new HttpResponseMessage(HttpStatusCode.OK);
            try
            {
                Kullanici user = db.Kullanicilar.Find(id);
                if (user != null)
                {
                    db.Kullanicilar.Remove(user);
                    db.SaveChanges();
                }
                return resp;
            }
            catch (Exception)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError); ;
            }


        }

        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

    }
}