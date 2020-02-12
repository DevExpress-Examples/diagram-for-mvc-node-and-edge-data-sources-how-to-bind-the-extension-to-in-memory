Imports DevExpress.Web.ASPxDiagram

Public Class Workflow
    Public Property Objects As List(Of Node)
    Public Property Connections As List(Of Edge)
End Class

Module WorkflowDataProvider
    Function LoadData() As Workflow
        Return New Workflow With {
            .Connections = GetConnections(),
            .Objects = GetObjects()
        }
    End Function

    Function GetObjects() As List(Of Node)
        Dim data = TryCast(HttpContext.Current.Session("DiagramObjects"), List(Of Node))

        If data Is Nothing Then
            data = New List(Of Node) From {
                New Node(1, DiagramShapeType.Terminator, "A new ticket", 96, 48),
                New Node(2, DiagramShapeType.Process, "Analyze the issue", 168, 72),
                New Node(3, DiagramShapeType.Diamond, "Do we have all information to work with?", 168, 96),
                New Node(4, DiagramShapeType.Terminator, "Answered", 96, 48),
                New Node(5, DiagramShapeType.Rectangle, "Request additional information or clarify the scenario", 144, 72),
                New Node(6, DiagramShapeType.Rectangle, "Prepare an example in Code Central", 168, 72),
                New Node(7, DiagramShapeType.Rectangle, "Update the documentation", 168, 72),
                New Node(8, DiagramShapeType.Rectangle, "Process the ticket", 168, 72),
                New Node(9, DiagramShapeType.Rectangle, "Work with the R&D team", 144, 72)
            }
            HttpContext.Current.Session("DiagramObjects") = data
        End If

        Return data
    End Function

    Function GetConnections() As List(Of Edge)
        Dim data = TryCast(HttpContext.Current.Session("DiagramConnections"), List(Of Edge))

        If data Is Nothing Then
            data = New List(Of Edge) From {
                New Edge(1, Nothing, 1, 2),
                New Edge(2, Nothing, 2, 3),
                New Edge(3, "No", 3, 5),
                New Edge(4, Nothing, 5, 2),
                New Edge(5, Nothing, 8, 4),
                New Edge(6, String.Empty, 4, 6),
                New Edge(9, String.Empty, 4, 7),
                New Edge(10, "Yes", 3, 8),
                New Edge(11, "Need developer assistance?", 8, 9),
                New Edge(12, Nothing, 9, 4)
            }
            HttpContext.Current.Session("DiagramConnections") = data
        End If

        Return data
    End Function

    Function InsertObject(ByVal item As Node) As Integer
        Dim objects As List(Of Node) = GetObjects()
        item.ID = If(objects.Count = 0, 1, objects.Max(Function(i) i.ID) + 1)
        objects.Add(item)
        Return item.ID
    End Function

    Function InsertConnection(ByVal item As Edge) As Integer
        Dim connections As List(Of Edge) = GetConnections()
        item.ID = If(connections.Count = 0, 1, connections.Max(Function(i) i.ID) + 1)
        connections.Add(item)
        Return item.ID
    End Function

    Sub UpdateObject(ByVal item As Node)
        Dim objects As List(Of Node) = GetObjects()
        Dim objectToUpdate = objects.First(Function(i) i.ID = item.ID)
        objectToUpdate.Type = item.Type
        objectToUpdate.Text = item.Text
        objectToUpdate.Width = item.Width
        objectToUpdate.Height = item.Height
    End Sub

    Sub UpdateConnection(ByVal item As Edge)
        Dim connections As List(Of Edge) = GetConnections()
        Dim itemToUpdate = connections.First(Function(i) i.ID = item.ID)
        itemToUpdate.FromID = item.FromID
        itemToUpdate.ToID = item.ToID
        itemToUpdate.Text = item.Text
    End Sub

    Sub DeleteObject(ByVal key As Integer)
        Dim objects = GetObjects()
        objects.RemoveAll(Function(i) i.ID = key)
    End Sub

    Sub DeleteConnection(ByVal key As Integer)
        Dim connections = GetConnections()
        connections.RemoveAll(Function(i) i.ID = key)
    End Sub
End Module

