namespace TPINTEGRADOR.Models
{
    public enum Rol
    {
        USUARIOAFECTADO,
        OBSERVADOR
    }

    public static class RolExtensions
    {
        public static Rol? GetType(string type)
        {
            switch (type)
            {
                case "USUARIOAFECTADO":
                    return Rol.USUARIOAFECTADO;
                case "OBSERVADOR":
                    return Rol.OBSERVADOR;
                default:
                    return null;

            }
        }

        public static string GetTipo(this Rol type)
        {
            switch (type)
            {
                case Rol.USUARIOAFECTADO:
                    return "USUARIOAFECTADO";
                case Rol.OBSERVADOR:
                    return "OBSERVADOR";
                default:
                    return string.Empty;

            }
        }
        public static List<object> GetAll()
        {
            List<object> lista = new List<object>();
            foreach (Rol rol in Enum.GetValues(typeof(Rol)))
            {
                lista.Add(new
                {
                    Id = (int)rol,
                    Text = RolExtensions.GetTipo(rol)
                });
            }
            return lista;
        }

        public static List<Rol> GetAllRoles()
        {
            List<Rol> lista = new List<Rol>();
            foreach (Rol rol in Enum.GetValues(typeof(Rol)))
            {
                lista.Add(rol);
            }
            return lista;
        }
    }
}
