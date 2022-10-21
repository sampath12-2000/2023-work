namespace CropDealWebAPI.Models
{
    public class ViewCrop
    {
        public int CropSaleId { get; set; }
        public string CropImage { get; set; }
        public string CropName { get; set; }
        public string CropType { get; set; }
        public int CropQty { get; set; }
        public double CropPrice { get; set; }
        public int? FarmerId { get; set; }
        public string FarmerAddress { get; set; }

        public string FarmerName { get; set; }

        public string FarmerPhoneNo { get; set; }
    }
}
