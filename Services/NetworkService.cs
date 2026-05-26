namespace MinimalAPI.Services;

public class NetworkService
{
    private readonly Dictionary<string, List<string>> _network = new()
    {
        { "Alice", new List<string> { "Bob", "Clara" } },
        { "Bob", new List<string> { "Alice", "Dave" } },
        { "Clara", new List<string> { "Alice", "Eve" } },
        { "Dave", new List<string> { "Bob" } },
        { "Eve", new List<string> { "Clara", "Frank" } },
        { "Frank", new List<string> { "Eve" } }
    };

    public bool IsConnected(string from, string to)
    {
        if (!_network.ContainsKey(from) || !_network.ContainsKey(to)) 
            return false;
        
        var visited = new HashSet<string>();
        var queue = new Queue<string>();
        
        queue.Enqueue(from);
        visited.Add(from);

        while (queue.Count > 0)
        {
            var current =  queue.Dequeue();

            if (current == to)
                return true;

            foreach (var neighbor in _network[current])
            {
                if (!visited.Contains(neighbor))
                {
                    visited.Add(neighbor);
                    queue.Enqueue(neighbor);
                }
            }
        }
        return false;
    }
}