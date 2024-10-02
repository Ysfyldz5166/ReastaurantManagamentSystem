using Cafe.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.Entities.Dto
{
    public class FoodDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public float? Calories { get; set; }

        public Guid CategoryId { get; set; }
        //public Category Category { get; set; }
    }
}
