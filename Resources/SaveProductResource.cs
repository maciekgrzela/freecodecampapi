using System.ComponentModel.DataAnnotations;
using freecodecampapi.Domain.Models;

namespace freecodecampapi.Resources
{
    public class SaveProductResource
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [Range(0, 100)]
        public int QuantityInPackage { get; set; }

        [Required]
        [Range(1, 5)]
        public EUnitOfMeasurement UnitOfMeasurement { get; set; }

        [Required]
        public int CategoryId { get; set; }

    }
}