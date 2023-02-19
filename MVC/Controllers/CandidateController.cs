using Application.Contracts.Persistence;
using Application.Features.Candidates.Commands.CreateCandidate;
using Application.Features.Candidates.Commands.DeleteCandidate;
using Application.Features.Candidates.Commands.UpdateCandidate;
using Application.Features.Candidates.Queries;
using Application.Features.CandidateExperiences;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Application.Features.CandidateExperiences.Commands.Create;
using Application.Features.CandidateExperiences.Queries;
using Application.Features.Candidates.Commands.DeleteCandidateExperience;
using Application.Features.CandidateExperiences.Commands.Update;
using Microsoft.AspNetCore.Mvc.ModelBinding;

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

        public async Task<IActionResult> Search(string? surname, string? email)
        {
            if (surname != null && email == null)
            {
                var query = new GetCandidatesBySurname(surname);
                return View(await _mediator.Send(query));
            }
            else if (surname == null && email != null)
            {
                var query = new GetCandidatesByEmail(email);
                return View(await _mediator.Send(query));
            }
            else if (surname != null && email != null)
            {
                var query = new GetCandidatesBySurnameAndEmail(surname, email);
                return View(await _mediator.Send(query));
            }
            else
            {
                var query = new GetCandidates();
                return View(await _mediator.Send(query));
            }
        }

        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            var query = new GetCandidateById(id);
            return View(await _mediator.Send(query));
        }



        [HttpPost]
        public async Task<IActionResult> Create(CandidatesVm candidateViewModel)
        {
            if (ModelState.IsValid == true)
            {
                var command = new CreateCandidateCommand(candidateViewModel);
                await _mediator.Send(command);
                return RedirectToAction(nameof(Index));
            }
            return View(candidateViewModel);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(CandidatesVm candidateViewModel)
        {
            if (ModelState.IsValid == true)
            {
                var command = new UpdateCandidateCommand(candidateViewModel);
                await _mediator.Send(command);
                return RedirectToAction(nameof(Index));
            }
            return View(candidateViewModel);
        }


        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteCandidateCommand(id);
            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DeleteExperience(int id)
        {
            var command = new GetExperienceById(id);
            CandidateExperiencesVm exp = await _mediator.Send(command);
            var commandDelete = new DeleteCandidateExperienceCommand(id);
            await _mediator.Send(commandDelete);
            return RedirectToAction(nameof(Edit), "Candidate", new { id = exp.IdCandidate });
        }

        public IActionResult CreateExperience(int id)
        {
            CandidateExperiencesVm experienceViewModel = new CandidateExperiencesVm();
            experienceViewModel.IdCandidate = id;
            return View(experienceViewModel);
        }

        public async Task<IActionResult> EditExperience(int id)
        {
            var command = new GetExperienceById(id);
            return View(await _mediator.Send(command));
        }

        [HttpPost]
        public async Task<IActionResult> CreateExperience(CandidateExperiencesVm experienceViewModel)
        {
            if (ModelState.IsValid == true)
            {
                var command = new CreateCandidateExperienceCommand(experienceViewModel);
                await _mediator.Send(command);
                return RedirectToAction(nameof(Edit), "Candidate", new { id = experienceViewModel.IdCandidate });
            }
            return View(experienceViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditExperience(CandidateExperiencesVm experienceViewModel)
        {
            if (ModelState.IsValid == true)
            {
                var command = new UpdateCandidateExperienceCommand(experienceViewModel);
                await _mediator.Send(command);
                return RedirectToAction(nameof(Edit), "Candidate", new { id = experienceViewModel.IdCandidate });
            }
            return View(experienceViewModel);
        }

    }
}
