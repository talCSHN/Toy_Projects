using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyPortfolioWebApp.Models;

namespace MyPortfolioWebApp.Controllers
{
    public class BoardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BoardController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: Board
        public async Task<IActionResult> Index()
        {
            // DB 게시글 가져오기
            var dbBoards = await _context.Board.ToListAsync();

            // 벨로그 RSS 불러오기
            string velogUserId = "wwh11111";
            string rssUrl = $"https://v2.velog.io/rss/{velogUserId}";

            List<Board> velogBoards = new List<Board>();

            try
            {
                using var httpClient = new HttpClient();
                var rssContent = await httpClient.GetStringAsync(rssUrl);
                var doc = XDocument.Parse(rssContent);

                var items = doc.Descendants("item");

                foreach (var item in items)
                {
                    var board = new Board
                    {
                        Id = 0,
                        VelogUrl = item.Element("link")?.Value,
                        Title = item.Element("title")?.Value,
                        Contents = item.Element("description")?.Value,
                        PostDate = DateTime.TryParse(item.Element("pubDate")?.Value, out var dt) ? dt : (DateTime?)null,
                        Writer = "박관호",
                        Email = "yujakinasakoon@gmail.com",
                        ReadCount = 0
                    };

                    velogBoards.Add(board);
                }
            }
            catch
            {
            }

            // DB 글 + 벨로그 글 합치기
            var combined = dbBoards.Concat(velogBoards)
                .OrderByDescending(b => b.PostDate)
                .ToList();

            Console.WriteLine(combined.Count + "+++++++++");
            return View(combined);
        }

        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Board.ToListAsync());
        //}

        // GET: Board/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var board = await _context.Board
                .FirstOrDefaultAsync(m => m.Id == id);
            if (board == null)
            {
                return NotFound();
            }

            return View(board);
        }

        // GET: Board/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Board/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Email,Writer,Title,Contents,PostDate,ReadCount")] Board board)
        {
            if (ModelState.IsValid)
            {
                _context.Add(board);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(board);
        }

        // GET: Board/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var board = await _context.Board.FindAsync(id);
            if (board == null)
            {
                return NotFound();
            }
            return View(board);
        }

        // POST: Board/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Email,Writer,Title,Contents,PostDate,ReadCount")] Board board)
        {
            if (id != board.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(board);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BoardExists(board.Id))
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
            return View(board);
        }

        // GET: Board/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var board = await _context.Board
                .FirstOrDefaultAsync(m => m.Id == id);
            if (board == null)
            {
                return NotFound();
            }

            return View(board);
        }

        // POST: Board/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var board = await _context.Board.FindAsync(id);
            if (board != null)
            {
                _context.Board.Remove(board);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BoardExists(int id)
        {
            return _context.Board.Any(e => e.Id == id);
        }
    }
}
