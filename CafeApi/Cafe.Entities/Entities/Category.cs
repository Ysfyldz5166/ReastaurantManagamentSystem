using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.Entities.Entities
{
    public class Category : BaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public  string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public virtual List<Food> Foods { get; set; }

    }
}
