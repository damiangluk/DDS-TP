using System.Data.Entity;
using TPINTEGRADOR.Models;

namespace TPINTEGRADOR.Database
{
    public class DBContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }

        /*public DBContext() : base(@"Data Source=DESKTOP-AT2OURJ;Initial Catalog=DDS;Integrated Security=True") { 
        }*/

        public DBContext() : base(@"Data Source=LAPTOP-4HDMLNB7;Initial Catalog=DDS;Integrated Security=True")
        {

        }
    
    }


}
