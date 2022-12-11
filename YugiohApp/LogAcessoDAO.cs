using System;
using System.Linq;

namespace YugiohApp
{
    internal class LogAcessoDAO
    {

        public static void CadastrarLogAcesso(LogAcesso log)
        {
            try
            {
                using (var ctx = new userDBEntities1())
                {
                    ctx.LogAcesso.Add(log);
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

            }

        }

        internal static void AtualizarLogAcesso(LogAcesso log)
        {
            try
            {
                using (var ctx = new userDBEntities1())
                {
                    var logAnterior =
                        ctx.LogAcesso.FirstOrDefault(x => x.IdLogAcesso == log.IdLogAcesso);
                    logAnterior.DataHoraLogoff = log.DataHoraLogoff;
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

            }
            
        }
    }
}
