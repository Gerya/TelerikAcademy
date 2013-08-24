using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Supermarket.Reports
{
   public class ProductReportJson
    {
       
        [BsonId]
        [JsonIgnore]
        public ObjectId Id { get; set; }

       //[JsonIgnore]
        [JsonProperty("product-id")]
        public int ProductId { get; set; }

        [JsonProperty("product-name")]
        public string Name { get; set; }

        [JsonProperty("vendor-name")]
        public string Vendor { get; set; }

        [JsonProperty("total-quantity-sold")]
        public int QuantitySold { get; set; }

        [JsonProperty("total-incomes")]
        public decimal Incomes { get; set; }

    }
}
