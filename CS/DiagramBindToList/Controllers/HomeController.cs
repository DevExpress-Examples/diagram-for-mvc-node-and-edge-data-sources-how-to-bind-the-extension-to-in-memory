using DevExpress.Web.Mvc;
using DiagramBindToList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DiagramBindToList.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(WorkflowDataProvider.LoadData());
        }

        public ActionResult DiagramUpdate(MVCxDiagramNodeUpdateValues<DiagramBindToList.Models.Node, int> nodeUpdateValues, MVCxDiagramEdgeUpdateValues<DiagramBindToList.Models.Edge, int> edgeUpdateValues)
        {
            foreach (var item in nodeUpdateValues.Update)
            {
                WorkflowDataProvider.UpdateObject(item);
            }
            foreach (var itemKey in nodeUpdateValues.DeleteKeys)
            {
                WorkflowDataProvider.DeleteObject(itemKey);
            }
            foreach (var item in nodeUpdateValues.Insert)
            {
                var key = WorkflowDataProvider.InsertObject(item);
                nodeUpdateValues.MapInsertedItemKey(item, key);
            }
            foreach (var item in edgeUpdateValues.Update)
            {
                WorkflowDataProvider.UpdateConnection(item);
            }
            foreach (var itemKey in edgeUpdateValues.DeleteKeys)
            {
                WorkflowDataProvider.DeleteConnection(itemKey);
            }
            foreach (var item in edgeUpdateValues.Insert)
            {
                var key = WorkflowDataProvider.InsertConnection(item);
                edgeUpdateValues.MapInsertedItemKey(item, key);
            }
            return DiagramExtension.GetBatchUpdateResult(nodeUpdateValues, edgeUpdateValues);
        }
    }
}