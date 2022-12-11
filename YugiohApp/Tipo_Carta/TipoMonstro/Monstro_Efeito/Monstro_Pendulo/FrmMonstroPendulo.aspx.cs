using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YugiohApp.Tipo_Carta.TipoMonstro.Monstro_Efeito.Monstro_Pendulo
{
    public partial class FrmMonstroPendulo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ChecarQueryString();
                List<MonstroPendulo> lista = MonstroPenduloDAO.ObterMonstrosPendulo();
                PopularLvMonstroPendulo(lista);
            }
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                var id = Request.QueryString["id"];
                var alterando = id != null;

                MonstroPendulo monstroPendulo = null;

                if (!alterando)
                {
                    monstroPendulo = new MonstroPendulo();
                }
                else
                {
                    var codigo = Convert.ToInt32(id);
                    monstroPendulo = MonstroPenduloDAO.ObterMonstroPendulo(codigo);
                }

                monstroPendulo.NomeMonstroPendulo = txtMonstroPendulo.Text;

                var mensagem = "";

                if (!alterando)
                {
                    MonstroPenduloDAO.CadastrarMonstroPendulo(monstroPendulo);
                    mensagem = "Subtipo de Monstro Pendulo cadastrado com sucesso!";
                }
                else
                {
                    MonstroPenduloDAO.AlterarMonstroPendulo(monstroPendulo);
                    Response.Redirect("MonstroPendulo");
                }

                PopularLvMonstroPendulo(MonstroPenduloDAO.ObterMonstrosPendulo());

                lblMensagem.InnerText = mensagem;
                txtMonstroPendulo.Text = "";
            }
            catch (Exception ex)
            {
                MensagemDeErro(ex);
            }
        }

        private void PopularLvMonstroPendulo(List<MonstroPendulo> lista)
        {
            lvMonstroPendulo.DataSource = lista;
            lvMonstroPendulo.DataBind();
        }

        private void PreencherDados(int id)
        {
            MonstroPendulo monstroPendulo = MonstroPenduloDAO.ObterMonstroPendulo(id);
            if (monstroPendulo != null)
            {
                txtMonstroPendulo.Text = monstroPendulo.NomeMonstroPendulo;
            }
        }


        private void ChecarQueryString()
        {
            var idQuery = Request.QueryString["id"];

            if (idQuery != null)
            {
                var id = Convert.ToInt32(idQuery);
                var view = Request.QueryString["view"];

                if (view != null)
                {
                    VisualizarSubMonstroPendulos(id);
                }
                else 
                {
                    AlterarSubMonstroPendulo(id);
                }
            }
        }

        private void AlterarSubMonstroPendulo(int id)
        {
            PreencherDados(id);
            btnCadastrar.Text = "Alterar";
        }

        private void VisualizarSubMonstroPendulos(int id)
        {
            PreencherDados(id);
            txtMonstroPendulo.Enabled = false;
            btnCadastrar.Visible = false;
        }

        protected void btn_Excluir_Command(object sender, CommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Excluir")
                {
                    int id = Convert.ToInt32(e.CommandArgument);
                    MonstroPenduloDAO.RemoverMonstroPendulo(id);
                }

                PopularLvMonstroPendulo(MonstroPenduloDAO.ObterMonstrosPendulo());
            }
            catch (Exception ex)
            {
                MensagemDeErro(ex);
            }
        }

        private void MensagemDeErro(Exception ex)
        {
            lblMensagem.InnerText = "Ocorreu um erro ao realizar a operação: " + ex.Message;
        }

        protected void Limparlbl_Click(object sender, EventArgs e)
        {
            Response.Redirect("MonstroPendulo");
        }
    }
}