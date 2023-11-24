<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="WebAdmImport.aspx.cs" Inherits="SolucionesMedicasBilbaoWeb.WebAdmImport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link rel="stylesheet" href="plugins/datatables-bs4/css/dataTables.bootstrap4.min.css">
 <link rel="stylesheet" href="plugins/datatables-responsive/css/responsive.bootstrap4.min.css">
 <link rel="stylesheet" href="plugins/datatables-buttons/css/buttons.bootstrap4.min.css">
   <style>
       .square-button {
           width: 30px;
           height: 30px;
           border: none;
           padding: 0;
           text-align: center;
           text-decoration: none;
           display: inline-block;
           font-size: 16px;
           margin: 2px;
           cursor: pointer;
           border-radius: 4px;
       }

       .blue-button {
           background-color: #007bff;
           color: white;
       }

       .red-button {
           background-color: #dc3545;
           color: white;
       }
       .green-button {
         background-color: green;
         color: white;
       }
       .fixed-headers th {
        position: sticky;
        top: 0;
        z-index: 1;
        background-color: #f7f7f7; 
        font-weight: bold; 
        }
   </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <form id="form1" runat="server">
<div class="form-box">

<section class="content-header">
    <h1 style="color:white; font-family:Oswald; font-size:30px;">I M P O R T A C I Ó N</h1>
</section>

<section class="content">
    <div class="row">
        <div class="col-md-3">
            <a class="btn btn-block btn-info btn-lg" href='WebNewImport.aspx'>Agregar</a>
        </div>
    </div>
    <br>
    <div class="row">
        <div class="col-md-12">
            <div class="input-group mb-3">
                <input type="text" id="txtSearch" class="form-control" placeholder="Buscar...">
                <div class="input-group-append">
                    <button class="btn btn-primary" id="btnSearchTop" onclick="searchData()">Buscar</button>
                    <asp:Button ID="btnGenerarPDF" runat="server" Text="Generar PDF" OnClick="btnGenerarPDF_Click" CssClass="btn btn-primary" />
                </div>
            </div>
        </div>
    </div>
    <div class="row">
    <div class="col-md-12">
        <div class="box-body" style="background-color:white;max-height: 450px; overflow-y: auto;" >
            <asp:GridView ID="gridData" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered table-hover fixed-headers" OnRowCommand="gridData_RowCommand" >
                <Columns>
                    <asp:BoundField DataField="Incoterms" HeaderText="Incoterms" />
                    <asp:BoundField DataField="FechaSalida" HeaderText="Fecha Salida" DataFormatString="{0:yyyy-MM-dd}" ItemStyle-Width="120px" />
                    <asp:BoundField DataField="FechaTentativa" HeaderText="Fecha Tentativa" DataFormatString="{0:yyyy-MM-dd}" ItemStyle-Width="120px" />
                    <asp:BoundField DataField="FechaLlegada" HeaderText="Fecha Llegada" DataFormatString="{0:yyyy-MM-dd}" ItemStyle-Width="120px" />
                    <asp:BoundField DataField="Origen" HeaderText="Origen" />
                    <asp:BoundField DataField="Destino" HeaderText="Destino" />
                    <asp:BoundField DataField="Embarcador" HeaderText="Embarcador" />
                    <asp:BoundField DataField="Proveedor" HeaderText="Proveedor" />  
                    <asp:BoundField DataField="Creado en:" HeaderText="Creado en:" />
                    <asp:TemplateField HeaderText="Acciones">
                        <ItemTemplate>
                            <a class="square-button blue-button" href='WebUpdateImport.aspx?id=<%#Eval("id")%>'><i class="fas fa-pencil-alt"></i></a>
                            <asp:LinkButton ID="btnEliminar" runat="server" CssClass="square-button red-button" CommandName="Eliminar" CommandArgument='<%# Eval("ID") %>' Text='<i class="fas fa-trash"></i>' OnClientClick="return confirm('¿Deseas Eliminarlo?');"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
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
</asp:Content>
