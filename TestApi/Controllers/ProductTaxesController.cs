using Generics.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestApi.Services.Contracts;

namespace TestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductTaxesController : ControllerBase
    {
        private readonly IProductService _IProductService;

        public ProductTaxesController(IProductService IProductService)
        {
            _IProductService = IProductService;
        }

        [HttpGet]
        public  ActionResult<ProductPostListModel> GetProductsTsxes(List<ProductPreListModel> model)
        {
            return _IProductService.CalculateTaxes(model);
        }

    }
}
