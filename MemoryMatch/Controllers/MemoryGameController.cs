using MemoryGame.Data;
using MemoryMatch.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace MemoryMatch.Controllers
{
    public class MemoryGameController : Controller
    {
        private readonly MemoryGameContext _context;

        public MemoryGameController(MemoryGameContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var theme = HttpContext.Session.GetString("Theme");
            
            var cards = _context.Cards.ToList();


            if (!cards.Any() && theme != null)
            {
                InitializeCards(theme);
                cards = _context.Cards.ToList();
            }

            ViewBag.Theme = theme;

            Shuffle(cards);
            return View(cards);
        }

        private void Shuffle(List<Card> cards)
        {
            Random rng = new Random();
            int n = cards.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Card value = cards[k];
                cards[k] = cards[n];
                cards[n] = value;
            }
        }

        private void InitializeCards(string theme)
        {
            var cards = new List<Card>();

            for (int i = 1; i < 16; i++)
            {
                cards.Add(new Card { ImageUrl = $"/{theme}/card{i}.png" });
            }

            for (int i = 1; i < 16; i++)
            {
                cards.Add(new Card { ImageUrl = $"/{theme}/card{i}.png" });
            }

            _context.Cards.AddRange(cards);
            _context.SaveChanges();
        }
    }
}