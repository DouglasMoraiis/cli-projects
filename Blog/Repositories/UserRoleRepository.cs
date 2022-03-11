using Blog.Models;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories
{
    public class UserRoleRepository
    {
        private readonly SqlConnection _connection;
        public UserRoleRepository(SqlConnection connection)
            => _connection = connection;

        public void Link(int idUser, int idRole)
        {
            var query = @"
                INSERT INTO
                    [UserRole]
                VALUES (
                    @IdUser,
                    @IdRole
                )
            ";

            _connection.Query(query,
            new
            {
                idUser,
                idRole
            });
        }
    }
}