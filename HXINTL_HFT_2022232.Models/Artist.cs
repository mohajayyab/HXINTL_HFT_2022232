using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HXINTL_HFT_2022232.Models
{

        [Table("Artist")]
        public class Artist
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int ArtistId { get; set; }

            [Required]
            [MaxLength(100)]
            public string Name { get; set; }

            [Required]
            public int Age { get; set; }

            [NotMapped]
            public virtual Album Album { get; set; }

            [ForeignKey(nameof(Album))]
            public int? Albumid { get; set; }

            public override string ToString()
            {
                return $"\n{this.ArtistId} | {this.Name} {this.Age} {this.Album} ";

            }
        }
}