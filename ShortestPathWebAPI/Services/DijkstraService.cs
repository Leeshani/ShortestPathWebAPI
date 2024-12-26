using ShortestPathWebAPI.Models;

namespace ShortestPathAPI.Services
{
    public class DijkstraService
    {
        public ShortestPathData ShortestPath(string fromNode, string toNode, List<Node> graphNodes)
        {
            var distances = new Dictionary<string, int>();
            var previousNodes = new Dictionary<string, string>();
            var unvisitedNodes = new HashSet<string>();

            try
            {
                // Initialize distances
                foreach (var node in graphNodes)
                {
                    distances[node.Name] = int.MaxValue;
                    unvisitedNodes.Add(node.Name);
                }
                distances[fromNode] = 0;

                while (unvisitedNodes.Count > 0)
                {
                    // Get the node with the smallest distance
                    var currentNode = unvisitedNodes.OrderBy(n => distances[n]).First();
                    if (currentNode == toNode)
                        break;

                    unvisitedNodes.Remove(currentNode); var currentDistance = distances[currentNode];

                    // Get adjacent nodes
                    var node = graphNodes.FirstOrDefault(n => n.Name == currentNode);
                    if (node != null)
                    {
                        foreach (var edge in node.Edges)
                        {
                            var neighbor = edge.Destination;
                            if (unvisitedNodes.Contains(neighbor))
                            {
                                var newDistance = currentDistance + edge.Distance;
                                if (newDistance < distances[neighbor])
                                {
                                    distances[neighbor] = newDistance;
                                    previousNodes[neighbor] = currentNode;
                                }
                            }
                        }
                    }
                }

                // Construct the shortest path
                var path = new List<string>();
                var current = toNode;
                while (current != fromNode)
                {
                    path.Insert(0, current);
                    current = previousNodes[current];
                }
                path.Insert(0, fromNode);

                return new ShortestPathData
                {
                    NodeNames = path,
                    Distance = distances[toNode]
                };
            }
            catch (Exception)
            {

                throw;
            }           
        }
    }
}
