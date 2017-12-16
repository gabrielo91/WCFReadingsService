using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using ReadingsService.Contracts.DataBase;
using ReadingsService.Contracts.Models;

namespace ReadingsService.Contracts.DAOs
{
    public class DAOProveedores : IDAOProveedores
    {
        public bool ValidateProveedor(string username, string password)
        {
            var resultado = false;
            OracleConnection conn = null;
            var cuenta = 0;

            try
            {
                IDatabaseController db = new DatabaseController();

                conn = db.GetConnection();
                var sql = "select count(*) cuenta from m_proveedores where vcusername = :username and vcpassword = :password";

                using (conn)
                {

                    conn.Open();
                    var command = new OracleCommand(sql, conn);
                    command.Parameters.Add(new OracleParameter(@"userame", username));
                    command.Parameters.Add(new OracleParameter(@"password", username));

                    OracleDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        cuenta = Convert.ToInt32(reader["cuenta"]);
                    }

                    if (cuenta > 0)
                    {
                        resultado = true;
                        Console.WriteLine("HAY DATOS");
                    }
                }


            }
            catch (Exception e)
            {
                throw new Exception("Error validando credenciales", e);
            }
            finally {
                if (null != conn) {
                    conn.Dispose();
                }
            }
            

            return resultado;
            
        }
    }
}
