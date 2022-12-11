using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YugiohApp
{
    public class TipoDAO
    {

        internal static void CadastrarTipoCarta(TipoCarta tipocarta)
        {
            try
            {
                using (var ctx = new userDBEntities1())
                {
                    ctx.TipoCarta.Add(tipocarta);
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

            }

        }

        internal static void AlterarTipoCarta(TipoCarta tipoCarta)
        {
            try
            {
                using (var ctx = new userDBEntities1())
                {
                    var tipoCartaAlterado = ctx.TipoCarta.
                        FirstOrDefault(x => x.IdTipoCarta == tipoCarta.IdTipoCarta );
                    tipoCartaAlterado.NomeTipoCarta = tipoCarta.NomeTipoCarta;
                    ctx.SaveChanges();

                }
            }
            catch (Exception)
            {

            }
            
        }

        internal static TipoCarta ObterTipo(int id)
        {
            TipoCarta tipoCarta = null;
            try
            {
                using (var ctx = new userDBEntities1())
                {
                    tipoCarta = ctx.TipoCarta.FirstOrDefault(x => x.IdTipoCarta == id);
                }
            }
            catch (Exception )
            {
            }
            return tipoCarta;
        }

        internal static List<TipoCarta> ObterTipoCarta()
        {
            List<TipoCarta> lista = null;
            try
            {
                using (var ctx = new userDBEntities1())
                {
                    lista = ctx.TipoCarta.OrderBy(x => x.NomeTipoCarta).ToList();
                }
            }
            catch (Exception )
            {
            }

            return lista;
        }

        internal static void RemoverTipo(int id)
        {
            try
            {
                using (var ctx = new userDBEntities1())
                {
                    var tipoCarta = 
                        ctx.TipoCarta.FirstOrDefault(x => x.IdTipoCarta == id);
                    ctx.TipoCarta.Remove(tipoCarta);
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

            }
        }

    }
}
