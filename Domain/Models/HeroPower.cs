namespace HeroesApi.Domain.Models
{

    public class HeroPower
    {
        public int HeroId { get; set; }
        public Hero Hero { get; set; }
        public int PowerId { get; set; }
        public Power Power { get; set; }
    }
}