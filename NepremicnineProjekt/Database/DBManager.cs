using System.Text.Json;

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
}