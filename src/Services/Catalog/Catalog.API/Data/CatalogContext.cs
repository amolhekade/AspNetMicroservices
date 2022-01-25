using Catalog.API.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Data
{
    public class CatalogContext : ICatalogContext
    {

        public IMongoCollection<Product> Products { get; }

        public CatalogContext(IConfiguration configuration)
        {
            var clinet = new MongoClient(configuration.GetValue <string>("DatabseSettings:ConnectionStrings"));
            var database = clinet.GetDatabase(configuration.GetValue<string>("DatabseSettings:DatabaseName"));
            Products = database.GetCollection<Product>(configuration.GetValue<string>("DatabseSettings:CollectionName"));

            CatalogContextSeed.SeedData(Products);
        }

    }
}
