using Blog.Models;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories
{
    public class PostRepository : Repository<Post>
    {
        private readonly SqlConnection _connection;
        public PostRepository(SqlConnection connection) : base(connection)
            => _connection = connection;

        public List<Post> GetWithCategories()
        {
            var query = @"
                SELECT
                    [Post].*,
                    [Role].*
                FROM
                    [Post]  
                LEFT JOIN 
                    [PostRole] ON [PostRole].[PostId] = [Post].[Id]
                LEFT JOIN 
                    [Role] ON [PostRole].[RoleId] = [Role].[Id]
            ";

            var posts = new List<Post>();

            // QUEREMOS BUSCAR UM Post + UM Role, SENDO QUE ESSE Role ESTÁ EM Post.
            // VOCE PODE PASSAR n OBJETOS NA QUERY, MAS O ULTIMO É ONDE VAI SER CONSUMADO OS DADOS
            // var items = _connection.Query<Post, Role, Post>(
            //     query,
            //     (user, role) =>
            //     {
            //         var usr = users.FirstOrDefault(x => x.Id == user.Id);
            //         if (usr == null)
            //         {
            //             usr = user;
            //             if (role != null)
            //                 usr.Roles.Add(role);

            //             users.Add(usr);
            //         }
            //         else
            //             usr.Roles.Add(role);

            //         return user;
            //     },
            //     splitOn: "Id"
            // );

            return posts;
        }

        public List<Post> GetWithTags()
        {
            var query = @"
                SELECT
                    [Post].*,
                    [Role].*
                FROM
                    [Post]  
                LEFT JOIN 
                    [PostRole] ON [PostRole].[PostId] = [Post].[Id]
                LEFT JOIN 
                    [Role] ON [PostRole].[RoleId] = [Role].[Id]
            ";

            var posts = new List<Post>();

            // QUEREMOS BUSCAR UM Post + UM Role, SENDO QUE ESSE Role ESTÁ EM Post.
            // VOCE PODE PASSAR n OBJETOS NA QUERY, MAS O ULTIMO É ONDE VAI SER CONSUMADO OS DADOS
            // var items = _connection.Query<Post, Role, Post>(
            //     query,
            //     (user, role) =>
            //     {
            //         var usr = users.FirstOrDefault(x => x.Id == user.Id);
            //         if (usr == null)
            //         {
            //             usr = user;
            //             if (role != null)
            //                 usr.Roles.Add(role);

            //             users.Add(usr);
            //         }
            //         else
            //             usr.Roles.Add(role);

            //         return user;
            //     },
            //     splitOn: "Id"
            // );

            return posts;
        }
    }
}