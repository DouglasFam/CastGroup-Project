using AutoMapper;
using CastGroup.Api.ViewModels;
using CastGroup.Domain.Models;
using CastGroup.Domain.Interface.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CastGroup.Domain.Interface.IRepository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CastGroup.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursosController : ControllerBase
    {
        private readonly ICursoService _cursoService;
        private readonly ICursoRepository _cursoRepository;
        private readonly IMapper _mapper;
        public CursosController(ICursoService cursoService,
                                ICursoRepository cursoRepository,
                                IMapper mapper)
        {
            _cursoService = cursoService;
            _cursoRepository = cursoRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CursoViewModel>>> GetCursos()
        {
            var cursos = await _cursoService.ObterTodos();

            if (cursos.Count == 0) return NotFound(new { message = "Não possui cursos na base!" });
            return Ok(cursos);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<CursoViewModel>> GetCurso(int id)
        {
            var curso = await _cursoService.ObterPorId(id);

            if (curso == null) return NotFound(new { message = "Curso não encontrado!" });
            return Ok(curso);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCurso(int id, CursoViewModel cursoViewModel)
        {
            var curso = await _cursoService.ObterPorId(id);

            if (curso == null) return NotFound(new { message = "Curso não encontrado!" });

            cursoViewModel.Id = id;
            var cursoMapper = _mapper.Map<Curso>(cursoViewModel);
     
            //_context.Entry(curso).State = EntityState.Modified;

            try
            {
                await _cursoService.Atualizar(cursoMapper);
            }
            catch (DbUpdateConcurrencyException er)
            {

                return NotFound(new { message = er });

                throw;

            }

            return NoContent();
        }

        // POST: api/Cursos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CursoViewModel>> PostCurso(CursoViewModel cursoViewModel)
        {

            if (!ModelState.IsValid) return BadRequest();
            if (cursoViewModel.DataFim < cursoViewModel.DataInicio) return NotFound(new { message = "A data de início do curso não pode ser menor que a data final!" });

            var curso = _mapper.Map<Curso>(cursoViewModel);

            var resultado = await _cursoService.Adicionar(curso);

            if (!resultado) return NotFound(new { message = "Existe(m) curso(s) planejados(s) dentro do período informado." });

            return CreatedAtAction("GetCurso", new { id = cursoViewModel.Id }, cursoViewModel);
        }

        // DELETE: api/Cursos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCurso(int id)
        {
            var curso = await _cursoService.ObterPorId(id);
            if (curso == null)
            {
                return NotFound(new { message = "Curso não encontrado!" });
            }

            await _cursoService.Remover(id);

            return NoContent();
        }
    }
}
