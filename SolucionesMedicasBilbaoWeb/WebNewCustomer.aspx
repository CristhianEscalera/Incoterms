<%@ Page Title="Nuevo Cliente" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="WebNewCustomer.aspx.cs" Inherits="SolucionesMedicasBilbaoWeb.WebNewCustomer" %>
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
        <h1 style="color:white; font-family:Oswald; font-size:30px;">C L I E N T E S</h1>
    </section>

    <section class="content">
        <div class="row">
         <div class="col-md-12">
            <div class="box-body">
               <div class="card card-primary">
                  <div class="card-header" style="background-color:#1B425E">
                    <h3 class="card-title">Administración Clientes</h3>
                  </div>
                  <!-- /.card-header -->
                  <!-- form start -->
                  <div class="card-body">
                      <span id="txtError" class="error-message" style="color:red;"></span>
                      <div class="form-group">
                        <asp:Label runat="server">Nombres</asp:Label>
                        <asp:TextBox ID="txtName" MaxLength="60" runat="server" class="form-control required"  onkeypress="return validateTextInput(event)" onkeyup="removeExtraSpaces(this)" onblur="validateSpaces(this)">
                        </asp:TextBox>
                      </div>
                      <div class="row">
                          <div class="form-group col-md-6">
                            <asp:Label runat="server">Primer Apellido</asp:Label>
                            <asp:TextBox ID="txtPApellido" MaxLength="60" runat="server" class="form-control required" onkeypress="return validateTextInput(event)" onkeyup="removeExtraSpaces(this)" onblur="validateSpaces(this)">
                            </asp:TextBox>
                          </div>
                          <div class="form-group col-md-6">
                            <asp:Label runat="server">Segundo Apellido</asp:Label>
                            <asp:TextBox ID="txtSApellido" MaxLength="60" runat="server" class="form-control required"  onkeypress="return validateTextInput(event)" onkeyup="removeExtraSpaces(this)" onblur="validateSpaces(this)">
                            </asp:TextBox>
                          </div>
                     </div>
                      <div class="row">
                          <div class="form-group col-md-6">
                            <asp:Label runat="server">Establecimiento</asp:Label>
                            <asp:TextBox ID="txtNameBussines" MaxLength="85" runat="server" class="form-control required"  onkeypress="return validateTextInput(event)" onkeyup="removeExtraSpaces(this)" onblur="validateSpaces(this)">
                            </asp:TextBox>
                          </div>
                          <div class="form-group col-md-6">
                            <asp:Label runat="server">Título</asp:Label>
                            <asp:TextBox ID="txtTitulo" MaxLength="150" runat="server" class="form-control required"  onkeypress="return validateTextInput(event)" onkeyup="removeExtraSpaces(this)" onblur="validateSpaces(this)">
                            </asp:TextBox>
                          </div>
                      </div>
                      
                      <div class="row">
                         <div class="form-group col-md-4">
                                <asp:Label runat="server">Ci</asp:Label>
                                <asp:TextBox ID="txtCi" MaxLength="15" runat="server" class="form-control required"  placeholder="Ingrese CI" onkeypress="validarCI(event)" onkeyup="removeExtraSpaces(this);">
                                </asp:TextBox>
                          </div>
                          <div class="form-group col-md-4">
                            <asp:Label runat="server">Nit</asp:Label>
                            <asp:TextBox ID="txtNit" MaxLength="30" runat="server" class="form-control required"  placeholder="Ingrese NIT" onkeypress="validarNIT(event)" onkeyup="removeExtraSpaces(this);">
                            </asp:TextBox>
                          </div>
                          <div class="form-group col-md-4">
                            <asp:Label runat="server">Teléfono</asp:Label>
                            <asp:TextBox ID="txtPhone" MaxLength="17" runat="server" class="form-control required"  placeholder="Ingrese teléfono" onkeypress="return validatePhoneNumber(event)">
                            </asp:TextBox>
                          </div>
                       </div>
                    </div>
                    <!-- /.card-body -->

                    <div class="card-footer">
                        <asp:Button ID="btnInsert" Text="Insertar" runat="server" CssClass="btn btn-block btn-info btn-lg"  OnClick="btnInsertar_Click"/>
                        <a class="btn btn-block btn-info btn-lg" href='WebAdmCustomer.aspx'>Cancelar</a>
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

        function validarNIT(event) {
            var keyCode = event.which ? event.which : event.keyCode;
            var inputValue = String.fromCharCode(keyCode);

            // Solo permitir números, guion "-", espacios y la letra "K" mayúscula
            if (!/^\d$|-|\s|K$/i.test(inputValue)) {
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
       var txtDPA = document.getElementById('<%= txtPApellido.ClientID %>');
       var txtCi = document.getElementById('<%= txtCi.ClientID %>');
       var txtTitulo = document.getElementById('<%= txtTitulo.ClientID %>');
       var txtNit = document.getElementById('<%= txtNit.ClientID %>');
       var txtTelefono = document.getElementById('<%= txtPhone.ClientID %>');
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

           // Verificar si los campos requeridos están vacíos
           if (txtName.value.trim() === '') {
               txtName.classList.add('error');
               txtDescriptionError.textContent = 'Ingrese Nombres';
               return false; // Evitar el envío del formulario
           }

           if (txtDPA.value.trim() === '') {
               txtDPA.classList.add('error');
               txtDescriptionError.textContent = 'Ingrese el primer apellido';
               return false; // Evitar el envío del formulario
           }

           if (txtTitulo.value.trim() === '') {
               txtTitulo.classList.add('error');
               txtDescriptionError.textContent = 'Ingrese título';
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

           if (txtNit.value.trim() === '') {
               txtNit.classList.add('error');
               txtDescriptionError.textContent = 'Ingrese correctamente el NIT';
               return false; // Evitar el envío del formulario
           } else if (!valNit(txtNit.value.trim())) {
               txtNit.classList.add('error');
               txtDescriptionError.textContent = 'Ingrese un NIT válido';
               return false; // Evitar el envío del formulario
           }

           var telefonoValue = txtTelefono.value.trim();
           if (telefonoValue === '' || telefonoValue.length < 7) {
               txtTelefono.classList.add('error');
               txtDescriptionError.textContent = 'Ingrese un número de teléfono válido';
               return false; // Evitar el envío del formulario
           }
       };
   </script>

</asp:Content>
