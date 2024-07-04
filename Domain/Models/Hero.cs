namespace HeroesApi.Domain.Models
{
    public class Hero
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string HeroName { get; set; }
        public DateTime BirthDate { get; set; }
        public float Height { get; set; }
        public float Weight { get; set; }
        public ICollection<HeroPower> HeroPowers { get; set; }
    }
}