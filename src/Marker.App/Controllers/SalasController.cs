using Marker.Business.Interfaces;
using Marker.Business.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marker.App.Controllers
{
    public class SalasController : Controller
    {
        private readonly ISalaRepository _salaRepository;

        public SalasController (ISalaRepository salaRepository)
        {
            _salaRepository = salaRepository;
        }

        public async Task<IActionResult> Index()
        {
            return View( await _salaRepository.ObterTodos() );
        }
    }
}
