using DomainValidationCore.Validation;

namespace Conexa.Domain.Entities
{
    public class EntidadeBase
    {
        public EntidadeBase()
        {
            Validacao = new ValidationResult();
        }

        public ValidationResult Validacao { get; set; }
    }
}
