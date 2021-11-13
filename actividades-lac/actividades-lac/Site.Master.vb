Public Class Site
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		Try
			If Not Page.IsPostBack Then
				If Not isLogin() Then
					Response.Redirect("Login.aspx", False)
				End If
				If Not IsNothing(Session("nombre")) Then
					lblNombreUsuario.Text = Session("nombre").ToString
				End If
			End If
			
		Catch ex As Exception
			'MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Mensaje del Sistema")
			Console.WriteLine(ex.Message)
		End Try
	End Sub

	Private Function isLogin()
		If IsNothing(Session("usuario")) AndAlso IsNothing(Session("password")) Then
			Return False
		End If
		Return True
	End Function


	Private Sub btnCerrarSesion_ServerClick(sender As Object, e As System.EventArgs) Handles btnCerrarSesion.ServerClick
		Try
			Session("idusuario") = Nothing
			Session("usuario") = Nothing
			Session("password") = Nothing
			Session("nombre") = Nothing
			Session("tipodeusuario") = Nothing
			Session("idtipodeusuario") = Nothing
			Response.Redirect("Login.aspx", False)
		Catch ex As Exception
			Console.WriteLine(ex.Message)
		End Try
	End Sub
End Class