using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using ProjetoKeener3.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoKeener3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IConfiguration _configutation;
        public ProdutosController(IConfiguration configuration)
        {
            _configutation = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                        select ProdutoID,ProdutoNome,ProdutoPreco from
                        Produto
            ";
            DataTable table = new DataTable();
            string sqlDataSource = _configutation.GetConnectionString("Default");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    mycon.Close();
                }
            }

            return new JsonResult(table);
        }

        [HttpPost]
        public JsonResult Post(Produto pro)
        {
            string query = @"
                        insert into Produto (ProdutoNome, ProdutoPreco) values
                                              (@ProdutoNome, @ProdutoPreco);
            ";
            DataTable table = new DataTable();
            string sqlDataSource = _configutation.GetConnectionString("Default");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myCommand.Parameters.AddWithValue("@ProdutoNome", pro.ProdutoNome);
                    myCommand.Parameters.AddWithValue("@ProdutoPreco", pro.ProdutoPreco);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    mycon.Close();
                }
            }

            return new JsonResult("Foi adicionado com sucesso");
        }

        [HttpPut]
        public JsonResult Put(Produto pro)
        {
            string query = @"
                        update Produto set
                        produtoNome=@ProdutoNome, ProdutoPreco=@ProdutoPreco 
                        where ProdutoID=@ProdutoID;
            ";
            DataTable table = new DataTable();
            string sqlDataSource = _configutation.GetConnectionString("Default");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myCommand.Parameters.AddWithValue("@ProdutoID", pro.ProdutoID);
                    myCommand.Parameters.AddWithValue("@ProdutoNome", pro.ProdutoNome);
                    myCommand.Parameters.AddWithValue("@ProdutoPreco", pro.ProdutoPreco);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    mycon.Close();
                }
            }

            return new JsonResult("Foi atualizado com sucesso");
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = @"
                        delete from Produto
                        where ProdutoID=@ProdutoID;
            ";
            DataTable table = new DataTable();
            string sqlDataSource = _configutation.GetConnectionString("Default");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myCommand.Parameters.AddWithValue("@ProdutoID", id);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    mycon.Close();
                }
            }

            return new JsonResult("Foi deletado com sucesso");
        }
    }
}
