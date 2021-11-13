<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master"
	CodeBehind="wfrmNuevaActividad.aspx.vb" Inherits="actividades_lac.wfrmNuevaActividad" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<link rel="stylesheet" href="plugins/bootstrap-datetimepicker.css">
	<h1 class="h3 mb-4 text-gray-800">
		Nueva Actividad</h1>
	<div class="container">
		<div class="card o-hidden border-0 shadow-lg my-5">
			<div class="card-body p-0">
				<!-- Nested Row within Card Body -->
				<div class="row">
					<div class="col-lg-12">
						<div class="p-5">
							<div class="text-center">
								<h1 class="h4 text-gray-900 mb-4">
									<asp:Label ID="lblTitulo" runat="server" Text="Grabar"></asp:Label></h1>
							</div>
							<form class="user" runat="server">
							<div class="row">
								<div class="col-sm-12 col-md-4 col-lg-4">
									<div class="form-group">
										<label>
											Fecha Inicial</label>
										<asp:TextBox ID="TxtFechaInicial" type="date" runat="server" PlaceHolder="dia/Mes/año"
											CssClass="form-control fecha datepicker" Width="100%"></asp:TextBox>
									</div>
								</div>
								<div class="col-sm-12 col-md-4 col-lg-4">
									<div class="form-group">
										<label>
											Fecha Final</label>
										<asp:TextBox ID="txtFechaFinal" type="date" runat="server" PlaceHolder="dia/Mes/año"
											CssClass="form-control fecha datepicker" Width="100%"></asp:TextBox>
									</div>
								</div>
								<div class="col-sm-12 col-md-4 col-lg-4">
									<div class="form-group">
										<label>
											Prioridad</label>
										<asp:DropDownList ID="cboPrioridad" runat="server" CssClass="form-control" Width="100%">
										</asp:DropDownList>
									</div>
								</div>
							</div>
							<div class="row">
								<div class="col-sm-12 col-md-4 col-lg-4">
									<div class="form-group">
										<label>
											Progreso</label>
										<asp:DropDownList ID="cboTipoProgreso" runat="server" CssClass="form-control" Width="100%">
										</asp:DropDownList>
									</div>
								</div>
								<div class="col-sm-12 col-md-8 col-lg-8">
									<div class="form-group">
										<label>
											Asignar A</label>
										<asp:DropDownList ID="cboUsuario" runat="server" CssClass="form-control" Width="100%">
										</asp:DropDownList>
									</div>
								</div>
							</div>
							<div class="row">
								<div class="col-sm-12 col-md-12 col-lg-12">
									<div class="form-group">
										<label>
											Actividad</label>
										<asp:TextBox ID="txtActividad" TextMode="MultiLine" MaxLength="400"  CssClass="form-control" Width="100%"  runat="server"></asp:TextBox>
									</div>
								</div>
							</div>
							<a id="btnGrabar" runat="server" type="button" class="btn btn-primary btn-user btn-block">
								Grabar </a>
							<hr>
							<a href="Default.aspx" class="btn btn-danger btn-user btn-block">Cancelar</a>
							</form>
						</div>
					</div>
				</div>
			</div>
		</div>
	</div>
	<script src="plugins/bootstrap-datetimepicker.js"></script>
	<script>

		$(document).ready(function () {
			bindEvent();
		});


		function openModal() {
			$("#dialog-alert").modal("show");
		}

		function bindEvent() {
			$('.fecha').mask('99/99/9999');
			$('.fecha').datetimepicker({
				locale: 'es'
            , format: 'L'
			});
		}
	</script>
</asp:Content>
