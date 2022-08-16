using OdeToFood.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace OdeToFood.Data.Services
{
    public class SqlRestaurantData : IRestaurantData
    {

        private readonly OdeToFoodDbContext db;


        // KOnstruktor
        public SqlRestaurantData(OdeToFoodDbContext db)
        {
            this.db = db;
        }



        public void Add(Restaurant restaurant)
        {
            db.Restaurants.Add(restaurant);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var restaurant = db.Restaurants.Find(id);
            db.Restaurants.Remove(restaurant);
            db.SaveChanges();
        }

        public Restaurant Get(int id)
        {
            return db.Restaurants.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurant> GetAll()
        {
            // Jedna moznost
            // return from r in db.Restaurants orderby r.Name select r;
            return db.Restaurants.OrderBy(r => r.Name);
        }

        public void Update(Restaurant restaurant)
        {
            var entry = db.Entry(restaurant);
            entry.State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
