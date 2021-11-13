<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site_Login.Master" CodeBehind="Login.aspx.vb" Inherits="actividades_lac.Login1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	  <!-- Outer Row -->
        <div class="row justify-content-center">

            <div class="col-xl-10 col-lg-12 col-md-9">

                <div class="card o-hidden border-0 shadow-lg my-5">
                    <div class="card-body p-0">
                        <!-- Nested Row within Card Body -->
                        <div class="row">
                            <div class="col-lg-6 d-none d-lg-block bg-login-image">
										<img src="img/Actividades.png" style="width:400px;height:400px;" />
									 </div>
                            <div class="col-lg-6">
                                <div class="p-5">
                                    <div class="text-center">
                                        <h1 class="h4 text-gray-900 mb-4">Ingreso</h1>
                                    </div>
                                    <form class="user" runat="server">
                                        <div class="form-group">
                                            <input type="text" runat="server" class="form-control form-control-user"
                                                id="txtUsuario" aria-describedby="emailHelp"
                                                placeholder="Ingrese Usuario...">
                                        </div>
                                        <div class="form-group">
                                            <input type="password" runat="server" class="form-control form-control-user"
                                                id="txtPassword" placeholder="Ingrese su Contraseña...">
                                        </div>
													  <hr>
                                        <a id="btnIngresar"  runat="server" type="button"  class="btn btn-primary btn-user btn-block">
                                            Ingresar
                                        </a>													
                                    </form>
                                    
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </div>

        </div>

</asp:Content>
