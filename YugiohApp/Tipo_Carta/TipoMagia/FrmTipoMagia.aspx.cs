using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YugiohApp.Tipo_Carta.TipoMagia;

namespace YugiohApp.Tipo_Carta.TipoMagia
{
    public partial class FrmTipoMagia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ChecarQueryString();
                List<Magia> lista = TipoMagiaDAO.ObterMagias();
                PopularLvMagia(lista);
            }
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                var id = Request.QueryString["id"];
                var alterando = id != null;

                Magia magia = null;

                if (!alterando)
                {
                    magia = new Magia();
                }
                else
                {
                    var codigo = Convert.ToInt32(id);
                    magia = TipoMagiaDAO.ObterMagia(codigo);
                }

                magia.NomeMagia = txtMagia.Text;

                var mensagem = "";

                if (!alterando)
                {
                    TipoMagiaDAO.CadastrarMagia(magia);
                    mensagem = "Tipo de munição cadastrado com sucesso!";
                }
                else
                {
                    TipoMagiaDAO.AlterarMagia(magia);
                    Response.Redirect("Magia");
                }

                PopularLvMagia(TipoMagiaDAO.ObterMagias());

                lblMensagem.InnerText = mensagem;
                txtMagia.Text = "";

            }
            catch (Exception ex)
            {
                MensagemDeErro(ex);
            }
        }

        private void PopularLvMagia(List<Magia> lista)
        {
            lvMagia.DataSource = lista;
            lvMagia.DataBind();
        }

        private void PreencherDados(int id)
        {
            Magia magia = TipoMagiaDAO.ObterMagia(id);
            if (magia != null)
            {
                txtMagia.Text = magia.NomeMagia;
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
                    VisualizarMagias(id);
                }
                else
                {
                    AlterarMagia(id);
                }
            }
        }

        private void AlterarMagia(int id)
        {
            PreencherDados(id);
            btnCadastrar.Text = "Alterar";
        }

        private void VisualizarMagias(int id)
        {
            PreencherDados(id);
            txtMagia.Enabled = false;
            btnCadastrar.Visible = false;
        }

        protected void btn_Excluir_Command(object sender, CommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Excluir")
                {
                    int id = Convert.ToInt32(e.CommandArgument);
                    TipoMagiaDAO.RemoverMagia(id);
                }

                PopularLvMagia(TipoMagiaDAO.ObterMagias());
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
            Response.Redirect("Magia");
        }
    }
}