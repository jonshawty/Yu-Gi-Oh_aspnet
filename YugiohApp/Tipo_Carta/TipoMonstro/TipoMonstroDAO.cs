using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace YugiohApp.Tipo_Carta.TipoMonstro
{
    internal class TipoMonstroDAO
    {
        internal static void CadastrarMonstro(Monstro monstro)
        {
            try
            {
                using (var ctx = new userDBEntities1())
                {
                    ctx.Monstro.Add(monstro);
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

            }

        }

        internal static Monstro ObterMonstro(int id)
        {
            Monstro monstro = null;
            try
            {
                using (var ctx = new userDBEntities1())
                {
                    monstro = ctx.Monstro.FirstOrDefault(x => x.IdMonstro == id );
                }
            }
            catch (Exception)
            {
            }
            return monstro;
        }

        internal static List<Monstro> ObterMonstros()
        {
            List<Monstro> lista = null;
            try
            {
                using (var ctx = new userDBEntities1())
                {
                    lista = ctx.Monstro.OrderBy(x => x.NomeMonstro).ToList();
                }
            }
            catch (Exception)
            {

            }

            return lista;
        }

        internal static void RemoverMonstro(int id)
        {
            try
            {
                using (var ctx = new userDBEntities1())
                {
                    var monstro = ctx.Monstro.FirstOrDefault(x => x.IdMonstro == id);

                    ctx.Monstro.Remove(monstro);
                    ctx.SaveChanges();
                }
            }
            catch (Exception )
            {

            }
        }

        public static void AlterarMonstro(Monstro monstro)
        {
            try
            {
                using (var ctx = new userDBEntities1())
                {
                    var MonstroAlterado = ctx.Monstro.
                        FirstOrDefault(x => x.IdMonstro == monstro.IdMonstro);
                    MonstroAlterado.NomeMonstro = monstro.NomeMonstro;
                    ctx.SaveChanges();

                }
            }
            catch (Exception)
            {

            }

        }


    }
}