<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="WebNewStateImport.aspx.cs" Inherits="SolucionesMedicasBilbaoWeb.WebNewStateImport" %>
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
        <h1 style="color:white; font-family:Oswald; font-size:30px;">E S T A D O</h1>
    </section>

    <section class="content">
        <div class="row">
         <div class="col-md-12">
            <div class="box-body">
               <div class="card card-primary">
                  <div class="card-header" style="background-color:#1B425E">
                    <h3 class="card-title">Administracion Estado</h3>
                  </div>              
                  <div class="card-body">
                      <span id="txtError" class="error-message" style="color:red;"></span>
                      <div class="row">
                         <div class="form-group col-md-6">
                          <asp:Label runat="server">Nombre</asp:Label>
                            <asp:TextBox ID="txtName" MaxLength="60" runat="server" class="form-control required"  placeholder="Ingrese nombre" onkeypress="return validateTextInput(event)" onkeyup="removeExtraSpaces(this)" onblur="validateSpaces(this)">
                            </asp:TextBox>
                          </div>
                          <div class="form-group col-md-6">
                            <asp:Label runat="server">País</asp:Label>
                            <asp:DropDownList ID="cmbPais" runat="server" class="form-control required"></asp:DropDownList>
                          </div>
                       </div>
                    </div>
                    <div class="card-footer">
                        <asp:Button ID="btnInsert" Text="Insertar" runat="server" CssClass="btn btn-block btn-info btn-lg" OnClick="btnInsert_Click"/>
                        <a class="btn btn-block btn-info btn-lg" href='WebAdmStateImport.aspx'>Cancelar</a>
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
        document.getElementById('<%= btnInsert.ClientID %>').onclick = function () {
            var txtName = document.getElementById('<%= txtName.ClientID %>');
            var txtDescriptionError = document.getElementById('txtError');

            if (txtName.value.trim() === '') {
                txtName.classList.add('error');
                txtDescriptionError.textContent = 'Ingrese Nombre del país';
                return false; 
            }

        };

    </script>
</asp:Content>
