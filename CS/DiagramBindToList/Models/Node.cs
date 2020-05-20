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
        public string Type { set; get; }
        public string Text { set; get; }
        public int Width { set; get; }
        public int Height { set; get; }
        public string Style { set; get; }
        public string TextStyle { set; get; }

        public Node(int id, string type, string text, int width, int height, string style = null, string textStyle = null)
        {
            ID = id;
            Type = type;
            Text = text;
            Width = width;
            Height = height;
            Style = style;
            TextStyle = textStyle;
        }

        public Node() {}
    }
}