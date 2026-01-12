using CarRentalApp.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarRentalApp.Models
{
    public class CarCategory
    {
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string Name { get; set; }

        public ICollection<Car> Cars { get; set; }
    }
}
