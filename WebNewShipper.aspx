<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="WebNewShipper.aspx.cs" Inherits="SolucionesMedicasBilbaoWeb.WebNewShipper" %>
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
     <form id="form2" runat="server">
        <div class="form-box">

        <section class="content-header">
            <h1 style="color:white; font-family:Oswald; font-size:30px;">E M B A R C A D O R</h1>
        </section>

        <section class="content">
            <div class="row">
             <div class="col-md-12">
                <div class="box-body">
                   <div class="card card-primary">
                      <div class="card-header" style="background-color:#1B425E">
                        <h3 class="card-title">Administración Proveedor</h3>
                      </div>
                      <!-- /.card-header -->
                      <!-- form start -->
                      <div class="card-body">
                          <span id="txtError" class="error-message" style="color:red;"></span>
                          <div class="form-group">
                            <asp:Label runat="server">Nombre</asp:Label>
                            <asp:TextBox ID="txtName" MaxLength="50" runat="server" class="form-control required"  placeholder="Ingrese proveedor" onkeyup="removeExtraSpaces(this)" onblur="validateSpaces(this)">
                            </asp:TextBox>
                          </div>
                          <div class="row">
                              <div class="form-group col-md-6">
                                <asp:Label runat="server">Localizacion</asp:Label>
                                <asp:TextBox ID="txtLocalizacion" MaxLength="13" runat="server" class="form-control required"  placeholder="Ingrese NIT" onkeypress="validarNIT(event)" onkeyup="removeExtraSpaces(this);">
                                </asp:TextBox>
                              </div>
                  
                              <div class="form-group col-md-6">
                                <asp:Label runat="server">Precio</asp:Label>
                                <asp:TextBox ID="txtPrecio" MaxLength="15" runat="server" class="form-control required"  onkeypress="return validatePhoneNumber(event)" onkeyup="removeExtraSpaces2(this); validateTelefono(this);">
                                </asp:TextBox>
                              </div>
                         </div>
                          <div class="form-group">
                              <asp:Label runat="server">Tipo envio</asp:Label>
                              <asp:DropDownList ID="Envio" runat="server" class="form-control">
                                  <asp:ListItem Text="Aereo" Value="Aereo"></asp:ListItem>
                                  <asp:ListItem Text="Ferroviario" Value="Ferroviario"></asp:ListItem>
                                  <asp:ListItem Text="Maritimo" Value="Maritimo"></asp:ListItem>
                                  <asp:ListItem Text="Internacional Carretera" Value="Internacional Carretera"></asp:ListItem>
                              </asp:DropDownList>
                            </div>
                        <div class="card-footer">
                          <asp:Button ID="btnInsert" Text="Insertar" runat="server" CssClass="btn btn-block btn-info btn-lg"  OnClick="btnInsertar_Click"/>
                            <a class="btn btn-block btn-info btn-lg" href='WebAdmSupplier.aspx'>Cancelar</a>
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
</asp:Content>
