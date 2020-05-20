using DevExpress.Web.ASPxDiagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiagramBindToList.Models
{
    public class Workflow
    {
        public List<Node> Objects { set; get; }
        public List<Edge> Connections { set; get; }
    }

    public static class WorkflowDataProvider
    {
        #region Load methods
        public static Workflow LoadData()
        {
            return new Workflow
            {
                Connections = GetConnections(),
                Objects = GetObjects()
            };
        }

        public static List<Node> GetObjects()
        {
            var data = HttpContext.Current.Session["DiagramObjects"] as List<Node>;
            if (data == null)
            {
                data = new List<Node>
                {
                    new Node(1, DiagramShapeType.Terminator.ToString(), "A new ticket", 96, 48),
                    new Node(2, DiagramShapeType.Process.ToString(), "Analyze the issue", 168, 72),
                    new Node(3, DiagramShapeType.Diamond.ToString(), "Do we have all \ninformation \nto work with?", 168, 96, "stroke: red"),
                    new Node(4, DiagramShapeType.Terminator.ToString(), "Answered", 96, 48, textStyle:"fill: darkgreen; font-weight: bold"),
                    new Node(5, DiagramShapeType.Rectangle.ToString(), "Request additional information or clarify the scenario", 144, 72),
                    new Node(6, DiagramShapeType.Rectangle.ToString(), "Prepare an example in Code Central", 168, 72),
                    new Node(7, DiagramShapeType.Rectangle.ToString(), "Update the documentation", 168, 72),
                    new Node(8, DiagramShapeType.Rectangle.ToString(), "Process the ticket", 168, 72),
                    new Node(9, DiagramShapeType.Rectangle.ToString(), "Work with the R&D team", 144, 72)
                };
                HttpContext.Current.Session["DiagramObjects"] = data;
            }
            return data;
        }

        public static List<Edge> GetConnections()
        {
            var data = HttpContext.Current.Session["DiagramConnections"] as List<Edge>;
            if (data == null)
            {
                data = new List<Edge>
                {
                    new Edge(1, null, 1, 2),
                    new Edge(2, null, 2, 3),
                    new Edge(3, "No", 3, 5),
                    new Edge(4, null, 5, 2),
                    new Edge(5, null, 8, 4),
                    new Edge(6, string.Empty, 4, 6),
                    new Edge(9, string.Empty, 4, 7),
                    new Edge(10, "Yes", 3, 8),
                    new Edge(11, "Need developer assistance?", 8, 9),
                    new Edge(12, null, 9, 4)
                };
                HttpContext.Current.Session["DiagramConnections"] = data;
            }
            return data;
        }
        #endregion

        #region Insert methods
        public static int InsertObject(Node item)
        {
            List<Node> objects = GetObjects();
            item.ID = objects.Count == 0 ? 1 : objects.Max(i => i.ID) + 1;
            objects.Add(item);
            return item.ID;
        }

        public static int InsertConnection(Edge item)
        {
            List<Edge> connections = GetConnections();
            item.ID = connections.Count == 0 ? 1 : connections.Max(i => i.ID) + 1;
            connections.Add(item);
            return item.ID;
        }
        #endregion

        #region Update methods
        public static void UpdateObject(Node item)
        {
            List<Node> objects = GetObjects();
            var objectToUpdate = objects.First(i => i.ID == item.ID);

            objectToUpdate.Type = item.Type;
            objectToUpdate.Text = item.Text;
            objectToUpdate.Width = item.Width;
            objectToUpdate.Height = item.Height;
            objectToUpdate.Style = item.Style;
            objectToUpdate.TextStyle = item.TextStyle;
        }

        public static void UpdateConnection(Edge item)
        {
            List<Edge> connections = GetConnections();
            var itemToUpdate = connections.First(i => i.ID == item.ID);

            itemToUpdate.FromID = item.FromID;
            itemToUpdate.ToID = item.ToID;
            itemToUpdate.Text = item.Text;
        }
        #endregion

        #region Delete methods
        public static void DeleteObject(int key)
        {
            var objects = GetObjects();
            objects.RemoveAll(i => i.ID == key);
        }

        public static void DeleteConnection(int key)
        {
            var connections = GetConnections();
            connections.RemoveAll(i => i.ID == key);
        }
        #endregion
    }
}