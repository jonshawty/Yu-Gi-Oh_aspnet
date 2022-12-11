using System.Collections.Generic;
using System.Linq;
using System;

namespace YugiohApp.Tipo_Carta.TipoMonstro.Monstro_Efeito.Monstro_Pendulo
{
    internal class MonstroPenduloDAO
    {
        internal static void CadastrarMonstroPendulo(MonstroPendulo monstroPendulo)
        {
            try
            {
                using (var ctx = new userDBEntities1())
                {
                    ctx.MonstroPendulo.Add(monstroPendulo);
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

            }

        }

        internal static MonstroPendulo ObterMonstroPendulo(int id)
        {
            MonstroPendulo monstroPendulo = null;
            try
            {
                using (var ctx = new userDBEntities1())
                {
                    monstroPendulo = ctx.MonstroPendulo.
                        FirstOrDefault (x => x.IdMonstroPendulo == id);
                }
            }
            catch (Exception ex)
            {
            }
            return monstroPendulo;
        }

        internal static List<MonstroPendulo> ObterMonstrosPendulo()
        {
            List<MonstroPendulo> lista = null;
            try
            {
                using (var ctx = new userDBEntities1())
                {
                    lista = ctx.MonstroPendulo.
                        OrderBy( x => x.NomeMonstroPendulo).ToList();

                }
            }
            catch (Exception)
            {
            }

            return lista;
        }

        internal static void RemoverMonstroPendulo(int id)
        {
            try
            {
                using (var ctx = new userDBEntities1())
                {
                    var monstroPendulo = ctx.MonstroPendulo.
                        FirstOrDefault(x => x.IdMonstroPendulo == id);

                    ctx.MonstroPendulo.Remove(monstroPendulo);
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {

            }
        }

        public static void AlterarMonstroPendulo(MonstroPendulo monstroPendulo)
        {
            try
            {
                using (var ctx = new userDBEntities1())
                {
                    var MonstroPenduloAlterado = ctx.MonstroPendulo.
                        FirstOrDefault( x => x.IdMonstroPendulo == monstroPendulo.IdMonstroPendulo );
                    MonstroPenduloAlterado.NomeMonstroPendulo = monstroPendulo.NomeMonstroPendulo;
                    ctx.SaveChanges();

                }
            }
            catch (Exception)
            {

            }

        }

    }
}