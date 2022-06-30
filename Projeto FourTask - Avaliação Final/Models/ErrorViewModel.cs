using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_FourTask___Avaliação_Final.Models
{
    [NotMapped]
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}