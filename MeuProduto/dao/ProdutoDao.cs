using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MeuProduto.model;
using System.Configuration;

namespace MeuProduto.dao
{
   public class ProdutoDao
    {
       
        //DAO de insercao de produtos
        public void inserir(Produto produto )
        {
            string connectionStringInserir = ConfigurationManager.ConnectionStrings["Banco"].ConnectionString;
            string queryInserir = "INSERT INTO produto (nome, quantidade, valor, fornecedor, preco_venda) values (@nome, @quantidade, @valor, @fornecedor, @preco_venda)";

            MySqlConnection connectionInsert = new MySqlConnection(connectionStringInserir);
            connectionInsert.Open();
            MySqlCommand commandInserir = new MySqlCommand(queryInserir, connectionInsert);
            commandInserir.Prepare();
            commandInserir.Parameters.Add(new MySqlParameter("nome", produto.nome));
            commandInserir.Parameters.Add(new MySqlParameter("quantidade",produto.quantidade));
            commandInserir.Parameters.Add(new MySqlParameter ("valor", produto.valor));
            commandInserir.Parameters.Add(new MySqlParameter ("fornecedor", produto.fornecedor));
            commandInserir.Parameters.Add(new MySqlParameter ("preco_venda", produto.preco_venda));
            commandInserir.ExecuteNonQuery();
            connectionInsert.Close();

        }

        // DAO que realiza a pesquisar pelo codigo do produto
        public Produto PesquisarPorId(int Id)
        {
            Produto pesquisarId = new Produto();
            string connectionStringPesquisarId = ConfigurationManager.ConnectionStrings["Banco"].ConnectionString;
            string queryPesquisarId = "SELECT id, nome, quantidade, valor, fornecedor, preco_venda FROM produto WHERE id = @id";

            
            MySqlConnection connectionPesquisarId = new MySqlConnection(connectionStringPesquisarId);
            connectionPesquisarId.Open();
            MySqlCommand commandPesquisarId = new MySqlCommand(queryPesquisarId, connectionPesquisarId);
            commandPesquisarId.Prepare();
            commandPesquisarId.Parameters.Add(new MySqlParameter("@id", Id));
            MySqlDataReader readerPesquisarId = commandPesquisarId.ExecuteReader();
            if (readerPesquisarId.Read())
            {
                pesquisarId.id = Convert.ToInt32(readerPesquisarId["id"]);
                pesquisarId.nome = Convert.ToString(readerPesquisarId["nome"]);
                pesquisarId.quantidade = Convert.ToInt32(readerPesquisarId["quantidade"]);
                pesquisarId.valor = Convert.ToDouble(readerPesquisarId["valor"]);
                pesquisarId.fornecedor = Convert.ToString(readerPesquisarId["fornecedor"]);
                pesquisarId.preco_venda = Convert.ToDouble(readerPesquisarId["preco_venda"]);
               // Console.WriteLine("Id:          {0}", Convert.ToString(readerPesquisarId["id"]));
              //  Console.WriteLine("Nome:        {0}", Convert.ToString(readerPesquisarId["nome"]));
               // Console.WriteLine("Quantidae:   {0}", Convert.ToString(readerPesquisarId["quantidade"]));
               // Console.WriteLine("valor:       {0}", Convert.ToString(readerPesquisarId["valor"]));
               // Console.WriteLine("fornecedor:  {0}", Convert.ToString(readerPesquisarId["fornecedor"]));
               // Console.WriteLine("preco_venda: {0}", Convert.ToString(readerPesquisarId["preco_venda"]));
            }
            readerPesquisarId.Close();
            return pesquisarId;
           
        }

