# CRUD API - Blog Management System

## Project Overview

This is a **comprehensive CRUD (Create, Read, Update, Delete) API** built with ASP.NET Core that demonstrates complete blog post management functionality. It showcases practical implementation of RESTful API principles using minimal APIs and in-memory data storage.

### Key Features
- ✅ **Create** - Add new blog posts
- ✅ **Read** - Retrieve all blogs or a specific blog by ID
- ✅ **Update** - Modify existing blog posts
- ✅ **Delete** - Remove blog posts
- ✅ **Error Handling** - Proper HTTP status codes (201, 200, 404, 204)
- ✅ **In-Memory Storage** - Fast data persistence during runtime
- ✅ **JSON Support** - Automatic JSON serialization/deserialization
- ✅ **Comprehensive Endpoints** - Multiple API routes with full CRUD operations

---

## Project Structure

```
CrudApi/
├── Program.cs                      # Main application with all CRUD endpoints and Blog model
├── CrudAPi.csproj                  # Project file with framework settings
├── appsettings.json                # Application configuration settings
├── appsettings.Development.json    # Development-specific configuration
├── request.http                    # REST client file for testing endpoints
├── Properties/
│   └── launchSettings.json         # Development server launch configurations
├── obj/                            # Build artifacts (auto-generated)
└── bin/                            # Compiled binaries (auto-generated)
```

---

## Technical Details

### Framework & Version
- **Target Framework:** .NET 10.0
- **SDK:** Microsoft.NET.Sdk.Web
- **Language Features:**
  - Nullable reference types enabled
  - Implicit using statements enabled
  - Required properties support

### Data Model

#### Blog Class
```csharp
public class Blog
{
    public required string Title { get; set; }    // Blog post title
    public required string Body { get; set; }     // Blog post content
}
```

---

## API Endpoints

### GET Endpoints (Read Operations)

#### 1. GET / - Root Endpoint
**Description:** Returns a greeting message  
**URL:** `http://localhost:5128/`  
**Response:** 
```
"I am root"
```

#### 2. GET /blogs - Retrieve All Blogs
**Description:** Returns a list of all blog posts  
**URL:** `http://localhost:5128/blogs`  
**Response Code:** 200 OK  
**Response Example:**
```json
[
  {
    "title": "My First Post",
    "body": "This is my first post"
  },
  {
    "title": "My Second Post",
    "body": "This is my second post"
  }
]
```

#### 3. GET /blogs/{id} - Retrieve Specific Blog
**Description:** Retrieves a blog post by its index ID  
**URL:** `http://localhost:5128/blogs/0`  
**Parameters:**
| Parameter | Type | Description |
|-----------|------|-------------|
| id | int | Index of the blog (0-based, required) |

**Response Codes:**
- `200 OK` - If blog found
- `404 Not Found` - If blog ID doesn't exist

**Response Example (Success):**
```json
{
  "title": "My First Post",
  "body": "This is my first post"
}
```

---

### POST Endpoint (Create Operation)

#### POST /blogs - Create New Blog
**Description:** Creates a new blog post and adds it to the collection  
**URL:** `http://localhost:5128/blogs`  
**Method:** POST  
**Response Code:** 201 Created  
**Request Body:**
```json
{
  "title": "My New Blog",
  "body": "This is the content of my new blog"
}
```

**Response Headers:**
- `Location: /blogs/{id}` - Points to the newly created resource

**Response Example:**
```json
{
  "title": "My New Blog",
  "body": "This is the content of my new blog"
}
```

---

### PUT Endpoint (Update Operation)

#### PUT /blogs/{id} - Update Existing Blog
**Description:** Updates an existing blog post completely  
**URL:** `http://localhost:5128/blogs/0`  
**Method:** PUT  
**Response Code:** 200 OK  
**Parameters:**
| Parameter | Type | Description |
|-----------|------|-------------|
| id | int | Index of the blog to update |

