<%@ Page Title="Mod. Usruario" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="WebUpdateUser.aspx.cs" Inherits="SolucionesMedicasBilbaoWeb.WebUpdateUser" %>
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
        <h1 style="color:white; font-family:Oswald; font-size:30px;">U S U A R I O S</h1>
    </section>

    <section class="content">
        <div class="row">
         <div class="col-md-12">
            <div class="box-body">
               <div class="card card-primary">
                  <div class="card-header" style="background-color:#1B425E">
                    <h3 class="card-title">Administración Usuarios</h3>
                  </div>
                  <!-- /.card-header -->
                  <!-- form start -->
                  <div class="card-body">
                      <div class="form-group">
                        <asp:Label runat="server">Nombre</asp:Label>
                        <asp:TextBox ID="txtName" MaxLength="50" runat="server" class="form-control required"  onkeyup="removeExtraSpaces(this)" onblur="validateSpaces(this)">
                        </asp:TextBox>
                      </div>
                      <div class="form-group">
                            <asp:Label runat="server">Usuario</asp:Label>
                            <asp:TextBox ID="txtUser" MaxLength="50" runat="server" class="form-control required"  onkeyup="removeExtraSpaces(this)" onblur="validateSpaces(this)">
                            </asp:TextBox>
                          </div>
                      <div class="row">
                          <div class="form-group col-md-6">
                            <asp:Label runat="server">Primer Apellido</asp:Label>
                            <asp:TextBox ID="txtPApellido" MaxLength="50" runat="server" class="form-control required"  onkeyup="removeExtraSpaces(this)" onblur="validateSpaces(this)">
                            </asp:TextBox>
                          </div>
                          <div class="form-group col-md-6">
                            <asp:Label runat="server">Segundo Apellido</asp:Label>
                            <asp:TextBox ID="txtSApellido" MaxLength="50" runat="server" class="form-control required"  onkeyup="removeExtraSpaces(this)" onblur="validateSpaces(this)">
                            </asp:TextBox>
                          </div>
                     </div>
                      <div class="form-group">
                        <asp:Label runat="server">Rol</asp:Label>
                        <asp:DropDownList ID="Rol" runat="server">
                            <asp:ListItem Text="Administrador" Value="Administrador"></asp:ListItem>
                            <asp:ListItem Text="Empleado" Value="Empleado"></asp:ListItem>
                            <asp:ListItem Text="Ingresos" Value="Ingresos"></asp:ListItem>
                        </asp:DropDownList>
                      </div>
                     <div class="form-group col-md-6">
                            <asp:Label runat="server">Ci</asp:Label>
                            <asp:TextBox ID="txtCi" MaxLength="15" runat="server" class="form-control required"  onkeypress="return validatePhoneNumber(event)" onkeyup="removeExtraSpaces2(this); validateTelefono(this);">
                            </asp:TextBox>
                      </div>
                      <div class="form-group">
                        <asp:Label runat="server">Email</asp:Label>
                        <asp:TextBox ID="txtEmail" MaxLength="50" runat="server" class="form-control required"  placeholder="Ingrese sitio web" onkeypress="disallowSpaces(event)">
                        </asp:TextBox>
                      </div>
                    </div>
                    <!-- /.card-body -->

                    <div class="card-footer">
                     <asp:Button ID="btnModificar" Text="Modificar" runat="server" CssClass="btn btn-block btn-info btn-lg"  OnClick="btnModificar_Click"/>
                        <a class="btn btn-block btn-info btn-lg" href='WebAdmUser.aspx'>Cancelar</a>
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
