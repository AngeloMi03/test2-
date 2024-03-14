using AutoMapper;
using MediatR;
using Persistence.IRepository;

namespace Application;

public record Details
{
    public  record Query : IRequest<ProductDetailsDto>
    {
          public Guid slug {get;set;}
    }

    internal sealed class Handler : IRequestHandler<Query, ProductDetailsDto>
    {
        private readonly IProductRepository _productRepository;
         private readonly IMapper _mapper;
        public Handler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ProductDetailsDto> Handle(Query request, CancellationToken cancellationToken)
        {
           var product =  await _productRepository.getProduct(request.slug);

           return _mapper.Map<ProductDetailsDto>(product);
        }
    }
}
