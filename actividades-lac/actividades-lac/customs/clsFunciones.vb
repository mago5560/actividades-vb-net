Imports Oracle.DataAccess.Client
Imports System.Security.Cryptography

Public Class clsFunciones
	Inherits System.Web.UI.Page
	Private oraConn As String = "Data Source=localhost:1521;User ID=admin;Password=123;"

	Public Function conn() As OracleConnection
		Return New OracleConnection(oraConn)
	End Function

	Public Sub ExecuteSQLQuery(ByVal sqlQuery As String)
		Try
			Dim cn As New OracleConnection(oraConn)
			If Not String.IsNullOrEmpty(sqlQuery) Then
				Dim sqlCmd As New OracleCommand
				sqlCmd.CommandText = sqlQuery
				sqlCmd.CommandType = CommandType.Text
				If cn.State = ConnectionState.Closed Then cn.Open()
				sqlCmd.Connection = cn
				sqlCmd.ExecuteNonQuery()
			End If
		Catch ex As Exception
			Throw ex
		End Try
	End Sub


	Public Function ConsultarFilaTabla(ByVal sqlQuery As String) As DataRow
		Try
			Dim Table As DataTable = ConsultarTabla(sqlQuery)
			If Not (Table Is Nothing) Then
				If Table.Rows.Count > 0 Then
					Return Table.Rows(0)
				End If
			End If
			Return Nothing
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function ConsultarTabla(ByVal sqlQuery As String) As DataTable
		Try
			Dim cn As New OracleConnection(oraConn)
			If Not String.IsNullOrEmpty(sqlQuery) Then
				Dim da As New OracleDataAdapter
				Dim table As New DataTable
				da.SelectCommand = New OracleCommand(sqlQuery, cn)
				da.Fill(table)
				Return table
			Else
				Return Nothing
			End If
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function ConsultarEscalar(ByVal sqlQuery As String) As String
		Try
			Dim cn As New OracleConnection(oraConn)
			If Not String.IsNullOrEmpty(sqlQuery) Then
				Dim sqlCmd As New OracleCommand
				sqlCmd.CommandText = sqlQuery
				sqlCmd.CommandType = CommandType.Text
				If Cn.State = ConnectionState.Closed Then Cn.Open()
				sqlCmd.Connection = Cn
				Return Convert.ToString(sqlCmd.ExecuteScalar)
			Else
				Return Nothing
			End If
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function EncriptaMD5(ByVal Texto As String) As String
		Dim md5hash As MD5
		md5hash = MD5.Create()
		Return GetMd5Hash(md5hash, Texto)
	End Function

	Private Function GetMd5Hash(ByVal md5Hash As MD5, ByVal input As String) As String
		Dim data As Byte() = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input))
		Dim sBuilder As StringBuilder = New StringBuilder()

		For i As Integer = 0 To data.Length - 1
			sBuilder.Append(data(i).ToString("x2"))
		Next

		Return sBuilder.ToString()
	End Function

	Public Function F_Null(ByVal xstring As String) As Boolean

		F_Null = True
		If Not xstring Is Nothing Then
			F_Null = True
		End If
		If Len(LTrim(RTrim(xstring))) = 0 Or xstring = "__/__/____" Or xstring = "__-___.___" Or xstring = "__:__" Then
			F_Null = True
		Else
			F_Null = False
		End If


	End Function
	Public Function Send(ByVal xstring As String, Optional ByVal xNull As Boolean = True) As String
		If F_Null(xstring) Then
			If xNull Then
				Send = "Null"
			Else
				Send = " ' ' "

			End If
		Else
			Send = "'" & xstring.Replace("'", "''") & "'"
		End If
	End Function
End Class
