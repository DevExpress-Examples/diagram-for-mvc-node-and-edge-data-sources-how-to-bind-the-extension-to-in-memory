Imports DevExpress.Web.Mvc

Public Class HomeController
    Inherits System.Web.Mvc.Controller

    Function Index() As ActionResult
        Return View(WorkflowDataProvider.LoadData())
    End Function

    Public Function DiagramUpdate(ByVal nodeUpdateValues As MVCxDiagramNodeUpdateValues(Of Node, Integer), ByVal edgeUpdateValues As MVCxDiagramEdgeUpdateValues(Of Edge, Integer)) As ActionResult
        For Each item In nodeUpdateValues.Update
            WorkflowDataProvider.UpdateObject(item)
        Next

        For Each itemKey In nodeUpdateValues.DeleteKeys
            WorkflowDataProvider.DeleteObject(itemKey)
        Next

        For Each item In nodeUpdateValues.Insert
            Dim key = WorkflowDataProvider.InsertObject(item)
            nodeUpdateValues.MapInsertedItemKey(item, key)
        Next

        For Each item In edgeUpdateValues.Update
            WorkflowDataProvider.UpdateConnection(item)
        Next

        For Each itemKey In edgeUpdateValues.DeleteKeys
            WorkflowDataProvider.DeleteConnection(itemKey)
        Next

        For Each item In edgeUpdateValues.Insert
            Dim key = WorkflowDataProvider.InsertConnection(item)
            edgeUpdateValues.MapInsertedItemKey(item, key)
        Next

        Return DiagramExtension.GetBatchUpdateResult(nodeUpdateValues, edgeUpdateValues)
    End Function
End Class