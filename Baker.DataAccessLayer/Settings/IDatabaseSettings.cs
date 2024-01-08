namespace Baker.DataAccessLayer.Settings
{
    public interface IDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }

        public string AboutCollectionName { get; set; }
        public string AboutItemCollectionName { get; set; }
        public string CarouselCollectionName { get; set; }
        public string CategoryCollectionName { get; set; }
        public string ContactCollectionName { get; set; }
        public string GalleryCollectionName { get; set; }
        public string MapCollectionName { get; set; }
        public string MessageCollectionName { get; set; }
        public string OfferCollectionName { get; set; }
        public string ProductCollectionName { get; set; }
        public string ServiceCollectionName { get; set; }
        public string SocialMediaCollectionName { get; set; }
        public string SubscribeCollectionName { get; set; }
        public string TeamCollectionName { get; set; }
        public string TestimonialCollectionName { get; set; }
    }
}