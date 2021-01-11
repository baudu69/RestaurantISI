namespace Restaurant.Models
{
    public class Plats
    {
        private RestaurantContext context;
        
        public int idPlat { get; set; }
        
        public string nomPlat { get; set; }
        
        public string prixPlat { get; set; }
        
        public Categories catPlat { get; set; }
    }
}