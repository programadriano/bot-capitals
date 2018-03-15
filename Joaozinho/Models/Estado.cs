using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Joaozinho.Models
{
    public class Estado
    {

        private Estado()
        {
            _estados = new List<Estado>
            {
                new Estado
                {
                    Nome = "Acre",
                    Capital = "Rio Branco"
                },
                 new Estado
                {
                    Nome = "Alagoas",
                    Capital = "Maceió"
                },
                 new Estado
                {
                    Nome = "Amapá",
                    Capital = "Macapá"
                },
                 new Estado
                {
                    Nome = "Amazonas",
                    Capital = "Manaus"
                },
                 new Estado
                {
                    Nome = "Bahia",
                    Capital = "Salvador"
                },
                 new Estado
                {
                    Nome = "Ceará",
                    Capital = "Fortaleza"
                },
                 new Estado
                {
                    Nome = "Distrito Federal",
                    Capital = "Brasília"
                },
                 new Estado
                {
                    Nome = "Espírito Santo",
                    Capital = "Vitória"
                },
                 new Estado
                {
                    Nome = "Goiás",
                    Capital = "Goiânia"
                },
                 new Estado
                {
                    Nome = "Maranhão",
                    Capital = "São Luís"
                },
                 new Estado
                {
                    Nome = "Mato Grosso",
                    Capital = "Cuiabá"
                },
                 new Estado
                {
                    Nome = "Mato Grosso do Sul",
                    Capital = "Campo Grande"
                },
                 new Estado
                {
                    Nome = "Minas Gerais",
                    Capital = "Belo Horizonte"
                },
                 new Estado
                {
                    Nome = "Pará",
                    Capital = "Belém"
                },
                 new Estado
                {
                    Nome = "Paraíba",
                    Capital = "João Pessoa"
                },
                 new Estado
                {
                    Nome = "Paraná",
                    Capital = "Curitiba"
                },
                 new Estado
                {
                    Nome = "Pernambuco",
                    Capital = "Recife"
                },
                 new Estado
                {
                    Nome = "Piauí",
                    Capital = "Teresina"
                },
                 new Estado
                {
                    Nome = "Rio de Janeiro",
                    Capital = "Rio de Janeiro"
                },
                 new Estado
                {
                    Nome = "Rio Grande do Norte",
                    Capital = "Natal"
                },
                 new Estado
                {
                    Nome = "Rio Grande do Sul",
                    Capital = "Porto Alegre"
                },
                 new Estado
                {
                    Nome = "Rondônia",
                    Capital = "Porto Velho"
                },
                 new Estado
                {
                    Nome = "Roraima",
                    Capital = "Boa Vista"
                },
                 new Estado
                {
                    Nome = "Santa Catarina",
                    Capital = "Florianópolis"
                },
                 new Estado
                {
                    Nome = "São Paulo",
                    Capital = "São Paulo"
                },
                 new Estado
                {
                    Nome = "Sergipe",
                    Capital = "Aracaju"
                },
                 new Estado
                {
                    Nome = "Tocantins",
                    Capital = "Palmas"
                }
            };
        }
        private string Nome { get; set; }
        private string Capital { get; set; }
        private static IList<Estado> _estados { get; set; }

        public static string VerificarCapital(string estado)
        {
            return _estados.FirstOrDefault(x => x.Nome == estado).Capital;
        }
    }
}