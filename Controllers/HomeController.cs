using Microsoft.AspNetCore.Mvc;
using MacApp.Models;

namespace MacApp.Controllers
{
    public class HomeController : Controller
    {
        // Menggunakan static list supaya data tidak hilang apabila halaman di-refresh
        private static readonly List<Item> _inventory = new()
        {
            new Item { Id = 1, Name = "MacBook Air M2", Category = "Laptop", Quantity = 12, Price = 4599.00m },
            new Item { Id = 2, Name = "iPhone 15 Pro", Category = "Telefon", Quantity = 5, Price = 5299.00m },
            new Item { Id = 3, Name = "iPad Pro M4", Category = "Tablet", Quantity = 0, Price = 4499.00m },
            new Item { Id = 4, Name = "Sony WH-1000XM5", Category = "Audio", Quantity = 25, Price = 1349.00m }
        };

        public IActionResult Index()
        {
            return View(_inventory);
        }

        [HttpPost]
        public IActionResult AddItem(Item newItem)
        {
            if (ModelState.IsValid)
            {
                newItem.Id = _inventory.Count + 1;
                _inventory.Add(newItem);
                return RedirectToAction(nameof(Index));
            }
            return View("Index", _inventory);
        }

        [HttpPost]
        public IActionResult ToggleStock(int id)
        {
            var item = _inventory.FirstOrDefault(i => i.Id == id);
            if (item != null)
            {
                // Simulasi ubah kuantiti: Jika asal 0 jadi 10, jika ada isi jadi 0
                item.Quantity = item.Quantity == 0 ? 10 : 0;
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
