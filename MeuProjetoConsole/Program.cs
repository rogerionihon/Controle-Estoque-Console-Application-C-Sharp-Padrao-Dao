using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MeuProduto.model;
using MeuProduto.dao;



namespace MeuProjetoConsole
{
    public class Program
    {
        static void Main(string[] args)
        {
            
            int opcao;
            

            Program inicio = new Program();

            do
            {
                ProdutoDao produto1 = new ProdutoDao();
                inicio.menu();
                opcao = Int32.Parse(Console.ReadLine());
                switch (opcao)
                {

                    case 1: Adcionar();
                        break;
                    case 2:
                        BuscarPorId();
                    break;
                    case 3:
                        BuscarPorNome();
                        break;
                    case 4:
                        ListarProdutos();
                        break;
                    case 5:
                        break;
                    case 6:
                        Remover();
                        break;
                    default:
                        inicio.sairPrograma();
                        break;
                }

            } while (opcao != 7);

        }

        // Metodos de construcao do menu
        public void menu()
        {
            Console.BackgroundColor = ConsoleColor.Gray; // muda a cor do fundo da tela
            Console.ForegroundColor = ConsoleColor.Blue; // muda a cor das letras
            Console.WriteLine("+++++  Meu do sistema  +++++");
            Console.WriteLine("----------------------------");
            Console.WriteLine(" 1 - Adicionar produto: ");
            Console.WriteLine(" 2 - buscar produto por ID: ");
            Console.WriteLine(" 3 - buscar produto por nome : ");
            Console.WriteLine(" 4 - listar todos produtos : ");
            Console.WriteLine(" 5 - modificar produto : ");
            Console.WriteLine(" 6 - remover : ");
            Console.WriteLine(" 7 - sair : ");
            Console.WriteLine("----------------------------");
            Console.WriteLine("Digite uma opcao");
       
        }
        // Metodo para encerra o sistema
        public void sairPrograma()
        {
            Console.WriteLine("Voce esta saindo do sistema pressione uma tecla para encerrar");
            Console.ReadKey();

        }
        // Metodo para adiciona um novo produto
        public static void Adcionar()
        {
            try
            {
                Console.Clear();
                ProdutoDao add = new ProdutoDao();
                Produto produto = new Produto();
                Console.WriteLine("+++++ Adicionar Produto +++++ ");
                Console.WriteLine("");
                Console.WriteLine("Digite o nome do Produto: " );
                produto.nome = Convert.ToString(Console.ReadLine());
                Console.WriteLine("Digite a quantidade do produto: " );
                produto.quantidade = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Digite o valor do produto: ");
                produto.valor = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Digite o nome do fornecedor: ");
                produto.fornecedor = Convert.ToString(Console.ReadLine());
                Console.WriteLine("Digite o preco de venda do produto: ");
                produto.preco_venda = Convert.ToDouble(Console.ReadLine());
                add.inserir(produto);
                Console.WriteLine("Produto adicionado com sucesso ");
                Console.WriteLine("Presione qualquer tecla para continuar:");
                Console.ReadKey();
                Console.Clear();
            }
            catch (Exception)
            {
                Console.WriteLine("O produto nao foi cadastrado, favor verificar os campos preenchidos!");
                Console.WriteLine("Presione qualquer tecla para continuar:");
                Console.Clear();
            }

        }

        // Metodo que realiza a busca do produto pelo codigo
        public static void BuscarPorId()
        {
                try
                {
                    Console.Clear();
                    ProdutoDao add = new ProdutoDao();
                    Produto prod = new Produto();
                    Console.WriteLine("+++++ Buscar por Codigo +++++");
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("Informe o codigo do produto");
                    int idi = Convert.ToInt32(Console.ReadLine());
                    prod = add.PesquisarPorId(idi);
            
                    Console.WriteLine("NOME:            / {0}", prod.nome);
                    Console.WriteLine("QUANTIDADE       / {0}", prod.quantidade);
                    Console.WriteLine("VALOR            / {0}", prod.valor);
                    Console.WriteLine("FORNECEDOR       / {0}", prod.fornecedor);
                    Console.WriteLine("PRECO DE VENDA   / {0}", prod.preco_venda);
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("Presione qualquer tecla para continuar:");
                    Console.ReadKey();
                    Console.Clear();
                }
            catch (Exception )
            {
                Console.WriteLine(" O codigo informado nao exite!");
                Console.WriteLine("Presione qualquer tecla para continuar:");
                Console.Clear();
            }
             
        }
      
