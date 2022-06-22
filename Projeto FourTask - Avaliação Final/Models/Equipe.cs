using System.ComponentModel.DataAnnotations;

namespace Projeto_FourTask___Avaliação_Final.Models
{
    public class Equipe
    {
        public int EquipeId { get; set; }

        public string Nome { get; set; }

        public string Senha { get; set; }

        public string Descricao { get; set; }

        public AreaAtuacao AreaAtuacao { get; set; }


        [DataType(DataType.Date)]
        public DateTime DataCriacao { get; set; }
    }

    
}


