using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RpgApi.Data;
using RpgApi.Models;

namespace RpgApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonagemHabilidadesController : ControllerBase
    {

        private readonly DataContext _context;

        public PersonagemHabilidadesController(DataContext context)
        {

            _context = context;
        }

        public async Task<IActionResult> AddPersonagemHabilidadeAsync(PersonagemHabilidade novoPersonagemHabilidade)
        {

            try
            {

                Personagem personagem = await _context.TB_PERSONAGENS
                .Include(p => p.Arma)
                .Include(p => p.PersonagemHabilidades).ThenInclude(ps => ps.Habilidade)
                .FirstOrDefaultAsync(p => p.Id == novoPersonagemHabilidade.PersonagemId);

                if (personagem == null)

                    throw new System.Exception("Personagem não encontrado para o id informado. ");

                Habilidade habilidade = await _context.TB_HABILIDADES.FirstOrDefaultAsync(h => h.Id == novoPersonagemHabilidade.HabilidadeId);

                if (habilidade == null)
                    throw new System.Exception("Habilidade não encontrada.");

                PersonagemHabilidade ph = new PersonagemHabilidade();
                ph.Personagem = personagem;
                ph.Habilidade = habilidade;
                await _context.TB_PERSONAGEM_HABILIDADES.AddAsync(ph);
                int linhasAfetadas = await _context.SaveChangesAsync();

                return Ok(linhasAfetadas);




            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet("{id}")]
        public async Task<List<PersonagemHabilidade>> ConsultarPersonagemHabilidade(int id)
        {

            var personagem = await _context.TB_PERSONAGEM_HABILIDADES.Where(p => p.PersonagemId == id).Include(p => p.Habilidade).ToListAsync();

            return personagem;

        }

        [HttpGet("GetHabilidades")]

        public async Task<ActionResult<List<Habilidade>>> GetHabilidades()
        {

            var habilidade = await _context.TB_HABILIDADES.ToListAsync();

            //habilidade == null:Verifica se foi inserido algum valor nulo
            //!habilidade.Any(): Verifica se aquele item inserido existe

            if (habilidade == null || !habilidade.Any())
            {

                return NotFound();
            }

            return habilidade;

        }

        [HttpPost("DeletePersonagemHabilidade")]

        public async Task<IActionResult> DeletarPersonagemHabilidade(PersonagemHabilidade ph)
        {

            var personagemHabilidade = await _context.TB_PERSONAGEM_HABILIDADES
             .FirstOrDefaultAsync(p => p.PersonagemId == ph.PersonagemId && p.HabilidadeId == ph.HabilidadeId);

            if (personagemHabilidade == null)
            {
                return NotFound(); // Retorna 404 se não for encontrado
            }

            _context.TB_PERSONAGEM_HABILIDADES.Remove(personagemHabilidade);
            await _context.SaveChangesAsync();

            return Ok();


        }





    }
}