using CleanBase.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanBase.Application.ProductsCQRS.Querys
{
    public class GetProductsQuery : IRequest<IEnumerable<Product>>
    {
    }
}
