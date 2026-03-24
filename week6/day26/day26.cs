using System;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Data;
using System.Collections.Generic;

namespace ConsoleApp8
{
    class Products
    {
        public int Productid { get; set; }
        public string Productname { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }

        public override string ToString()
        {
            return $"ID: {Productid}, Name: {Productname}, Category: {Category}, Price: {Price}";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connStr = config.GetConnectionString("DefaultConnection");

            using SqlConnection con = new SqlConnection(connStr);
            while(true){
            Console.WriteLine("Operations:");
            Console.WriteLine("1. Insert Product");
            Console.WriteLine("2. View All Products");
            Console.WriteLine("3. Update Product");
            Console.WriteLine("4. Delete Product");
            Console.WriteLine("5.get products by id");
            Console.WriteLine("6.exit");
            Console.Write("Enter option: ");
            int option = int.Parse(Console.ReadLine()!);

            switch (option)
            {
                case 1: 
                    InsertProduct(con);
                    break;
                case 2: 
                    ViewProducts(con);
                    break;
                case 3: 
                    UpdateProduct(con);
                    break;
                case 4: 
                    DeleteProduct(con);
                    break;
                case 5:
                     getproductbyid(con);
                     break;
                case 6:
                     return;
                default:
                    Console.WriteLine("Invalid option!");
                    break;
            }
        }
        }
        static void InsertProduct(SqlConnection con)
        {
         try{
            Console.Write("Enter Product Name: ");
            string name = Console.ReadLine()!;
            Console.Write("Enter Category: ");
            string category = Console.ReadLine()!;
            Console.Write("Enter Price: ");
            decimal price = decimal.Parse(Console.ReadLine()!);

            string cmdText = "sp_InsertProduct";
            SqlCommand cmd = new SqlCommand(cmdText, con);
            cmd.CommandType=CommandType.StoredProcedure;

            con.Open();
            SqlParameter p1 = new SqlParameter();
            p1.ParameterName = "@Productname";
            p1.SqlDbType = SqlDbType.VarChar;
            p1.Direction = ParameterDirection.Input;
            p1.Value =name;

            SqlParameter p2 = new SqlParameter();
            p2.ParameterName = "@Category";
            p2.SqlDbType = SqlDbType.VarChar; 
            p2.Direction = ParameterDirection.Input;
            p2.Value=category;

            SqlParameter p3 = new SqlParameter();
            p3.ParameterName = "@Price";
            p3.SqlDbType = SqlDbType.Decimal; 
            p3.Direction = ParameterDirection.Input;
            p3.Value=price;
            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);
            cmd.Parameters.Add(p3);
            cmd.ExecuteNonQuery();
            
            con.Close();

            Console.WriteLine("Product inserted successfully!");
             Console.WriteLine();
         }
         catch(SqlException ex)
            {
              Console.WriteLine("database error"+ex.Message);
            }
         catch(Exception ex)
            {
              Console.WriteLine("error"+ex.Message);
            }
        }

