namespace ChatupNET
{
    class SqliteConstants
    {
        /// <summary>
        /// 
        /// </summary>
        public static readonly string Id = "id";
        public static readonly string Name = "name";
        public static readonly string Owner = "owner";
        public static readonly string Capacity = "capacity";
        public static readonly string Password = "password";
        public static readonly string Username = "username";

        /// <summary>
        /// 
        /// </summary>
        public static readonly string ROOMS = "rooms";
        public static readonly string USERS = "users";

        /// <summary>
        /// 
        /// </summary>
        public static readonly string rooms_DELETE = "DELETE FROM rooms WHERE id = :id AND owner = :owner";
        public static readonly string rooms_INSERT_Public = "INSERT INTO rooms(id, name, owner, capacity) VALUES(:id, :name, :owner, :capacity)";
        public static readonly string rooms_INSERT_Private = "INSERT INTO rooms(id, name, owner, password, capacity) VALUES(:id, :name, :owner, :password, :capacity)";
        public static readonly string rooms_CREATE = "CREATE TABLE `rooms`(`id` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, `name` TEXT NOT NULL UNIQUE, `owner` TEXT NOT NULL, `password` TEXT, `capacity` INTEGER DEFAULT 4 CHECK(capacity > 0), FOREIGN KEY(`owner`) REFERENCES `users`(`username`))";
        public static readonly string users_INSERT = "INSERT INTO users(username, name, password) VALUES(:username, :name, :password)";
        public static readonly string users_CREATE = "CREATE TABLE `users`(`username` TEXT NOT NULL UNIQUE, `name` TEXT NOT NULL, `password` TEXT NOT NULL)";
    }
}