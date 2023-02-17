using Application.Contracts.Persistence;
using Application.Features.Candidates.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class CandidateController : Controller
    {
        private readonly IMediator _mediator;
        public CandidateController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IActionResult> Index()
        {
            var query = new GetCandidates();
            return View(await _mediator.Send(query));
        }
    }
}
