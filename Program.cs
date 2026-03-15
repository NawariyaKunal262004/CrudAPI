/*
 * ==============================================
 * CRUD API - Blog Management System
 * ==============================================
 * 
 * This is a RESTful API that demonstrates Create, Read, Update, Delete (CRUD) operations
 * on blog posts using ASP.NET Core minimal APIs with in-memory data storage.
 * 
 * ENDPOINTS:
 *   GET    /              - Root endpoint
 *   GET    /blogs         - Get all blogs
 *   GET    /blogs/{id}    - Get specific blog by ID
 *   POST   /blogs         - Create new blog
 *   PUT    /blogs/{id}    - Update blog by ID
 *   DELETE /blogs/{id}    - Delete blog by ID
 *   GET    /debug         - Get total blog count
 * 
 * DATA MODEL:
 *   Blog: { Title (string), Body (string) }
 * 
 * STORAGE:
 *   In-memory List<Blog> initialized with 2 sample blog posts
 *   Data persists during runtime but is lost on application restart
 * 
 * FEATURES:
 *   - Full CRUD operations on blog collection
 *   - Proper HTTP status codes (200, 201, 204, 404)
 *   - Automatic JSON serialization/deserialization
 *   - Basic validation for valid blog IDs
 * 
 * ==============================================
 */

public partial class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();

        var blogs = new List<Blog>
        {
            new Blog { Title = "My First Post", Body = "This is my first post" },
            new Blog { Title = "My Second Post", Body = "This is my second post" }
        };

        // Read endpoints
        app.MapGet("/", () => "I am root");
        
        app.MapGet("/blogs", () => blogs);
        
        app.MapGet("/blogs/{id}", (int id) =>
        {
            if (id < 0 || id >= blogs.Count)
                return Results.NotFound();
            return Results.Ok(blogs[id]);
        });

        // Create endpoint
        app.MapPost("/blogs", (Blog blog) =>
        {
            blogs.Add(blog);
            return Results.Created($"/blogs/{blogs.Count - 1}", blog);
        });

        // Delete endpoint
        app.MapDelete("/blogs/{id}", (int id) =>
        {
            if (id < 0 || id >= blogs.Count)
                return Results.NotFound();
            blogs.RemoveAt(id);
            return Results.NoContent();
        });

        // Update endpoint
        app.MapPut("/blogs/{id}", (int id, Blog blog) =>
        {
            if (id < 0 || id >= blogs.Count)
                return Results.NotFound();
            blogs[id] = blog;
            return Results.Ok(blog);
        });

        // Debug endpoint
        app.MapGet("/debug", () => blogs.Count);
        
        app.Run();
    }
}

public class Blog
{
    public required string Title { get; set; }
    public required string Body { get; set; }
}

