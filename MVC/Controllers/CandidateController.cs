using Application.Contracts.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class CandidateController : Controller
    {
        private readonly ICandidateRepository _repo;
        public CandidateController(ICandidateRepository repo)
        {
            _repo = repo;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _repo.GetAllAsync());
        }
    }
}
