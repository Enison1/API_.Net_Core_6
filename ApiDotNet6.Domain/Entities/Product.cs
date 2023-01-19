using ApiDotNet6.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDotNet6.Domain.Entities
{
    public sealed class Product
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string CodErp { get; private set; }
        public decimal Price { get; private set; }
        public ICollection<Purchase> Purchases { get; private set; }


        public Product(string name, string codErp, decimal price)
        {
            Validation(name, CodErp, price);
        }
        public Product(int id, string name, string codErp, decimal price)
        {
            DomainValidationException.when(id < 0, "Id do produo deve ser informado");
            Id = id;
            Validation(name, CodErp, price);
        }
        private void Validation(string name, string codErp, decimal price)
        {
            DomainValidationException.when(string.IsNullOrEmpty(name), "O nome do produo deve ser informado!");
            DomainValidationException.when(string.IsNullOrEmpty(codErp), "Codigo erp deve ser informado!");
            DomainValidationException.when(price < 0, "O preço do produo deve ser informado!");
            Name = name;
            CodErp = codErp;
            Price = price;
        }

    }
}
