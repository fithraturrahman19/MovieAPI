using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPI
{
    public class Movies
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public float Rating { get; set; }
        public string Image { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }

        public Movies()
        {

        }

        public Movies(int id, string title, string description, float rating, string image, DateTime created_at, DateTime updated_at)
        {
            Id = id;
            Title = title;
            Description = description;
            Rating = rating;
            Image = image;
            Created_at = created_at;
            Updated_at = updated_at;
        }
    }
}
