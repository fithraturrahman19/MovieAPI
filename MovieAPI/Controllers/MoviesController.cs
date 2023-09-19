using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MovieAPI.Helper;
using System.Data;
using Dapper;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        // GET: api/<MoviesController>
        [HttpGet]
        public IEnumerable<Movies> Get()
        {

            try
            {
                //MYSQL
                MySqlConnection conn = new Util().SetupConnection();

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spMovies_GetMovies";
                cmd.Connection = conn;

                conn.Open();

                MySqlDataReader reader = cmd.ExecuteReader();

                List<Movies> listMovies = new List<Movies>();
                while (reader.Read())
                {
                    listMovies.Add(new Movies(
                        Int32.Parse(reader["Id"].ToString()),
                        reader["Title"].ToString(),
                        reader["Description"].ToString(),
                        float.Parse(reader["Rating"].ToString()),
                        reader["Image"].ToString(),
                        DateTime.Parse(reader["Created_at"].ToString()),
                        DateTime.Parse(reader["Updated_at"].ToString())
                        ));
                }

                conn.Close();

                return listMovies;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Movies>();
            }
        }        


        // GET api/<MoviesController>/5
        [HttpGet("{id}")]
        public Movies Get(int id)
        {
            try
            {
                //MYSQL
                MySqlConnection conn = new Util().SetupConnection();

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spMovies_GetMovie";
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Connection = conn;

                conn.Open();

                MySqlDataReader reader = cmd.ExecuteReader();

                Movies movie = new Movies();
                while (reader.Read())
                {
                    movie = new Movies(
                        Int32.Parse(reader["Id"].ToString()), 
                        reader["Title"].ToString(), 
                        reader["Description"].ToString(),
                        float.Parse(reader["Rating"].ToString()), 
                        reader["Image"].ToString(), 
                        DateTime.Parse(reader["Created_at"].ToString()),
                        DateTime.Parse(reader["Updated_at"].ToString())
                        );
                }

                conn.Close();

                return movie;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return new Movies();
            }
        }

        
        // POST api/<MoviesController>
        [HttpPost]
        public void Post([FromBody]Movies movie)
        {
            try
            {
                //MYSQL
                MySqlConnection conn = new Util().SetupConnection();

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spMovies_AddMovie";
                cmd.Parameters.AddWithValue("@Id", movie.Id);
                cmd.Parameters.AddWithValue("@Title", movie.Title);
                cmd.Parameters.AddWithValue("@Description", movie.Description);
                cmd.Parameters.AddWithValue("@Rating", movie.Rating);
                cmd.Parameters.AddWithValue("@Image", movie.Image);
                cmd.Parameters.AddWithValue("@Created_at", movie.Created_at);
                cmd.Parameters.AddWithValue("@Updated_at", movie.Updated_at);
                cmd.Connection = conn;

                conn.Open();

                cmd.ExecuteNonQuery();

                conn.Close();

            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        // PUT api/<MoviesController>/5
        [HttpPatch("{id}")]
        public void Patch(int id, [FromBody] Movies movie)
        {
            //MYSQL
            MySqlConnection conn = new Util().SetupConnection();

            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SpMovies_UpdateMovie";
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@Title", movie.Title);
            cmd.Parameters.AddWithValue("@Description", movie.Description);
            cmd.Parameters.AddWithValue("@Rating", movie.Rating);
            cmd.Parameters.AddWithValue("@Image", movie.Image);
            cmd.Parameters.AddWithValue("@Created_at", movie.Created_at);
            cmd.Parameters.AddWithValue("@Updated_at", movie.Updated_at);
            cmd.Connection = conn;

            conn.Open();

            cmd.ExecuteNonQuery();

            conn.Close();
        }

        // DELETE api/<MoviesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            //MYSQL
            MySqlConnection conn = new Util().SetupConnection();

            MySqlCommand cmd = new MySqlCommand();
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SpMovies_DeleteMovie";
            cmd.Connection = conn;

            conn.Open();

            cmd.ExecuteNonQuery();

            conn.Close();
        }
    }
}
