using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace WebApi.Models
{
    public class Kullanici
    {
         [Key]
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string Contact { get; set; }
    }
}