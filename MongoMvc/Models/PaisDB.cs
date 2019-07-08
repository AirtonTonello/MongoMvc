using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Linq.Expressions;
using MongoDB.Bson;

namespace MongoMvc.Models
{
    public class PaisDB
    {
        IMongoClient client;
        IMongoDatabase database;

        public PaisDB()
        {
            client = new MongoClient(ConfigurationManager.ConnectionStrings["conexaoMongoDB"].ConnectionString);
            database = client.GetDatabase("TestMongo");
        }

        public IMongoCollection<Pais> GetPais()
        {
            var pais = database.GetCollection<Pais>("pais");

            return pais;
        }

        public void CriarPais(Pais pais)
        {
            IMongoCollection<Pais> db = database.GetCollection<Pais>("pais");
            db.InsertOne(pais);
        }

        public void EditarPais()
        {
            var db = database.GetCollection<Pais>("pais");

            Expression<Func<Pais, bool>> filter = x => x.Id.Equals(ObjectId.Parse("5d238c6032b6544830313bd6"));

            Pais news = db.Find(filter).FirstOrDefault();

            if (news != null)
            {
                news.Value = 200d;
                ReplaceOneResult result = db.ReplaceOne(filter, news);
            }
        }

        public IList<Pais> PesquisaPais(string titulo)
        {
            var db = database.GetCollection<Pais>("pais");

            Expression<Func<Pais, bool>> filter = x => x.Title.Contains(titulo);

            IList<Pais> items = db.Find(filter).ToList();

            return items;
        }

        public void DeletarPais()
        {
            var db = database.GetCollection<Pais>("pais");

            Expression<Func<Pais, bool>> filter = x => x.Id.Equals(ObjectId.Parse("5d238e2f32b65443d8ee416b"));

            DeleteResult delresult = db.DeleteOne(filter);
        }
    }
}