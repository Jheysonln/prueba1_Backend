using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesInterface
{
    public interface IMUsuario
    {
        Task<IEnumerable<UsuarioBE>> GetUser(UsuarioBE pageResult, int? userPerfilId);
    }
}
