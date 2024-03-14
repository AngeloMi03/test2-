using API.Controllers;
using Application;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API;

public class ProductController : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<List<ListProductDto>>> GetProducts()
    {
        return await Mediator.Send(new List.Query());
    }

    [HttpGet("{slug}")]
    public async Task<ActionResult<ProductDetailsDto>> GetProduct(Guid slug)
    {
        return await Mediator.Send(new Details.Query() {slug = slug});
    }
}