        //Metodo que realiza a busca do produto pelo nome
        public static void BuscarPorNome()
        {

                try
                {
                    Console.Clear();
                    ProdutoDao add = new ProdutoDao();
                    Produto prod = new Produto();

                    Console.WriteLine("+++++ Buscar por Nome +++++");
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("Informe o nome do produto");
                    Console.WriteLine("");
                    string nome1 = Convert.ToString(Console.ReadLine());
                    prod =  add.PesquisarPorNome(nome1);
                    Console.WriteLine("ID               / {0}", prod.id);
                    Console.WriteLine("NOME             / {0}", prod.nome);
                    Console.WriteLine("QUANTIDADE       / {0}", prod.quantidade);
                    Console.WriteLine("VALOR            / {0}", prod.valor);
                    Console.WriteLine("FORNECEDOR       / {0}", prod.fornecedor);
                    Console.WriteLine("PRECO DE VENDA   / {0}", prod.preco_venda);
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("Presione qualquer tecla para continuar:");
                    Console.ReadKey();
                    Console.Clear();
                }
            catch (Exception ex)
            {
                Console.WriteLine("O nome informado nao existe!");
                Console.WriteLine("Presione qualquer tecla para continuar:");
                Console.Clear();
            }
        }

        
        //Metodo que realiza a listagem de todos os produtos
        public static void ListarProdutos()
        {
                try
                {
                    Console.Clear();
                    ProdutoDao add = new ProdutoDao();
           

                    foreach (Produto prod in add.PesquisarTodos())
                    {
                        add.PesquisarTodos();
                        Console.WriteLine("+++++ Listar Todos os Produtos +++++");
                        Console.WriteLine("");
                        Console.WriteLine("++++++++++++++++++++++++++");
                        Console.WriteLine("++ ID          / {0}       ", prod.id);
                        Console.WriteLine("++ NOME        / {0}       ", prod.nome);
                        Console.WriteLine("++ QUANTIDADE  / {0}       ", prod.quantidade);
                        Console.WriteLine("++ VALOR       / {0}       ", prod.valor);
                        Console.WriteLine("++ FORNECEDOR  / {0}       ", prod.fornecedor);
                        Console.WriteLine("++ PRECO_VENDA / {0}       ", prod.preco_venda);
                        Console.WriteLine("++++++++++++++++++++++++++");
                        Console.WriteLine("");
                
                    }
                    Console.WriteLine("Precione qualquer tecla para continuar!!");
                    Console.ReadKey();
                    Console.Clear();
                }
            catch (Exception)
            {
                Console.WriteLine("Nao foi possivel listar os produtos!");
                Console.WriteLine("Presione qualquer tecla para continuar:");
                Console.Clear();
            }
        }

        //Metodo que realiza a remocao de produtos
        public static void Remover()
        {
                try
                {
                    Console.Clear();
                    int opcao;
                    Produto prod = new Produto();
                    ProdutoDao add = new ProdutoDao();
            
                    do
                    {
                        Console.WriteLine("+++++ Excluir Produto +++++");
                        Console.WriteLine("");
                        Console.WriteLine("");
                        Console.WriteLine("Digite o id do produto: ");
                        int id = Convert.ToInt32(Console.ReadLine());
                        prod = add.PesquisarPorId(id);
                        Console.Clear();
                        Console.WriteLine("+++++ Descricao do Produto  +++++");
                        Console.WriteLine("");
                        Console.WriteLine("");
                        Console.WriteLine("Id         / {0}", id);
                        Console.WriteLine("Produto    / {0}", prod.nome);
                        Console.WriteLine("Quantidade / {0}", prod.quantidade);
                        Console.WriteLine("Valor      / {0}", prod.valor);
                        Console.WriteLine("fornecedor / {0}", prod.fornecedor);
                        Console.WriteLine("preco_venda/ {0}", prod.preco_venda);
                        Console.WriteLine("");
                        Console.WriteLine("");

                        Console.WriteLine("Precione 1 para excluir o produto");
                        Console.WriteLine("");
                        Console.WriteLine("");
                        Console.WriteLine("Precione 0 para voltar ao menu principal "); 
                        opcao = Convert.ToInt32(Console.ReadLine());
                        if (opcao == 1)
                        {
                            add.Remover(prod);
                            Console.WriteLine("Produto Removido com sucesso");
                            opcao = 0;
                            Console.WriteLine("Aperte qualquer tecla para continuar");
                            Console.ReadKey();
                        }

                    } while (opcao != 0);
                Console.Clear();
                }
            catch (Exception)
            {
                Console.WriteLine("Nao foi possivel remover o produto");
            }
        }
    }
}