using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YugiohApp
{
    public partial class FrmAtributo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ChecarQueryString();
                List<Atributo> lista = AtributoDAO.ObterAtributos();
                PopularLvAtributos(lista);
            }

        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                var id = Request.QueryString["id"];
                var alterando = id != null;

                Atributo atributo = null;

                if (!alterando)
                {
                    atributo = new Atributo();
                }
                else
                {
                    var codigo = Convert.ToInt32(id);
                    atributo = AtributoDAO.ObterAtributo(codigo);
                }

                atributo.NomeAtributo = txtAtributo.Text;


                var mensagem = "";

                if (!alterando)
                {
                    AtributoDAO.CadastrarAtributo(atributo);
                    mensagem = "Tipo de munição cadastrado com sucesso!";
                }
                else
                {
                    AtributoDAO.AlterarAtributo(atributo);
                    Response.Redirect("Atributo");
                }

                PopularLvAtributos(AtributoDAO.ObterAtributos());

                lblMensagem.InnerText = mensagem;
                txtAtributo.Text = "";

            }
            catch (Exception ex)
            {
                MensagemDeErro(ex);
            }
        }

        private void PopularLvAtributos(List<Atributo> lista)
        {
            lvAtributos.DataSource = lista;
            lvAtributos.DataBind();
        }

        private void PreencherDados(int id)
        {
            Atributo atributo = AtributoDAO.ObterAtributo(id);
            if (atributo != null)
            {
                txtAtributo.Text = atributo.NomeAtributo;
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
                    VisualizarAtributos(id);
                }
                else 
                {
                    AlterarAtributo(id);
                }        
            }
        }

        private void AlterarAtributo(int id)
        {
            PreencherDados(id);
            btnCadastrar.Text = "Alterar";
        }

        private void VisualizarAtributos(int id)
        {
            PreencherDados(id);
            txtAtributo.Enabled = false;
            btnCadastrar.Visible = false;
        }

        protected void btn_Excluir_Command(object sender, CommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Excluir")
                {
                    //VerificaReferencia();
                    // se exite alguma carta usando algum atributo
                    //se existe algum atributo relacionado a uma carta
                    /*  if ()
                      {
                          lblMensagem.InnerText = "Erro de integridade referencial"
                              + "O item que deseja excluir está sendo referenciado po outro elemento";
                      } 
                      else { */
                    var id = Convert.ToInt32(e.CommandArgument);
                        AtributoDAO.RemoverAtributo(id);
                   // }
                }
                    
                PopularLvAtributos(AtributoDAO.ObterAtributos());
            }
            catch (Exception ex)
            {
                MensagemDeErro(ex);
            }
        }

        private void VerificaReferencia(int id)
        {

            Atributo atributo = AtributoDAO.ObterAtributo(id);
            if (atributo != null)
            {
               
            }
           
        }

        private void MensagemDeErro(Exception ex)
        {
            lblMensagem.InnerText = "Ocorreu um erro ao realizar a operação: " + ex.Message;
        }

        protected void Limparlbl_Click(object sender, EventArgs e)
        {
            Response.Redirect("Atributo");
        }

    }
}

