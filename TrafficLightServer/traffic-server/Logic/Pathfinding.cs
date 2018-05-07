using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficLightPanel;

namespace traffic_server.Logic
{
    public class Pathfinder
    {
        private Node[,] nodes;

        public Pathfinder(Tile[] tiles)
        {      
            this.nodes = new Node[tiles.Length, tiles.Length];

            foreach (Tile t in tiles)
            {
                bool walkable = true;

                if (t.TypeTile == "MiddleRoadVertical" || t.TypeTile == "MiddleRoadHorizontal")
                    walkable = false;

                this.nodes[t.RectLoc.X, t.RectLoc.Y] = new Node(t.RectLoc.Location, walkable);
            }

            //for (int y = 0; y < this.nodes.GetUpperBound(1); y++)
            //{
            //    for (int x = 0; x < this.nodes.GetUpperBound(0); x++)
            //    {
            //        if (this.nodes[x, y] == null)
            //            this.nodes[x, y] = new Node(new Point(x, y), true);
            //    }
            //}
        }

        public Stack<Node> FindPath(Point startPoint, Point endPoint)
        {
            Node start = new Node(startPoint, true);
            Node end = new Node(endPoint, true);

            Stack<Node> path = new Stack<Node>();
            List<Node> openList = new List<Node>();
            List<Node> closedList = new List<Node>();
            List<Node> adjacencies;
            Node current = start;
            openList.Add(start);

            while (openList.Count != 0 && !closedList.Exists(x=> x.Position == end.Position))
            {
                current = openList[0];
                openList.Remove(current);
                closedList.Add(current);
                adjacencies = this.getAdjacentNodes(current);

                foreach (Node n in adjacencies)
                {
                    if (!closedList.Contains(n) && n != null && n.Walkable)
                    {
                        if (!openList.Contains(n))
                        {
                            n.Parent = current;
                            n.DistanceToTarget = Math.Abs(n.Position.X - endPoint.X) + Math.Abs(n.Position.Y - endPoint.Y);
                            openList.Add(n);
                            openList = openList.OrderBy(node => node.DistanceToTarget).ToList<Node>();
                        }
                    }
                }
            }

            Node temp = closedList[closedList.IndexOf(current)];
            while (temp != null && temp.Parent != start)
            {
                path.Push(temp);
                temp = temp.Parent;
            }
            return path;
        }

        private List<Node> getAdjacentNodes(Node n)
        {
            List<Node> temp = new List<Node>();

            if (n.Position.X + 10 < this.nodes.GetUpperBound(0))
            {
                temp.Add(this.nodes[n.Position.X +10, n.Position.Y]);
            }
            if (n.Position.X - 10 >= 0)
            {
                temp.Add(this.nodes[n.Position.X - 10, n.Position.Y]);
            }
            if (n.Position.Y - 10 >= 0)
            {
                temp.Add(this.nodes[n.Position.X, n.Position.Y - 10]);
            }
            if (n.Position.Y + 10 < this.nodes.GetUpperBound(1))
            {
                temp.Add(this.nodes[n.Position.X, n.Position.Y + 10]);
            }
            return temp;
        }
    }
    public class Node
    {
        public const int NODE_SIZE = 10;
        public Node Parent { get; set; }
        public Point Position { get; private set; }
        public Point Center
        {
            get
            {
                return new Point(Position.X + NODE_SIZE / 2, Position.Y + NODE_SIZE / 2);
            }
        }
        public float DistanceToTarget { get; set; }

        public bool Walkable { get; private set; }

        public Node(Point pos, bool walkable)
        {
            this.Parent = null;
            this.Position = pos;
            this.DistanceToTarget = -1;
            this.Walkable = walkable;
        }
    }
}
