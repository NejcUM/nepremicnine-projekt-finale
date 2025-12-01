using System.Text.Json;
using NepremicnineProjekt;

public class DBManager
{
    public List<User> GetUsers()
    {
        var usersFile = "Database/Users.json";
        var users = File.Exists(usersFile)
            ? JsonSerializer.Deserialize<List<User>>(File.ReadAllText(usersFile))!
            : new List<User>();
        return users;
    }

    public (bool Success, string Message) AddUser(User user)
    {
        if (UsernameExist(user.Username))
            return (false, "username exists");
 
        if (EmailExist(user.Email))
            return (false, "email exists");
        
        var users = GetUsers();
        users.Add(user);
        SetUsers(users);
        
        return (true, "");
    }
    
    public void SetUsers(List<User> users)
    {
        var usersFile = "Database/Users.json";
        File.WriteAllText(usersFile, JsonSerializer.Serialize(users));
    }
    
    public List<Post> GetPosts()
    {
        var postsFile = "Database/Posts.json";
        var posts = File.Exists(postsFile)
            ? JsonSerializer.Deserialize<List<Post>>(File.ReadAllText(postsFile))!
            : new List<Post>();
        return posts;
    }
    
    public void SetPosts(List<Post> posts)
    {
        var postsFile = "Database/Posts.json";
        File.WriteAllText(postsFile, JsonSerializer.Serialize(posts));
    }
    
    public bool UsernameExist(string username)
    {
        var users = GetUsers();
        return (users.Any(u => u.Username == username));
    }
    
    public bool EmailExist(string email)
    {
        var users = GetUsers();
        return (users.Any(u => u.Email == email));
    }

    public bool LoginCheck(string username, string password)
    {
        return (GetUsers().FirstOrDefault(u => u.Username == username && u.Password == password) != null);
    }
    
}
