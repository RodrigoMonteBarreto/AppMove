using System;
using System.Net.Http;
using System.Threading.Tasks;
using AppMove.Models;
using AppMove.Persistence.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppMove.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompraController : ControllerBase
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;
        private static readonly HttpClient client = new HttpClient();

        public CompraController(IProductRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }
        /// <summary>Realizar uma compra</summary>
        /// <returns>Objeto recém-criado</returns>
        /// <response code="201">Criado</response>
        /// <response code="400">Requisição inválida</response>
        /// <response code="412">Pré-condição falhou</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status412PreconditionFailed)]
        public async Task<IActionResult> Post(AddCompraInputModel model)
        {
            try
            {

                var produto = _repository.GetByIdAsync(model.IdProduto);
                if (produto == null)
                {
                    return this.StatusCode(StatusCodes.Status412PreconditionFailed, "Os valores informados não são válidos");
                }

                if (model.qtdComprada < produto.Result.Estoque && produto.Result.Estoque > 0)
                {
                    await _repository.DarBaixa(model.IdProduto);

                    return Ok("Venda realizada com sucesso");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro desconhecido:{ex.Message}");

            }


            return null;
        }
    }
}