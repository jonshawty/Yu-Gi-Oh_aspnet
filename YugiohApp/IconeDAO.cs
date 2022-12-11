using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YugiohApp
{
    public class IconeDAO
    {

        internal static void CadastrarIcone(Icone icone)
        {
            try
            {
                using (var ctx = new userDBEntities1())
                {
                    ctx.Icone.Add(icone);
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {
            }
           
        }

        internal static Icone ObterIcone(int id)
        {
            Icone icone = null;
            try
            {
                using (var ctx = new userDBEntities1())
                {
                    icone = ctx.Icone.FirstOrDefault(tm => tm.IdIcone == id);
                }
            }
            catch (Exception )
            {
            }
            return icone;
        }
        internal static List <Icone> ObterIcones()
        {
            List<Icone> lista = null;
            try
            {
                using (var ctx = new userDBEntities1())
                {
                    lista = ctx.Icone.OrderBy(x => x.NomeIcone).ToList();
                }
            }
            catch (Exception)
            {

            }

            return lista;
        }

        internal static void AlterarIcone(Icone icone)
        {
            try
            {
                using (var ctx = new userDBEntities1())
                {
                    var IconeAlterado =
                        ctx.Icone.FirstOrDefault(x => x.IdIcone == icone.IdIcone);
                    IconeAlterado.NomeIcone = icone.NomeIcone;
                    ctx.SaveChanges();

                }
            }
            catch (Exception)
            {

            }
            
        }

        internal static void RemoverIcone(int id)
        {
            try
            {
                using (var ctx = new userDBEntities1())
                {
                    var icone = ctx.Icone.FirstOrDefault( x => x.IdIcone == id);
                    ctx.Icone.Remove(icone);
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

            }
        }
    }



}
