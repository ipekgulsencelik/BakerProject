using Baker.EntityLayer.Abstract;

namespace Baker.EntityLayer.Concrete
{
    public class Map : IMongoBaseEntity
    {
        public string? MapURL { get; set; }
    }
}