using DevExpress.Web.ASPxDiagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiagramBindToList.Models
{
    public class Node
    {
        public int ID { set; get; }
        public DiagramShapeType Type { set; get; }
        public string Text { set; get; }
        public int Width { set; get; }
        public int Height { set; get; }

        public Node(int id, DiagramShapeType type, string text, int width, int height)
        {
            ID = id;
            Type = type;
            Text = text;
            Width = width;
            Height = height;
        }

        public Node() {}
    }
}