using Blog.Models;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories
{
    public class TagRepository : Repository<Tag>
    {
        private readonly SqlConnection _connection;
        public TagRepository(SqlConnection connection) : base(connection)
            => _connection = connection;

        public List<Tag> GetWithPosts()
        {
            var query = @"
                SELECT
                    [User].*,
                    [Role].*
                FROM
                    [User]  
                LEFT JOIN 
                    [UserRole] ON [UserRole].[UserId] = [User].[Id]
                LEFT JOIN 
                    [Role] ON [UserRole].[RoleId] = [Role].[Id]
            ";

            var tags = new List<User>();

            // QUEREMOS BUSCAR UM User + UM Role, SENDO QUE ESSE Role ESTÁ EM User.
            // VOCE PODE PASSAR n OBJETOS NA QUERY, MAS O ULTIMO É ONDE VAI SER CONSUMADO OS DADOS
            var items = _connection.Query<Tag, Post, Tag>(
                query,
                (tag, post) =>
                {
                    var tg = tags.FirstOrDefault(x => x.Id == tag.Id);
                    if (tg == null)
                    {
                        tg = tag;
                        if (post != null)
                            tg.Roles.Add(post);

                        tags.Add(tg);
                    }
                    else
                        tg.Roles.Add(post);

                    return tags;                        
                },
                splitOn: "Id"
            );

            return tags;
        }
    }
}