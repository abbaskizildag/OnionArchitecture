using AutoMapper;
using MediatR;
using ProductApp.Application.Dto;
using ProductApp.Application.Interfaces.Repository;
using ProductApp.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Application.Features.Queries.GetProductById
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, ServiceResponse<GetProductByIdViewModel>>
    {
        IProductRespository productRespository;
        private readonly IMapper mapper;

        public GetProductByIdHandler(IProductRespository productRespository, IMapper mapper)
        {
            this.productRespository = productRespository;
            this.mapper = mapper;
        }


        public async Task<ServiceResponse<GetProductByIdViewModel>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await productRespository.GetByIdAsync(request.Id);
            var dto = mapper.Map<GetProductByIdViewModel>(product);
            return new ServiceResponse<GetProductByIdViewModel>(dto);
        }
    }
}
