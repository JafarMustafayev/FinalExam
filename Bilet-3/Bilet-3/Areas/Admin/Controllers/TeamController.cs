using Bilet_3.Helper;
using Bilet_3.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bilet_3.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class TeamController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IWebHostEnvironment _evn;

        public TeamController(DataContext dataContext , IWebHostEnvironment evn)
        {
            this._dataContext = dataContext;
            this._evn = evn;
        }

        public IActionResult Index()
        {
            ViewBag.Position = _dataContext.Positions.ToList();

            return View(_dataContext.Teams.ToList());
        }

        public IActionResult Create()
        {
            ViewBag.Position = _dataContext.Positions.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Team team)
        {
            ViewBag.Position = _dataContext.Positions.ToList();
            if (team is null) return NotFound();
            if (!ModelState.IsValid) return View();

            if (team.ImageFile is not null)
            {
                if (FileManager.IsImage(team.ImageFile))
                {
                    if (FileManager.CheckImageFile(team.ImageFile))
                    {
                        team.Image = FileManager.CheckAndReturnName(team.ImageFile);
                        string path = Path.Combine(_evn.WebRootPath, "upload/teams", team.Image);
                        FileManager.SaveFile(team.ImageFile, path);
                        _dataContext.Teams.Add(team);
                        _dataContext.SaveChanges();
                        return RedirectToAction("Index");

                    }
                    else ModelState.AddModelError("ImageFile", "Olcusu 3MB dan az olan sekilleri qebul edir");
                }
                else ModelState.AddModelError("ImageFile", "Bura yalniz sekil atmaq olar ");
            }
            else
            {
                ModelState.AddModelError("ImageFile", "Mutleq sekil qeyd olunmalidir");
            }
            return View();

        }

        public IActionResult Update(int id)
        {
            Team oldTeam = _dataContext.Teams.FirstOrDefault(x => x.Id == id);
            if (oldTeam is null) return NotFound();
            ViewBag.Position = _dataContext.Positions.ToList();
            return View(oldTeam);
        }

        public IActionResult Update(Team team)
        {
            ViewBag.Position = _dataContext.Positions.ToList();
            Team oldTeam = _dataContext.Teams.FirstOrDefault(x => x.Id == team.Id);
            if (oldTeam is null || team is null) return NotFound();

            if (!ModelState.IsValid) return View();

            if(team.ImageFile is not null)
            {
                if (FileManager.IsImage(team.ImageFile))
                {
                    if (FileManager.CheckImageFile(team.ImageFile))
                    {
                        team.Image = FileManager.CheckAndReturnName(team.ImageFile);
                        string path = Path.Combine(_evn.WebRootPath, "upload/teams");
                        FileManager.SaveFile(team.ImageFile,Path.Combine(path,team.Image));
                        FileManager.DeleteFile(Path.Combine(path,oldTeam.Image));
                        oldTeam.Image = team.Image;

                    }
                    else ModelState.AddModelError("ImageFile", "Olcusu 3MB dan az olan sekilleri qebul edir");
                }
                else ModelState.AddModelError("ImageFile", "Bura yalniz sekil atmaq olar ");
            }

            oldTeam.FUllName = team.FUllName;
            oldTeam.Instagram = team.Instagram;
            oldTeam.Twitter = team.Twitter;
            oldTeam.Linkedin = team.Linkedin;
            oldTeam.Facebook = team.Facebook;
            oldTeam.Position = team.Position;
            _dataContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public  IActionResult Delete(int id)
        {
            Team oldTeam = _dataContext.Teams.FirstOrDefault(x => x.Id == id);
            if (oldTeam is null ) return NotFound();
            string path = Path.Combine(_evn.WebRootPath, "upload/teams", oldTeam.Image);
            FileManager.DeleteFile(path);
            _dataContext.Teams.Remove(oldTeam);
            _dataContext.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}
