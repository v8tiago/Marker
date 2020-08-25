using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Marker.App.Data;
using Marker.App.ViewModels;
using Marker.Business.Interfaces;
using AutoMapper;
using Marker.Business.Models;

namespace Marker.App.Controllers
{
    public class ReunioesController : Controller
    {
        private readonly IReuniaoRepository _reuniaoRepository;
        private readonly IMapper _mapper;
        private readonly ISalaRepository _salaRepository;

        public ReunioesController(IReuniaoRepository reuniaoRepository, IMapper mapper, ISalaRepository salaRepository)
        {
            _reuniaoRepository = reuniaoRepository;
            _mapper = mapper;
            _salaRepository = salaRepository;
        }

        // GET: Reunioes
        public async Task<IActionResult> Index ()
        {
            return View( _mapper.Map<IEnumerable<ReuniaoViewModel>>( await _reuniaoRepository.ObterTodos()));
        }

        // GET: Reunioes/Details/5
        public async Task<IActionResult> Details (Guid id)
        {
            var reuniaoViewModel = await ObterReuniao( id );

            if (reuniaoViewModel == null)
            {
                return NotFound();
            }

            return View( reuniaoViewModel );
        }

        // GET: Reunioes/Create
        public async Task<IActionResult> Create ()
        {
            var reuniaoViewMode = await PopularSalas( new ReuniaoViewModel() );
            return View(reuniaoViewMode);
        }

        // POST: Reunioes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create (ReuniaoViewModel reuniaoViewModel)
        {
            if (!ModelState.IsValid) return View( reuniaoViewModel );

            await _reuniaoRepository.Adicionar( _mapper.Map<Reuniao>( reuniaoViewModel ) );

            return View( reuniaoViewModel );
        }

        // GET: Reunioes/Edit/5
        public async Task<IActionResult> Edit (Guid id)
        {
            var reuniaoViewModel = await ObterReuniao( id );

            if (reuniaoViewModel == null)
            {
                return NotFound();
            }

            return View( reuniaoViewModel );
        }

        // POST: Reunioes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit (Guid id, ReuniaoViewModel reuniaoViewModel)
        {
            if (id != reuniaoViewModel.Id) return NotFound();

            if (ModelState.IsValid) return View( reuniaoViewModel );

            await _reuniaoRepository.Atualizar( _mapper.Map<Reuniao>( reuniaoViewModel ) );
            return RedirectToAction( "Index" );

        }

        // GET: Reunioes/Delete/5
        public async Task<IActionResult> Delete (Guid id)
        {
            var reuniao = await ObterReuniao( id );

            if (reuniao == null)
            {
                return NotFound();
            }

            return View( reuniao );
        }

        // POST: Reunioes/Delete/5
        [HttpPost, ActionName( "Delete" )]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed (Guid id)
        {
            var reuniao = await ObterReuniao( id );

            if (reuniao == null)
            {
                return NotFound();
            }
            await _reuniaoRepository.Remover( id );

            return View( "Index");
        }

        private async Task<ReuniaoViewModel> ObterReuniao(Guid id)
        {
            var reuniao = _mapper.Map<ReuniaoViewModel>( await _reuniaoRepository.ObterPorId( id ) );
            reuniao.Salas = _mapper.Map<IEnumerable<SalaViewModel>>( await _salaRepository.ObterTodos() );

            return reuniao;

        }

        private async Task<ReuniaoViewModel> PopularSalas (ReuniaoViewModel reuniao)
        {
            reuniao.Salas = _mapper.Map<IEnumerable<SalaViewModel>>( await _salaRepository.ObterTodos() );
            return reuniao;

        }

    }
}
