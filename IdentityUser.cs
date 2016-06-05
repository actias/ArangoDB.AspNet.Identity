using System;
using System.Collections.Generic;
using ArangoDB.Client;
using Microsoft.AspNet.Identity;

namespace ArangoDB.AspNet.Identity
{
    /// <summary>
    /// Class IdentityUser.
    /// </summary>
    public class IdentityUser : IUser
    {
        /// <summary>
        /// Database key for the user. This is relative to the collection
        /// and could be duplicated between shards. Do not use this as the
        /// unique for your users.
        /// </summary>
        [DocumentProperty(Identifier = IdentifierType.Key)]
        public string Key;

        /// <summary>
        /// Unique key for the user
        /// </summary>
        /// <value>The identifier.</value>
        /// <returns>The unique key for the user</returns>
	    public string Id { get; set; }
        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>The name of the user.</value>
		public virtual string UserName { get; set; }
        /// <summary>
        /// Gets or sets the password hash.
        /// </summary>
        /// <value>The password hash.</value>
		public string PasswordHash { get; set; }
        /// <summary>
        /// Gets or sets the security stamp.
        /// </summary>
        /// <value>The security stamp.</value>
		public string SecurityStamp { get; set; }
        /// <summary>
        /// Gets the roles.
        /// </summary>
        /// <value>The roles.</value>
		public List<string> Roles { get; private set; }
        /// <summary>
        /// Gets the claims.
        /// </summary>
        /// <value>The claims.</value>
		public List<IdentityUserClaim> Claims { get; private set; }
        /// <summary>
        /// Gets the logins.
        /// </summary>
        /// <value>The logins.</value>
		public List<UserLoginInfo> Logins { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="IdentityUser"/> class.
        /// </summary>
		public IdentityUser()
		{
			Claims = new List<IdentityUserClaim>();
			Roles = new List<string>();
			Logins = new List<UserLoginInfo>();
            Id = Guid.NewGuid().ToString("D");
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="IdentityUser"/> class.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
		public IdentityUser(string userName) : this()
		{
			UserName = userName;
		}
	}

    /// <summary>
    /// Class IdentityUserClaim.
    /// </summary>
	public class IdentityUserClaim
	{
        /// <summary>
        /// Database key for the user this claim.
        /// </summary>
        [DocumentProperty(Identifier = IdentifierType.Key)]
        public string Key;

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>The user identifier.</value>
        public virtual string UserId { get; set; }
        /// <summary>
        /// Gets or sets the type of the claim.
        /// </summary>
        /// <value>The type of the claim.</value>
        public virtual string ClaimType { get; set; }
        /// <summary>
        /// Gets or sets the claim value.
        /// </summary>
        /// <value>The claim value.</value>
		public virtual string ClaimValue { get; set; }
        
	}
}
