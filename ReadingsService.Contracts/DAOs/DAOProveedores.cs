using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using ReadingsService.Contracts.DataBase;
using ReadingsService.Contracts.Logging;
using ReadingsService.Contracts.Models;

namespace ReadingsService.Contracts.DAOs
{
    public class DAOProveedores : IDAOProveedores
    {

        private readonly string CUENTA = "cuenta";

        public bool ValidateProveedor(string username, string password)
        {
            var resultado = false;
            var cuenta = 0;
            OracleDataReader reader = null;

            try
            {
                IDatabaseController db = new DatabaseController();

                const string sql = "select count(*) cuenta from m_proveedores where vcusername = :username and vcpassword = :password";

                using (OracleConnection conn = db.GetConnection())
                {
                    conn.Open();
                    using (var command = new OracleCommand(sql, conn))
                    {
                        command.Parameters.Add(new OracleParameter(nameof(username), username));
                        command.Parameters.Add(new OracleParameter(nameof(password), username));

                        reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            cuenta = Convert.ToInt32(reader[CUENTA]);
                        }

                        if (cuenta > 0)
                        {
                            resultado = true;
                            Console.WriteLine("HAY DATOS");
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Logger.Log(e);
                throw new Exception("Error validando credenciales", e);
            }

            return resultado;
            
        }
    }
}
