using System;
using System.Collections.Generic;
using System.Linq;

namespace Semestrovka
{
    public class Graph
    {
        public HashSet<int> Ids;
        public List<Node> nodes;
        List<Tuple<Node, Node>> pairsList;
        bool isPairSetted;

        public Graph()
        {
            Ids = new HashSet<int>();
            nodes = new List<Node>();
            pairsList = new List<Tuple<Node, Node>>();
            isPairSetted = false;
        }

        public void AddNodeById(int id)
        {
            var node = new Node(id);
            AddNode(node);
        }

        public void AddNode(Node node)
        {
            if (!Ids.Contains(node.Id))
            {
                Ids.Add(node.Id);
                nodes.Add(node);
            }
            else
                throw new Exception("Нода с таким ID уже существует!");
        }

        public void RemoveNode(Node removeNode)
        {
            if (Ids.Contains(removeNode.Id))
            {
                Ids.Remove(removeNode.Id);
                foreach (Node node in nodes.Where(x => x.IncidentNodes.Contains(removeNode)))
                {
                    node.Disconnect(removeNode);
                }
                nodes.Remove(removeNode);
            }
            else
            {
                throw new Exception("Ноды с таким ID не существует!");
            }
        }

        public void ConnectNodesById(int firstNode, int secondNode) => FindNode(firstNode).Connect(FindNode(secondNode));

        private void MakePairs()
        {
            Node nodeWithPairs = null;
            foreach (Node node in nodes)
            {
                if (node.IncidentNodes.Count() == 1)
                {
                    AddPairInList(node);
                    return;
                }
                if (node.IncidentNodes.Count() > 1 && nodeWithPairs == null)
                {
                    nodeWithPairs = node;
                }
            }
            if (nodeWithPairs != null)
            {
                AddPairInList(nodeWithPairs);
                return;
            }
            isPairSetted = true;
        }

        private void AddPairInList(Node node)
        {
            var pairNode = node.IncidentNodes.First();
            pairsList.Add(new Tuple<Node, Node>(node, pairNode));
            RemoveNode(node);
            RemoveNode(pairNode);
        }

        public void GetPairs()
        {
            while (!isPairSetted) MakePairs();
            foreach (Tuple<Node,Node> tuple in pairsList)
                Console.WriteLine("Нода " + tuple.Item1.Id + " является парой с " + tuple.Item2.Id);
        }

       Node FindNode(int id) => nodes.FirstOrDefault(x => x.Id == id);
    }
}
