Public Class AppReflist
    Inherits ReferenceList(Of ReferenceListEntity)

    Public Sub New()
        MyBase.New(Constants.Values.ApplicationKey, "")
    End Sub

    Public Sub New(ByVal listName As String)
        MyBase.New(Constants.Values.ApplicationKey, listName)
    End Sub
End Class

