using System.Linq;

namespace CinemaColaborativos.Business
{
    public class UserBusiness
    {
        CinemaProjectEntities DbContext = new CinemaProjectEntities();
        public void Createuser(string mail,string birthday,string phone)
        {
            usuario user = new usuario();
            user.correo = mail;
            user.estado = true;
            user.telefono = phone;
            user.tipo_usuario = 1;
            user.fecha_nacimiento = birthday;
            DbContext.usuario.Add(user);
            DbContext.SaveChanges();   
        }

        public usuario loginUser(string mail)
        {
            var user = DbContext.usuario.Where(b => b.correo == mail).FirstOrDefault();
            if (user != null)
                return user;
            else
                return null;
        }
    }
}