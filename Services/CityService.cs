namespace MinimalAPI.Services;

public class CityService
{
    private readonly Dictionary<string, List<(string City, int Cost)>> _map = new()
    {
        { "Alice", new() { ("Bob", 4), ("Clara", 3) } },
        { "Bob",   new() { ("Alice", 4), ("Dave", 2) } },
        { "Clara", new() { ("Alice", 3), ("Eve", 1) } },
        { "Dave",  new() { ("Bob", 2) } },
        { "Eve",   new() { ("Clara", 1), ("Frank", 5) } },
        { "Frank", new() { ("Eve", 5) } }
    };

    public (int cost, List<string> path)? FindCheapest(string from, string to)
    {
        if (!_map.ContainsKey(from) || !_map.ContainsKey(to))
            return null;
        
        // Cheapest knows cost to reach each city - start at infinity
        var costs = _map.Keys.ToDictionary(k => k, _ => int.MaxValue);
        costs[from] = 0;

        var previous = new Dictionary<string, string?>();

        var queue = new PriorityQueue<string, int>();
        queue.Enqueue(from, 0);

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();

            if (current == to)
                break;

            foreach (var (neighbour, cost) in _map[current])
            {
                var newCost = costs[current] + cost;

                if (newCost < costs[neighbour])
                {
                    costs[neighbour] = newCost;
                    previous[neighbour] = current;
                    queue.Enqueue(neighbour, newCost);
                }
            }
        }

        if (costs[to] == int.MaxValue)
            return null;
        
        // Reconstruct path by walking backwards
        var path = new List<string>();
        var step = to;
        while (step != null)
        {
            path.Add(step);
            previous.TryGetValue(step, out step);
        }

        path.Reverse();

        return (costs[to], path);
    }
}