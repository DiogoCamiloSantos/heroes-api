using System;
using System.Collections.Generic;

namespace HeroesApi.Presentation.Dto
{
     public class HeroCreateDto
    {
        public string Name { get; set; }
        public string HeroName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public float Height { get; set; }
        public float Weight { get; set; }
        public List<int> PowerIds { get; set; }
    }
}
