using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BangazonSite.Data;
using BangazonSite.Models;
using Microsoft.AspNetCore.Identity;

namespace BangazonSite.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly UserManager<ApplicationUser> _userManager;

        public ProductsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // Private method to get current user
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);


        // GET: Products
        public async Task<IActionResult> Index(string searchString, string searchBy)
        {
            ViewData["searchBy"] = searchBy;
            ViewData["CurrentFilter"] = searchString;

            var user = await GetCurrentUserAsync();

            var applicationDbContext = _context.Product.Where(p => p.isArchived == true).Include(p => p.ProductType).Include(p => p.User).Where(s => s.User == user);

            //If user enters a string into the search input field in the navbar - adding a where clause to include products whose name contains string.
            if (!String.IsNullOrEmpty(searchString))
            {
                switch (searchBy)
                {
                    case "1":
                        applicationDbContext = _context.Product.Where(p => p.City.Contains(searchString)).Include(p => p.ProductType).Include(p => p.User);
                        break;
                    case "2":
                        applicationDbContext = _context.Product.Where(p => p.Title.Contains(searchString)).Include(p => p.ProductType).Include(p => p.User);
                        break;
                    default:
                        applicationDbContext = _context.Product.Where(p => p.Title.Contains(searchString) || p.City.Contains(searchString)).Include(p => p.ProductType).Include(p => p.User);
                        break;
                }
            }
            //This switch case statement uses the searchBy parameter which is in _Layout.cs and tells us what we want to be searching through.

            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .Include(p => p.ProductType)
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

		// GET: Products/Category

		public async Task<IActionResult> Category(int? id)
		{
			var applicationDbContext = await _context.Product.Include(p => p.ProductType).Include(p =>p.User).ToListAsync();
			var SortedProducts = applicationDbContext.Where(p => p.ProductTypeId == id);
			return View(SortedProducts);
		}

		// GET: Products/Create
		public IActionResult Create()
        {
            ViewData["ProductTypeId"] = new SelectList(_context.ProductType, "ProductTypeId", "Name");
            //ViewData["UserId"] = new SelectList(_context.Users, "Id", "FirstName");
            Product product = new Product();
            return View(product);
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DateCreated,Description,Title,Price,Quantity,UserId,City,ProductImage,LocalDelivery,ProductTypeId,isArchived")] Product product)
        {
            ModelState.Remove("User");
            ModelState.Remove("UserId");

            var user = await GetCurrentUserAsync();

            if (ModelState.IsValid)
            {
                //If the user has not entered a city but local delivery is checked, return back to the view with an error
                if (product.LocalDelivery == true && product.City == null)
                {
                    product.Error = new string("You have selected Local Delivery, please enter a City");
                    return View(product);

                }
                else
                {
                    product.UserId = user.Id;
                    _context.Add(product);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Details", new { id = product.Id });
                }
            }
            ViewData["ProductTypeId"] = new SelectList(_context.ProductType, "ProductTypeId", "Name", product.ProductTypeId);
            //ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", product.User);
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["ProductTypeId"] = new SelectList(_context.ProductType, "ProductTypeId", "ProductTypeId", product.ProductTypeId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", product.UserId);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DateCreated,Description,Title,Price,Quantity,UserId,City,ProductImage,LocalDelivery,ProductTypeId,isArchived")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductTypeId"] = new SelectList(_context.ProductType, "ProductTypeId", "ProductTypeId", product.ProductTypeId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", product.UserId);
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .Include(p => p.ProductType)
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Product.FindAsync(id);
            _context.Product.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.Id == id);
        }
    }
}
