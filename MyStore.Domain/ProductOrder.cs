using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Domain
{
    public class ProductOrder
    {
        public Guid ProductId { get; private set; }
        public Product Product { get; private set; } = null!;

        public Guid OrderId { get; private set; }
        public Order Order { get; private set; } = null!;

    }
}
