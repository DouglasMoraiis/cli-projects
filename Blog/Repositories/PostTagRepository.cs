using Blog.Models;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories
{
    public class PostTagRepository
    {
        private readonly SqlConnection _connection;
        public PostTagRepository(SqlConnection connection)
            => _connection = connection;

        public void Link(int idPost, int idTag)
        {
            var query = @"
                INSERT INTO
                    [PostTag]
                VALUES (
                    @IdPost,
                    @IdTag
                )
            ";

            _connection.Query(query,
            new
            {
                idPost,
                idTag
            });
        }
    }
}