
using System.Configuration;
using ArangoDB.Client;
using Microsoft.AspNet.Identity;

namespace ArangoDB.AspNet.Identity
{
    /// <summary>
    ///     Class UserStore.
    /// </summary>
    /// <typeparam name="TUser">The type of the t user.</typeparam>
    public partial class UserStore<TUser> :
        IUserStore<TUser>,
        IUserLoginStore<TUser>, 
        IUserClaimStore<TUser>, 
        IUserRoleStore<TUser>, 
        IUserPasswordStore<TUser>, 
        IUserSecurityStampStore<TUser> where TUser : IdentityUser
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="UserStore{TUser}" /> class. Uses DefaultConnection name if none was
        ///     specified.
        /// </summary>
        public UserStore() : this("DefaultConnection"){}

        /// <summary>
        ///     Initializes a new instance of the <see cref="UserStore{TUser}" /> class. Uses name from ConfigurationManager or connection string
        /// </summary>
        /// <param name="connectionStringOrName">The connection name or sql style string.</param>
        public UserStore(string connectionStringOrName)
        {

            var connectionString = ConfigurationManager.ConnectionStrings[connectionStringOrName] != null
                ? ConfigurationManager.ConnectionStrings[connectionStringOrName].ConnectionString
                : connectionStringOrName;

            _db = GetDatabaseFromSqlStyle(connectionString);
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="UserStore{TUser}" /> class.
        /// </summary>
        /// <param name="url">The URL of the database.</param>
        /// <param name="database">Name of the database.</param>
        public UserStore(string url, string database)
        {
            _db = new ArangoDatabase(url, database);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserStore{TUser}"/> class using a already initialized Arango Database.
        /// </summary>
        /// <param name="arangoDatabase">The Arango database.</param>
        public UserStore(ArangoDatabase arangoDatabase)
        {
            _db = arangoDatabase;
        }

    }
}
        