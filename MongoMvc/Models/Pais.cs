﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MongoMvc.Models
{
    public class Pais
    {
        [BsonId()]
        public ObjectId Id { get; set; }

        [BsonElement("title")]
        [BsonRequired()]
        public string Title { get; set; }

        [BsonElement("body")]
        [BsonRequired()]
        public string Body { get; set; }

        [BsonElement("created")]
        [BsonRequired()]
        public DateTime Created { get; set; }

        [BsonElement("active")]
        [BsonRequired()]
        public bool Active { get; set; }

        [BsonElement("value")]
        [BsonRequired()]
        public double Value { get; set; }

        [BsonElement("position")]
        [BsonRequired()]
        public int Position { get; set; }
    }
}