using OdeToFood.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Data.Services
{
    public class OdeToFoodDbContext : DbContext  //the class derives from DbContext
    {
        public DbSet<Restaurant> Restaurants { get; set; } 
        // telling Entity framework there is a table named Restaurants in the db and will contain columns such as name, cuisine, id
            // attributes of the Restaurant class
    }
}
