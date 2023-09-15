<%@ Page Title="Nuevo Usuario" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="WebNewUser.aspx.cs" Inherits="SolucionesMedicasBilbaoWeb.WebNewUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
                     <asp:Button ID="btnInsert" Text="Insertar" runat="server" CssClass="btn btn-block btn-info btn-lg"  OnClick="btnInsertar_Click"/>
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
