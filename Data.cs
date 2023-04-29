using MinimalApiResponse.Models;

namespace MinimalApiResponse;

public class Data {
    public static List<Post> Posts = new List<Post>
    {
        new Post { Id = 1, Title = "Post 1",
            Content = "Content 1", Author = "Younes",
            Slug = "post-1" },
        new Post { Id = 2, Title = "Post 2",
            Content = "Content 2", Author = "Momen",
            Slug = "post-2" },
        new Post { Id = 3, Title = "Post 3",
            Content = "Content 3", Author = "Ali",
            Slug = "post-3" },
        new Post { Id = 4, Title = "Post 4",
            Content = "Content 4", Author = "Mohammad",
            Slug = "post-4" },
    };
}
