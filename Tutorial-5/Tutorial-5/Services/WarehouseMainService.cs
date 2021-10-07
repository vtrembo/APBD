using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Tutorial_5.Models;

namespace Tutorial_5.Services
{
    public class WarehouseMainService
    {
        public interface IDatabaseService
        {
            public bool productExists(int idProduct);
            public bool warehouseExists(int idWarehouse);
            public bool checkOrder(int IdProduct, int Amount);
            public bool checkDate(DateTime date, int IdProduct, int Amount);
            public bool checkCompletedOrder(int IdProduct, int Amount);
            public void updateFullfilledAt(int IdProduct, int Amount);
            public int createProductWarehouse(int IdProduct, int IdWarehouse, int Amount);
            public void createProductWarehouseWithProcedure(int IdProduct, int IdWarehouse, int Amount, DateTime CreatedAt);
            public int getProductWarehouseID(int IdProduct, int IdWarehouse, int Amount);

        }
        public class SqlServerDatabaseService : IDatabaseService
        {
            private IConfiguration _configuration;

            public SqlServerDatabaseService(IConfiguration configuration)
            {
                _configuration = configuration;
            }

            public bool productExists(int idProduct)
            {
                using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("ProductionDb")))
                {
                    SqlCommand com = new SqlCommand();
                    com.Connection = con;
                    con.Open();
                    com.CommandText = "SELECT COUNT(idProduct) FROM Product WHERE idProduct =@idProduct";
                    com.Parameters.AddWithValue("@idProduct", idProduct);
                    int exists = (int)com.ExecuteScalar();
                    if (exists == 0) return false; else return true;
                }
            }
            public bool warehouseExists(int idWarehouse)
            {
                using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("ProductionDb")))
                {
                    SqlCommand com = new SqlCommand();
                    com.Connection = con;
                    con.Open();
                    com.CommandText = "SELECT COUNT(idWarehouse) FROM Warehouse WHERE idWarehouse =@idWarehouse";
                    com.Parameters.AddWithValue("idWarehouse", idWarehouse);
                    int exists = (int)com.ExecuteScalar();
                    if (exists == 0) return false; else return true;
                }
            }
            public bool checkOrder(int IdProduct, int Amount)
            {
                using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("ProductionDb")))
                {
                    SqlCommand com = new SqlCommand();
                    com.Connection = con;
                    con.Open();
                    com.CommandText = "SELECT COUNT(idOrder) FROM [Order] WHERE IdProduct =@IdProduct AND Amount =@Amount";
                    com.Parameters.AddWithValue("IdProduct", IdProduct);
                    com.Parameters.AddWithValue("Amount", Amount);
                    int exists = (int)com.ExecuteScalar();
                    if (exists == 0) return false; else return true;
                }
            }
            public bool checkDate(DateTime date, int IdProduct, int Amount)
            {
                using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("ProductionDb")))
                {
                    SqlCommand com = new SqlCommand();
                    com.Connection = con;
                    con.Open();
                    com.CommandText = "SELECT CreatedAt FROM [Order] WHERE IdProduct =@IdProduct AND Amount =@Amount";
                    com.Parameters.AddWithValue("IdProduct", IdProduct);
                    com.Parameters.AddWithValue("Amount", Amount);
                    if ((DateTime)com.ExecuteScalar() > date) return false; else return true;
                }
            }
            public bool checkCompletedOrder(int IdProduct, int Amount)
            {
                using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("ProductionDb")))
                {
                    SqlCommand com = new SqlCommand();
                    com.Connection = con;
                    con.Open();
                    com.CommandText = "SELECT count(IdProductWarehouse) from Product_Warehouse Where IdOrder = (SELECT IdOrder FROM [Order] WHERE IdProduct =@IdProduct AND Amount =@Amount)";
                    com.Parameters.AddWithValue("IdProduct", IdProduct);
                    com.Parameters.AddWithValue("Amount", Amount);
                    int exists = (int)com.ExecuteScalar();
                    if (exists == 0) return true; else return false;
                }
            }
            public void updateFullfilledAt(int IdProduct, int Amount)
            {
                using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("ProductionDb")))
                {
                    SqlCommand com = new SqlCommand();
                    com.Connection = con;
                    con.Open();
                    com.CommandText = "UPDATE [Order] SET FulfilledAt = GETDATE() WHERE IdOrder = (SELECT idOrder FROM [Order] WHERE IdProduct =@IdProduct AND Amount =@Amount)";
                    com.Parameters.AddWithValue("IdProduct", IdProduct);
                    com.Parameters.AddWithValue("Amount", Amount);
                    com.ExecuteNonQuery();
                }
            }
            public int createProductWarehouse(int IdProduct, int IdWarehouse, int Amount)
            {
                using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("ProductionDb")))
                {
                    SqlCommand com = new SqlCommand();
                    com.Connection = con;
                    con.Open();
                    com.CommandText = "SET IDENTITY_INSERT Product_Warehouse ON;INSERT INTO Product_Warehouse (IdProductWarehouse, IdWarehouse, IdProduct, IdOrder, Amount, Price, CreatedAt)VALUES (((SELECT ISNULL(Max(IdProductWarehouse),0) FROM Product_Warehouse) + 1), @IdWarehouse, @IdProduct,(SELECT idOrder FROM [Order] WHERE IdProduct =@IdProduct AND Amount =@Amount),@Amount, ((SELECT Price FROM Product WHERE IdProduct = @IdProduct) * @Amount), GETDATE());SET IDENTITY_INSERT Product_Warehouse OFF";
                    com.Parameters.AddWithValue("IdProduct", IdProduct);
                    com.Parameters.AddWithValue("Amount", Amount);
                    com.Parameters.AddWithValue("IdWarehouse", IdWarehouse);
                    com.ExecuteNonQuery();
                    com.CommandText = "SELECT IdProductWarehouse from Product_Warehouse Where IdProduct = @IdProduct and IdWarehouse = @IdWarehouse and Amount = @Amount and Price = ((SELECT Price FROM Product WHERE IdProduct = @IdProduct) * @Amount)";
                    int id = (int)com.ExecuteScalar();
                    return id;
                }
            }
            public void createProductWarehouseWithProcedure(int IdProduct, int IdWarehouse, int Amount, DateTime CreatedAt)
            {
                using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("ProductionDb")))
                {
                    SqlCommand com = new SqlCommand("AddProductToWarehouse", con);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("IdProduct", IdProduct);
                    com.Parameters.AddWithValue("Amount", Amount);
                    com.Parameters.AddWithValue("IdWarehouse", IdWarehouse);
                    com.Parameters.AddWithValue("CreatedAt", CreatedAt);
                    con.Open();
                    com.ExecuteNonQuery();
                }
            }
            public int getProductWarehouseID(int IdProduct, int IdWarehouse, int Amount)
            {
                using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("ProductionDb")))
                {
                    SqlCommand com = new SqlCommand();
                    com.Connection = con;
                    con.Open();
                    com.CommandText = "SELECT IdProductWarehouse from Product_Warehouse Where IdProduct = @IdProduct and IdWarehouse = @IdWarehouse and Amount = @Amount and Price = ((SELECT Price FROM Product WHERE IdProduct = @IdProduct) * @Amount)";
                    com.Parameters.AddWithValue("IdProduct", IdProduct);
                    com.Parameters.AddWithValue("Amount", Amount);
                    com.Parameters.AddWithValue("IdWarehouse", IdWarehouse);
                    int id = (int)com.ExecuteScalar();
                    return id;
                }
            }
        }
    }
}
