using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class MongoObjectIdModel
    {
        /// <summary>
        /// mongo _id
        /// </summary>
        public ObjectId Id { get; set; }
    }
}
