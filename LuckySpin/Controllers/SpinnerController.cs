using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LuckySpin.Models;
using LuckySpin.ViewModels;

namespace LuckySpin.Controllers
{
    public class SpinnerController : Controller
    {
        Random random;
        Repository _repository;

        /***
         * Controller Constructor
         */
        public SpinnerController(Repository repository) //injecting singleton service from startup thru parameter
        {
            random = new Random();
            //TODO: Inject the Repository singleton
            _repository = repository; 
        }

        /***
         * Entry Page Action
         **/
        [HttpGet]
        public IActionResult Index()
        {
                return View();
        }

        [HttpPost]
        public IActionResult Index(Player player)
        {
            if (!ModelState.IsValid) { return View(); }

            // TODO: Add the Player to the Repository
            _repository.currentPlayer = player;

            // TODO: Build a new SpinItViewModel object with data from the Player and pass it to the View
            SpinViewModel spinvm = new SpinViewModel()
            {
                FirstName = player.FirstName,
                Balance = player.Balance
            };

            return RedirectToAction("SpinIt", player); //player
        }

        /***
         * Spin Action - Game Play
         **/  
         public IActionResult SpinIt(SpinViewModel spinvm) //TODO: replace the parameter with a ViewModel
        {

            //spinvm.Luck;
            spinvm.A = random.Next(1, 10);
            spinvm.B = random.Next(1, 10);
            spinvm.C = random.Next(1, 10);

            spinvm.IsWinning = (spinvm.A == spinvm.Luck || spinvm.B == spinvm.Luck || spinvm.C == spinvm.Luck);

            //Add to Spin Repository
            //_repository.AddSpin(spin);

            //TODO: Clean up ViewBag using a SpinIt ViewModel instead
            if (spinvm.IsWinning)
                ViewBag.Display = "block";
            else
                ViewBag.Display = "none";


            return View("SpinIt", spinvm);
        }

        /***
         * LuckList Action - End of Game
         **/
         public IActionResult LuckList()
        {
                return View();
        }
    }
}

