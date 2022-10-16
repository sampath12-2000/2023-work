using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CropDealWebAPI.Models
{
    public partial class Invoice
    {
        public int InvoiceId { get; set; }
        public DateTime OrderDate { get; set; }
        public int? FarmerId { get; set; }
        public int? DealerId { get; set; }
        public string CropName { get; set; }
        public string CropType { get; set; }
        public int CropQty { get; set; }
        public double OrderTotal { get; set; }
        public string Review { get; set; }

        [JsonIgnore]
        public virtual UserProfile Dealer { get; set; }
        [JsonIgnore]
        public virtual UserProfile Farmer { get; set; }
    }
}
