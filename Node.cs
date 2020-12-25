using System;
using System.Collections.Generic;

namespace Semestrovka
{
    public class Node
    {
        public readonly int Id;
        private readonly List<Node> incidentNodes;

        public Node(int id)
        {
            Id = id;
            incidentNodes = new List<Node>();
        }

        public IEnumerable<Node> IncidentNodes
        {
            get
            {
                foreach (var node in incidentNodes)
                    yield return node;
            }
        }

        public void Connect(Node node)
        {
            if (!incidentNodes.Contains(node) && Id != node.Id)
            {
                incidentNodes.Add(node);
                node.incidentNodes.Add(this);
            }
        }

        public void Disconnect(Node node) => incidentNodes.Remove(node);

        public override string ToString()
        {
            var nodes = string.Empty;
            foreach (var node in IncidentNodes)
            {
                nodes += node.Id + " ";
            }
            if (nodes != String.Empty)
                return "ID:" + this.Id  +
                       " соединена с вершинами : " + nodes.TrimEnd();
            return "Вершина с ID:" + this.Id + " не соединена";
        }
    }
}
