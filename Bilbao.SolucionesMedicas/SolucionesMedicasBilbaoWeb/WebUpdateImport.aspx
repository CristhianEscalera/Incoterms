<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="WebUpdateImport.aspx.cs" Inherits="SolucionesMedicasBilbaoWeb.WebUpdateImport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <link rel="stylesheet" href="plugins/datatables-bs4/css/dataTables.bootstrap4.min.css">
<link rel="stylesheet" href="plugins/datatables-responsive/css/responsive.bootstrap4.min.css">
<link rel="stylesheet" href="plugins/datatables-buttons/css/buttons.bootstrap4.min.css">
  <style>
      .required {
        border: 1px solid #ccc;
      }
      .required.error {
        border: 1px solid red;
      }
  </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        <form id="form1" runat="server">
<div class="form-box">

<section class="content-header">
    <h1 style="color:white; font-family:Oswald; font-size:30px;">I M P O R T A C I Ó N</h1>
</section>

<section class="content">
    <div class="row">
     <div class="col-md-12">
        <div class="box-body">
           <div class="card card-primary">
              <div class="card-header" style="background-color:#1B425E">
                <h3 class="card-title">Administracion de Importación</h3>
              </div>              
              <div class="card-body">
                  <span id="txtError" class="error-message" style="color:red;"></span>
                  <div class="row">
                       <div class="form-group col-md-12">
                         <asp:Label runat="server">Incoterms</asp:Label>
                         <asp:DropDownList ID="Incoterm" runat="server" class="form-control">
                             <asp:ListItem Text="EXW" Value="EXW"></asp:ListItem>
                             <asp:ListItem Text="FCA" Value="FCA"></asp:ListItem>
                             <asp:ListItem Text="FAS" Value="FAS"></asp:ListItem>
                             <asp:ListItem Text="FOB" Value="FOB"></asp:ListItem>
                             <asp:ListItem Text="CFR" Value="CFR"></asp:ListItem>
                            <asp:ListItem Text="CIF" Value="CIF"></asp:ListItem>
                            <asp:ListItem Text="CPT" Value="CPT"></asp:ListItem>
                            <asp:ListItem Text="CIP" Value="CIP"></asp:ListItem>
                              <asp:ListItem Text="DPU" Value="DPU"></asp:ListItem>
                            <asp:ListItem Text="DAP" Value="DAP"></asp:ListItem>
                            <asp:ListItem Text="DDP" Value="DDP"></asp:ListItem>
                         </asp:DropDownList>
                       </div>
                  </div>
                  <div class="row">
                        <div class="form-group col-md-4">
                            <asp:Label runat="server" Text="Fecha Inicio"></asp:Label>
                            <asp:TextBox ID="txtFechaInicio" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                        </div>

                        <div class="form-group col-md-4">
                            <asp:Label runat="server" Text="Fecha tentativa"></asp:Label>
                            <asp:TextBox ID="txtFechaTentativa" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                        </div>

                        <div class="form-group col-md-4">
                            <asp:Label runat="server" Text="Fecha Final"></asp:Label>
                            <asp:TextBox ID="txtFechaFin" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                        </div>
   
                   </div>
                  <div class="row">
                    <div class="form-group col-md-3">
                        <asp:Label runat="server">Origen</asp:Label>
                        <asp:DropDownList ID="cmbOrigen" runat="server" class="form-control required"></asp:DropDownList>
                    </div>

                    <div class="form-group col-md-3">
                        <asp:Label runat="server">Destino</asp:Label>
                        <asp:DropDownList ID="cmbDestino" runat="server" class="form-control required"></asp:DropDownList>
                    </div>
    
                    <div class="form-group col-md-3">
                        <asp:Label runat="server">Proveedor</asp:Label>
                        <asp:DropDownList ID="cmbProveedor" runat="server" class="form-control required"></asp:DropDownList>
                    </div>

                     <div class="form-group col-md-3">
                        <asp:Label runat="server">Embarcador</asp:Label>
                        <asp:DropDownList ID="cmbEmbarcador" runat="server" class="form-control"></asp:DropDownList>
                    </div>
                 </div>
                </div>
                <div class="card-footer">
                    <asp:Button ID="btnModificar" Text="Modificar" runat="server" CssClass="btn btn-block btn-info btn-lg"  OnClick="btnModificar_Click"/>
                    <a class="btn btn-block btn-info btn-lg" href='WebAdmImport.aspx'>Cancelar</a>
                </div>
            </div>
        </div>
    </div>
    </div>
</section>
</div>
</form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
    <script>
document.getElementById('<%= btnModificar.ClientID %>').onclick = function () {
    var txtFechaInicio = document.getElementById('<%= txtFechaInicio.ClientID %>');
    var txtFechaFin = document.getElementById('<%= txtFechaFin.ClientID %>');
    var txtFechaTentativa = document.getElementById('<%= txtFechaTentativa.ClientID %>');
    var txtDescriptionError = document.getElementById('txtError');

    var fechaInicio = new Date(txtFechaInicio.value);
    var fechaTentativa = new Date(txtFechaTentativa.value);
    var fechaFin = new Date(txtFechaFin.value);

    if (isNaN(fechaInicio) ) {
        txtDescriptionError.textContent = 'Ingrese fecha de inicio';
        return false;
    }

    if ( isNaN(fechaTentativa)) {
        txtDescriptionError.textContent = 'Ingrese fechas tentativa';
        return false;
    } else if(fechaInicio > fechaTentativa) {
        txtDescriptionError.textContent = 'La fecha tentativa no puede ser mayor a la fecha inicial';
        return false;
    }

    if (txtFechaFin.value.trim() !== '') {
        if (fechaInicio > fechaFin ) {
            txtDescriptionError.textContent = 'La Fecha Final no puede ser menor a la fecha inicial';
            return false;
        }
    }

    return true;
};
    </script>
</asp:Content>