**Request Body:**
```json
{
  "title": "Updated Title",
  "body": "Updated content"
}
```

**Response Codes:**
- `200 OK` - If update successful
- `404 Not Found` - If blog ID doesn't exist

**Response Example (Success):**
```json
{
  "title": "Updated Title",
  "body": "Updated content"
}
```

---

### DELETE Endpoint (Delete Operation)

#### DELETE /blogs/{id} - Delete Blog
**Description:** Deletes a blog post from the collection  
**URL:** `http://localhost:5128/blogs/1`  
**Method:** DELETE  
**Response Code:** 204 No Content  
**Parameters:**
| Parameter | Type | Description |
|-----------|------|-------------|
| id | int | Index of the blog to delete |

**Response Codes:**
- `204 No Content` - If deletion successful (no response body)
- `404 Not Found` - If blog ID doesn't exist

---

### Utility Endpoints

#### GET /debug - Get Blog Count
**Description:** Returns the total number of blogs in the system (for debugging)  
**URL:** `http://localhost:5128/debug`  
**Response:**
```
2
```

---

## How to Run

### Prerequisites
- .NET 10.0 SDK or higher installed
- A terminal or command prompt
- Optional: REST client (Postman, Thunder Client, or VS Code REST Client extension)

### Steps

1. **Navigate to the project directory:**
   ```bash
   cd c:\dotnet tut\CrudApi
   ```

2. **Build the project (optional):**
   ```bash
   dotnet build
   ```

3. **Run the application:**
   ```bash
   dotnet run
   ```

4. **Expected Output:**
   ```
   info: Microsoft.Hosting.Lifetime[14]
      Now listening on: http://localhost:5128
      Now listening on: https://localhost:7128
   ```

5. **Access the API:**
   - Open browser or REST client
   - Navigate to `http://localhost:5128/blogs`

---

## Testing the API

### Using request.http File

The project includes a `request.http` file with pre-configured test requests. Open it in VS Code with the REST Client extension:

```http
### Get root
GET http://localhost:5128/

### Get all blogs
GET http://localhost:5128/blogs

### Get specific blog
GET http://localhost:5128/blogs/1

### Create new blog
POST http://localhost:5128/blogs
Content-Type: application/json

{
  "title":"My third blog",
  "body":"This is my third blog"
}

### Delete a blog
DELETE http://localhost:5128/blogs/2

### Update a blog
PUT http://localhost:5128/blogs/0
Content-Type: application/json

{
  "title":"My Fourth blog",
  "body":"This is my Fourth blog"
}

### Check blog count
GET http://localhost:5128/debug
```

### Using cURL

```bash
# Get all blogs
curl http://localhost:5128/blogs

# Get specific blog
curl http://localhost:5128/blogs/0

# Create new blog
curl -X POST http://localhost:5128/blogs \
  -H "Content-Type: application/json" \
  -d '{"title":"New Blog","body":"New content"}'

# Update blog
curl -X PUT http://localhost:5128/blogs/0 \
  -H "Content-Type: application/json" \
  -d '{"title":"Updated","body":"Updated content"}'

# Delete blog
curl -X DELETE http://localhost:5128/blogs/1

# Check debug info
curl http://localhost:5128/debug
```

### Using Postman

1. **Create Collection:** "Blog CRUD API"
2. **Create Requests:**
   - GET `{{url}}/blogs` - Get all blogs
   - GET `{{url}}/blogs/0` - Get specific blog
   - POST `{{url}}/blogs` - Create blog
   - PUT `{{url}}/blogs/0` - Update blog
   - DELETE `{{url}}/blogs/1` - Delete blog

3. **Set Variables:**
   - url: `http://localhost:5128`

---

## Code Structure Explanation

### Main Application Setup
```csharp
var builder = WebApplication.CreateBuilder(args);  // Configure app
var app = builder.Build();                          // Build app instance
```

### In-Memory Data Storage
```csharp
var blogs = new List<Blog> { ... };  // Stores blog posts in memory during runtime
```

