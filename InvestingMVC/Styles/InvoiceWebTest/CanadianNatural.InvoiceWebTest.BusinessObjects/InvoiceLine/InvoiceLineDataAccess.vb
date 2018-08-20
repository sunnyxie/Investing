Public Class InvoiceLineDataAccess
    Inherits AppDataAccessBase(Of InvoiceLineEntity)

#Region "Constructor/Destructor"

    ''' <summary>
    ''' Default Constructor 
    ''' </summary>
    Public Sub New(ByVal ownerObject As mmBusinessObject)
        MyBase.New(ownerObject)
    End Sub

#End Region

#Region "Properties"

#End Region

#Region "Public Methods"

	' Override commands in this region to bind objects to stored procedures.
	' Note: If object is read-only comment out (or delete) CreateInsertCommand, CreateUpdateCommand(), and CreateDeleteCommand().

    ' <summary>
    ' Creates the Select command which is used to populate the business object, returns a cursor.
    ' </summary>
    ' <returns>Select Command</returns>
    Public Overrides Function CreateSelectCommand() As System.Data.IDbCommand
        Dim oCommand As System.Data.OracleClient.OracleCommand = Me.CreateCommandBase("DA_INVOICELINE.READALL2")

        ' Add Parameters
        oCommand.Parameters.Add(New System.Data.OracleClient.OracleParameter("cur_out", System.Data.OracleClient.OracleType.Cursor, 0, System.Data.ParameterDirection.Output, True, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        oCommand.Parameters.Add(New System.Data.OracleClient.OracleParameter("inv_id", System.Data.OracleClient.OracleType.Number))

        ' Map Parameters 
        MapParameterToValue(oCommand, "inv_id", CDec(GetFilterValue("InvoiceID")), ParameterDirection.Input)

        Return oCommand
    End Function
    
	Public Overrides Function CreateSelectByPkCommand() As System.Data.IDbCommand
        Dim oCommand As System.Data.OracleClient.OracleCommand = Me.CreateCommandBase("DA_INVOICELINE.READBYPK")

        ' Add Parameters
        oCommand.Parameters.Add(New System.Data.OracleClient.OracleParameter("cur_out", System.Data.OracleClient.OracleType.Cursor, 0, System.Data.ParameterDirection.Output, True, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
		oCommand.Parameters.Add(New System.Data.OracleClient.OracleParameter("i_id", System.Data.OracleClient.OracleType.Number))



        ' Map Parameters 
		MapParameterToValue(oCommand, "i_id", GetFilterValue("Id"),ParameterDirection.Input)


        Return oCommand
    End Function
    	
    ' <summary>
    ' Creates the Insert command.  Note that this command is for a single datarow and is bound to the dataset during the save.
    ' </summary>
    ' <returns>Insert Command</returns>
    Public Overrides Function CreateInsertCommand() As System.Data.IDbCommand
        Dim oCommand As System.Data.OracleClient.OracleCommand = Me.CreateCommandBase("DA_INVOICELINE.CREATE_ROW")

        ' Add Parameters
		oCommand.Parameters.Add(New System.Data.OracleClient.OracleParameter("o_id", System.Data.OracleClient.OracleType.Number)).Direction = ParameterDirection.Output
		oCommand.Parameters.Add(New System.Data.OracleClient.OracleParameter("i_line_num", System.Data.OracleClient.OracleType.Number))
		oCommand.Parameters.Add(New System.Data.OracleClient.OracleParameter("i_category", System.Data.OracleClient.OracleType.VarChar))
		oCommand.Parameters.Add(New System.Data.OracleClient.OracleParameter("i_sub_category", System.Data.OracleClient.OracleType.VarChar))
		oCommand.Parameters.Add(New System.Data.OracleClient.OracleParameter("i_description", System.Data.OracleClient.OracleType.VarChar))
		oCommand.Parameters.Add(New System.Data.OracleClient.OracleParameter("i_amount", System.Data.OracleClient.OracleType.Number))
		oCommand.Parameters.Add(New System.Data.OracleClient.OracleParameter("i_invoice_id", System.Data.OracleClient.OracleType.Number))


        ' Map Parameters
        MapParameterToColumn(oCommand, "o_id", GetPropertyMapping("Id"))
		MapParameterToColumn(oCommand, "i_line_num", GetPropertyMapping("LineNum"))
		MapParameterToColumn(oCommand, "i_category", GetPropertyMapping("Category"))
		MapParameterToColumn(oCommand, "i_sub_category", GetPropertyMapping("SubCategory"))
		MapParameterToColumn(oCommand, "i_description", GetPropertyMapping("Description"))
        MapParameterToColumn(oCommand, "i_amount", GetPropertyMapping("Amount"))
        If Me.BusinessObject.ParentBizObj Is Nothing Then
            MapParameterToColumn(oCommand, "i_invoice_id", GetPropertyMapping("InvoiceId"))
        Else
            MapParameterToValue(oCommand, "i_invoice_id", DirectCast(Me.BusinessObject.ParentBizObj, Invoice(Of InvoiceEntity)).GetCurrentEntity.Id, ParameterDirection.Input)
        End If

        Return oCommand
    End Function

    ' <summary>
    ' Creates the Update command.  Note that this command is for a single datarow and is bound to the dataset during the save.
    ' </summary>
    ' <returns>Update Command</returns>
    Public Overrides Function CreateUpdateCommand() As System.Data.IDbCommand
        Dim oCommand As System.Data.OracleClient.OracleCommand = Me.CreateCommandBase("DA_INVOICELINE.UPDATE_ROW")

        ' Add Parameters
		oCommand.Parameters.Add(New System.Data.OracleClient.OracleParameter("i_id", System.Data.OracleClient.OracleType.Number))
		oCommand.Parameters.Add(New System.Data.OracleClient.OracleParameter("i_line_num", System.Data.OracleClient.OracleType.Number))
		oCommand.Parameters.Add(New System.Data.OracleClient.OracleParameter("i_category", System.Data.OracleClient.OracleType.VarChar))
		oCommand.Parameters.Add(New System.Data.OracleClient.OracleParameter("i_sub_category", System.Data.OracleClient.OracleType.VarChar))
		oCommand.Parameters.Add(New System.Data.OracleClient.OracleParameter("i_description", System.Data.OracleClient.OracleType.VarChar))
		oCommand.Parameters.Add(New System.Data.OracleClient.OracleParameter("i_amount", System.Data.OracleClient.OracleType.Number))
		oCommand.Parameters.Add(New System.Data.OracleClient.OracleParameter("i_invoice_id", System.Data.OracleClient.OracleType.Number))


        ' Map Parameters
		MapParameterToColumn(oCommand, "i_id", GetPropertyMapping("Id"))
		MapParameterToColumn(oCommand, "i_line_num", GetPropertyMapping("LineNum"))
		MapParameterToColumn(oCommand, "i_category", GetPropertyMapping("Category"))
		MapParameterToColumn(oCommand, "i_sub_category", GetPropertyMapping("SubCategory"))
		MapParameterToColumn(oCommand, "i_description", GetPropertyMapping("Description"))
		MapParameterToColumn(oCommand, "i_amount", GetPropertyMapping("Amount"))
		MapParameterToColumn(oCommand, "i_invoice_id", GetPropertyMapping("InvoiceId"))


        Return oCommand
    End Function

    ' <summary>
    ' Creates the Update command.  Note that this command is for a single datarow and is bound to the dataset during the save.
    ' </summary>
    ' <returns>Delete Command</returns>
    Public Overrides Function CreateDeleteCommand() As System.Data.IDbCommand
        Dim oCommand As System.Data.OracleClient.OracleCommand = Me.CreateCommandBase("DA_INVOICELINE.DELETE_ROW")

        ' Add Parameters
		oCommand.Parameters.Add(New System.Data.OracleClient.OracleParameter("i_id", System.Data.OracleClient.OracleType.Number))


        ' Map Parameters
		MapParameterToColumn(oCommand, "i_id", GetPropertyMapping("Id"))


        Return oCommand
    End Function

	    ' <summary>
    ' Select Empty DataSet Factory method
    ' </summary>
    ' <returns>Select Command</returns>
    Public Function CreateSelectEmptyCommand() As System.Data.IDbCommand
        Dim oCommand As System.Data.OracleClient.OracleCommand = Me.CreateCommandBase("DA_INVOICELINE.READEMPTY")

        ' Add Parameters
        oCommand.Parameters.Add(New System.Data.OracleClient.OracleParameter("cur_out", System.Data.OracleClient.OracleType.Cursor, 0, System.Data.ParameterDirection.Output, True, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))

        Return oCommand
    End Function


    ' Override method to hook custom commands
    Public Overrides Function CreateCommand(cmdText As String) As System.Data.IDbCommand
            Select cmdText
            Case "SelectEmpty" : Return CreateSelectEmptyCommand()
        End Select
        Return MyBase.CreateCommand(cmdText)
    End Function

#End Region
	
#Region "Private/Protected Methods"
   
#End Region

End Class