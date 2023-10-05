using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aula7exer1
{
    public partial class empresa : System.Web.UI.Page
    {
        MySqlConnection conexao = new MySqlConnection
        ("server=localhost; port=3306; user id=root; password=12345; database=empresa;SSL Mode = None; ");

        protected void Page_Load(object sender, EventArgs e)
        {
            PopulaDataGrid();
        }

        public void AbrirConexao()
        {
             try
            {
                conexao.Open();
            }
            catch (Exception exec)
            {
                Label1.Text = "Erro na conexão: " + exec.Message;
            }
        }

        public void PopulaDataGrid()
        {
            AbrirConexao();
            try
            {
                MySqlCommand cmd =
                    new MySqlCommand("SELECT * FROM instrutores ORDER BY cpf;", conexao);
                DataTable dataTable = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dataTable);
                GridView1.DataSource = dataTable;
                GridView1.DataBind();
                Label1.Text = "Mostramos os dados das tabelas 'instrutores' e 'veiculo' do BD formato MySQL 'empresa' ";
            }
            catch (Exception exec)
            {
                Label1.Text = "Erro preenchendo o GridView1: " + exec.Message;
            }

            //popular o GridView2 com dados da tabela 'profes':
            try
            {
                MySqlCommand cmd =
                    new MySqlCommand("SELECT * FROM veiculo ORDER BY placa;", conexao);
                DataTable dataTable = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dataTable);
                GridView2.DataSource = dataTable;
                GridView2.DataBind();
            }
            catch (Exception exec)
            {
                Label1.Text = "Erro preenchendo o GridView2: " + exec.Message;
            }
            conexao.Close();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}