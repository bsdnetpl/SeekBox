namespace SeekBox.DTOs
{
    public class PackageDto
    {
        public string dateOfPosting { get; set; }
        public string typeOfDelivery { get; set; }
        public string countryOfOrigin { get; set; }
        public string description { get; set; }
        public string destinationCountry { get; set; }
        public string posId { get; set; }
        public double mass { get; set; }
        public double dimensionsX { get; set; }
        public double dimensionsY { get; set; }
        public double dimensionsZ { get; set; }
        public int ClientId { get; set; }
        public int shippingPointId { get; set; }
    }
}
