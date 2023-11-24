<%@ Page Title="Empleado" Language="C#" MasterPageFile="~/Empleado.Master" AutoEventWireup="true" CodeBehind="Empleado.aspx.cs" Inherits="SolucionesMedicasBilbaoWeb.Empleado1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .Inicio{
            width: 100%;
            height: auto;
            position: relative;
        }
        video{
            width: 100%; 
            height: 100%;
        }
        .absolute{
            width: 100%;
            height: 100%;
            top: 0;
            right: 0;
            position: absolute;
            text-align: center;
            display: flex;
            justify-content: center;
            align-items: center;
        }
        .Inicio h1{
            font-size: 80px;
            font-weight: 900;
            z-index: 100;
            color: white;
            margin-bottom: 30px;
        }
        .Inicio h1::after{
            display: block;
            width: 30%;
            height: 10px;
            content: "";
            margin: auto;
            background: white;
        }
        .overlay{
            width: 100%;
            height: 100%;
            position: absolute;
            background: rgba(0, 0, 0, 0.575);
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-lg-12 col-12">
                 <div class="Inicio"
                    <div class="overlay"></div>
                    <div class="absolute">
                        <h1>BIENVENIDO</h1>
                    </div>
                    <video onloadstart="this.muted=true" autoplay loop>
                        <source src="../../dist/img/inicio.mov">
                    </video>
                </div>
        </div>
        <br>
         <div class="row">
             
          <div class="col-lg-3 col-6">
            <div class="small-box" style="background-color:#699CCC">
              <div class="inner">
                <h3>157</h3>

                <p>Objetos en Stock</p>
              </div>
              <div class="icon">
                <i class="fa fa-briefcase"></i>
              </div>
            </div>
          </div>
          <div class="col-lg-3 col-6">
            <div class="small-box" style="background-color:#699CCC">
              <div class="inner">
                <h3>2154<sup style="font-size: 20px">Bs</sup></h3>

                <p>Ganancia total actual</p>
              </div>
              <div class="icon">
                <i class="fa fa-credit-card"></i>
              </div>
            </div>
          </div>
          <div class="col-lg-3 col-6">
            <div class="small-box" style="background-color:#699CCC">
              <div class="inner">
                <h3>53<sup style="font-size: 20px">%</sup></h3>

                <p>Clientes Atendidos</p>
              </div>
              <div class="icon">
                <i class="fa fa-address-book"></i>
              </div>
            </div>
          </div>
          <div class="col-lg-3 col-6">
            <div class="small-box" style="background-color:#699CCC">
              <div class="inner">
                <h3>65</h3>

                <p>Facturas realizadas</p>
              </div>
              <div class="icon">
                <i class="fa fa-address-card"></i>
              </div>
            </div>
          </div>
        </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
