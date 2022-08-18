using Dapper;
using DataAccesInterface;
using Microsoft.Extensions.Configuration;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcces
{
    public class UsuarioDA : IMUsuario
    {
        private readonly string _connectionString;
        public UsuarioDA(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DevConnection");
        }

        public async Task<IEnumerable<UsuarioBE>> GetUser(UsuarioBE pageResult, int? userPerfilId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    var parametros = new DynamicParameters();//instalar paquete dapper 
                    parametros.Add("@pCodusuario", pageResult.cod_usuario);
                    parametros.Add("@pNomusuario", pageResult.nom_usuario);
                    parametros.Add("@pUserPerfilId", userPerfilId);

                    var result = await con.QueryAsync(
                      sql: "uspListadoUsuario",
                      param: parametros,
                      commandType: CommandType.StoredProcedure
                      );

                    var usuarios = result.ToList().Select(p => new UsuarioBE()
                    {
                        cod_usuario = p.cod_usuario,
                        nom_usuario = p.nom_usuario,
                        descripcion = p.descripcion,
                        telefono = p.telefono,
                        direccion = p.direccion,
                        correo = p.correo,
                        fechaNacimiento = p.fechaNacimiento,
                        fechaRegistro = p.fechaRegistro,
                        fechaModifica = p.fechaModifica,
                        password = p.password,
                        imgPerfil = p.imgPerfil
                    });
                    //pageResult.TotalCount = parametros.Get<int>("@pCantidadTotal");
                    return usuarios;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
