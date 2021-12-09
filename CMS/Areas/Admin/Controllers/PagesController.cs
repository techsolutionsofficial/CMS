﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS.Data;
using CMS.Models;
using Microsoft.EntityFrameworkCore;

namespace CMS.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PagesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PagesController(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            IQueryable<Page> pages = from p in _context.Pages orderby p.Sorting select p;

            List<Page> pagesList = await pages.ToListAsync();

            return View(pagesList);
        }


        public async Task<IActionResult> Details(int id)
        {
            Page page = await _context.Pages.FirstOrDefaultAsync(x => x.Id == id);
            if (page == null)
            {
                return NotFound();
            }

            return View(page);
        }


        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(Page page)
        {
            if (ModelState.IsValid)
            {
                page.Slug = page.Title.ToLower().Replace(" ", "-");
                page.Sorting = 100;

                var slug = await _context.Pages.FirstOrDefaultAsync(x => x.Slug == page.Slug);
                if (slug != null)
                {
                    ModelState.AddModelError("", "The page already exists.");
                    return View(page);
                }

                await _context.AddAsync(page);
                await _context.SaveChangesAsync();

                TempData["Success"] = "The page has been added!";

                return RedirectToAction("Index");
            }

            return View(page);
        }


    }
}
