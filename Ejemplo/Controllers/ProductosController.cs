using Dapper;
using Ejemplo.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Ejemplo.Controllers
{
    [EnableCors(origins: "http://localhost:56323", headers:"*",methods:"*")]
    public class ProductosController : ApiController
    {
        // GET: api/Productos
        public IEnumerable<Producto> Get()
        {
            string cadenaCon = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            
            using (var conexion = new SqlConnection(cadenaCon))
            {
                var productos =conexion.Query<Producto>("spSelectProductos",commandType:CommandType.StoredProcedure).ToList();
                return productos;
            }
        }

        // GET: api/Productos/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Productos
        
        public IHttpActionResult Post(Producto value)
        {
            string cadenaCon = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            DynamicParameters parametros = new DynamicParameters();
            parametros.Add("@id",value.Id,DbType.Int32,ParameterDirection.Input);
            parametros.Add("@Nombre", value.Nombre, DbType.String, ParameterDirection.Input);
            parametros.Add("@Descripcion", value.Descripcion, DbType.String, ParameterDirection.Input);
            parametros.Add("@Precio", value.Precio, DbType.Decimal, ParameterDirection.Input);

            using (var conexion = new SqlConnection(cadenaCon))
            {
                conexion.Execute("spProductos",parametros,commandType:CommandType.StoredProcedure);
                return Ok();
            }
            
        }

        

        // DELETE: api/Productos/5
        public IHttpActionResult Delete(int id)
        {
            string cadenaCon = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            DynamicParameters parametros = new DynamicParameters();
            parametros.Add("@id", id, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@RowCount", DbType.Int32, direction:ParameterDirection.ReturnValue);

            using (var conexion = new SqlConnection(cadenaCon))
            {
                conexion.Execute("spProductos", parametros, commandType: CommandType.StoredProcedure);
                return Ok();
            }
        }
    }
}
