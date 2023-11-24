<%@ Page Title="Nuevo Proveedor" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="WebNewSupplier.aspx.cs" Inherits="SolucionesMedicasBilbaoWeb.WebNewSupplier" %>
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
        <h1 style="color:white; font-family:Oswald; font-size:30px;">P R O V E E D O R</h1>
    </section>

    <section class="content">
        <div class="row">
         <div class="col-md-12">
            <div class="box-body">
               <div class="card card-primary">
                  <div class="card-header" style="background-color:#1B425E">
                    <h3 class="card-title">Administración Proveedor</h3>
                  </div>
                  <div class="card-body">
                      <span id="txtError" class="error-message" style="color:red;"></span>
                      <div class="form-group">
                        <asp:Label runat="server">Nombre</asp:Label>
                        <asp:TextBox ID="txtName" MaxLength="50" runat="server" class="form-control required"  placeholder="Ingrese proveedor" onkeyup="removeExtraSpaces(this)" onblur="validateSpaces(this)">
                        </asp:TextBox>
                      </div>
                      <div class="row">
                          <div class="form-group col-md-4">
                            <asp:Label runat="server">Nit</asp:Label>
                            <asp:TextBox ID="txtNit" MaxLength="13" runat="server" class="form-control required"  placeholder="Ingrese NIT" onkeypress="validarNIT(event)" onkeyup="removeExtraSpaces(this);">
                            </asp:TextBox>
                          </div>
                      
                          <div class="form-group col-md-4">
                          <asp:Label runat="server">País Codigo</asp:Label>
                          <asp:DropDownList ID="ddlPais" runat="server" class="form-control">
                            <asp:ListItem Text="Estados Unidos" Value="+1" />
                            <asp:ListItem Text="Canadá" Value="+1" />
                            <asp:ListItem Text="China" Value="+86" />
                            <asp:ListItem Text="Bolivia" Value="+591" />
                          </asp:DropDownList>
                        </div>

                        <div class="form-group col-md-4">
                          <asp:Label runat="server">Teléfono</asp:Label>
                          <asp:TextBox ID="txtTelefono" MaxLength="15" runat="server" class="form-control required" onkeypress="return validatePhoneNumber(event)" onkeyup="removeExtraSpaces2(this); validateTelefono(this);">
                          </asp:TextBox>
                        </div>
                     </div>

                      <div class="form-group">
                        <asp:Label runat="server">Dirección</asp:Label>
                        <asp:TextBox ID="txtDireccion" MaxLength="150" runat="server" class="form-control required"  placeholder="Ingrese dirección" onkeyup="removeExtraSpaces(this)" onblur="validateSpaces(this)">
                        </asp:TextBox>
                      </div>
                      <div class="form-group">
                        <asp:Label runat="server">Sitio Web</asp:Label>
                        <asp:TextBox ID="txtSitioWeb" MaxLength="50" runat="server" class="form-control required"  placeholder="Ingrese sitio web" onkeypress="disallowSpaces(event)">
                        </asp:TextBox>
                      </div>
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
    
<script src="plugins/datatables/jquery.dataTables.min.js"></script>
<script src="plugins/datatables-bs4/js/dataTables.bootstrap4.min.js"></script>
<script src="plugins/datatables-responsive/js/dataTables.responsive.min.js"></script>
<script src="plugins/datatables-responsive/js/responsive.bootstrap4.min.js"></script>
<script src="plugins/datatables-buttons/js/dataTables.buttons.min.js"></script>
<script src="plugins/datatables-buttons/js/buttons.bootstrap4.min.js"></script>
<script src="plugins/jszip/jszip.min.js"></script>
<script src="plugins/pdfmake/pdfmake.min.js"></script>
<script src="plugins/pdfmake/vfs_fonts.js"></script>
<script src="plugins/datatables-buttons/js/buttons.html5.min.js"></script>
<script src="plugins/datatables-buttons/js/buttons.print.min.js"></script>
<script src="plugins/datatables-buttons/js/buttons.colVis.min.js"></script>
     <script>

         function validateTelefono(textbox) {
             var minCaracteres = 7;
             var telefono = textbox.value.trim();

             if (telefono.length < minCaracteres) {
                 textbox.style.borderColor = 'red';
             } else {
                 textbox.style.borderColor = '';
             }
         }

         function disallowSpaces(event) {
             var key = event.key;

             if (key === " ") {
                 event.preventDefault();                                
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

        function validatePhoneNumber(event) {
            var keyCode = event.which ? event.which : event.keyCode;
            var inputValue = String.fromCharCode(keyCode);

            if (!/^\d$|\+$|\s$/.test(inputValue)) {
                event.preventDefault();
            }
        }

        function removeExtraSpaces2(element) {
            var phoneNumber = element.value.trim();
            var phoneNumberWithoutExtraSpaces = phoneNumber.replace(/\s{2,}/g, ' '); 
            var phoneNumberPattern = /^(\+)?(\d|\s)*$/; 

            if (!phoneNumberPattern.test(phoneNumberWithoutExtraSpaces)) {
                element.classList.add('error');
            } else {
                element.classList.remove('error');                      
                element.value = phoneNumberWithoutExtraSpaces;
            }
        }
    </script>
    <script>
        document.getElementById('<%= btnInsert.ClientID %>').onclick = function () {
            var txtName = document.getElementById('<%= txtName.ClientID %>');
            var txtDireccion = document.getElementById('<%= txtDireccion.ClientID %>');
            var txtTelefono = document.getElementById('<%= txtTelefono.ClientID %>');
            var txtCampo1 = document.getElementById('<%= txtSitioWeb.ClientID %>');
            var txtNit = document.getElementById('<%= txtNit.ClientID %>');
            var txtDescriptionError = document.getElementById('txtError');

            if (txtName.value.trim() === '') {
                txtName.classList.add('error');
                txtDescriptionError.textContent = 'Ingrese Nombres';
                return false; 
            }

            if (txtDireccion.value.trim() === '') {   
                txtDireccion.classList.add('error');        
                txtDescriptionError.textContent = 'Ingrese una dirección';
                return false; 
            }

            var telefonoValue = txtTelefono.value.trim();
            if (telefonoValue === '' || telefonoValue.length < 7) {
                txtTelefono.classList.add('error');
                txtDescriptionError.textContent = 'Ingrese un teléfono valido';
                return false; 
            }

            if (txtCampo1.value.trim() === '') {
                txtCampo1.classList.remove('error');
            } else if (txtCampo1.value.trim().length < 10) {
                txtCampo1.classList.add('error');
                txtDescriptionError.textContent = 'Ingrese un Sitio Web  valido';
                return false; 
            }

            if (txtNit.value.trim() === '') {
                txtNit.classList.remove('error');
            } else if (txtNit.value.trim().length <= 7) {
                txtNit.classList.add('error');
                txtDescriptionError.textContent = 'Ingrese correctamente el NIT';
                return false; 
            } 
        };

    </script>
</asp:Content>
