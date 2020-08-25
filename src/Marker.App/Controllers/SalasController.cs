using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Marker.App.ViewModels;
using Marker.Business.Interfaces;
using AutoMapper;
using Marker.Business.Models;

namespace Marker.App.Controllers
{
    public class SalasController : Controller
    {
        private readonly ISalaRepository _salaRepository;
        private readonly IMapper _mapper;
        private readonly IReuniaoRepository _reuniaoRepository;

        public SalasController (ISalaRepository salaRepository, IMapper mapper, IReuniaoRepository reuniaoRepository)
        {
            _salaRepository = salaRepository;
            _mapper = mapper;
            _reuniaoRepository = reuniaoRepository;
        }

        // GET: Salas
        public async Task<IActionResult> Index ()
        {
            return View( _mapper.Map<IEnumerable<SalaViewModel>>( await _salaRepository.ObterTodos() ) );
        }

        // GET: Salas/Details/5
        public async Task<IActionResult> Details (Guid id)
        {
            var salaViewModel = await ObterSala( id );

            if (salaViewModel == null)
            {
                return NotFound();
            }

            return View( salaViewModel );
        }

        // GET: Salas/Create
        public IActionResult Create ()
        {
            return View();
        }

        // POST: Salas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create (SalaViewModel salaViewModel)
        {
            if (!ModelState.IsValid) return View( salaViewModel );

            var sala = _mapper.Map<Sala>( salaViewModel );
            await _salaRepository.Adicionar( sala );

            return RedirectToAction( "Index" );


        }

        // GET: Salas/Edit/5
        public async Task<IActionResult> Edit (Guid id)
        {
            var salaViewModel = await ObterSala( id );

            if (salaViewModel == null)
            {
                return NotFound();
            }
            return View( salaViewModel );
        }

        // POST: Salas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit (Guid id,  SalaViewModel salaViewModel)
        {
            if (id != salaViewModel.Id) return NotFound();

            if (!ModelState.IsValid) return View( salaViewModel );

            var sala = _mapper.Map<Sala>( salaViewModel );
            await _salaRepository.Atualizar( sala );

            return RedirectToAction( "Index" );

            
        }

        // GET: Salas/Delete/5
        public async Task<IActionResult> Delete (Guid id)
        {
            var salaViewModel = await ObterSala( id );
            if (salaViewModel == null)
            {
                return NotFound();
            }

            return View( salaViewModel );
        }

        // POST: Salas/Delete/5
        [HttpPost, ActionName( "Delete" )]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed (Guid id)
        {
            var salaViewModel = await ObterSala( id );

            if (salaViewModel == null) return NotFound();

            await _salaRepository.Remover(id);
            return RedirectToAction( "Index" );
        }

        private async Task<SalaViewModel> ObterSala (Guid id)
        {
            var sala =  _mapper.Map<SalaViewModel>( await _salaRepository.ObterPorId( id ) );
            sala.Reunioes = _mapper.Map<IEnumerable<ReuniaoViewModel>>( await _reuniaoRepository.ObterTodos() );

            return sala;
        }
    }
}
