using AlunosApi.Models;
using AlunosApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlunosApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class AlunosController : ControllerBase
    {
        private IAlunoService _alunoService;

        public AlunosController(IAlunoService alunoService)
        {
            _alunoService = alunoService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IAsyncEnumerable<Aluno>>> GetAlunos()
        {
            try
            {
                var alunos = await _alunoService.GetAlunos();
                return Ok(alunos);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error ao obter alunos");
            }
        }
        [HttpGet("AlunoPorNome")]
        public async Task<ActionResult<IAsyncEnumerable<Aluno>>>
            GetAlunosByName([FromQuery] string nome)
        {
            try
            {
                var alunos = await _alunoService.GetAlunosByNome(nome);
                if (alunos.Count() == 0)

                    return NotFound($"Não exixtem alunos com o critério {nome}");

                return Ok(alunos);
            }
            catch
            {
                return BadRequest("Request inválido analise seu Get");
            }
        }

        [HttpGet("{id:int}", Name = "GetAluno")]
        public async Task<ActionResult<Aluno>> GetAluno(int id)

        {
            try
            {
                var alunos = await _alunoService.GetAluno(id);
                if (alunos == null)

                    return NotFound($"Não exixtem alunos com id={id}");

                return Ok(alunos);
            }
            catch
            {
                return BadRequest("Request inválido analise seu Get");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create(Aluno aluno)
        {   
            try
            {
                 await _alunoService.CreateAluno(aluno);
                return CreatedAtRoute(nameof(GetAluno), new { id = aluno.Id }, aluno);
            }
            catch
            {
                return BadRequest("Request inválido analise seu Get");
            }
        }


        [HttpPut("{id:int}")]
        public async Task<ActionResult> Edit(int id, [FromBody] Aluno aluno)
        {
            try
            {
                if (aluno.Id == id)
                {
                    await _alunoService.UpdateAluno(aluno);
                    return Ok($"Aluno com id={id} foi atualizado com sucesso");
                }
                else
                {
                    return BadRequest("Dados inconsistente");
                }
            }
            catch
            {
                return BadRequest("Request inválido analise seu Get");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var aluno = await _alunoService.GetAluno(id);
                if(aluno != null)
                {
                    await _alunoService.DeleteAluno(aluno);
                    return Ok($"Aluno com id={id} foi atualizado com sucesso");
                }
                else
                {
                    return NotFound($"Dados inconsistente com id={id} não encontrado");
                }
            }
            catch
            {
                return BadRequest("Request inválido analise seu Get");
            }
        }

    }
}
