using Microsoft.AspNetCore.Mvc;
using CardGameScoreCalculator.Models;

public class CardGameController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult CalculateScore(string cardInput)
    {
        try
        {
            var game = new CardGame(cardInput);
            var score = game.CalculateScore();
            ViewBag.Score = score;
        }
        catch (ArgumentException ex)
        {
            ViewBag.ErrorMessage = ex.Message;
        }

        return View("Index");
    }
}
