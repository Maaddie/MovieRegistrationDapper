using Microsoft.AspNetCore.Mvc;
using MovieRegistration.Models;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;



namespace MovieRegistration.Controllers
{
    public class RegistrationController : Controller
    {
        public IActionResult Index()
        {
            using (var connect = new MySqlConnection(Secret.Connection))
            {
                string sql = "select * from movies";

                connect.Open();

                List<Movie> movies = connect.Query<Movie>(sql).ToList();

                connect.Close();
                Movie m = movies[0];

                return View(m);
            }

        }

        public IActionResult Result(Movie m)
        {
            if (ModelState.IsValid)
            {
                string sql = "INSERT INTO movies (ID, Title, Genre, Year, Runtime) Values (@ID, @Title, @Genre, @Year, @Runtime );";

                using (var connection = new MySqlConnection(Secret.Connection))
                {
                    connection.Execute(sql, new { ID = m.ID, Title = m.Title, Genre = m.Genre, Year = m.Year, Runtime = m.Runtime });
                }
                return View(m);
                //return RedirectToAction("Index", "Registration");
            }
            else
            {
                return RedirectToAction("Index", "Registration");
            }
        }

        public IActionResult viewMovies()
        {
            using (var connect = new MySqlConnection(Secret.Connection))
            {
                string sql = "select * from movies";

                connect.Open();

                List<Movie> movies = connect.Query<Movie>(sql).ToList();

                connect.Close();
                //Movie m = movies;

                return View(movies);
            }
        }

    }

}