        static void ViewProducts(SqlConnection con)
        {
            try{
            string cmdText = "sp_GetAllProducts";
            SqlCommand cmd = new SqlCommand(cmdText, con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader reader=cmd.ExecuteReader();
            List<Products> empList = new List<Products>();
            while (reader.Read())
            {
                Products e1 = new Products();

                e1.Productid = (int) reader["Productid"];
                e1.Productname = (string) reader["Productname"];
                e1.Category = (string) reader["Category"];
                e1.Price = (decimal) reader["Price"];
                empList.Add(e1);    
            }


            foreach (Products e in empList)
            {
                Console.WriteLine(e);
            }
            con.Close();
            Console.WriteLine();
        }
        catch(SqlException ex)
            {
              Console.WriteLine("database error"+ex.Message);
            }
         catch(Exception ex)
            {
              Console.WriteLine("error"+ex.Message);
            }
        }
        static void UpdateProduct(SqlConnection con)
        {
            try{
            Console.Write("Enter Product ID to update: ");
            int id = int.Parse(Console.ReadLine()!);
            Console.Write("Enter New Product Name: ");
            string name = Console.ReadLine()!;
            Console.Write("Enter New Category: ");
            string category = Console.ReadLine()!;
            Console.Write("Enter New Price: ");
            decimal price = decimal.Parse(Console.ReadLine()!);

            string cmdText = "sp_UpdateProduct";
            SqlCommand cmd = new SqlCommand(cmdText, con);
            cmd.CommandType=CommandType.StoredProcedure;

            con.Open();
            SqlParameter p0 = new SqlParameter();
            p0.ParameterName = "@Productid";
            p0.SqlDbType = SqlDbType.Int;
            p0.Direction = ParameterDirection.Input;
            p0.Value = id;

            SqlParameter p1 = new SqlParameter();
            p1.ParameterName = "@Productname";
            p1.SqlDbType = SqlDbType.VarChar;
            p1.Direction = ParameterDirection.Input;
            p1.Value = name;

            SqlParameter p2 = new SqlParameter();
            p2.ParameterName = "@Category";
            p2.SqlDbType = SqlDbType.VarChar; 
            p2.Direction = ParameterDirection.Input;
            p2.Value=category;

            SqlParameter p3 = new SqlParameter();
            p3.ParameterName = "@Price";
            p3.SqlDbType = SqlDbType.Decimal; 
            p3.Direction = ParameterDirection.Input;
            p3.Value=price;
            cmd.Parameters.Add(p0);
            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);
            cmd.Parameters.Add(p3);
            int rows= cmd.ExecuteNonQuery();
            con.Close();
            Console.WriteLine(rows > 0 ? "Product updated successfully!" : "Product not found!");
            Console.WriteLine();
            }
            catch(SqlException ex)
            {
              Console.WriteLine("database error"+ex.Message);
            }
         catch(Exception ex)
            {
              Console.WriteLine("error"+ex.Message);
            }
        }
        static void DeleteProduct(SqlConnection con)
        {
            try{
            Console.Write("Enter Product ID to delete: ");
            int id = int.Parse(Console.ReadLine()!);
            string cmdText = "sp_DeleteProduct";
            SqlCommand cmd = new SqlCommand(cmdText, con);
            cmd.CommandType=CommandType.StoredProcedure;
            con.Open();
            SqlParameter p0 = new SqlParameter();
            p0.ParameterName = "@Productid";
            p0.SqlDbType = SqlDbType.Int;
            p0.Direction = ParameterDirection.Input;
            p0.Value = id;
            cmd.Parameters.Add(p0);
            int rows=cmd.ExecuteNonQuery();
            con.Close();
            Console.WriteLine(rows > 0 ? "Product deleted successfully!" : "Product not found!");
            Console.WriteLine();
            }
            catch(SqlException ex)
            {
              Console.WriteLine("database error"+ex.Message);
            }
         catch(Exception ex)
            {
              Console.WriteLine("error"+ex.Message);
            }
        }
        static void getproductbyid(SqlConnection con)
{
    try
    {
        Console.Write("Enter Product ID to display: ");
        int id = int.Parse(Console.ReadLine()!);

        string cmdText = "sp_getProductsbyid";
        using SqlCommand cmd = new SqlCommand(cmdText, con);
        cmd.CommandType = CommandType.StoredProcedure;
        SqlParameter p0 = new SqlParameter();
            p0.ParameterName = "@Productid";
            p0.SqlDbType = SqlDbType.Int;
            p0.Direction = ParameterDirection.Input;
            p0.Value = id;
            cmd.Parameters.Add(p0);
        con.Open();
        using SqlDataReader reader = cmd.ExecuteReader();
        if (reader.Read())
        {
            Console.WriteLine($"ID: {reader["Productid"]}, Name: {reader["Productname"]}, Category: {reader["Category"]}, Price: {reader["Price"]}");
        }
        else
        {
            Console.WriteLine("Product not found!");
        }
        con.Close();
    }
    catch (SqlException ex)
    {
        Console.WriteLine("Database error: " + ex.Message);
    }
    catch (Exception ex)
    {
        Console.WriteLine("Error: " + ex.Message);
    }
}
    }
}