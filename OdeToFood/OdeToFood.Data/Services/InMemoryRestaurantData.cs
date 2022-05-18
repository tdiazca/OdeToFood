using OdeToFood.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data.Services
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> restaurants; // in memory list of restaurant - private field
        public InMemoryRestaurantData() // in memory data dissapears at the end of the session
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant { Id = 1, Name = "Maite's Pizza", Cuisine = CuisineType.Italian},
                new Restaurant { Id = 2, Name = "Tersiguels", Cuisine = CuisineType.French},
                new Restaurant { Id = 3, Name = "Mango Grove", Cuisine = CuisineType.Indian},
            };
        }

        public void Add(Restaurant restaurant) // add an instance of the class Restaurant to list of restaurants in memory
        {
            restaurants.Add(restaurant);
            restaurant.Id = restaurants.Max(r => r.Id) + 1;
        }

        public void Update(Restaurant restaurant)
        {
            var existing = Get(restaurant.Id);
            if(existing!= null)
            {
                existing.Name = restaurant.Name;
                existing.Cuisine = restaurant.Cuisine;
            }
        }

        public Restaurant Get(int id)
        {
            return restaurants.FirstOrDefault(r => r.Id == id); 
            // given a rest r, give me the first rest were id matches this incoming id or the default value for the rest reference (null) 
        }

        public IEnumerable<Restaurant> GetAll() // List<Restaurant> restaurants implements the interface IEnumerable<restaurant>
        {
            return restaurants.OrderBy(r => r.Name); // enumerates by name is asc order
        }

        public void Delete(int id)
        {
            var restaurant = Get(id);
            if(restaurant != null)
            {
                restaurants.Remove(restaurant);
            }
        }
    }
}
