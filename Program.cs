using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace siteDeCadastro
{


    public class Cad
    {
        SqlConnection conexao = null;
        SqlCommand comando = null;
        SqlDataReader leitor = null;
        string Query;
        public void CadastroDeFrutas(string nome)
        {
            Query = "INSERT INTO Frutas (nome, quantidade) VALUES (@nome, @quantidade)";
            using (SqlConnection conexao = new SqlConnection(@"Data Source = DESKTOP-OTU2M0A\SQLEXPRESS; Initial Catalog = cadastro; Integrated Security=true;"))
            {
                try
                {
                    conexao.Open();
                    using (SqlCommand comando = new SqlCommand(Query, conexao))
                    {
                        comando.Parameters.AddWithValue("@nome", nome);
                        comando.Parameters.AddWithValue("@quantidade", 25);
                        comando.ExecuteNonQuery();
                    }
                    Console.WriteLine("cadastro realizado com sucesso!");
                }
                catch (SqlException erro)
                {

                    Console.WriteLine($"erro ao cadastrar no banco de dados {erro}");
                }
            }
        }
    }
    public class Atu
    {
        SqlConnection conexao = null;
        SqlCommand comando = null;
        SqlDataReader leitor = null;
        string Query;
        public void CadastroDeFrutas(string n, int id, int p, int o)
        {
            Query = "UPDATE Frutas SET id= @id , nome = @nome, quantidade= @quantidade WHERE id = @id";
            using (SqlConnection conexao = new SqlConnection(@"Data Source = DESKTOP-OTU2M0A\SQLEXPRESS; Initial Catalog = cadastro; Integrated Security=true;"))
            {
                try
                {
                    conexao.Open();
                    using (SqlCommand comando = new SqlCommand(Query, conexao))
                    {
                        comando.Parameters.AddWithValue("@nome", n);
                        comando.Parameters.AddWithValue("@quantidade", p);
                        comando.Parameters.AddWithValue("@id", id);
                        comando.Parameters.AddWithValue("@id", o);
                        comando.ExecuteNonQuery();
                    }
                    Console.WriteLine("atualização realizada com sucesso!");
                }
                catch (SqlException erro)
                {

                    Console.WriteLine($"erro ao atualizar {erro}");
                }
            }
         }
        public class Listar
        {
            SqlConnection conexao = null;
            SqlCommand comando = null;
            SqlDataReader leitor = null;
            string Query;

            public void ListarFrutas()
            {

                Query = "SELECT * FROM Frutas";

                using (SqlConnection conexao = new SqlConnection(@"Data Source = DESKTOP-OTU2M0A\SQLEXPRESS; Initial Catalog = cadastro; Integrated Security=true;"))
                {
                    try
                    {
                        conexao.Open();
                        using (SqlCommand comando = new SqlCommand(Query, conexao))
                        {
                           
                            leitor = comando.ExecuteReader();
                            while (leitor.Read())
                            {
                                Console.WriteLine("ID: " + leitor["Id"] + " Nome: " + leitor["Nome"] + " Quantidade: " + leitor["Quantidade"]);
                            }
                            



                        }

                    }
                    catch (SqlException erro)
                    {
                        Console.WriteLine("Erro ao acessar o banco: " + erro.Message);
                    }
                }
            }
        }
        public class delete
        {
            SqlConnection cone = null;
            SqlCommand comando = null;
            string Query;


            
            public void deletar()
            {
                
                Query = " DELETE  FROM Frutas ";

                using (SqlConnection cone = new SqlConnection(@"Data Source = DESKTOP-OTU2M0A\SQLEXPRESS; Initial Catalog = cadastro; Integrated Security=true;"))
                {
                    try
                    {
                        cone.Open();
                        using (SqlCommand comando = new SqlCommand(Query, cone))
                        {
                            
                            comando.ExecuteNonQuery();

                        }

                        Console.WriteLine("Deletado com sucesso!");



                    }
                    catch (SqlException erro)
                    {

                        Console.WriteLine($"erro ao deletar {erro}");
                    }
                }



            }
        }




        public class program
        {
            static void Main(string[] args)
            {
                string option;
            Menu:
                Console.WriteLine("1 - Cadastrar.");
                Console.WriteLine("2 - Listar Frutas.");
                Console.WriteLine("3 - Atualizar.");
                Console.WriteLine("4 - Deletar.");

                option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        Cad cadastro = new Cad();
                        Console.WriteLine("Cadastrar Frutas");
                        Console.WriteLine("Nome da Fruta:");
                        string nome = Console.ReadLine();
                        
                        cadastro.CadastroDeFrutas(nome);
                        Console.ReadKey();
                        goto Menu;


                    case "2":
                        Console.WriteLine("Lista das Frutas em Estoque!");
                        Console.WriteLine("ID | Nome | Quantidade");
                        Console.WriteLine("----------------------");

                        Listar listar = new Listar();
                        listar.ListarFrutas(); 

                        Console.ReadKey();
                        goto Menu;
                    case "3":
                        Console.WriteLine("Atualizar");
                        Atu att = new Atu();
                        Console.WriteLine("ID das Fruta:");
                        int d = int.Parse (Console.ReadLine());
                        Console.WriteLine("Nome da Fruta:");
                        string tex = Console.ReadLine();
                        Console.WriteLine("Quantidade:");
                       int p= int.Parse(Console.ReadLine());
                        Console.WriteLine("atua id:");
                        int o = int.Parse(Console.ReadLine());
                        att.CadastroDeFrutas(tex, d, p, o);
                        Console.ReadKey();
                        goto Menu;
                        break;

                    case "4":
                        Console.WriteLine("Deletar");
                        delete del = new delete();
                    
                        del.deletar();
                        Console.ReadKey();
                        goto Menu;
                    default:
                        Console.WriteLine("Opção Inválida");
                        goto Menu;

                }
            }

        }
    }
    }


