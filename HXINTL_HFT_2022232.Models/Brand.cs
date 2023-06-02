using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXINTL_HFT_2022232.Models
{
    public class Brand
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(100)]
        [Required]
        public string BrandName { get; set; }
        public string BrandCountry { get; set; }
        public int BrandYear { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<Motorcycle> Motorcycle { get; set; }

        public Brand()
        {
            Motorcycle=new HashSet<Motorcycle>();
        }

    }
}
