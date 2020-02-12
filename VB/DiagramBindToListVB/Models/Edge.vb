Public Class Edge
    Public Property ID As Integer
    Public Property Text As String
    Public Property FromID As Integer?
    Public Property ToID As Integer?

    Public Sub New(ByVal id As Integer, ByVal text As String, ByVal fromId As Integer, ByVal toId As Integer)
        Me.ID = id
        Me.Text = text
        Me.FromID = fromId
        Me.ToID = toId
    End Sub

    Public Sub New()
    End Sub
End Class