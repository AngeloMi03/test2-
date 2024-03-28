
using Application;
using AutoMapper;
using Domain;
using Moq;
using Persistence.IRepository;

namespace TestListProduct;


public class TestListProduct
{
    private readonly Mock<IProductRepository> _productRepositoryMock;
    private readonly Mock<IMapper> _mapperMock;

    public TestListProduct()
    {
        _productRepositoryMock = new();
        _mapperMock = new();

        _mapperMock.Setup(m => m.Map<List<ListProductDto>>(It.IsAny<List<Product>>()))
             .Returns((List<Product> source) => source.Select(p => new ListProductDto { Name = p.Name, Matricule = p.Matricule }).ToList());

        _productRepositoryMock.Setup(repo => repo.getAllProduct()).ReturnsAsync(GetTestProducts());
    }

    private List<Product> GetTestProducts()
    {
        return new List<Product>
        {
            new Product() { Name = "P1", Matricule="1234", Slug = Guid.Parse("466e4744-4dc5-4987-aae0-b621acfc5e39"), Date_Create = DateTime.Now, Date_Edit = DateTime.Now},
            new Product() { Name = "P2", Matricule="1234", Slug = Guid.Parse("466e4744-4dc5-4987-aae0-b621acfc5e39"), Date_Create = DateTime.Now,  Date_Edit = DateTime.Now},
            new Product() { Name = "P3", Matricule="1234", Slug = Guid.Parse("466e4744-4dc5-4987-aae0-b621acfc5e39"), Date_Create = DateTime.Now, Date_Edit = DateTime.Now},

        };
    }

    [Fact]
    public async Task Handle_ReturnsListOfProductDto()
    {
        var command = new Application.List.Query();

        var handler = new Application.List.Handler(_productRepositoryMock.Object, _mapperMock.Object);

        var result = await handler.Handle(command, default);

        Assert.Equal(3, result.Count());

        Assert.IsType<List<ListProductDto>>(result);

        Assert.All(result, item =>
        {
            Assert.NotNull(item.Name);
            Assert.NotNull(item.Matricule);
            Assert.NotNull(item.Matricule);
        });

    }


}

