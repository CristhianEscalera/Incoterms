<%@ Page Title="Login" Language="C#" MasterPageFile="~/Login.Master" AutoEventWireup="true" CodeBehind="WebLogin.aspx.cs" Inherits="SolucionesMedicasBilbaoWeb.WebLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,400i,700&display=fallback">
    
    <link rel="stylesheet" href="../../plugins/fontawesome-free/css/all.min.css">
    
    <link rel="stylesheet" href="../../dist/css/adminlte.min.css">
    <link rel="stylesheet" href="../../plugins/icheck-bootstrap/icheck-bootstrap.min.css">
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
  <div class="login-box">
  <div class="login-logo">
    <img src="../../dist/img/capture.png" width="200">
  </div>
  <div class="card">
    <div class="card-body login-card-body">
        <span id="txtError" class="error-message" runat="server"></span>
        <div class="input-group mb-3">
          <asp:TextBox ID="txtUser" runat="server" class="form-control required"  placeholder="User" />
          <div class="input-group-append">
            <div class="input-group-text">
              <span class="fas fa-user"></span>
            </div>
          </div>
        </div>
        <div class="input-group mb-3">
          <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" class="form-control required"  placeholder="Contraseña" />
          <div class="input-group-append">
            <div class="input-group-text">
              <span class="fas fa-lock"></span>
            </div>
          </div>
        </div>

      <div class="social-auth-links text-center mb-3">
          <asp:Button ID="btnIngresar" Text="Ingresar" runat="server" CssClass="btn btn-block btn-info"  OnClick="btnIngresar_Click"/>
      </div>
    </div>
  </div>
</div>
 </form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
     <script src="../../plugins/jquery/jquery.min.js"></script>
    
    <script src="../../plugins/bootstrap/js/bootstrap.bundle.min.js"></script>
    
    <script src="../../dist/js/adminlte.min.js"></script>
     <script>
        document.getElementById('<%= btnIngresar.ClientID %>').onclick = function () {
            var txtUser = document.getElementById('<%= txtUser.ClientID %>');
            var txtPassword = document.getElementById('<%= txtPassword.ClientID %>');
            var txtDescriptionError = document.getElementById('txtError');

            if (txtUser.value.trim() === '') {
                txtUser.classList.add('error');
                txtDescriptionError.textContent = 'Ingrese su User';
                return false; 
            }

            if (txtPassword.value.trim() === '') {
                txtPassword.classList.add('error');
                txtDescriptionError.textContent = 'Ingrese su Contraseña';
                return false; 
            }
        };

     </script>
</asp:Content>
