using Application;
using AutoMapper;
using Domain;
using Moq;
using Persistence.IRepository;

namespace TestListProduct;

public class TestGetDetailsProduct
{

    private readonly Mock<IProductRepository> _productRepositoryMock;
    private readonly Mock<IMapper> _mapperMock;
    public TestGetDetailsProduct()
    {

        var expectedProduct = new Product
        {
            Name = "product3",
            Matricule = "1234",
            Slug = Guid.Parse("466e4744-4dc5-4987-aae0-b621acfc5e39"),
            Date_Create = DateTime.Now,
            Date_Edit = DateTime.Now
        };


        _productRepositoryMock = new();
        _mapperMock = new();

        _mapperMock.Setup(mapper => mapper.Map<ProductDetailsDto>(expectedProduct))
          .Returns(new ProductDetailsDto()
          {
              Name = "product3",
              Matricule = "1234",
              Slug = Guid.Parse("466e4744-4dc5-4987-aae0-b621acfc5e39"),
              Date_Create = DateTime.Now,
              Date_Edit = DateTime.Now
          });

        _productRepositoryMock.Setup(repo => repo.getProduct(Guid.Parse("466e4744-4dc5-4987-aae0-b621acfc5e39"))).ReturnsAsync(expectedProduct);

    }


    [Fact]
    public async Task Handle_ReturnsProductDetailsDto()
    {
        var command = new Application.Details.Query() { slug = Guid.Parse("466e4744-4dc5-4987-aae0-b621acfc5e39") };

        var handler = new Application.Details.Handler(_productRepositoryMock.Object, _mapperMock.Object);

        var result = await handler.Handle(command, default);

        Assert.NotNull(result);

        Assert.IsType<ProductDetailsDto>(result);

        Assert.Equal("product3", result.Name);

    }
}
