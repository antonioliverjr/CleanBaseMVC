using CleanBase.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanBase.Application.ProductsCQRS.Commands
{
    public class ProductDeleteCommand : IRequest<Product>
    {
        public int Id { get; set; }
        public ProductDeleteCommand(int id)
        {
            Id = id;
        }
    }
}
