using WebAPI.Models;
using System.Data;
using System.Data.SqlClient;

namespace WebAPI.Data
{
    public class ApiWebData
    {
        private readonly string conexion;

        public ApiWebData(IConfiguration configuration)
        {
            conexion = configuration.GetConnectionString("CadenaSQL")!;
        }
        
        public async Task<List<ClientPrediction>> ListaDatePrediction()
        {
            List<ClientPrediction> listaDatePrediction = new List<ClientPrediction>();

            using (var connection = new SqlConnection(conexion))
            {
                await connection.OpenAsync();

                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Sales.DatePrediction", connection))
                {
                    cmd.CommandType = CommandType.Text;

                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var client = new ClientPrediction
                            {
                                IdCliente = reader.GetInt32(0),
                                CustomerName = reader.GetString(1),
                                LastOrderDate = reader.GetDateTime(2),
                                NextPredictedOrder = reader.GetDateTime(3)
                            };

                            listaDatePrediction.Add(client);
                        }
                    }
                }
            }
            return listaDatePrediction;
        }

        public async Task<List<ClientOrders>> ListaGetClientOrders()
        {
            List<ClientOrders> listaGetClientOrders = new List<ClientOrders>();

            using (var connection = new SqlConnection(conexion))
            {
                await connection.OpenAsync();

                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Sales.GetClientOrders", connection))
                {
                    cmd.CommandType = CommandType.Text; 

                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var clientOrders = new ClientOrders
                            {
                                Orderid = reader.GetInt32(0),
                                Custid = reader.GetInt32(1),
                                Requireddate = reader.IsDBNull(2) ? (DateTime?)null : reader.GetDateTime(2),
                                Shippeddate = reader.IsDBNull(3) ? (DateTime?)null : reader.GetDateTime(3),
                                Shipname = reader.GetString(4),
                                Shipaddress = reader.GetString(5),
                                Shipcity = reader.GetString(6),
                            };

                            listaGetClientOrders.Add(clientOrders);
                        }
                    }
                }
            }
            return listaGetClientOrders;
        }

        public async Task<List<ClientOrders>> ListaGetClientOrdersID(int IdClient)
        {
            List<ClientOrders> listaGetClientOrders = new List<ClientOrders>();

            using (var connection = new SqlConnection(conexion))
            {
                await connection.OpenAsync();

                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Sales.GetClientOrders WHERE Custid = @IdClient", connection))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@IdClient", IdClient);

                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var clientOrders = new ClientOrders
                            {
                                Orderid = reader.GetInt32(0),
                                Custid = reader.GetInt32(1),
                                Requireddate = reader.IsDBNull(2) ? (DateTime?)null : reader.GetDateTime(2),
                                Shippeddate = reader.IsDBNull(3) ? (DateTime?)null : reader.GetDateTime(3),
                                Shipname = reader.GetString(4),
                                Shipaddress = reader.GetString(5),
                                Shipcity = reader.GetString(6),
                            };

                            listaGetClientOrders.Add(clientOrders);
                        }
                    }
                }
            }
            return listaGetClientOrders;
        }

        public async Task<List<Employees>> ListaGetEmployees()
        {
            List<Employees> listaGetEmployees = new List<Employees>();

            using (var connection = new SqlConnection(conexion))
            {
                await connection.OpenAsync();

                using (SqlCommand cmd = new SqlCommand("SELECT * FROM HR.GetEmployees", connection))
                {
                    cmd.CommandType = CommandType.Text; 

                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var employees = new Employees
                            {
                                Empid = reader.GetInt32(0),
                                FullName = reader.GetString(1),
                            };

                            listaGetEmployees.Add(employees);
                        }
                    }
                }
            }
            return listaGetEmployees;
        }

        public async Task<List<Shippers>> ListaGetShippers()
        {
            List<Shippers> listaGetShippers = new List<Shippers>();

            using (var connection = new SqlConnection(conexion))
            {
                await connection.OpenAsync();

                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Sales.GetShippers", connection))
                {
                    cmd.CommandType = CommandType.Text;

                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var shippers = new Shippers
                            {
                                Shipperid = reader.GetInt32(0),
                                Companyname = reader.GetString(1),
                            };

                            listaGetShippers.Add(shippers);
                        }
                    }
                }
            }
            return listaGetShippers;
        }

        public async Task<List<Products>> ListaGetProducts()
        {
            List<Products> listaGetShippers = new List<Products>();

            using (var connection = new SqlConnection(conexion))
            {
                await connection.OpenAsync();

                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Production.GetProducts", connection))
                {
                    cmd.CommandType = CommandType.Text;

                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var products = new Products
                            {
                                Productid = reader.GetInt32(0),
                                Productname = reader.GetString(1),
                            };

                            listaGetShippers.Add(products);
                        }
                    }
                }
            }
            return listaGetShippers;
        }

        public async Task<bool> CrearNewOrder(Orders objetoOrders, OrderDetails objetoOrdersDetails)
        {
            bool respuesta = true;

            using (var connection = new SqlConnection(conexion))
            {         
                using (SqlCommand cmd = new SqlCommand("dbo.spAddNewOrder", connection))
                {
                    cmd.Parameters.AddWithValue("@EmployeeId", objetoOrders.empid); 
                    cmd.Parameters.AddWithValue("@Shipperid", objetoOrders.shipperid);
                    cmd.Parameters.AddWithValue("@Shipname", objetoOrders.shipname);
                    cmd.Parameters.AddWithValue("@Shipaddress", objetoOrders.shipaddress);
                    cmd.Parameters.AddWithValue("@Shipcity", objetoOrders.shipcity);
                    cmd.Parameters.AddWithValue("@Orderdate", objetoOrders.orderdate);
                    cmd.Parameters.AddWithValue("@Requireddate", objetoOrders.requireddate);
                    cmd.Parameters.AddWithValue("@Shippeddate", objetoOrders.shippeddate);
                    cmd.Parameters.AddWithValue("@Freight", objetoOrders.freight);
                    cmd.Parameters.AddWithValue("@Shipcountry", objetoOrders.Shipcountry);
                    cmd.Parameters.AddWithValue("@Productid", objetoOrdersDetails.productid);
                    cmd.Parameters.AddWithValue("@Unitprice", objetoOrdersDetails.unitprice);
                    cmd.Parameters.AddWithValue("@Qty", objetoOrdersDetails.qty);
                    cmd.Parameters.AddWithValue("@Discount", objetoOrdersDetails.discount);
                    cmd.CommandType = CommandType.StoredProcedure;

                    try
                    {
                        await connection.OpenAsync();

                        respuesta = await cmd.ExecuteNonQueryAsync() > 0 ? true : false;
                    }
                    catch
                    {
                        respuesta = false;
                    }                    
                }
            }
            return respuesta;
        }

    }
}
