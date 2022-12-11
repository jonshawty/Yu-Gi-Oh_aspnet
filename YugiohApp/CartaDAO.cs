using System.Collections.Generic;
using System.Linq;
using System;

namespace YugiohApp
{
    internal class CartaDAO
    {
        internal static void CadastrarCarta(Carta carta)
        {
            try
            {
                using (var ctx = new userDBEntities1())
                {
                    ctx.Carta.Add(carta);
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {
            }
            
        }


        internal static Carta ObterCarta(int id)
        {
            Carta carta = null;
            try
            {
                using (var ctx = new userDBEntities1())
                {
                    carta = ctx.Carta.FirstOrDefault(x => x.IdCarta == id);
                }
            }
            catch (Exception)
            {
            }
            return carta;
        }

        internal static List<Carta> ObterCartas()
        {
            List<Carta> lista = null;
            try
            {
                using (var ctx = new userDBEntities1())
                {
                    lista = ctx.Carta.OrderBy(x => x.NomeCarta).ToList();
                }
            }
            catch (Exception )
            {
            }

            return lista;
        }

        internal static void RemoverCarta(int id)
        {
            try
            {
                using (var ctx = new userDBEntities1())
                {
                    var carta = ctx.Carta.FirstOrDefault(x => x.IdCarta == id);
                    ctx.Carta.Remove(carta);
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {
            }
        }


        public static void AlterarCarta(Carta carta)
        {
            try
            {
                using (var ctx = new userDBEntities1())
                {
                    var CartaAlterado =
                        ctx.Carta.FirstOrDefault(x => x.IdCarta == carta.IdCarta);
                    CartaAlterado.NomeCarta = carta.NomeCarta;
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {
            }
           
        }

    }
}
