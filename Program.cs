using Microsoft.AspNetCore.Mvc;
using MinimalApiResponse;
using MinimalApiResponse.Models;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
// redirect https
app.UseHttpsRedirection();

app.MapGet("/", () => Results.Json("Blog"));

// Posts API
app.MapGet("/api/Posts", (int count) =>
{
    var posts = Data.Posts.Take(count);

    return Results.Ok(posts);
});

app.MapGet("/api/Posts/{id}", (int id) =>
{
    var post = Data.Posts.FirstOrDefault(p => p.Id == id);
    if (post is null)
        return Results.NotFound(new
        {
            Message = "Post not found"
        });

    return Results.Ok(post);
});

app.MapPost("/api/Posts", ([FromBody] Post newPost) =>
{
    Data.Posts.Add(newPost);

    return Results.Created("Posts", newPost.Id);
});

app.MapDelete("/api/Posts/{id}", ([FromRoute] int id) =>
{
    var post = Data.Posts.FirstOrDefault(p => p.Id == id);
    if (post is null)
        return Results.NotFound();

    Data.Posts.Remove(post);

    //return Results.NoContent();
    return Results.StatusCode(204);
});

app.MapPut("/api/Posts/{id}", ([FromRoute] int id, [FromBody] Post updatedPost) =>
{
    var postIndex = Data.Posts.FindIndex(p => p.Id == id);
    if (postIndex < 0)
        return Results.NotFound();

    Data.Posts[postIndex] = updatedPost;

    return Results.NoContent();
});


app.Run();
