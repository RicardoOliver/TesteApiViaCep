using NUnit.Framework;
using ProjectTestApiViaCep.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTestApiViaCep.Aplicacao
{
    
    public class AddressAplicacao
    {
       
        private List<Address> address = new List<Address>
        {
            new Address{ Id = 0, Cep  = "1111-1111", Logradouro  = "Alameda", Bairro ="Itaquera",Uf="São Paulo" },
            new Address{ Id = 1, Cep  = "222-2222", Logradouro  = "Área", Bairro ="Guaianazes" , Uf="São Paulo" },
            new Address{ Id = 2, Cep  = "3333-333", Logradouro  = "Chácara", Bairro ="Santana" , Uf="São Paulo" },
            new Address{ Id = 3, Cep  = "444-4444", Logradouro  = "Estação", Bairro ="Mooca"  ,  Uf="São Paulo" },
        };

       
        public bool Adicionar(Address addressRecebido)
        {
            
            var addressInserir = addressRecebido;
            
            var ultimoIdCadastrado = address[address.Count - 1].Id;
            
            addressInserir.Id = ultimoIdCadastrado + 1;

            try
            {
                address.Add(addressInserir);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        
        public bool Remover(int Id)
        {
            try
            {
                address.Remove(address.Where(x => x.Id == Id).ToList()[0]);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        
        public bool Alterar(Address adressRecebido)
        {
            //como o id é automatico, caso o id passado não exista
            //joga uma exceção que é tratada no controller
            try
            {
                address[adressRecebido.Id].Cep = adressRecebido.Cep;
                address[adressRecebido.Id].Logradouro = adressRecebido.Logradouro;
                address[adressRecebido.Id].Bairro = adressRecebido.Bairro;
                address[adressRecebido.Id].Uf = adressRecebido.Uf;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        //método para exibir todos os usuarios
        
        public List<Address> ExibirTodos()
        {
            return address;
        }

        //método que busca um usuario através do id e retorna
       
        public Address ExibirAddress(int id)
        {
            try
            {
                return address.Where(x => x.Id == id).ToList()[0];
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}

