<%@ Page Title="Home Page" Language="vb" MasterPageFile="~/Site.Master" AutoEventWireup="false"
	CodeBehind="Default.aspx.vb" Inherits="actividades_lac._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
	<!-- Begin Page Content -->
	<div class="container-fluid">
		<!-- Page Heading -->
		<div class="d-sm-flex align-items-center justify-content-between mb-4">
			<h1 class="h3 mb-0 text-gray-800">
				Principal</h1>
		</div>
		<form id="Form1" class="user" runat="server">
		<!-- Content Row -->
		<div class="row">
			<div class="col-xl-3 col-md-6 mb-4">
				<div class="card border-left-primary shadow h-100 py-2">
					<div class="card-body">
						<div class="row no-gutters align-items-center">
							<div class="col mr-2">
								<div class="text-xs font-weight-bold text-primary text-uppercase mb-1">
									Total Actividades</div>
								<div class="h5 mb-0 font-weight-bold text-gray-800">
									<asp:Label ID="lblTotalActividades" runat="server" Text="0"></asp:Label></div>
							</div>
							<div class="col-auto">
								<i class="fas fa-calendar fa-2x text-gray-300"></i>
							</div>
						</div>
					</div>
				</div>
			</div>
			<div class="col-xl-3 col-md-6 mb-4">
				<div class="card border-left-success shadow h-100 py-2">
					<div class="card-body">
						<div class="row no-gutters align-items-center">
							<div class="col mr-2">
								<div class="text-xs font-weight-bold text-success text-uppercase mb-1">
									Actividades No Iniciadas</div>
								<div class="h5 mb-0 font-weight-bold text-gray-800">
									<asp:Label ID="lblActividadesNoIniciadas" runat="server" Text="0"></asp:Label></div>
							</div>
							<div class="col-auto">
								<i class="fas fa-hand-paper fa-2x text-gray-300"></i>
							</div>
						</div>
					</div>
				</div>
			</div>
			<!-- Earnings (Monthly) Card Example -->
			<div class="col-xl-3 col-md-6 mb-4">
				<div class="card border-left-info shadow h-100 py-2">
					<div class="card-body">
						<div class="row no-gutters align-items-center">
							<div class="col mr-2">
								<div class="text-xs font-weight-bold text-info text-uppercase mb-1">
									Iniciadas
								</div>
								<div class="row no-gutters align-items-center">
									<div class="col-auto">
										<div class="h5 mb-0 mr-3 font-weight-bold text-gray-800">
											<asp:Label ID="lblActividadesIniciadas" runat="server" Text="0"></asp:Label></div>
									</div>
								
								</div>
							</div>
							<div class="col-auto">
								<i class="fas fa-play fa-2x text-gray-300"></i>
							</div>
						</div>
					</div>
				</div>
			</div>
			<!-- Pending Requests Card Example -->
			<div class="col-xl-3 col-md-6 mb-4">
				<div class="card border-left-warning shadow h-100 py-2">
					<div class="card-body">
						<div class="row no-gutters align-items-center">
							<div class="col mr-2">
								<div class="text-xs font-weight-bold text-warning text-uppercase mb-1">
									Finalizadas</div>
								<div class="h5 mb-0 font-weight-bold text-gray-800">
									<asp:Label ID="lblActividadesFinalizadas" runat="server" Text="0"></asp:Label></div>
							</div>
							<div class="col-auto">
								<i class="fas fa-check-double fa-2x text-gray-300"></i>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
		<!-- Content Row -->
		<div class="row">
			
			<div class="card shadow mb-4">
			<div class="card-header py-3">
				<h6 class="m-0 font-weight-bold text-primary">
					Seguimiento de Actividades</h6>
			</div>
			<div class="card-body">
				<div class="table-responsive">
					<asp:GridView class="table table-bordered" ID="grdDatos" Width="100%" runat="server"
						AutoGenerateColumns="False">
						<Columns>
								<asp:BoundField DataField="IDACTIVIDAD" HeaderText="Id" SortExpression="IDACTIVIDAD" />
							<asp:BoundField DataField="FECHAINICIAL" HeaderText="Fecha Inicial" SortExpression="FECHAINICIAL"
								DataFormatString="{0:d}" />
							<asp:BoundField DataField="FECHAFINAL" HeaderText="Fecha Final" SortExpression="FECHAFINAL"
								DataFormatString="{0:d}" />
							<asp:BoundField DataField="DESCRIPCION" HeaderText="Descripcion" SortExpression="DESCRIPCION" />
							<asp:BoundField DataField="USUARIO" HeaderText="Usuario" SortExpression="USUARIO" />
							<asp:BoundField DataField="TIPODEUSUARIO" HeaderText="Tipo de Usuario" SortExpression="TIPODEUSUARIO" />
							<asp:BoundField DataField="TIPODEPROGRESO" HeaderText="Progreso" SortExpression="TIPODEPROGRESO" />
							<asp:BoundField DataField="PRIORIDAD" HeaderText="Prioridad" SortExpression="PRIORIDAD" />
						</Columns>
					</asp:GridView>
				</div>
			</div>
		</div>

		</div>

		</form>
	</div>
	<!-- /.container-fluid -->
</asp:Content>
