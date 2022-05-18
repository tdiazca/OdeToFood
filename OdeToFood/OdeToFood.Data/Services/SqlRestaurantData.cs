using OdeToFood.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace OdeToFood.Data.Services
{
    public class SqlRestaurantData : IRestaurantData  //Implements this interface
        // different to the InMeMoryRestaurantData class because this one stores data on a sql server not in memory
    {
        private readonly OdeToFoodDbContext db;

        public SqlRestaurantData(OdeToFoodDbContext db) // constructor (ctor)
        {
            this.db = db; // private field 
        }
        public void Add(Restaurant restaurant)
        {
            db.Restaurants.Add(restaurant); //Restaurants is a table on my db (see OdeToFoodDbContext)
            db.SaveChanges();
                // execute INSERT statement in sqlserver. WIll see all restaurants have an id property. This is made a primary key automatically. Makes this column an identity column. Will generate a new id for this new restaurant. This populates my restaurant object with a new id value in MVS. 
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
            // returns the restaurant with id = incoming id or returns null if not found
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return db.Restaurants;            
        }
        /*public IEnumerable<Restaurant> GetAll()
        {
            return from r in db.Restaurants
                   orderby r.Name
                   select r;
        }*/
        public void Update(Restaurant restaurant)
        {
            var entry = db.Entry(restaurant);
            entry.State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
