using System;
using System.Linq;
using ArangoDB.Client;

namespace ArangoDB.AspNet.Identity
{
    /// <summary>
    ///     Class UserStore.
    /// </summary>
    /// 
    // ReSharper disable once UnusedTypeParameter
	public partial class UserStore<TUser> where TUser : IdentityUser
    {
        /// <summary>
        ///     The database
        /// </summary>
        private readonly ArangoDatabase _db;

        /// <summary>
        ///     The _disposed
        /// </summary>
        private bool _disposed;

        /// <summary>
        /// Retrieves all users from the database.
        /// </summary>
        public IQueryable<TUser> Users => _db.Query<TUser>();

        /// <summary>
        ///     Gets the database from connection string.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        /// <returns>MongoDatabase.</returns>
        /// <exception cref="System.Exception">No database name specified in connection string</exception>
        public static ArangoDatabase GetDatabaseFromSqlStyle(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
                throw new ArgumentNullException(connectionString);

            var server = "";
            var database = "";
            var username = "";
            var password = "";

            foreach (var item in connectionString.Split(';'))
            {
                if (!item.Contains("=")) continue;

                var split = item.Split('=');
                var key = split[0].ToLower();
                var value = split[1];

                switch (key)
                {
                    case "server":
                        server = value;
                        break;
                    case "database":
                        database = value;
                        break;
                    case "user id":
                        username = value;
                        break;
                    case "password":
                        password = value;
                        break;
                }
            }

            if (string.IsNullOrEmpty(server))
                throw new ArgumentException("Url cannot be blank in connection string");

            Uri uri;

            if (!Uri.TryCreate(server, UriKind.Absolute, out uri))
                throw new ArgumentException("Url is in an incorrect format");

            if (string.IsNullOrEmpty(server))
                throw new ArgumentException("Database cannot be blank connection string");

            if ((!string.IsNullOrEmpty(username) && string.IsNullOrEmpty(password))
                || (!string.IsNullOrEmpty(password) && string.IsNullOrEmpty(username)))
                throw new ArgumentException("User and Password must both have values");

            var userInfo = string.IsNullOrEmpty(username) ? "" : $"{username}:{password}@";

            server = $"{uri.Scheme}://{userInfo}{uri.Host}:{uri.Port}";

            return new ArangoDatabase(server, database);
        }


        
    }
}