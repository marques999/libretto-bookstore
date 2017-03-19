namespace ChatupNET
{
    class SqliteConstants
    {
        /// <summary>
        /// 
        /// </summary>
        internal static readonly string Id = "id";
        internal static readonly string Name = "name";
        internal static readonly string Owner = "owner";
        internal static readonly string Capacity = "capacity";
        internal static readonly string Password = "password";
        internal static readonly string Username = "username";

        /// <summary>
        /// 
        /// </summary>
        internal static readonly string ROOMS = "rooms";
        internal static readonly string USERS = "users";

        /// <summary>
        /// 
        /// </summary>
        internal static readonly string rooms_DELETE = "DELETE FROM rooms WHERE id = :id AND owner = :owner";
        internal static readonly string rooms_INSERT_Public = "INSERT INTO rooms(id, name, owner, capacity) VALUES(:id, :name, :owner, :capacity)";
        internal static readonly string rooms_INSERT_Private = "INSERT INTO rooms(id, name, owner, password, capacity) VALUES(:id, :name, :owner, :password, :capacity)";
        internal static readonly string rooms_CREATE = "CREATE TABLE `rooms`(`id` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, `name` TEXT NOT NULL UNIQUE, `owner` TEXT NOT NULL, `password` TEXT, `capacity` INTEGER DEFAULT 4 CHECK(capacity > 0), FOREIGN KEY(`owner`) REFERENCES `users`(`username`))";
        internal static readonly string users_INSERT = "INSERT INTO users(username, name, password) VALUES(:username, :name, :password)";
        internal static readonly string users_CREATE = "CREATE TABLE `users`(`username` TEXT NOT NULL UNIQUE, `name` TEXT NOT NULL, `password` TEXT NOT NULL)";
    }
}