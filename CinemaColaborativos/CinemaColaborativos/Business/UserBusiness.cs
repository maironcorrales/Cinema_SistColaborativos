using System.Collections.Generic;
using System.Linq;

namespace CinemaColaborativos.Business
{
    public class UserBusiness
    {
        DB_A14118_colaborativosEntities DbContext = new DB_A14118_colaborativosEntities();
        public void Createuser(string mail,string birthday,string phone,string nombre)
        {
            usuario user = new usuario();
            user.correo = mail;
            user.estado = true;
            user.telefono = phone;
            user.tipo_usuario = 1;
            user.fecha_nacimiento = birthday;
            user.nombre = nombre;
            DbContext.usuario.Add(user);
            DbContext.SaveChanges();   
        }

        public bool CreateAdministratorUser(string mail, string birthday, string phone,string nombre)
        {
            usuario user = new usuario();
            user.correo = mail;
            user.estado = true;
            user.telefono = phone;
            user.tipo_usuario = 0;
            user.fecha_nacimiento = birthday;
            user.nombre = nombre;
            DbContext.usuario.Add(user);
            if (DbContext.SaveChanges() == 1)
                return true;
            else
                return false;
        }

        public usuario loginUser(string mail)
        {
            var user = DbContext.usuario.Where(b => b.correo == mail).FirstOrDefault();
            if (user != null)
                return user;
            else
                return null;
        }

        public bool CheckUserType(usuario user)
        {
            if (user.tipo_usuario == 0)
                return true;
            else
                return false;
        }

        public List<usuario> GetAllAdmnistrators()
        {
            List<usuario> adminList = new List<usuario>();
            adminList = DbContext.usuario.Where(u => u.tipo_usuario == 0).ToList();
            return adminList;
        }

        public bool updateUser(usuario user)
        {
            var result = DbContext.usuario.FirstOrDefault(u => u.id_usuario == user.id_usuario);
            if (result != null)
            {
                result.correo = user.correo;
                result.estado = user.estado;
                result.fecha_nacimiento = user.fecha_nacimiento;
                result.telefono = user.telefono;
                result.tipo_usuario = user.tipo_usuario;
            }
            if (DbContext.SaveChanges() == 1)
                return true;
            else
                return false;
        }

        public bool UpdateMailAndPhonenumber(string phone, int id,string nombre)
        {
            var result = DbContext.usuario.FirstOrDefault(u => u.id_usuario == id);
            if (result != null)
            {
                result.telefono = phone;
                result.nombre = nombre;
            }
            if (DbContext.SaveChanges() == 1)
                return true;
            else
                return false;       
        }

        public usuario GetUpdatedUser(int id)
        {
            usuario user = DbContext.usuario.FirstOrDefault(u => u.id_usuario == id);
            return user;
        }
        
    }
}