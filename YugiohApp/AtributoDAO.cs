using System;
using System.Collections.Generic;
using System.Linq;
using YugiohApp;

namespace YugiohApp
{


    /// <summary>
    /// deixar o botão do + e apenas redirecionar pra mesma pagina, deixando um alert informando que não existe um nome possivel prea cadastrar
    /// </summary>
    public class AtributoDAO
    {       
     
        internal static void CadastrarAtributo(Atributo atributo)
        {
            try
            {
                using (var ctx = new userDBEntities1())
                {
                    ctx.Atributo.Add(atributo);
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {
            }           
        }

        internal static Atributo ObterAtributo(int id)
        {
            Atributo atributo = null;
            try
            {
                using (var ctx = new userDBEntities1())
                {
                    atributo = ctx.Atributo.FirstOrDefault(x => x.IdAtributo == id);
                }
            }
            catch (Exception)
            {
            }
            return atributo;
        }

        internal static List<Atributo> ObterAtributos()
        {
            List<Atributo> lista = null;
            try
            {
                using (var ctx = new userDBEntities1())
                {
                    lista = ctx.Atributo.OrderBy(x => x.NomeAtributo).ToList();
                }
            }
            catch (Exception)
            {
            }

            return lista;
        }

        internal static void RemoverAtributo(int id)
        {
            try
            {
                using (var ctx = new userDBEntities1())
                {
                    var atributo = 
                        ctx.Atributo.FirstOrDefault(x => x.IdAtributo == id);
                    ctx.Atributo.Remove(atributo);
                    ctx.SaveChanges();
                }
            }
            catch (Exception )
            {
            }
        }


        public static void AlterarAtributo(Atributo atributo)
        {
            try
            {
                using (var ctx = new userDBEntities1())
                {
                    var AtributoAlterado = ctx.Atributo.
                        FirstOrDefault(x => x.IdAtributo == atributo.IdAtributo);
                    AtributoAlterado.NomeAtributo = atributo.NomeAtributo;
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            { 
            }

        }
    }
}