using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieRegistration.Models
{
    public class Movie
    {
        [Key]
        public string ID { get; set; }
        [MaxLength(30)]
        public string Title { get; set; }
        public string Genre { get; set; }
        [Range(1880,2021)]
        public int Year { get; set; }

        public float Runtime { get; set;}
    }

    //public enum Genre
    //{
    //    Action,
    //    Animation,
    //    Comedy,
    //    Drama,
    //    Romantic
    //}
}
