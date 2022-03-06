﻿using BaltaDataAcces.Models;
using Dapper;
using Microsoft.Data.SqlClient;
namespace BaltaDataAccess
{
    class Program
    {
        public static void Main(string[] args)
        {
            const string connectionString = "Server=localhost, 1433;Database=balta;User ID=sa; Password=S=jdm123mdj@";

            var category = new Category();
            category.Id = Guid.NewGuid();
            category.Title = "Amazon AWS";
            category.Url = "amazon.com";
            category.Summary = "AWS Cloud";
            category.Order = 8;
            category.Description = "Categoria destinada a serviços AWS";
            category.Featured = false;

            //Warning !!! - SQL Injection
            var insertSql = @"
                INSERT INTO 
                    [Category] 
                VALUES (
                    @Id, 
                    @Title, 
                    @Url, 
                    @Summary, 
                    @Order, 
                    @Description, 
                    @Featured
            )";
            
            using (var connection = new SqlConnection(connectionString))
            {
                var rows = connection.Execute(insertSql, new {
                    category.Id,
                    category.Title,
                    category.Url,
                    category.Summary,
                    category.Order,
                    category.Description,
                    category.Featured,
                });
                Console.WriteLine($"{rows} linhas inseridas.");

                var categories = connection.Query<Category>("SELECT [Id], [Title] FROM [Category]");
                foreach (var item in categories)
                {
                    Console.WriteLine($"{item.Id} - {item.Title}");
                }
            }
        }
    }
}