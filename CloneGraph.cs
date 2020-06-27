// Use DFS and a hashmap/dictionary to achieve cloning a graph

public class Solution {
    Dictionary<int, Node> dict = new Dictionary<int, Node>();

    public Node CloneGraph(Node node) {
        if(node == null)
            return null;
        
        Node newNode = new Node(node.val);
        dict.Add(newNode.val, newNode);
        foreach(var neighbor in node.neighbors)
        {
            if(dict.ContainsKey(neighbor.val))
                newNode.neighbors.Add(dict[neighbor.val]);            
            else
            {
                newNode.neighbors.Add(CloneGraph(neighbor));
            }
        }
        return newNode;
    }
}
