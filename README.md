ArangoDB.AspNet.Identity
=======================

ASP.NET Identity provider that uses ArangoDB for storage

## Purpose ##

This provider acts as a replacement/plugin for the ASP.NET Identity Framework using ArangoDB as the backend.
This project replies on the fantastic [ArangoClient.NET](https://github.com/ra0o0f/arangoclient.net) by [ra0o0f](https://github.com/ra0o0f)
for connectivity and will be updated as that library is updated.

## Installation ##

```
Install-Package ArangoDB.AspNet.Identity
```

## Features ##
* Drop-in replacement ASP.NET Identity with ArangoDB as the backing store.
* Requires only 1 ArangoDB document type, while EntityFramework requires 5 tables
* Contains the same IdentityUser class used by the EntityFramework provider in the MVC 5 project template.
* Supports additional profile properties on your application's user model.
* Provides UserStore<TUser> implementation that implements the same interfaces as the EntityFramework version:
    * IUserStore<TUser>
    * IUserLoginStore<TUser>
    * IUserRoleStore<TUser>
    * IUserClaimStore<TUser>
    * IUserPasswordStore<TUser>
    * IUserSecurityStampStore<TUser>

## Connection Strings ##
The UserStore has multiple constructors for handling connection strings. Here are some examples of the expected inputs and where the connection string should be located.



<code>UserStore("ArangoDB")</code>

**web.config**
```xml
<add name="demoConnection" connectionString="Server=localhost:27017;Database=SomeDB;User Id=SomeUser;Password=SomePassword" />
```

**C# Example**

```C#
var userStore = new UserStore<IdentityUser>("demoConnection");
```


## Thanks To ##

Special thanks to [InspectorIT](https://github.com/InspectorIT) who's project [MongoDB.AspNet.Identity](https://github.com/InspectorIT/MongoDB.AspNet.Identity) 
provided the inspiration and starting point for this project.