### Endpoint Mapping
- **MapGet()** - Maps HTTP GET requests
- **MapPost()** - Maps HTTP POST requests  
- **MapPut()** - Maps HTTP PUT requests
- **MapDelete()** - Maps HTTP DELETE requests

### Response Results
- `Results.Ok(data)` - Returns 200 with data
- `Results.Created(uri, data)` - Returns 201 with location header
- `Results.NoContent()` - Returns 204 (no content)
- `Results.NotFound()` - Returns 404 (resource not found)

---

## Important Concepts

### HTTP Status Codes Used
| Code | Meaning | When Used |
|------|---------|-----------|
| 200 | OK | Successful GET, PUT, DELETE operations |
| 201 | Created | Successful POST operation |
| 204 | No Content | Successful DELETE with no response body |
| 404 | Not Found | Requested blog ID doesn't exist |

### REST Principles Demonstrated
- **Resource-Based URLs** - `/blogs` represents the blogs collection
- **HTTP Methods** - Different operations use appropriate HTTP verbs
- **Status Codes** - Proper HTTP status codes for each response
- **Content Negotiation** - Automatic JSON serialization

### In-Memory Storage Limitations
- **Data Persistence:** Data is lost when application restarts
- **Single Instance:** Each application instance has separate data
- **No Concurrency:** Limited for multi-threaded scenarios

---

## Enhancement Ideas

1. **Database Integration:** Replace List with Entity Framework Core and SQL Server
2. **Authentication:** Add JWT token-based authentication
3. **Authorization:** Implement role-based access control
4. **Validation:** Add data validation before creating/updating blogs
5. **Pagination:** Implement pagination for the GET /blogs endpoint
6. **Search Filters:** Add filtering by title or content
7. **Logging:** Add comprehensive logging
8. **Documentation:** Add Swagger/OpenAPI documentation
9. **Error Handling:** Implement global exception handling middleware

---

## Learning Outcomes

This project teaches:
- ✅ ASP.NET Core minimal APIs
- ✅ RESTful API design principles
- ✅ CRUD operations implementation
- ✅ HTTP methods and status codes
- ✅ Route parameters and binding
- ✅ JSON serialization/deserialization
- ✅ Error handling patterns
- ✅ In-memory data structures

---

## Troubleshooting

| Issue | Solution |
|-------|----------|
| Port 5128 already in use | Change port in `launchSettings.json` |
| 404 error on endpoints | Ensure app is running and use correct base URL |
| JSON parsing errors | Verify JSON format in request body |
| Cannot create blog | Check that title and body are provided as strings |
| `required` keyword errors | Update .NET version or enable nullable reference types |

---

## Configuration Files

### appsettings.json
```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

**Settings Explanation:**
- **Logging:** Configures log verbosity levels
- **AllowedHosts:** Controls which host headers are accepted

---

## Project Information

| Detail | Value |
|--------|-------|
| Project Name | CrudApi |
| Framework | .NET 10.0 |
| SDK | Microsoft.NET.Sdk.Web |
| Type | ASP.NET Core Web API |
| Data Storage | In-Memory List<T> |
| API Style | Minimal APIs |

---

## Related Resources

- [ASP.NET Core Minimal APIs](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis/)
- [RESTful API Design](https://restfulapi.net/)
- [HTTP Methods Reference](https://developer.mozilla.org/en-US/docs/Web/HTTP/Methods)
- [HTTP Status Codes](https://developer.mozilla.org/en-US/docs/Web/HTTP/Status)
- [.NET CLI Commands](https://learn.microsoft.com/en-us/dotnet/core/tools/)
- [Entity Framework Core (for database)](https://learn.microsoft.com/en-us/ef/core/)

---

## License

This is a learning project demonstrating CRUD API implementation with ASP.NET Core.

---

**Built with ASP.NET Core Minimal APIs** | **.NET 10.0** | **RESTful API**
# CrudAPI
