using CrudTestMVC.Data;
using CrudTestMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;


namespace CrudTestMVC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var users = _context.users.ToList();
            return View(users);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken] 
        public IActionResult Create(Users user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.users.Add(user);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    
                }
            }
            return View(user);
        }
        public IActionResult Edit(int id)
        {
            var user = _context.users.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Users user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
               
                    return View(user);
                }
            }
            return View(user);
        }
        public IActionResult Delete(int id)
        {
            var user = _context.users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            try
            {
                _context.users.Remove(user);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
               
                return RedirectToAction(nameof(Index));
            }
        }





    }
}
