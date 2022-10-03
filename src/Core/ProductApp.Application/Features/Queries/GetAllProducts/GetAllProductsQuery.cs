using MediatR;
using ProductApp.Application.Dto;
using ProductApp.Application.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Application.Features.Queries.GetAllProducts
{
    public class GetAllProductsQuery: IRequest<List<ProductViewDto>>
    {
        public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<ProductViewDto>>
        {
            private readonly IProductRespository productRespository;

            public GetAllProductsQueryHandler(IProductRespository productRespository)
            {
                this.productRespository = productRespository;
            }
            public async Task<List<ProductViewDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
            {
                var products = await productRespository.GetAllAsync();

                return products.Select(i => new ProductViewDto
                {
                    Id = i.Id,
                    Name = i.Name,
                }).ToList();
            }
        }
    }
}
