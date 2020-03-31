using System.ComponentModel.DataAnnotations.Schema;

namespace WebMotors.Repository.Entity
{
    [Table("AnunciosWebmotors")]
    public class Anuncio: BaseEntity
    { 
        public string Marca { get; set; }
         
        public string Modelo { get; set; }
         
        public string Versao { get; set; }
         
        public int Ano { get; set; }
         
        public int Kilometragem { get; set; }

        public string Observacao { get; set; }
    }
}


 