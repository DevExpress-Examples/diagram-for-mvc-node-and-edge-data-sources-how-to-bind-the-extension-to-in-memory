Imports DevExpress.Web.ASPxDiagram

Public Class Node
    Public Property ID As Integer
    Public Property Type As String
    Public Property Text As String
    Public Property Width As Integer
    Public Property Height As Integer
    Public Property Style As String
    Public Property TextStyle As String

    Public Sub New(ByVal id As Integer, ByVal type As String, ByVal text As String, ByVal width As Integer, ByVal height As Integer, Optional ByVal style As String = Nothing, Optional ByVal textStyle As String = Nothing)
        Me.ID = id
        Me.Type = type
        Me.Text = text
        Me.Width = width
        Me.Height = height
        Me.Style = style
        Me.TextStyle = textStyle
    End Sub

    Public Sub New()
    End Sub
End Class