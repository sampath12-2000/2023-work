using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CropDealWebAPI.Models
{
    public partial class Crop
    {
        public Crop()
        {
            CropOnSales = new HashSet<CropOnSale>();
        }

        public int CropId { get; set; }
        public string CropName { get; set; }
        public string CropImage { get; set; }

        [JsonIgnore]
        public virtual ICollection<CropOnSale> CropOnSales { get; set; }
    }
}
