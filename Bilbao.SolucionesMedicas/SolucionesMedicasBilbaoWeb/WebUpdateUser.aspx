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
                  <div class="card-body">
                      <span id="txtError" class="error-message" style="color:red;"></span>
                      <div class="form-group">
                        <asp:Label runat="server">Nombre</asp:Label>
                        <asp:TextBox ID="txtName" MaxLength="50" runat="server" class="form-control required"  onkeyup="removeExtraSpaces(this)" onblur="validateSpaces(this)">
                        </asp:TextBox>
                      </div>
                      <div class="form-group">
                            <asp:Label runat="server">Usuario</asp:Label>
                            <asp:TextBox ID="txtUser" MaxLength="50" runat="server" class="form-control required"   onkeyup="removeExtraSpaces(this)" onblur="validateSpaces(this)">
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
                      <div class="row">
                      <div class="form-group col-md-6"">
                            <asp:Label runat="server">Rol</asp:Label>
                            <asp:DropDownList ID="Rol" runat="server" class="form-control">
                                <asp:ListItem Text="Administrador" Value="Administrador"></asp:ListItem>
                                <asp:ListItem Text="Empleado" Value="Empleado"></asp:ListItem>
                                <asp:ListItem Text="Ingresos" Value="Ingresos"></asp:ListItem>
                            </asp:DropDownList>
                          </div>
                         <div class="form-group col-md-6">
                                <asp:Label runat="server">Ci</asp:Label>
                                <asp:TextBox ID="txtCi" MaxLength="15" runat="server" class="form-control required"  placeholder="Ingrese CI" onkeypress="validarCI(event)" onkeyup="removeExtraSpaces(this);">
                                </asp:TextBox>
                          </div>
                      </div>
                      <div class="form-group">
                        <asp:Label runat="server">Email</asp:Label>
                        <asp:TextBox ID="txtEmail" MaxLength="50" runat="server" class="form-control required" placeholder="Ingrese su correo electrónico" onblur="validateEmail()" onkeypress="disallowSpaces(event)">
                        </asp:TextBox>
                      </div>
                    </div>
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
                  <script>

                      function validarCI(event) {
                          var keyCode = event.which ? event.which : event.keyCode;
                          var inputValue = String.fromCharCode(keyCode);

                          if (!/^\d|\s|-|[A-Z]$/.test(inputValue)) {
                              event.preventDefault();
                          }
                      }

                      function disallowSpaces(event) {
                          var key = event.key;

                          if (key === " ") {
                              event.preventDefault();
                          }
                      }

                      function validarNIT(event) {
                          var keyCode = event.which ? event.which : event.keyCode;
                          var inputValue = String.fromCharCode(keyCode);

                          if (!/^\d$|-|\s|K$/i.test(inputValue)) {
                              event.preventDefault();
                          }
                      }

                      function validatePhoneNumber(event) {
                          var keyCode = event.which ? event.which : event.keyCode;
                          var inputValue = String.fromCharCode(keyCode);

                          if (!/^\d$|\+$/.test(inputValue)) {
                              event.preventDefault();
                          }
                      }

                      function validateTextInput(event) {
                          var key = event.keyCode || event.which;
                          var keyChar = String.fromCharCode(key);

                          var regex = /^[a-zA-ZáéíóúüñÁÉÍÓÚÜÑ\s]*$/;

                          if (!regex.test(keyChar)) {
                              event.preventDefault();
                              return false;
                          }
                      }

                      function removeExtraSpaces(textInput) {
                          textInput.value = textInput.value.replace(/\s{2,}/g, ' ');
                      }

                      function removeLeadingTrailingSpaces(textInput) {
                          textInput.value = textInput.value.trim();
                      }

                      function validateSpaces(textInput) {
                          textInput.value = textInput.value.replace(/^\s+|\s+$/g, '');
                      }
                  </script>
        <script>
                document.getElementById('<%= btnModificar.ClientID %>').onclick = function () {
                var txtName = document.getElementById('<%= txtName.ClientID %>');
                var txtD = document.getElementById('<%= txtPApellido.ClientID %>');
                var txtTelefono = document.getElementById('<%= txtSApellido.ClientID %>');
                var txtCampo1 = document.getElementById('<%= txtEmail.ClientID %>');
                var txtUser = document.getElementById('<%= txtUser.ClientID %>');
                var txtCi = document.getElementById('<%= txtCi.ClientID %>');
                var txtDescriptionError = document.getElementById('txtError');

                function verificarCI(ci) {
                    var r = /^\d{5,10}((\s|[-])\d{1}[A-Z]{1})?$/;
                    return r.test(ci);
                }


                function validateEmail(email) {
                    var emailRegex = /^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$/;
                    return emailRegex.test(email);
                }

                var UserValue = txtUser.value.trim();
                if (txtUser.value.trim() === '' || UserValue.length < 3) {
                    txtUser.classList.add('error');
                    txtDescriptionError.textContent = 'Ingrese el nombre de usuario';
                    return false; 
                }

                if (txtName.value.trim() === '') {
                    txtName.classList.add('error');
                    txtDescriptionError.textContent = 'Ingrese Nombres';
                    return false; 
                }

                if (txtD.value.trim() === '') {
                    txtD.classList.add('error');
                    txtDescriptionError.textContent = 'Ingrese el primer apellido';
                    return false; 
                }

                if (txtCi.value.trim() === '') {
                    txtCi.classList.add('error');
                    txtDescriptionError.textContent = 'Ingrese correctamente el CI';
                    return false;
                } else if (!verificarCI(txtCi.value.trim())) {
                    txtCi.classList.add('error');
                    txtDescriptionError.textContent = 'Ingrese un CI válido';
                    return false; 
                }

                if (txtCampo1.value.trim() === '') {
                    txtCampo1.classList.add('error');
                    txtDescriptionError.textContent = 'Ingrese su correo electrónico';
                    return false; 
                } else if (!validateEmail(txtCampo1.value.trim())) {
                    txtCampo1.classList.add('error');
                    txtDescriptionError.textContent = 'Ingrese un correo electrónico válido';
                    return false; 
                }
            };

        </script>
</asp:Content>