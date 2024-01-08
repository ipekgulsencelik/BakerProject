using Baker.EntityLayer.Abstract;

namespace Baker.EntityLayer.Concrete
{
    public class Subscribe : IMongoBaseEntity
    {
        public string Email { get; set; }
    }
}