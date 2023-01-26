using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourceApp.Model
{
    public class DogadjajiModel
    {
        [Key]
        [MaxLength(3)]
        [Column("Id", TypeName = "smallint")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public short Id { get; set; }

        [MaxLength(3)]
        [Column("ZaposleniciId", TypeName = "smallint")]
        public short ZaposleniciId { get; set; }

        [Column("Datum", TypeName = "datetime2")]
        public DateTime Datum { get; set; }

        [MaxLength(1000)]
        [Column("Ime", TypeName = "varchar")]
        public string TekstDogadjaja { get; set; }

        public ZaposleniciModel Zaposlenici { get; set; }
    }
}
