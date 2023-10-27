using TPINTEGRADOR.Models.Sistema;

namespace TPINTEGRADOR.Models.daos
{
    public class UsuarioDao : GenericDao<Usuario>
    {
        public bool ExistUser(string token, string email)
        {
            return context.Usuarios.Any(u => u.Activo && (u.Token == token || u.CorreoElectronico == email));
        }

        public Usuario GetByTokenAndEmail(string token, string email)
        {
            return context.Usuarios.FirstOrDefault(u => u.Activo && u.Token == token && u.CorreoElectronico == email);
        }

    }
}
