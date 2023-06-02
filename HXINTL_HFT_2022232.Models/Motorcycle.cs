using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HXINTL_HFT_2022232.Models
{
    public class Motorcycle
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string MotorcycleName { get; set; }
        public string MotorcycleType { get; set; }
        public int MotorcyclePrice { get; set; }
        public string NewOrUsed { get; set; }
        public int MotorcycleReleaseYear { get; set; }
        public string MotorcycleColor { get; set; }
        public int MotorcycleSeatNumber { get; set; }
        public bool IsLeftWheel { get; set; }
        public string FuelType { get; set; }
        public bool IsElectricMotorcycle { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<RentMotorcycle> RentMotorcycle { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual Brand Brand { get; set; }
        [ForeignKey(nameof (Brand))]
        public int? Brand_id { get; set; }

        public Motorcycle()
        {
            RentMotorcycle = new HashSet<RentMotorcycle>();
        }

    }
}
