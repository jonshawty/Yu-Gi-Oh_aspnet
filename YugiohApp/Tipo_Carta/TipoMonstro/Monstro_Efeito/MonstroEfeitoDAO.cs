using System.Collections.Generic;
using System.Linq;
using System;

namespace YugiohApp.Tipo_Carta.TipoMonstro.Monstro_Efeito
{
    internal class MonstroEfeitoDAO
    {
        internal static void CadastrarMonstroEfeito(MonstroEfeito monstroEfeito)
        {
            try
            {
                using (var ctx = new userDBEntities1())
                {
                    ctx.MonstroEfeito.Add(monstroEfeito);
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

            }

        }

        internal static MonstroEfeito ObterMonstroEfeito(int id)
        {
            MonstroEfeito monstroEfeito = null;
            try
            {
                using (var ctx = new userDBEntities1())
                {
                    monstroEfeito = ctx.MonstroEfeito.
                        FirstOrDefault(x => x.IdMonstroEfeito == id);
                }
            }
            catch (Exception )
            {
            }
            return monstroEfeito;
        }

        internal static List<MonstroEfeito> ObterMonstrosEfeito()
        {
            List<MonstroEfeito> lista = null;
            try
            {
                using (var ctx = new userDBEntities1())
                {
                    lista = ctx.MonstroEfeito.
                        OrderBy(x => x.NomeMonstroEfeito).ToList();
                }
            }
            catch (Exception ex)
            {

            }

            return lista;
        }

        internal static void RemoverMonstroEfeito(int id)
        {
            try
            {
                using (var ctx = new userDBEntities1())
                {
                    var monstroEfeito = ctx.MonstroEfeito.
                        FirstOrDefault( x => x.IdMonstroEfeito == id);

                    ctx.MonstroEfeito.Remove(monstroEfeito);
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {

            }
        }

        public static void AlterarMonstroEfeito(MonstroEfeito monstroEfeito)
        {
            try
            {
                using (var ctx = new userDBEntities1())
                {
                    var MonstroEfeitoAlterado = ctx.MonstroEfeito.
                        FirstOrDefault( x => x.IdMonstroEfeito == monstroEfeito.IdMonstroEfeito);
                    MonstroEfeitoAlterado.NomeMonstroEfeito = monstroEfeito.NomeMonstroEfeito;
                    ctx.SaveChanges();

                }
            }
            catch (Exception)
            {

            }

        }

    }
}