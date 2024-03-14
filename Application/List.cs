using AutoMapper;
using Domain;
using MediatR;
using Persistence.IRepository;

namespace Application;

public record List
{
    
    public  record Query : IRequest<List<ListProductDto>>
    {

    }

    internal sealed class Handler : IRequestHandler<Query, List<ListProductDto>>
    {private readonly IProductRepository _productRepository;
         private readonly IMapper _mapper;
        public Handler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<List<ListProductDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            List<Product> products = await _productRepository.getAllProduct();

            return _mapper.Map<List<ListProductDto>>(products);
        }
    }
}


