using Bilet_3.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bilet_3.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class PositionController : Controller
    {
        private readonly DataContext _dataContext;

        public PositionController(DataContext dataContext)
        {
            this._dataContext = dataContext;
        }

        public IActionResult Index()
        {
            List<Position> positions = _dataContext.Positions.ToList();

            return View(positions);
        }


        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Position position)
        {
            if (!ModelState.IsValid) { return View(position); }
            _dataContext.Add(position);
            _dataContext.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult Update(int id)
        {
            Position position = _dataContext.Positions.FirstOrDefault(x => x.Id == id);
            if (position == null) { return NotFound(); }
            
           return View (position);
        }
        [HttpPost]
        public IActionResult Update(Position position)
        {
            if (position is null) return NotFound();
            
            Position oldPosition = _dataContext.Positions.FirstOrDefault(x=>x.Id == position.Id);
            if (oldPosition == null)return NotFound();

            if(!ModelState.IsValid) return View(position);

            oldPosition.Name= position.Name;
            _dataContext.SaveChanges();
            return RedirectToAction("Index");

        }

        public IActionResult Delete(int id)
        {
            Position oldPosition = _dataContext.Positions.FirstOrDefault(x => x.Id == id);
            if (oldPosition == null) return NotFound();

            _dataContext.Positions.Remove(oldPosition);
            _dataContext.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
