using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YugiohApp
{
    public partial class FrmIcone : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ChecarQueryString();
                List<Icone> lista = IconeDAO.ObterIcones();
                PopularLvIcones(lista);
            }

        }


        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                var id = Request.QueryString["id"];
                var alterando = id != null;

                Icone icone = null;

                if (!alterando)
                {
                    icone = new Icone();
                }
                else
                {
                    var codigo = Convert.ToInt32(id);
                    icone = IconeDAO.ObterIcone(codigo);
                }

                icone.NomeIcone = txtIcone.Text;


                var mensagem = "";

                if (!alterando)
                {
                    IconeDAO.CadastrarIcone(icone);
                    mensagem = "Tipo de munição cadastrado com sucesso!";
                }
                else
                {
                    IconeDAO.AlterarIcone(icone);
                    Response.Redirect("Icone");
                }

                PopularLvIcones(IconeDAO.ObterIcones());

                lblMensagem.InnerText = mensagem;
                txtIcone.Text = "";

            }
            catch (Exception ex)
            {
                MensagemDeErro(ex);
            }
        }

        private void PreencherDados(int id)
        {
            Icone icone = IconeDAO.ObterIcone(id);
            if (icone != null)
            {
                txtIcone.Text = icone.NomeIcone;
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
                    VisualizarIcone(id);
                }
                else
                {
                    AlterarIcone(id);
                }
            }
        }

        private void AlterarIcone(int id)
        {
            PreencherDados(id);
            btnCadastrar.Text = "Alterar";
        }

        private void VisualizarIcone(int id)
        {
            PreencherDados(id);
            txtIcone.Enabled = false;
            btnCadastrar.Visible = false;
        }

        protected void btn_Excluir_Command(object sender, CommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Excluir")
                {
                    int id = Convert.ToInt32(e.CommandArgument);
                    IconeDAO.RemoverIcone(id);
                }

                PopularLvIcones(IconeDAO.ObterIcones());
            }
            catch (Exception ex)
            {
                MensagemDeErro(ex);
            }
        }

        private void PopularLvIcones(List<Icone> lista)
        {
            lvIcones.DataSource = lista;
            lvIcones.DataBind();
        }

        private void MensagemDeErro(Exception ex)
        {
            lblMensagem.InnerText = "Ocorreu um erro ao realizar a operação: " + ex.Message;
        }

        protected void Limparlbl_Click(object sender, EventArgs e)
        {
            Response.Redirect("Icone");
        }
    }
}
