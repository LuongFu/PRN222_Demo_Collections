using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyStockApp.Models;

namespace MyStockApp.Controllers
{
    public class ProductController : Controller
    {
            private readonly MyStockContext context;
            public ProductController(MyStockContext context) => this.context = context;
            public ActionResult Index()
            {
                var model = context.Products.ToList();
                return View(model);
            }

            public ActionResult Details(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }
                var product = context.Products.FirstOrDefault(m => m.ProductId == id);
                if (product == null)
                {
                    return NotFound();
                }
                return View(product);
            }

            public ActionResult Create()
            {
                return View();
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Create(Product product)
            {
                if (ModelState.IsValid)
                {
                    context.Add(product);
                    context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                return View(product);
            }

            public ActionResult Edit(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var product = context.Products.Find(id);
                if (product == null)
                {
                    return NotFound();
                }

                return View(product);
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Edit(int? id, Product product)
            {
                if (id != product.ProductId)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    context.Update(product);
                    context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }

                return View(product);
            }
            public ActionResult Delete(int? id)
            {
                var product = context.Products.Find(id);
                context.Products.Remove(product);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
    }
}