using BlazorAspNetFactory.Server.IRepository;
using BlazorAspNetFactory.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorAspNetFactory.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class Teste1Controller : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;


        public Teste1Controller(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [HttpGet]
        public async Task<IActionResult> GetTeste1s()
        {
            var teste1s = await _unitOfWork.Teste1Repository.GetAll();
            return Ok(teste1s);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeste1(int id)
        {
            var teste1 = await _unitOfWork.Teste1Repository.GetAll(q => q.Teste1id == id);

            if (teste1 == null)
            {
                return NotFound();
            }

            return Ok(teste1);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeste1(int id, Teste1 teste1)
        {

            if(id != teste1.Teste1id)
            {
                return BadRequest();
            }

            _unitOfWork.Teste1Repository.Update(teste1);

            try
            {
                await _unitOfWork.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await Teste1Exists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        } 

        [HttpPost]
        public async Task<ActionResult<Teste1>> PostTeste1(Teste1 teste1)
        {
            await _unitOfWork.Teste1Repository.Insert(teste1);

            await _unitOfWork.Save();

            return CreatedAtAction("GetTeste1", new { id = teste1.Teste1id }, teste1);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTeste1(int id)
        {
            var teste1 = await _unitOfWork.Teste1Repository.GetAll(q => q.Teste1id == id);
            if(teste1 == null)
            {
                return NotFound();
            }

            await _unitOfWork.Teste1Repository.Delete(id);
            await _unitOfWork.Save();

            return NoContent();
        }

        private async Task<bool> Teste1Exists(int id)
        {
            var teste1 = await _unitOfWork.Teste1Repository.GetAll(q => q.Teste1id == id);

            return teste1 == null;

        }

    }
}
