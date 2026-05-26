# MinimalAPI — ASP.NET Core Learning Project

A small C# backend project built to explore ASP.NET Core web APIs and foundational graph algorithms. Created as part of first-year backend programming studies.

---

## Purpose

This project was built to practise the following topics recommended for study:

- Minimal API vs Controller API in ASP.NET Core
- BFS (Breadth-First Search)
- DFS (Depth-First Search)
- Dijkstra's Algorithm

---

## Project Structure

```
MinimalAPI/
├── Controllers/
│   ├── BooksController.cs      # Controller API example
│   ├── NetworkController.cs    # BFS and DFS endpoints
│   └── CitiesController.cs     # Dijkstra endpoint
├── Services/
│   ├── BookService.cs          # Book data and retrieval logic
│   ├── NetworkService.cs       # Graph traversal (BFS + DFS)
│   └── CityService.cs          # Weighted graph (Dijkstra)
└── Program.cs                  # Composition root, service registration
```

---

## Endpoints

### Books — Controller API
| Method | Route | Description |
|--------|-------|-------------|
| GET | `/api/books` | Returns all books |
| GET | `/api/books/{id}` | Returns a single book or 404 |

### Network — BFS & DFS
| Method | Route | Description |
|--------|-------|-------------|
| GET | `/api/network/connected?from=X&to=Y` | BFS — checks if two people are connected |
| GET | `/api/network/path?from=X&to=Y` | DFS — returns the actual path between two people |

### Cities — Dijkstra
| Method | Route | Description |
|--------|-------|-------------|
| GET | `/api/cities/cheapest?from=X&to=Y` | Returns the cheapest route and its total cost |

---

## Concepts Covered

### ASP.NET Core
- **Minimal API** — defining routes inline in `Program.cs` with lambda handlers
- **Controller API** — structured endpoints using `ControllerBase`, `[ApiController]`, `[HttpGet]`, `[Route]`
- **Dependency Injection** — services registered in `Program.cs` and injected via constructors
- **`[FromQuery]`** — binding URL query parameters to method arguments
- **HTTP status codes** — returning `Ok()`, `NotFound()` with appropriate response bodies
- **Composition root pattern** — `Program.cs` wires everything together; services contain all logic

### Algorithms

**BFS (Breadth-First Search)**
- Explores a graph outward ring by ring from a starting node
- Uses a `Queue<T>` (FIFO) and a `HashSet<T>` to track visited nodes
- Guarantees the shortest path in an unweighted graph
- Used here to check whether two people in a network are connected

**DFS (Depth-First Search)**
- Explores as deep as possible down one path before backtracking
- Implemented recursively, using the call stack implicitly
- Uses a `HashSet<T>` for visited tracking and a `List<T>` as a breadcrumb trail
- Backtracking via `RemoveAt(path.Count - 1)` undoes dead-end steps
- Used here to find and return an actual path between two people

**Dijkstra's Algorithm**
- Finds the cheapest path through a weighted graph
- Uses a `PriorityQueue<T, int>` — always processes the lowest-cost node next
- Tracks the best known cost to each node, only updating when a cheaper route is found
- Reconstructs the path by walking backwards through a `previous` dictionary
- Uses `int.MaxValue` as a sentinel for "not yet reached"

---

## Running the Project

```bash
dotnet run
```

The API will be available at `http://localhost:5160`.

---

## Tech Stack

| Frameworks   | Languages |
|--------------|-----------|
| .NET 10      | C#        |
| ASP.NET Core |           |

---

<p align="center">
  <sub>Made with ❤️, caffeine, and a bull terrier supervising.</sub>
</p>
