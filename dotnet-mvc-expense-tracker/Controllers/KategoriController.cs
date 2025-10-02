using Microsoft.AspNetCore.Mvc;
using dotnet_mvc_expense_tracker.Models;
using System.Collections.Generic;
using System.Linq;

namespace dotnet_mvc_expense_tracker.Controllers
{
    public class KategoriController : Controller
    {
        // Data dummy pakai static biar gak hilang saat pindah action
        private static List<Kategori> _kategoriList = new List<Kategori>
        {
            new Kategori { Id = 1, Tipe = "Income", Nama = "Gaji", Deskripsi = "Pendapatan bulanan", Status = "Active" },
            new Kategori { Id = 2, Tipe = "Expense", Nama = "Makan", Deskripsi = "Biaya makan harian", Status = "Active" }
        };

        // GET: /Kategori
        public IActionResult Index()
        {
            return View(_kategoriList);
        }

        // GET: /Kategori/Details/1
        public IActionResult Details(int id)
        {
            var kategori = _kategoriList.FirstOrDefault(x => x.Id == id);
            if (kategori == null) return NotFound();
            return View(kategori);
        }

        // GET: /Kategori/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Kategori/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Kategori model)
        {
            if (ModelState.IsValid)
            {
                model.Id = _kategoriList.Max(x => x.Id) + 1;
                _kategoriList.Add(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: /Kategori/Edit/1
        public IActionResult Edit(int id)
        {
            var kategori = _kategoriList.FirstOrDefault(x => x.Id == id);
            if (kategori == null) return NotFound();
            return View(kategori);
        }

        // POST: /Kategori/Edit/1
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Kategori model)
        {
            var kategori = _kategoriList.FirstOrDefault(x => x.Id == id);
            if (kategori == null) return NotFound();

            kategori.Tipe = model.Tipe;
            kategori.Nama = model.Nama;
            kategori.Deskripsi = model.Deskripsi;
            kategori.Status = model.Status;

            return RedirectToAction(nameof(Index));
        }

        // GET: /Kategori/Delete/1
        public IActionResult Delete(int id)
        {
            var kategori = _kategoriList.FirstOrDefault(x => x.Id == id);
            if (kategori == null) return NotFound();
            return View(kategori);
        }

        // POST: /Kategori/Delete/1
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var kategori = _kategoriList.FirstOrDefault(x => x.Id == id);
            if (kategori != null)
                _kategoriList.Remove(kategori);

            return RedirectToAction(nameof(Index));
        }
    }
}
