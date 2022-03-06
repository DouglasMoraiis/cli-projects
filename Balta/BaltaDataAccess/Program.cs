using BaltaDataAcces.Models;
using Dapper;
using Microsoft.Data.SqlClient;
namespace BaltaDataAccess
{
    class Program
    {
        static void Main(string[] args)
        {
            const string connectionString = "Server=localhost, 1433;Database=balta;User ID=sa; Password=S=jdm123mdj@";

            using (var connection = new SqlConnection(connectionString))
            {
                ListCategories(connection);
                UpdateCategory(connection);
                DeleteCategory(connection);
                ListCategories(connection);
                //CreateCategory(connection);
            }
        }

        static void ListCategories(SqlConnection connection)
        {
            var categories = connection.Query<Category>("SELECT [Id], [Title] FROM [Category]");
            foreach (var item in categories)
            {
                Console.WriteLine($"{item.Id} - {item.Title}");
            }
        }

        static void CreateCategory(SqlConnection connection)
        {
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

            var rows = connection.Execute(insertSql, new
            {
                category.Id,
                category.Title,
                category.Url,
                category.Summary,
                category.Order,
                category.Description,
                category.Featured,
            });
            Console.WriteLine($"Operação Create: {rows} linha(s) afetada(s).");
        }

        static void UpdateCategory(SqlConnection connection)
        {
            var updateQuery = @"
                UPDATE 
                    [Category] 
                SET 
                    [Title] = @Title 
                WHERE 
                    [Id] = @Id
            ";

            var rows = connection.Execute(updateQuery, new
            {
                Id = new Guid("af3407aa-11ae-4621-a2ef-2028b85507c4"),
                Title = "Frontend 2021",
            });

            Console.WriteLine($"Operação Update: {rows} linha(s) afetada(s).");
        }

        static void DeleteCategory(SqlConnection connection)
        {
            var deleteQuery = @"
                DELETE FROM 
                    [Category] 
                WHERE
                    [Id] = @Id
            ";
            var rows = connection.Execute(deleteQuery, new
            {
                Id = "8079762d-b2c7-4617-ac60-bf6187563b06"
            });
            Console.WriteLine($"Operação Delete: {rows} linha(s) afetada(s).");
        }
    }
}