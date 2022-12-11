using System;
using System.Linq;
using YugiohApp;

namespace YugiohApp
{
    public class UsuarioDAO
    {
        public static Usuario ObterUsuario(string login)
        {
            Usuario user = null;
            try
            {
                using (var ctx = new userDBEntities1())
                {
                    user = ctx.Usuario.FirstOrDefault(x => x.Login == login);
                }
            }
            catch (Exception)
            {
            }

            return user;
        }

        public static void CadastrarUsuario(Usuario usuario)
        {
            try
            {
                using (var ctx = new userDBEntities1())
                {
                    ctx.Usuario.Add(usuario);
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {
            }
            
        }
    }
}