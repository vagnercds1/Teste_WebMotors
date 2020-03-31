using System.ComponentModel.DataAnnotations;

namespace WebMotors.Domain.Data.DTO
{
    public class AnuncioDTO
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "A marca é obrigatoria", AllowEmptyStrings = false)]
        public string Marca { get; set; }

        [Required(ErrorMessage = "O modelo é obrigatorio", AllowEmptyStrings = false)]
        public string Modelo { get; set; }

        [Required(ErrorMessage = "A versão é obrigatoria", AllowEmptyStrings = false)]
        public string Versao { get; set; }

        [Required(ErrorMessage = "O ano é obrigatorio", AllowEmptyStrings = false)]
        public int Ano { get; set; }

        [Required(ErrorMessage = "A Kilometragem é obrigatoria", AllowEmptyStrings = false)]
        public int Kilometragem { get; set; }

        public string Observacao { get; set; }
    }
}
