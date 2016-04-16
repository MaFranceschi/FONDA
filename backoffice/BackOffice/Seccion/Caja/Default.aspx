﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MasterUI.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BackOffice.Seccion.Caja.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="pagina" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">
    Ordenes
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">
    Lista de Ordenes
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="migas" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="contenido" runat="server">
   
    <div class="text-right">
                   <asp:Button id="Button2" Text="Cerrar Caja" CssClass="btn btn-primary" runat="server" OnClick="Button1_Click"/>
    </div>

    <div class="row">
        <div class="col-lg-12">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h3 class="panel-title"><i class="fa fa-money fa-fw"></i> Ordenes Abiertas </h3>
                </div>
                <div class="panel-body">
                    <div class="table-responsive">
                        <table class="table table-bordered table-hover table-striped">
                            <thead>
                                <tr>
                                    <th>N° Orden</th>
                                    <th>Cliente</th>                          
                                    <th >Modificar</th>
                                    <th >Pagar</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td><a href="VerDetalleOrden.aspx">#1</a></td>
                                    <td>@pperez</td>
                                    <td><a href="ModificarOrden.aspx"><i class="fa fa-pencil-square-o"></i></a></td>
                                    <td><a href="CrearFactura.aspx"><i class="fa fa-money fa-fw"></i></a></td>
                                </tr>
                                <tr>
                                    <td><a href="VerDetalleOrden.aspx">#2</a></td>
                                    <td>@jero1604</td>
                                    <td><a href="ModificarOrden.aspx"><i class="fa fa-pencil-square-o"></i></a></td>
                                    <td><a href="CrearFactura.aspx"><i class="fa fa-money fa-fw"></i></a></td>
                                </tr>
                                <tr>
                                    <td><a href="VerDetalleOrden.aspx">#3</a></td>
                                    <td>@vero12</td>
                                    <td><a href="ModificarOrden.aspx"><i class="fa fa-pencil-square-o"></i></a></td>
                                    <td><a href="CrearFactura.aspx"><i class="fa fa-money fa-fw"></i></a></td>
                                </tr>
                            </tbody>
                        </table>
                        <div class="text-right">
                            <a href="AgregarOrden.aspx"><i class="fa fa-plus"></i> Agregar nueva orden</a>
                        </div>
       
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- /.row -->

    <div class="row">
        <div class="col-lg-12">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h3 class="panel-title"><i class="fa fa-money fa-fw"></i> Ordenes Cerradas </h3>
                </div>
                <div class="panel-body">
                    <div class="table-responsive">
                        <table class="table table-bordered table-hover table-striped">
                            <thead>
                                <tr>
                                    <th>N° Orden</th>
                                    <th>Cliente</th>                          
                                    <th>Fecha</th>
                                    <th>Monto Total</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td><a href="VerDetalleOrdenCerrada.aspx">#1</a></td>
                                    <td>@pperez</td>
                                    <td>10/10/2014</td>
                                    <td>8000</td>
                                </tr>
                                <tr>
                                    <td><a href="VerDetalleOrdenCerrada.aspx">#2</a></td>
                                    <td>@jero1604</td>
                                    <td>10/10/2014</td>
                                    <td>6000</td>
                                </tr>
                                <tr>
                                    <td><a href="VerDetalleOrdenCerrada.aspx">#3</a></td>
                                    <td>@vero12</td>
                                    <td>10/10/2014</td>
                                    <td>7000</td>
                                </tr>
                            </tbody>
                        </table>
       
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- /.row -->
</asp:Content>
