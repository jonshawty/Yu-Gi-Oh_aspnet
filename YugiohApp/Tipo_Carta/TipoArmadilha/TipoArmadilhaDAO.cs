using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YugiohApp.Tipo_Carta.TipoArmadilha
{
    public class TipoArmadilhaDAO
    {

        internal static void CadastrarArmadilha(Armadilha armadilha)
        {
            try
            {
                using (var ctx = new userDBEntities1())
                {
                    ctx.Armadilha.Add(armadilha);
                    ctx.SaveChanges();
                }
            }
             catch (Exception)
            {
            }

        }

        internal static Armadilha ObterArmadilha(int id)
        {
            Armadilha armadilha = null;
            try
            {
                using (var ctx = new userDBEntities1())
                {
                    armadilha = ctx.Armadilha.FirstOrDefault(
                                tm => tm.IdArmadilha == id);
                }
            }
            catch (Exception ex)
            {
            }
            return armadilha;
        }

        internal static List<Armadilha> ObterArmadilhas()
        {
            List<Armadilha> lista = null;
            try
            {
                using (var ctx = new userDBEntities1())
                {
                    lista = ctx.Armadilha.OrderBy(
                        x => x.NomeArmadilha).ToList();
                }
            }
            catch (Exception ex)
            {
            }

            return lista;
        }

        internal static void RemoverArmadilha(int id)
        {
            try
            {
                using (var ctx = new userDBEntities1())
                {
                    var armadilha = ctx.Armadilha.
                        FirstOrDefault(
                            x => x.IdArmadilha == id);

                    ctx.Armadilha.Remove(armadilha);
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {

            }
        }


        public static void AlterarArmadilha(Armadilha armadilha)
        {
            try
            {
                using (var ctx = new userDBEntities1())
                {
                    var ArmadilhaAlterada =
                        ctx.Armadilha.FirstOrDefault(
                                x => x.IdArmadilha == armadilha.IdArmadilha
                            );
                    ArmadilhaAlterada.NomeArmadilha = armadilha.NomeArmadilha;
                    ctx.SaveChanges();

                }
            }
            catch (Exception)
            {

            }

        }
    }
}