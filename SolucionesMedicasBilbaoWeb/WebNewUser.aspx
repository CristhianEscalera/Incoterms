<%@ Page Title="Nuevo Usuario" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="WebNewUser.aspx.cs" Inherits="SolucionesMedicasBilbaoWeb.WebNewUser" %>
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
                      <span id="txtError" class="error-message" style="color:red;"></span>
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
                        <asp:Label runat="server" class="form-control">Rol</asp:Label>
                        <asp:DropDownList ID="Rol" runat="server">
                            <asp:ListItem Text="Administrador" Value="Administrador"></asp:ListItem>
                            <asp:ListItem Text="Empleado" Value="Empleado"></asp:ListItem>
                            <asp:ListItem Text="Ingresos" Value="Ingresos"></asp:ListItem>
                        </asp:DropDownList>
                      </div>
                     <div class="form-group col-md-6">
                            <asp:Label runat="server">Ci</asp:Label>
                            <asp:TextBox ID="txtCi" MaxLength="15" runat="server"  class="form-control required"  placeholder="Ingrese CI" onkeypress="validarCI(event)" onkeyup="removeExtraSpaces(this);">
                            </asp:TextBox>
                      </div>
                      <div class="form-group">
                        <asp:Label runat="server">Email</asp:Label>
                        <asp:TextBox ID="txtEmail" MaxLength="50" runat="server" class="form-control required" placeholder="Ingrese su correo electrónico" onblur="validateEmail()" onkeypress="disallowSpaces(event)">
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
     <script>

         function validarCI(event) {
             var keyCode = event.which ? event.which : event.keyCode;
             var inputValue = String.fromCharCode(keyCode);

             // Permitir números, espacios, guiones y letras mayúsculas
             if (!/^\d|\s|-|[A-Z]$/.test(inputValue)) {
                 event.preventDefault();
             }
         }

         function validatePhoneNumber(event) {
             var keyCode = event.which ? event.which : event.keyCode;
             var inputValue = String.fromCharCode(keyCode);

             // Solo permitir números y el signo "+" al principio
             if (!/^\d$|\+$/.test(inputValue)) {
                 event.preventDefault();
             }
         }

         function validateTextInput(event) {
             var key = event.keyCode || event.which;
             var keyChar = String.fromCharCode(key);

             // Expresión regular para permitir letras con tilde y la letra "ñ"
             var regex = /^[a-zA-ZáéíóúüñÁÉÍÓÚÜÑ\s]*$/;

             // Verifica si la tecla presionada es una letra con tilde, la letra "ñ" o un espacio
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
    document.getElementById('<%= btnInsert.ClientID %>').onclick = function () {
        var txtName = document.getElementById('<%= txtName.ClientID %>');
        var txtD = document.getElementById('<%= txtPApellido.ClientID %>');
    var txtTelefono = document.getElementById('<%= txtSApellido.ClientID %>');
    var txtCampo1 = document.getElementById('<%= txtEmail.ClientID %>');
        var txtCi = document.getElementById('<%= txtCi.ClientID %>');
        var txtDescriptionError = document.getElementById('txtError');

        function verificarCI(ci) {
            var r = /^\d{5,10}((\s|[-])\d{1}[A-Z]{1})?$/;
            return r.test(ci);
        }

        function valNit(nit) {
            var nd, add = 0;
            if (nd = /^(\d+)\-?([\dk])$/i.exec(nit)) {
                nd[2] = (nd[2].toLowerCase() == 'k') ? 10 : parseInt(nd[2]);
                for (var i = 0; i < nd[1].length; i++) {
                    add += (((i - nd[1].length) * -1) + 1) * nd[1][i];
                }
                return ((11 - (add % 11)) % 11) == nd[2];
            } else {
                return false;
            }
        }

        // Función para validar el formato de correo electrónico
        function validateEmail(email) {
            var emailRegex = /^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$/;
            return emailRegex.test(email);
        }

        // Verificar si los campos requeridos están vacíos
        if (txtName.value.trim() === '') {
            txtName.classList.add('error');
            txtDescriptionError.textContent = 'Ingrese Nombres';
            return false; // Evitar el envío del formulario
        }

        if (txtD.value.trim() === '') {
            txtD.classList.add('error');
            txtDescriptionError.textContent = 'Ingrese el primer apellido';
            return false; // Evitar el envío del formulario
        }

        if (txtCi.value.trim() === '') {
            txtCi.classList.add('error');
            txtDescriptionError.textContent = 'Ingrese correctamente el CI';
            return false; // Evitar el envío del formulario
        } else if (!verificarCI(txtCi.value.trim())) {
            txtCi.classList.add('error');
            txtDescriptionError.textContent = 'Ingrese un CI válido';
            return false; // Evitar el envío del formulario
        }

        // Validar el formato del correo electrónico
        if (txtCampo1.value.trim() === '') {
            txtCampo1.classList.add('error');
            txtDescriptionError.textContent = 'Ingrese su correo electrónico';
            return false; // Evitar el envío del formulario
        } else if (!validateEmail(txtCampo1.value.trim())) {
            txtCampo1.classList.add('error');
            txtDescriptionError.textContent = 'Ingrese un correo electrónico válido';
            return false; // Evitar el envío del formulario
        }

        // Resto de tu lógica de validación y envío del formulario
    };

</script>
</asp:Content>
