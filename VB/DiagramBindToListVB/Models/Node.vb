Imports DevExpress.Web.ASPxDiagram

Public Class Node
    Public Property ID As Integer
    Public Property Type As DiagramShapeType
    Public Property Text As String
    Public Property Width As Integer
    Public Property Height As Integer

    Public Sub New(ByVal id As Integer, ByVal type As DiagramShapeType, ByVal text As String, ByVal width As Integer, ByVal height As Integer)
        Me.ID = id
        Me.Type = type
        Me.Text = text
        Me.Width = width
        Me.Height = height
    End Sub

    Public Sub New()
    End Sub
End Class