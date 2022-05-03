using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;

namespace ProjetoEscola.Views
{
    /// <summary>
    /// Lógica interna para EscolaFormWindow.xaml
    /// </summary>
    public partial class EscolaFormWindow : Window
    {
        public EscolaFormWindow()
        {
            InitializeComponent();
        }

        private void btSalvar_Click(object sender, RoutedEventArgs e)
        {
            string nome = txtNome.Text;
            string razao = txtRazao.Text;
            string cnpj = txtCNPJ.Text;
            string inscricao = txtInscEst.Text;
            string tipo ="Pública";
            if (rdtipo.IsChecked == true)
            {
                tipo = "Privada";
            }

            var data = dtCriacao.SelectedDate?.ToString("yyyy-MM-dd");
            string nomeResp = txtNome2.Text;
            string telefoneResp = txtTelefone.Text;
            string telefoneEsc = txtTelefone1.Text;
            string email = txtEmail.Text;
            string rua = txtRua.Text;
            string numero = txtNumero.Text;
            string bairro = txtBairro.Text;
            string complemeto = txtComplemento.Text;
            string cep = txtCEP.Text;   
            string cidade = txtCidade.Text; 
            string estado = cbEstado.Text;

            

            try
            {
                var conexao = new MySqlConnection("server=localhost;database=escola_bd;port=3360;user=root;password=root");
                conexao.Open();
                var comando = conexao.CreateCommand();

                comando.CommandText = "insert into Escola values(null,@nome,@razao,@cnpj,@inscEst,@tipo,@dtCriacao,@responsavel,@responsavelTelefone,@email,@telefone,@rua,@numero,@bairro,@complemento,@cep,@cidade,@estado);";
                comando.Parameters.AddWithValue("@nome",nome);
                comando.Parameters.AddWithValue("@razao", razao);
                comando.Parameters.AddWithValue("@cnpj", cnpj);
                comando.Parameters.AddWithValue("@inscEst", inscricao);
                comando.Parameters.AddWithValue("@tipo", tipo);
                comando.Parameters.AddWithValue("@dtCriacao", data);
                comando.Parameters.AddWithValue("@responsavel", nomeResp);
                comando.Parameters.AddWithValue("@responsavelTelefone", telefoneResp);
                comando.Parameters.AddWithValue("@email", email);
                comando.Parameters.AddWithValue("@telefone", telefoneEsc);
                comando.Parameters.AddWithValue("@rua", rua);
                comando.Parameters.AddWithValue("@numero", numero);
                comando.Parameters.AddWithValue("@bairro", bairro);
                comando.Parameters.AddWithValue("@complemento", complemeto);
                comando.Parameters.AddWithValue("@cep", cep);
                comando.Parameters.AddWithValue("@cidade", cidade);
                comando.Parameters.AddWithValue("@estado", estado);

                var resultado = comando.ExecuteNonQuery();

                if (resultado > 0)
                {
                    MessageBox.Show("Registro Salvo com Sucesso");
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } 
        }
    }
}
