Public Class Login1
    Inherits System.Web.UI.Page
	Dim util As New clsFunciones
	Dim query As String
	Dim tableDefault As DataTable
	Dim rowDefault As DataRow

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		Try
			If Not Page.IsPostBack Then

			End If
		Catch ex As Exception
			'MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Mensaje del Sistema")
			Console.WriteLine(ex.Message)
		End Try
	End Sub


	Private Sub btnIngresar_ServerClick(sender As Object, e As System.EventArgs) Handles btnIngresar.ServerClick
		Try
			If validaCampos() Then

				query = ""
				query = " SELECT        USUARIO.IDUSUARIO, USUARIO.NOMBRE, USUARIO.USUARIO, USUARIO.PASSWORD, USUARIO.ACTIVO, USUARIO.IDTIPODEUSUARIO, TIPODEUSUARIO.DESCRIPCION "
				query += " FROM  USUARIO, TIPODEUSUARIO  "
				query += " WHERE        USUARIO.IDTIPODEUSUARIO = TIPODEUSUARIO.IDTIPODEUSUARIO  "
				query += " AND USUARIO.USUARIO = '" + txtUsuario.Value.ToString + "'"
				query += " AND USUARIO.PASSWORD = '" + util.EncriptaMD5(txtPassword.Value.ToString) + "'"
				rowDefault = util.ConsultarFilaTabla(query)

				If Not rowDefault Is Nothing Then
					Session("idusuario") = rowDefault.Item("IdUsuario").ToString
					Session("usuario") = txtUsuario.Value.ToString
					Session("password") = txtPassword.Value.ToString
					Session("nombre") = rowDefault.Item("Nombre").ToString
					Session("tipodeusuario") = rowDefault.Item("Descripcion").ToString
					Session("idtipodeusuario") = rowDefault.Item("IdTipoDeUsuario").ToString

					Response.Redirect("Default.aspx", False)
				End If
				
			End If
		Catch ex As Exception
			MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Mensaje del Sistema")
		End Try
	End Sub


	Private Function validaCampos() As Boolean

		If String.IsNullOrEmpty(txtUsuario.Value.ToString) Then
			txtUsuario.Focus()
			Return False
		End If

		If String.IsNullOrEmpty(txtPassword.Value.ToString) Then
			txtPassword.Focus()
			Return False
		End If

		Return True
	End Function


End Class