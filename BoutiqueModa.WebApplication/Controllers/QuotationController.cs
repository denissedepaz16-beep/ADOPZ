using ADOPZ.BusinessLogic.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ADOPZ.WebApplication.Controllers
{
    public class QuotationController : Controller
    {
        private readonly IMediator _mediator;

        public QuotationController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: QuotationController
        public async Task<IActionResult> Index()
        {
            var quotations = await _mediator.Send(new GetQuotationQuery(3));
            return View(quotations);
        }


        public async Task<IActionResult> Create()
        {
            var products = await _mediator.Send(new GetProductsQuery());
            ViewData["ProductId"] = new SelectList(products, "ProductId", "ProductName");
            return View();
        }

        // POST: BrandController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateQuotationRequest createProductRequest)
        {
            try
            {
                var result = await _mediator.Send(new CreateQuotationCommand(createProductRequest));
                if (result > 0)
                    return RedirectToAction(nameof(Index));
                else
                    throw new Exception("Sucedio un error al intentar guardar el nuevo producto");
            }
            catch (Exception ex)
            {
                var products = await _mediator.Send(new GetProductsQuery());
                ViewData["ProductId"] = new SelectList(products, "ProductId", "ProductName");
                ModelState.AddModelError("", ex.Message);
                return View(createProductRequest);
            }
        }

    }
}
