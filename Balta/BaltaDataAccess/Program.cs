using System.Data;
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
                //ListCategories(connection);
                //UpdateCategory(connection);
                //DeleteCategory(connection);
                //GetCategory(connection);
                //CreateManyCategories(connection);
                //ExecuteProcedure(connection);
                //ExecuteReadProcedure(connection);
                //ExecuteScalar(connection);
                // ReadView(connection);
                //OneToOne(connection);
                //OneToMany(connection);
                //ListCategories(connection);
                QueryMultiple(connection);
            }
        }

        static void GetCategory(SqlConnection connection)
        {
            var getQuery = @"
                SELECT 
                    [Id], [Title]
                FROM 
                    [Category]
                WHERE 
                    [Id] = @Id
            ";

            var category = connection.QueryFirst<Category>(getQuery, new
            {
                Id = "af3407aa-11ae-4621-a2ef-2028b85507c4"
            });

            Console.WriteLine($"{category.Id} - {category.Title}");
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

            var affectedrows = connection.Execute(insertSql, new
            {
                category.Id,
                category.Title,
                category.Url,
                category.Summary,
                category.Order,
                category.Description,
                category.Featured,
            });
            Console.WriteLine($"Operação Create: {affectedrows} linha(s) afetada(s).");
        }

        static void CreateManyCategories(SqlConnection connection)
        {
            var category = new Category();
            category.Id = Guid.NewGuid();
            category.Title = "Amazon AWS New";
            category.Url = "amazon.com";
            category.Summary = "AWS Cloud";
            category.Order = 8;
            category.Description = "Categoria destinada a serviços AWS";
            category.Featured = false;

            var category2 = new Category();
            category2.Id = Guid.NewGuid();
            category2.Title = "Fundamentos de Java";
            category2.Url = "java.com";
            category2.Summary = "Java";
            category2.Order = 9;
            category2.Description = "Categoria destinada Java";
            category2.Featured = true;

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

            var affectedrows = connection.Execute(insertSql, new[]{
            new
            {
                category.Id,
                category.Title,
                category.Url,
                category.Summary,
                category.Order,
                category.Description,
                category.Featured,
            },
            new
            {
                category2.Id,
                category2.Title,
                category2.Url,
                category2.Summary,
                category2.Order,
                category2.Description,
                category2.Featured,
            }
        });
            Console.WriteLine($"Operação Create: {affectedrows} linha(s) afetada(s).");
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

            var affectedrows = connection.Execute(updateQuery, new
            {
                Id = new Guid("af3407aa-11ae-4621-a2ef-2028b85507c4"),
                Title = "Frontend 2021",
            });

            Console.WriteLine($"Operação Update: {affectedrows} linha(s) afetada(s).");
        }

        static void DeleteCategory(SqlConnection connection)
        {
            var deleteQuery = @"
                DELETE FROM 
                    [Category] 
                WHERE
                    [Id] = @Id
            ";
            var affectedrows = connection.Execute(deleteQuery, new
            {
                Id = "8079762d-b2c7-4617-ac60-bf6187563b06"
            });
            Console.WriteLine($"Operação Delete: {affectedrows} linha(s) afetada(s).");
        }

        static void ExecuteProcedure(SqlConnection connection)
        {
            var procedure = "spDeleteStudent";
            var parms = new
            {
                StudentId = "df6f2bf6-f951-4aa8-ac8e-7423fd241625"
            };

            var affectedrows = connection.Execute(
                procedure,
                parms,
                commandType: CommandType.StoredProcedure
            );

            Console.WriteLine($"Operação Delete: {affectedrows} linha(s) afetada(s).");
        }

        static void ExecuteReadProcedure(SqlConnection connection)
        {
            var procedure = "spGetCourseByCategory";
            var parms = new
            {
                CategoryId = "af3407aa-11ae-4621-a2ef-2028b85507c4"
            };

            var courses = connection.Query(
                procedure,
                parms,
                commandType: CommandType.StoredProcedure
            );

            foreach (var item in courses)
            {
                Console.WriteLine($"{item.Id} - {item.Title}");
            }
        }

        static void ExecuteScalar(SqlConnection connection)
        {
            var category = new Category();
            category.Title = "Amazon AWS Scalar";
            category.Url = "amazon.com";
            category.Summary = "AWS Cloud";
            category.Order = 8;
            category.Description = "Categoria destinada a serviços AWS";
            category.Featured = false;

            //Warning !!! - SQL Injection
            var insertSql = @"
                INSERT INTO 
                    [Category] 
                OUTPUT inserted.[Id]
                VALUES (
                    NEWID(), 
                    @Title, 
                    @Url, 
                    @Summary, 
                    @Order, 
                    @Description, 
                    @Featured
                )";

            var id = connection.ExecuteScalar<Guid>(insertSql, new
            {
                category.Title,
                category.Url,
                category.Summary,
                category.Order,
                category.Description,
                category.Featured,
            });
            Console.WriteLine($"ID da categoria = {id}");
        }

        static void ReadView(SqlConnection connection)
        {
            var sql = "SELECT * FROM [vwCourses]";
            var courses = connection.Query(sql);

            foreach (var item in courses)
            {
                Console.WriteLine($"{item.Id} - {item.Title}");
            }
        }

        static void OneToOne(SqlConnection connection)
        {
            var sql = @"
                SELECT * FROM 
                    [CareerItem] 
                INNER JOIN 
                    [Course] 
                ON
                    [CareerItem].[CourseId] = [Course].[Id]
                ";

            var items = connection.Query<CareerItem, Course, CareerItem>(
                sql,
                (careerItem, course) =>
                {
                    careerItem.Course = course;
                    return careerItem;
                },
                splitOn: "Id"
            );

            foreach (var item in items)
            {
                Console.WriteLine($"{item.Title} -  Curso: {item.Course.Title}");
            }
        }

        static void OneToMany(SqlConnection connection)
        {
            var sql = @"
                SELECT
                    [Career].[Id],
                    [Career].[Title],
                    [CareerItem].[CareerId],
                    [CareerItem].[Title]
                FROM
                    [Career]
                INNER JOIN
                    [CareerItem]
                ON
                    [Career].[Id] = [CareerItem].[CareerId]
                ORDER BY
                    [Career].[Title]                    
                ";

            var careers = new List<Career>();
            var items = connection.Query<Career, CareerItem, Career>(
                sql,
                (career, item) =>
                {
                    var car = careers.Where(x => x.Id == career.Id).FirstOrDefault();
                    if (car == null)
                    {
                        car = career;
                        car.Items.Add(item);
                        careers.Add(car);
                    }
                    else
                    {
                        car.Items.Add(item);
                    }
                    return career;
                },
                splitOn: "CareerId"
            );

            foreach (var career in careers)
            {
                Console.WriteLine($"{career.Title}");
                foreach (var item in career.Items)
                {
                    Console.WriteLine($" + {item.Title}");
                }
            }
        }

        static void QueryMultiple(SqlConnection connection)
        {
            var query = "SELECT * FROM [Category]; SELECT * FROM [Course]";

            using (var multi = connection.QueryMultiple(query))
            {
                var categories = multi.Read<Category>();
                var courses = multi.Read<Course>();

                foreach (var item in categories)
                {
                    Console.WriteLine(item.Title);
                }

                foreach (var item in courses)
                {
                    Console.WriteLine(item.Title);
                }
            }
        }

        static void SelectIn(SqlConnection connection)
        {
            var query = @"
                SELECT * FROM
                    [Career] 
                WHERE
                    [Id] IN @Id
                ";

            var items = connection.Query<Career>(query, new
            {
                Id = new[] {
                    "GUID 1",
                    "GUID 2"
                },
            });

            foreach (var item in items)
            {
                Console.WriteLine(item.Title);
            }

        }
    }
}