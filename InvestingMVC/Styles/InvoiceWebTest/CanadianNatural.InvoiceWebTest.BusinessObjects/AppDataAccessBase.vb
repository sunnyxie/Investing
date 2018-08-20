Imports OakLeaf.MM.Main.Business

Public Class AppDataAccessBase(Of EntityType As {CNRLBusinessEntity, New})
    Inherits CNRLDataAccessOracle(Of EntityType)

#Region "Constructor/Destructor"

    Public Sub New(ByVal ownerObject As mmBusinessObject)
        MyBase.New(Constants.Values.ApplicationKey, ownerObject)
    End Sub

#End Region

#Region "Properties"

#End Region

#Region "Public Methods"

#End Region

#Region "Private/Protected Methods"

#End Region

End Class
