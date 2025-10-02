using Microsoft.AspNetCore.Mvc;
using dotnet_mvc_expense_tracker.Models;
using System.Collections.Generic;
using System.Linq;

namespace dotnet_mvc_expense_tracker.Controllers
{
    public class BudgetController : Controller
    {
        // Dummy data kategori
        private static List<Kategori> _kategoriList = new List<Kategori>
        {
            new Kategori { Id = 1, Tipe = "Income", Nama = "Gaji", Deskripsi = "Pendapatan bulanan", Status = "Active" },
            new Kategori { Id = 2, Tipe = "Expense", Nama = "Makan", Deskripsi = "Biaya makan harian", Status = "Active" }
        };

        // Dummy data budget
        private static List<Budget> _budgetList = new List<Budget>
        {
            new Budget { Id = 1, KategoriId = 1, Nama = "Budget Januari", Deskripsi = "Budget bulanan", TotalBudget = 5000000, StartDate = new System.DateTime(2025,1,1), EndDate = new System.DateTime(2025,1,31), IsRepeat = false, Status = "Active" },
            new Budget { Id = 2, KategoriId = 2, Nama = "Budget Makan", Deskripsi = "Budget makan harian", TotalBudget = 2000000, StartDate = new System.DateTime(2025,1,1), EndDate = new System.DateTime(2025,1,31), IsRepeat = true, Status = "Active" }
        };

        // GET: /Budget
        public IActionResult Index()
        {
            var data = _budgetList.Select(b => new Budget
            {
                Id = b.Id,
                KategoriId = b.KategoriId,
                Kategori = _kategoriList.FirstOrDefault(k => k.Id == b.KategoriId),
                Nama = b.Nama,
                Deskripsi = b.Deskripsi,
                TotalBudget = b.TotalBudget,
                StartDate = b.StartDate,
                EndDate = b.EndDate,
                IsRepeat = b.IsRepeat,
                Status = b.Status
            }).ToList();

            return View(data);
        }

        // GET: /Budget/Details/1
        public IActionResult Details(int id)
        {
            var budget = _budgetList.FirstOrDefault(x => x.Id == id);
            if (budget == null) return NotFound();
            budget.Kategori = _kategoriList.FirstOrDefault(k => k.Id == budget.KategoriId);
            return View(budget);
        }

        // GET: /Budget/Create
        public IActionResult Create()
        {
            ViewBag.KategoriList = _kategoriList;
            return View();
        }

        // POST: /Budget/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Budget model)
        {
            if (ModelState.IsValid)
            {
                model.Id = _budgetList.Max(x => x.Id) + 1;
                _budgetList.Add(model);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.KategoriList = _kategoriList;
            return View(model);
        }

        // GET: /Budget/Edit/1
        public IActionResult Edit(int id)
        {
            var budget = _budgetList.FirstOrDefault(x => x.Id == id);
            if (budget == null) return NotFound();

            ViewBag.KategoriList = _kategoriList;
            return View(budget);
        }

        // POST: /Budget/Edit/1
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Budget model)
        {
            var budget = _budgetList.FirstOrDefault(x => x.Id == id);
            if (budget == null) return NotFound();

            budget.KategoriId = model.KategoriId;
            budget.Nama = model.Nama;
            budget.Deskripsi = model.Deskripsi;
            budget.TotalBudget = model.TotalBudget;
            budget.StartDate = model.StartDate;
            budget.EndDate = model.EndDate;
            budget.IsRepeat = model.IsRepeat;
            budget.Status = model.Status;

            return RedirectToAction(nameof(Index));
        }

        // GET: /Budget/Delete/1
        public IActionResult Delete(int id)
        {
            var budget = _budgetList.FirstOrDefault(x => x.Id == id);
            if (budget == null) return NotFound();

            budget.Kategori = _kategoriList.FirstOrDefault(k => k.Id == budget.KategoriId);
            return View(budget);
        }

        // POST: /Budget/Delete/1
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var budget = _budgetList.FirstOrDefault(x => x.Id == id);
            if (budget != null)
                _budgetList.Remove(budget);

            return RedirectToAction(nameof(Index));
        }
    }
}
