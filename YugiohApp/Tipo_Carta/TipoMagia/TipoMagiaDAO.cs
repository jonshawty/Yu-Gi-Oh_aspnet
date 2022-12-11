using System.Collections.Generic;
using System.Linq;
using System;

namespace YugiohApp.Tipo_Carta.TipoMagia
{
    internal class TipoMagiaDAO
    {

        internal static void CadastrarMagia(Magia magia)
        {
            try
            {
                using (var ctx = new userDBEntities1())
                {
                    ctx.Magia.Add(magia);
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

            }

        }

        internal static Magia ObterMagia(int id)
        {
            Magia magia = null;
            try
            {
                using (var ctx = new userDBEntities1())
                {
                    magia = ctx.Magia.FirstOrDefault(x => x.IdMagia == id);
                }
            }
            catch (Exception)
            {
            }
            return magia;
        }

        internal static List<Magia> ObterMagias()
        {
            List<Magia> lista = null;
            try
            {
                using (var ctx = new userDBEntities1())
                {
                    lista = ctx.Magia.OrderBy(x => x.NomeMagia).ToList();
                }
            }
            catch (Exception)
            {
            }

            return lista;
        }

        internal static void RemoverMagia(int id)
        {
            try
            {
                using (var ctx = new userDBEntities1())
                {
                    var magia = ctx.Magia. FirstOrDefault( x => x.IdMagia == id);
                    ctx.Magia.Remove(magia);
                    ctx.SaveChanges();
                }
            }
            catch (Exception )
            {

            }
        }


        public static void AlterarMagia(Magia magia)
        {
            try
            {
                using (var ctx = new userDBEntities1())
                {
                    var MagiaAlterada =
                        ctx.Magia.FirstOrDefault( x => x.IdMagia == magia.IdMagia );
                    MagiaAlterada.NomeMagia = magia.NomeMagia;
                    ctx.SaveChanges();

                }
            }
            catch (Exception)
            {

            }

        }

    }
}