        //DAO que realiza a pesquisar pelo nome do produto
        public Produto PesquisarPorNome(string nome)
        {
            Produto listaProduto = new Produto();
            string connectionStringPesquisarNome = ConfigurationManager.ConnectionStrings["Banco"].ConnectionString;
            string queryPesquisarNome = "SELECT id, nome, quantidade, valor, fornecedor, preco_venda FROM produto WHERE nome like @nome";

            MySqlConnection connectionPesquisarId = new MySqlConnection(connectionStringPesquisarNome);
            connectionPesquisarId.Open();
            MySqlCommand commandPesquisarId = new MySqlCommand(queryPesquisarNome, connectionPesquisarId);
            commandPesquisarId.Prepare();
            commandPesquisarId.Parameters.Add(new MySqlParameter("@nome",nome));
            MySqlDataReader readerPesquisarId = commandPesquisarId.ExecuteReader();
            if (readerPesquisarId.Read())
            {
                
                listaProduto.id = Convert.ToInt32(readerPesquisarId["id"]);
                listaProduto.nome = Convert.ToString(readerPesquisarId["nome"]);
                listaProduto.quantidade = Convert.ToInt32(readerPesquisarId["quantidade"]);
                listaProduto.valor = Convert.ToDouble(readerPesquisarId["valor"]);
                listaProduto.fornecedor = Convert.ToString(readerPesquisarId["fornecedor"]);
                listaProduto.preco_venda = Convert.ToDouble(readerPesquisarId["preco_venda"]);
            
            }
            readerPesquisarId.Close();
            return listaProduto;

        }

        //DAO que realiza a apresentacao de todos os produtos cadastrados
        
        public List<Produto> PesquisarTodos()
        {
            List<Produto> listartodos = new List<Produto>();
            string connectionStringPesquisarTodos = ConfigurationManager.ConnectionStrings["Banco"].ConnectionString;
            string queryPesquisarId = "SELECT id, nome, quantidade,valor, fornecedor, preco_venda FROM produto";

            MySqlConnection connectionPesquisarId = new MySqlConnection(connectionStringPesquisarTodos);
            connectionPesquisarId.Open();
            MySqlCommand commandPesquisarId = new MySqlCommand(queryPesquisarId, connectionPesquisarId);
            commandPesquisarId.Prepare();
            MySqlDataReader readerPesquisarId = commandPesquisarId.ExecuteReader();
            while (readerPesquisarId.Read())
            {
                Produto pp = new model.Produto();
                pp.id = Convert.ToInt32(readerPesquisarId["id"]);
                pp.nome = Convert.ToString(readerPesquisarId["nome"]);
                pp.quantidade = Convert.ToInt32(readerPesquisarId["quantidade"]);
                pp.valor = Convert.ToDouble(readerPesquisarId["valor"]);
                pp.fornecedor = Convert.ToString(readerPesquisarId["fornecedor"]);
                pp.preco_venda = Convert.ToDouble(readerPesquisarId["preco_venda"]);
                listartodos.Add(pp);
            }
            readerPesquisarId.Close();
            return listartodos;

        }

        //DAO que realiza as modificacoes dos produtos 
        public void modificar(Produto produto)
        {
            string connectionStringModificar = ConfigurationManager.ConnectionStrings["Banco"].ConnectionString;
            string queryModificar = "UPDATE produto set nome=@nome, quantidade=@quantidade, valor=@valor, fornecedor=@fornecedor, preco_venda=preco_venda WHERE id = @id";

            MySqlConnection connectionModificar = new MySqlConnection(connectionStringModificar);
            connectionModificar.Open();
            MySqlCommand commandModificar = new MySqlCommand(queryModificar, connectionModificar);
            commandModificar.Prepare();
            commandModificar.Parameters.Add(new MySqlParameter("id",produto.id));
            commandModificar.Parameters.Add(new MySqlParameter("quantidade", produto.quantidade));
            commandModificar.Parameters.Add(new MySqlParameter("valor", produto.valor));
            commandModificar.Parameters.Add(new MySqlParameter("fornecedor", produto.fornecedor));
            commandModificar.Parameters.Add(new MySqlParameter("preco_venda", produto.preco_venda));
            commandModificar.ExecuteNonQuery();
            connectionModificar.Close();
            Console.WriteLine("Produto atualizado com sucesso");
            Console.ReadKey();

        }

       //DAO que realiza a remocao dos produtos
        public void Remover(Produto produto)
        {
            String connectionStringRemover = ConfigurationManager.ConnectionStrings["Banco"].ConnectionString;
            String queryRemover = "DELETE FROM produto WHERE id = @id";
            MySqlConnection connectionRemover = new MySqlConnection(connectionStringRemover);
            connectionRemover.Open();

            MySqlCommand commandRemover = new MySqlCommand(queryRemover, connectionRemover);
            commandRemover.Prepare();
            commandRemover.Parameters.Add(new MySqlParameter("id", produto.id));
            commandRemover.ExecuteNonQuery();
            connectionRemover.Close();
        }
        
        
    }
}
