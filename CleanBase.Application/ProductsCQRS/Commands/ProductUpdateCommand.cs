using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanBase.Application.ProductsCQRS.Commands
{
    public class ProductUpdateCommand : ProductCommand
    {
        public int Id { get; set; }
    }
}
