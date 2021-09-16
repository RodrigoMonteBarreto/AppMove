using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AppMove.Entities;
using AppMove.Models;
using AppMove.Persistence.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppMove.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public ProductsController(IProductRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }


        /// <summary>Listagem de todos Produtos</summary>
        /// <returns>Listar de Produtos</returns>
        /// <response code="200">Sucesso</response>
        /// <response code="400">Dados inválidos</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var products = await _repository.GetAllAsync();

                var productsViewModel = _mapper.Map<List<ProductViewModel>>(products);

                return Ok(productsViewModel);

            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro desconhecido:{ex.Message}");
            }
        }
        /// <summary>Cadastro de Produtos</summary>
        /// <returns>Objeto recém-criado</returns>
        /// <response code="200">Ok</response>
        /// <response code="400">Requisição inválida</response>
        /// <response code="404">Pré-condição falhou</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var product = await _repository.GetByIdAsync(id);

                if (product == null)
                {
                    return NotFound("ID incorreto.");
                }

                var productDetails = _mapper.Map<ProductDetailsViewModel>(product);

                return Ok(productDetails);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro desconhecido:{ex.Message}");
            }
        }

        /// <summary>Cadastro de Produtos</summary>
        /// <returns>Objeto recém-criado</returns>
        /// <response code="201">Criado</response>
        /// <response code="400">Requisição inválida</response>
        /// <response code="412">Pré-condição falhou</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status412PreconditionFailed)]
        public async Task<IActionResult> Post(AddProductInputModel model)
        {
            try
            {
                var product = new Product(model.Nome, model.Valor, model.Estoque);

                if (product == null)
                {
                    return this.StatusCode(StatusCodes.Status412PreconditionFailed, "Os valores informados não são válidos");
                }
                await _repository.AddAsync(product);
                CreatedAtAction(nameof(GetById), new { id = product.Id }, model);
                return Ok("Produto cadastrado");
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro desconhecido:{ex.Message}");
            }

        }

        /// <summary>Deletar Produto por ID</summary>
        /// <returns>Produto deletado</returns>
        /// <response code="204">Nenhum conteúdo</response>
        /// <response code="400">Recurso não encontrado</response>
        /// <response code="404">Requisição inválida</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            // var p =  _repository.RemoveAsync(id);
            // return Ok(p);
            try
            {
                if (id > 0)
                {
                    await _repository.RemoveAsync(id);
                    return Ok("Produto excluído com sucesso");
                }
                else
                {
                    return NotFound("Produto não encontrado");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro desconhecido:{ex.Message}");
            }
        }
    }
}