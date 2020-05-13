using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProjectTestApiViaCep.Aplicacao;
using ProjectTestApiViaCep.Modelo;
using NUnit.Framework;

namespace ProjectTestApiViaCep
{
    [Route("{controller}/{action}/{id}")]
    
    public class AddressController : ApiController
    {
        //variavel estatica, para não resetar os dados quando nós fizermos as rotas
        static private readonly AddressAplicacao addressAplicacao = new AddressAplicacao();

        //rota para adicionar um novo endereço, recebe um usuario serializado em JSON
        
        [HttpPost]
        public IHttpActionResult Adicionar([FromBody]Address address)
        {
            try
            {
                //chama a camada de aplciação para adicionar o endereço
                var sucesso = addressAplicacao.Adicionar(address);

                if (sucesso)
                {
                    return Ok("Address entered successfully.");
                }
                else
                {
                    return BadRequest("We were unable to enter the address. Please try again");
                }

            }
            catch (Exception)
            {
                return BadRequest("An error occurred, please try again.");
            }
        }

        //rota para alterar um endereço existente, recebe um endereço serializado em JSON
        
        [HttpPut]
        public IHttpActionResult Alterar([FromBody]Address address)
        {
            try
            {
                //chama a camada de aplciação para alterar o endereço
                var sucesso = addressAplicacao.Alterar(address);

                if (sucesso)
                {
                    return Ok("Address updated successfully.");
                }
                else
                {
                    return BadRequest("We were unable to update the address. Please try again");
                }
            }
            catch (Exception)
            {
                return BadRequest("An error occurred, please try again.");
            }
        }

        //rota para deletar um endereço existente, recebe o id do endereço que será deletado
        
        [HttpDelete]
        public IHttpActionResult Remover([FromBody]int idUAddress)
        {
            try
            {
                //chama a camada de aplciação para deletar o endereço
                var sucesso = addressAplicacao.Remover(idUAddress);

                if (sucesso)
                {
                    return Ok("Address removed successfully.");
                }
                else
                {
                    return BadRequest("We were unable to remove the Address. Please try again");
                }
            }
            catch (Exception)
            {
                return BadRequest("An error occurred, please try again.");
            }
        }

        //rota para exibir um endereço existente, recebe o id do usuario que será retornado
        
        [HttpPost]
        public IHttpActionResult ExibirUsuario([FromBody]int idAddress)
        {
            try
            {
                //chama a camada de aplicação para retornar um endereço
                var addresRetornar = addressAplicacao.ExibirAddress(idAddress);
                if (addresRetornar != null)
                {
                    //caso o endereço exista, ele transforma o endereço em um documento json e o retorna
                    var addressSerializado = JsonConvert.SerializeObject(addresRetornar);
                    return Ok(addressSerializado);
                }
                else
                {
                    return BadRequest("No address was found with that ID, please try again.");
                }
            }
            catch (Exception)
            {
                return BadRequest("An error occurred, please try again.");
            }
        }
        
        [HttpGet]
        public IHttpActionResult ExibirTodos()
        {
            try
            {
                //pega TODOS os endereço da camada aplicação
                var address = addressAplicacao.ExibirTodos();

                if (address != null)
                {
                    //se ele conseguir pegar todos os endereços ele transforma essa lista de endreços em JSON e retorna
                    var addressSerializados = JsonConvert.SerializeObject(address);
                    return Ok(addressSerializados);
                }
                else
                {
                    return BadRequest("No registered address!");
                }
            }
            catch (Exception)
            {
                return BadRequest("An error occurred, please try again.");
            }
        }
    }
}