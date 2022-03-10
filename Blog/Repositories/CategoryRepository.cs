using Blog.Models;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories
{
    public class CategoryRepository : Repository<Category>
    {
        private readonly SqlConnection _connection;
        public CategoryRepository(SqlConnection connection) : base(connection)
            => _connection = connection;

        public List<Category> GetWithPosts()
        {
            var query = @"
                SELECT
                    [Category].*,
                    [Post].*
                FROM
                    [Category]  
                LEFT JOIN 
                    [CategoryPost] ON [CategoryPost].[CategoryId] = [Category].[Id]
                LEFT JOIN 
                    [Post] ON [UserPost].[PostId] = [Post].[Id]
            ";

            var categories = new List<Category>();

            // QUEREMOS BUSCAR UM Category + UM Post, SENDO QUE ESSE Post ESTÁ EM Category.
            // VOCE PODE PASSAR n OBJETOS NA QUERY, MAS O ULTIMO É ONDE VAI SER CONSUMADO OS DADOS
            var items = _connection.Query<Category, Post, Category>(
                query,
                (category, post) =>
                {
                    var ctg = categories.FirstOrDefault(x => x.Id == category.Id);
                    if (ctg == null)
                    {
                        ctg = category;
                        if (post != null)
                            category.Posts.Add(post);

                        categories.Add(category);
                    }
                    else
                        ctg.Posts.Add(post);

                    return category;
                },
                splitOn: "Id"
            );

            return categories;
        }
    }
}