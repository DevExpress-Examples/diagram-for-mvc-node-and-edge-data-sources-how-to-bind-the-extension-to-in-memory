using DevExpress.Web.ASPxDiagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiagramBindToList.Models
{
    public class Edge
    {
        public int ID { set; get; }
        public string Text { set; get; }
        public int? FromID { set; get; }
        public int? ToID { set; get; }
        //public ConnectorLineType LT { get; set; }

        public Edge(int id, string text, int fromId, int toId)
        {
            ID = id;
            Text = text;
            FromID = fromId;
            ToID = toId;
        }

        public Edge() { }
    }
}