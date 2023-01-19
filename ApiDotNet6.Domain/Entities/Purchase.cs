using ApiDotNet6.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ApiDotNet6.Domain.Entities
{
    public class Purchase
    {
        public int Id { get; private set; }
        public int ProductId { get; private set; }
        public int PersonId { get; private set; }
        public DateTime Date { get; private set; }
        public Person Person { get; set; }
        public Product Product { get; set; }

        public Purchase(int productId, int personId, DateTime? date)
        {
            Validation(productId, personId, date);
        }
        public Purchase(int id, int productId, int personId, DateTime? date)
        {
            DomainValidationException.when(id < 0, "Id deve ser Informado");
            Id= id;
            Validation(productId, personId, date);
        }

        private void Validation(int productId, int personId, DateTime? date)
        {
            DomainValidationException.when(productId < 0, "O Id do produo deve ser informado!");
            DomainValidationException.when(personId < 0, "O Id da pessoa deve ser informado!");
            DomainValidationException.when(!date.HasValue, "A data da compra deve ser informado!");

            PersonId = personId;
            ProductId = productId;
            Date = date.Value;
        }
    }
}
