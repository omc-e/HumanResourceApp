using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HumanResourceApp.Model
{
    public class ZaposleniciModel 
    {
        [MaxLength(3)]
        [Column("Id", TypeName = "smallint")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public short Id { get; set; }

        [MaxLength(25)]
        [Column("Ime", TypeName = "varchar")]
        public string Ime { get; set; }

        [MaxLength(25)]
        [Column("Prezime", TypeName = "varchar")]
        public string Prezime { get; set; }

        [Column("Pol", TypeName = "tinyint")]
        public byte Pol { get; set; }

        [MaxLength(50)]
        [Column("Grad", TypeName = "varchar")]
        public string Grad { get; set; }

        [MaxLength(70)]
        [Column("Adresa", TypeName = "varchar")]
        public string Adresa { get; set; }

        [Column("DatumDodavanja", TypeName = "datetime2")]
        public DateTime DatumDodavanja { get; set; }

        [Column("DatumIzmjene", TypeName = "datetime2")]
        public DateTime DatumIzmjene { get; set; }

        public ICollection<DogadjajiModel> Dogadjaji { get; set; }

        
    }
}
