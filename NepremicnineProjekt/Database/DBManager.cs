using System.Text.Json;
using NepremicnineProjekt;

public class DBManager
{
    private static readonly string[] Colors =
    {
        "#1F2937",
        "#1E3A8A",
        "#064E3B",
        "#7C2D12",
        "#4C1D95",
        "#831843"
    };
    private static readonly Random _random = new();
    
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

    public (bool Success, string Message) AddUser(User user)
    {
        if (UsernameExist(user.Username))
            return (false, "username exists");
        
        if(!ValidEmail(user.Email))
            return (false, "invalid email format");
 
        if (EmailExist(user.Email))
            return (false, "email exists");
        
        var users = GetUsers();
        users.Add(user);
        SetUsers(users);
        
        return (true, "");
    }

    public Post? GetPost(int id)
    {
        var posts = GetPosts();
        return posts.FirstOrDefault(p => p.Id == id);
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

        var options = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        File.WriteAllText(postsFile, JsonSerializer.Serialize(posts, options));
    }
    
    public (bool Success, string Message) AddPost(Post post)
    {
        var posts = GetPosts();

        if (!IsValueNumber(post.Price)) 
            return (false, "price should be a number");
 
        
        if (!IsImageUrlValid(post.ImageUrl))
            return (false, "imageUrl is not in right format (https://)");
        
        post.Color = Colors[_random.Next(Colors.Length)];
        
        
        post.Id = posts.Any() ? posts.Max(p => p.Id) + 1 : 1;
        posts.Add(post);
        SetPosts(posts);
        
        return (true, "");
    }

    public bool DeletePost(int id)
    {
        var postsFile = "Database/Posts.json";
        if (!File.Exists(postsFile))
            return false;

        var posts = JsonSerializer.Deserialize<List<Post>>(File.ReadAllText(postsFile)) ?? new List<Post>();

        var postToRemove = posts.FirstOrDefault(p => p.Id == id);
        if (postToRemove == null)
            return false;

        posts.Remove(postToRemove);

        File.WriteAllText(postsFile, JsonSerializer.Serialize(posts, new JsonSerializerOptions
        {
            WriteIndented = true
        }));

        return true;
    }
    
    public bool IsValueNumber(string value)
    {
        return int.TryParse(value, out _);
    }
    
    public bool IsImageUrlValid(string imageUrl)
    {
        if (string.IsNullOrWhiteSpace(imageUrl))
            return false;

        return Uri.TryCreate(imageUrl, UriKind.Absolute, out var uri)
               && (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps);
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
    
    public bool ValidEmail(string email)
    {
        return email.Contains("@") && email.Contains(".");
    }

    public bool LoginCheck(string username, string password)
    {
        return (GetUsers().FirstOrDefault(u => u.Username == username && u.Password == password) != null);
    }
    
}
