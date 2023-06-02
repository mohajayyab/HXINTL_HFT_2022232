using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace HXINTL_HFT_2022232.Models
{
    public class RentMotorcycle
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(100)]
        [Required]
        public string BuyerName { get; set; }
        public int BuyDate { get; set; }
        public string BuyerGender { get; set; }
        public bool IsFirstMotorcycle { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual Motorcycle Motorcycle { get; set; }
        [ForeignKey(nameof(Motorcycle))]
        public int? Motorcycle_id { get; set; }

    }
}
