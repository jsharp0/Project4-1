using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project4_1.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Project4_1.Controllers
{
    public class ContactController : Controller
    {
        private ContactDbContext context { get; set; }

        public ContactController(ContactDbContext ctx)
        {
            context = ctx;
        }

        public IActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.action = "Edit";
            ViewBag.Categories = context.Categories.OrderBy(c => c.name).ToList();
            var contact = context.Contacts.Find(id);
            return View(contact);
        }

        public IActionResult Add()
        {
            ViewBag.action = "Add";
            ViewBag.Categories = context.Categories.OrderBy(c => c.name).ToList();
            return View("Edit", new Contact());
        }

        public IActionResult Delete(int id)
        {
            var contact = context.Contacts.Find(id);
            return View(contact);
        }


        public IActionResult Details(int id)
        {
            var contact = context.Contacts.Find(id);
            return View(contact);
        }

        [HttpPost]
        public IActionResult Edit(Contact contact)
        {
            if (ModelState.IsValid)
            {
                if (contact.ID == 0)
                {
                    context.Contacts.Add(contact);
                }
                else
                {
                    context.Contacts.Update(contact);
                }
                context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            ViewBag.action = (contact.ID == 0) ? "Add" : "Edit";
            ViewBag.Categories = context.Categories.OrderBy(c => c.name).ToList();
            return View(contact);
        }

        [HttpPost]
        public IActionResult Delete(Contact contactId)
        {
            //var contact = context.Contacts.Find(id);
            var contact = context.Contacts.Find(contactId.ID);

            context.Contacts.Remove(contact);
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

    }
}
