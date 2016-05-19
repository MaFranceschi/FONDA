﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MasterUI.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BackOffice.Seccion.Menu.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="pagina" runat="server">
    Menu Principal
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">
    Menú
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">
    Menú Principal
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="migas" runat="server">
    <%--Breadcrumbs--%>
    <div>
        <ol class="breadcrumb" style="background-color: rgba(0,0,0,0);">
            <li>
                <a href="../Menu/Default.aspx">Inicio</a>
            </li>

            <li>
                <a href="../Menu/Default.aspx">Menú</a>
            </li>
            <li class="active">Menú Principal
            </li>
        </ol>
    </div>
    <%--Fin_Breadcrumbs--%>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="contenido" runat="server">

       <%--Alertas--%>
    <div id="AlertSuccess_AgregarPlato" class="row" runat="server">
        <div class="col-lg-12">
            <div class="alert alert-success fade in alert-dismissable">
                <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                <i class="fa fa-check"></i>El platillo fue agregado <strong>exitosamente!</strong>
            </div>
        </div>
    </div>

    <div id="AlertSuccess_ModificarPlato" class="row" runat="server">
        <div class="col-lg-12">
            <div class="alert alert-success fade in alert-dismissable">
                <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                <i class="fa fa-check"></i>El plato fue modificado <strong>exitosamente!</strong>
            </div>
        </div>
    </div>

       <div id="AlertDanger_AgregarPlato" class="row" runat="server">
        <div class="col-lg-12">
            <div class="alert  alert-danger fade in alert-dismissable">
                <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                <i class="fa fa-times"></i>El plano <strong>no</strong> pudo ser agregado exitosamente.
            </div>
        </div>
    </div>

    <div id="AlertDanger_ModificarPlato" class="row" runat="server">
        <div class="col-lg-12">
            <div class="alert alert-danger fade in alert-dismissable">
                <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                <i class="fa fa-times"></i>El plato <strong>no</strong> pudo ser modificado exitosamente.
            </div>
        </div>
    </div>

     <%--/Alertas--%>



    <%--Tabla Platos vieja--%>
 <%--   <div class="row">
        <div class="col-lg-12">
            <div class="panel panel-default">
                            <div class="panel-heading">
                                <h3 class="panel-title pull-left"><i class="fa fa-shopping-basket fa-fw"></i> Pastas</h3>
                                <a data-toggle="modal" data-target="#add_dish" class="btn btn-default pull-right"><i class="fa fa-plus"></i></a>
                                <div class="clearfix"></div>
                            </div>
                            <div class="panel-body">
                                <div class="table-responsive">
                                    <table id="default" class="table table-bordered table-hover table-striped">
                                        <thead>
                                            <tr>
                                            <th style="vertical-align: middle">Plato</th>
                                            <th style="vertical-align: middle">Precio</th>
                                            <th style="vertical-align: middle">IVA</th>
                                            <th style="vertical-align: middle">Total</th>
                                            <th style="vertical-align: middle">Sugerencia del día</th>
                                            <th>Estado</th>
                                            <th class="no-sort">Acciones</th>
 
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                               
                                            <td style="vertical-align: middle">Pasta Carbonara</td>
                                            <td style="vertical-align: middle">2350</td>
                                            <td style="vertical-align: middle">650</td>
                                            <td style="vertical-align: middle">3000</td>
                                            <td style="text-align: center; vertical-align: middle">
                                                 <div class="checkbox">
                                                    <label>
                                                        <input type="checkbox" id="blankCheckbox" value="option1" aria-label="...">
                                                    </label>
                                                </div>
                                            </td>
                                                <td class="text-center" style="text-align:center; vertical-align:middle""><span class="label label-success"><i class="fa fa-check"><p class="stat">A</p></i></span></td>

                                                <td class="text-center" style="text-align:center; vertical-align:middle"><a data-toggle="modal" data-target="#see_dish"><i class="fa fa-info-circle" aria-hidden="true"></i></a><a data-toggle="modal" data-target="#modify_dish"><i class="fa fa-pencil"></i></a><a data-toggle="modal" data-target="#"><i class="fa fa-check" aria-hidden="true"></i></a><a data-toggle="modal" data-target="#"><i class="fa fa-times"></i></a></td>
                                        </tr>
                                            <tr>
                                          
                                            <td style="vertical-align: middle">Pasta Carbonara</td>
                                            <td style="vertical-align: middle">2350</td>
                                            <td style="vertical-align: middle">650</td>
                                            <td style="vertical-align: middle">3000</td>
                                            <td style="text-align: center; vertical-align: middle">
                                                <div class="checkbox">
                                                    <label>
                                                        <input type="checkbox" id="blankCheckbox" value="option1" aria-label="...">
                                                    </label>
                                                </div>
                                            </td>
                                                <td class="text-center" style="text-align:center; vertical-align:middle""><span class="label label-success"><i class="fa fa-check"><p class="stat">A</p></i></span></td>

                                               <td class="text-center" style="text-align:center; vertical-align:middle"><a data-toggle="modal" data-target="#see_dish"><i class="fa fa-info-circle" aria-hidden="true"></i></a><a data-toggle="modal" data-target="#modify_dish"><i class="fa fa-pencil"></i></a><a data-toggle="modal" data-target="#"><i class="fa fa-check" aria-hidden="true"></i></a><a data-toggle="modal" data-target="#"><i class="fa fa-times"></i></a></td>

                                            </tr>
                                            <tr>
                                          
                                            <td style="vertical-align: middle">Pasta con Vegetales</td>
                                            <td style="vertical-align: middle">2350</td>
                                            <td style="vertical-align: middle">650</td>
                                            <td style="vertical-align: middle">3000</td>
                                            <td style="text-align: center; vertical-align: middle">
                                                <div class="checkbox disabled">
                                                    <label>
                                                        <input type="checkbox" value="" disabled aria-label="...">
                                                    </label>
                                                </div>
                                            </td>
                                                <td class="text-center" style="text-align:center; vertical-align:middle""><span class="label label-danger"><i class="fa fa-times"><p>I</p></i></span></td>

                                               <td class="text-center" style="text-align:center; vertical-align:middle"><a data-toggle="modal" data-target="#see_dish"><i class="fa fa-info-circle" aria-hidden="true"></i></a><a data-toggle="modal" data-target="#modify_dish"><i class="fa fa-pencil"></i></a><a data-toggle="modal" data-target="#"><i class="fa fa-check" aria-hidden="true"></i></a><a data-toggle="modal" data-target="#"><i class="fa fa-times"></i></a></td>

                                              
                                        </tr>
                                            <tr>
                                           
                                            <td style="vertical-align: middle">Pasta con Salmon</td>
                                            <td style="vertical-align: middle">2350</td>
                                            <td style="vertical-align: middle">650</td>
                                            <td style="vertical-align: middle">3000</td>
                                            <td style="text-align: center; vertical-align: middle">
                                                <div class="checkbox">
                                                    <label>
                                                        <input type="checkbox" id="blankCheckbox" value="option1" aria-label="...">
                                                    </label>
                                                </div>
                                            </td>
                                                <td class="text-center" style="text-align:center; vertical-align:middle""><span class="label label-success"><i class="fa fa-check"><p class="stat">A</p></i></span></td>

                                               <td class="text-center" style="text-align:center; vertical-align:middle"><a data-toggle="modal" data-target="#see_dish"><i class="fa fa-info-circle" aria-hidden="true"></i></a><a data-toggle="modal" data-target="#modify_dish"><i class="fa fa-pencil"></i></a><a data-toggle="modal" data-target="#"><i class="fa fa-check" aria-hidden="true"></i></a><a data-toggle="modal" data-target="#"><i class="fa fa-times"></i></a></td>

                                           
                                        </tr>
                                                
                                             
                                        </tbody>
                                    </table>       
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
           
    
                <!-- /.row -->
            <!-- /.container-fluid -->
        


        <div class="row">
                <div class="col-lg-12">
                             <div class="panel panel-default">
                            <div class="panel-heading">
                                <h3 class="panel-title pull-left"><i class="fa fa-shopping-basket fa-fw"></i> Carnes</h3>
                                <a data-toggle="modal" data-target="#add_dish" class="btn btn-default pull-right"><i class="fa fa-plus"></i></a>
                                <div class="clearfix"></div>
                            </div>
                            <div class="panel-body">
                                <div class="table-responsive">
                                    <table id="default1" class="table table-bordered table-hover table-striped">
                                        <thead>
                                            <tr>
                                            <th style="vertical-align: middle">Plato</th>
                                            <th style="vertical-align: middle">Precio</th>
                                            <th style="vertical-align: middle">IVA</th>
                                            <th style="vertical-align: middle">Total</th>
                                            <th style="vertical-align: middle">Sugerencia del día</th>
                                                 <th style="vertical-align: middle">Estado</th>
                                            <th class="no-sort">Acciones</th>
 
                                            </tr>
                                       </thead>
                                    <tbody>
                                        <tr>
                                            
                                            <td style="vertical-align: middle">Lomito a la Parrilla</td>
                                            <td style="vertical-align: middle">2350</td>
                                            <td style="vertical-align: middle">650</td>
                                            <td style="vertical-align: middle">3000</td>
                                            <td style="text-align: center; vertical-align: middle">
                                                <div class="checkbox">
                                                    <label>
                                                        <input type="checkbox" id="blankCheckbox" value="option1" aria-label="...">
                                                    </label>
                                                </div>
                                            </td>
                                             <td class="text-center" style="text-align:center; vertical-align:middle""><span class="label label-success"><i class="fa fa-check"><p>A</p></i></span></td>
                                             <td class="text-center" style="text-align:center; vertical-align:middle"><a data-toggle="modal" data-target="#see_dish"><i class="fa fa-info-circle" aria-hidden="true"></i></a><a data-toggle="modal" data-target="#modify_dish"><i class="fa fa-pencil"></i></a><a data-toggle="modal" data-target="#"><i class="fa fa-check" aria-hidden="true"></i></a><a data-toggle="modal" data-target="#"><i class="fa fa-times"></i></a></td>

                                        </tr>
                                        <tr>
                                           
                                            <td style="vertical-align: middle">Solomo a la Plancha</td>
                                            <td style="vertical-align: middle">2350</td>
                                            <td style="vertical-align: middle">650</td>
                                            <td style="vertical-align: middle">3000</td>
                                            <td style="text-align: center; vertical-align: middle">
                                                <div class="checkbox">
                                                    <label>
                                                        <input type="checkbox" id="blankCheckbox" value="option1" aria-label="...">
                                                    </label>
                                                </div>
                                            </td>
                                                <td class="text-center" style="text-align:center; vertical-align:middle""><span class="label label-success"><i class="fa fa-check"><p>A</p></i></span></td>

                                               <td class="text-center" style="text-align:center; vertical-align:middle"><a data-toggle="modal" data-target="#see_dish"><i class="fa fa-info-circle" aria-hidden="true"></i></a><a data-toggle="modal" data-target="#modify_dish"><i class="fa fa-pencil"></i></a><a data-toggle="modal" data-target="#"><i class="fa fa-check" aria-hidden="true"></i></a><a data-toggle="modal" data-target="#"><i class="fa fa-times"></i></a></td>

                                        </tr>
                                        <tr>
                                           
                                            <td style="vertical-align: middle">Chuleta Ahumada</td>
                                            <td style="vertical-align: middle">2350</td>
                                            <td style="vertical-align: middle">650</td>
                                            <td style="vertical-align: middle">3000</td>
                                            <td style="text-align: center; vertical-align: middle">
                                                <div class="checkbox">
                                                    <label>
                                                        <input type="checkbox" id="blankCheckbox" value="option1" aria-label="...">
                                                    </label>
                                                </div>
                                            </td>
                                                <td class="text-center" style="text-align:center; vertical-align:middle""><span class="label label-success"><i class="fa fa-check"><p>A</p></i></span></td>

                                                <td class="text-center" style="text-align:center; vertical-align:middle"><a data-toggle="modal" data-target="#see_dish"><i class="fa fa-info-circle" aria-hidden="true"></i></a><a data-toggle="modal" data-target="#modify_dish"><i class="fa fa-pencil"></i></a><a data-toggle="modal" data-target="#"><i class="fa fa-check" aria-hidden="true"></i></a><a data-toggle="modal" data-target="#"><i class="fa fa-times"></i></a></td>

                                        </tr>
                                    </tbody>
                                </table>
                             
                            </div>
                        </div>
                    </div>
                </div>
            </div>
                <!-- /.row -->
            <!-- /.container-fluid -->--%>

     <%--/Tabla Platos vieja--%>

    <%--Tabla Platos nueva--%>
      <div class="row">
        <div class="col-lg-12">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h3 class="panel-title pull-left"><i class="fa fa-shopping-basket fa-fw"></i>Pastas</h3>
                    <a data-toggle="modal" data-target="#add_dish" class="btn btn-default pull-right"><i class="fa fa-plus"></i></a>
                    <div class="clearfix"></div>
                </div>
                <div class="panel-body">
                    <div class="table-responsive">
                        <asp:HiddenField ID="HiddenFieldDishModifyId" runat="server" Value="" />
                        <asp:Table ID="TableDish" CssClass="table table-bordered table-hover table-striped" runat="server"></asp:Table>
                    </div>
                </div>
            </div>
        </div>
    </div>

     <%--/ Tabla Platos nueva--%>

       <%-- Modals --%>
       <!-- Modal modificar plato-->
     <div class="modal fade" id="modify_dish" role="dialog">
                <div class="modal-dialog">

                    <!-- Modal content-->
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                            <h4 class="modal-title">Modificar Platillo</h4>
                        </div>
                            <div class="modal-body">
                            
                                <div class="row">
                                      <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                                         <div class="form-group">
                                            <label class="control-label">Nombre del platillo</label>
                                            <asp:TextBox ID="TextBoxModifyDishName" CssClass="form-control" placeholder="Pasta Carbonara" runat="server"/>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                     <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                                        <div class="form-group">
                                            <label class="control-label">Descripcion del platillo</label>
                                            <asp:TextBox ID="TextBoxModifyDishDescription" CssClass="form-control" placeholder="Pasta con tocineta y queso parmesano"  runat="server"/>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                                        <div class="form-group">
                                            <label class="control-label">Precio del platillo</label>
                                            <asp:TextBox ID="TextBoxModifyDishPrice" CssClass="form-control" placeholder="1000" MaxLength="5" runat="server"/>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                                        <div class="form-group">
                                            <label for="ejemplo_archivo_1">Adjuntar una imagen del platillo</label>
                                            <input type="file" id="ejemplo_archivo_1"/>
                                            <p class="help-block">Imagen .jpg o .png</p>
                                        </div>
                                    </div>
                                </div>
                            
                                </div>


                        <div class="modal-footer">
                            <asp:Button ID="ButtonModifyDish" Text="Modificar" CssClass="btn btn-success" OnClick="ButtonModifyDish_Click" runat="server" />
                            <asp:Button ID="Button4" Text="Cancelar" CssClass="btn btn-danger" runat="server" />
                        </div>
                    </div>
                 </div>
   </div>
    <!-- Modal Ver Plato-->
     <div class="modal fade" id="see_dish" role="dialog">
                <div class="modal-dialog">

                    <!-- Modal content-->
                    <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                                <h4 class="modal-title">Platillo</h4>
                            </div>
                                <div class="modal-body">
                                     <div class="row">
                                             <div class="col-lg-4 col-md-10 col-sm-10 col-xs-10">
                                                    <div class="form-group">
                                                          <img class="img-thumbnail" src="http://placehold.it/2600x2600" alt=""></td>
                                                    </div>
                                            </div>

                                             <div class="col-lg-8 col-md-10 col-sm-10 col-xs-10">
                                                   <div class="row">
                                                      <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                                                             <div class="form-group">
                                                                <label class="control-label">Nombre del platillo</label>
                                                                 <p class="form-control-static">ej. Pasta Carbonara</p>
                                                            </div>
                                                      </div>
                                                   </div>  
                                                   <div class="row">
                                                         <div class="col-lg-12 col-md-10 col-sm-10 col-xs-10">
                                                            <div class="form-group">
                                                                <label class="control-label">Descripcion del platillo</label>
                                                                      <p class="form-control-static">ej. pasta con tocineta y queso parmesano</p>
                                                                   </div>
                                                        </div> 
                                                    </div> 
                                                     <div class="row">
                                                         <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                                                            <div class="form-group">
                                                                <label class="control-label">Precio</label>
                                                                          <p class="form-control-static">ej. 1000 bsf</p>
                                                         </div>
                                                        </div> 
                                                    </div> 
                                            </div> 
                                    
                                </div>
                         </div>
                  
                </div>
            </div>
         </div>

    <!-- Modal agregar platillo-->
    <div class="modal fade" id="add_dish" role="dialog">
                <div class="modal-dialog">

                    <!-- Modal content-->
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                            <h4 class="modal-title">Agregar Platillo</h4>
                        </div>
                            <div class="modal-body">
                              
                                <div class="row">
                                    <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                                         <div class="form-group">
                                            <label class="control-label">Nombre del platillo</label>
                                            <asp:TextBox ID="TextBoxAddDishName" CssClass="form-control" placeholder="ej. pasta carbonara" runat="server"/>
                                        </div>
                                    </div>       
                                </div>
                                <div class="row">
                                     <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                                        <div class="form-group">
                                            <label class="control-label">Descripcion del platillo</label>
                                            <asp:TextBox ID="TextBoxAddDishDescription" CssClass="form-control" placeholder="ej. pasta con tocineta y queso parmesano" runat="server"/>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                                        <div class="form-group">
                                            <label class="control-label">Precio del platillo</label>
                                            <asp:TextBox ID="TextboxAddDishPrice" CssClass="form-control" placeholder="ej. 1000" MaxLength="5" runat="server"/>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                                        <div class="form-group">
                                            <label for="ejemplo_archivo_1">Adjuntar una imagen del platillo</label>
                                            <input type="file" id="ejemplo_archivo_1"/>
                                            <p class="help-block">Imagen .jpg o .png</p>
                                        </div>
                                    </div>
                                </div>
                        <div class="modal-footer">
                           <asp:Button id="ButtonAddDish" Text="Agregar" CssClass="btn btn-success" runat="server" OnClick="ButtonAddDish_Click"/>
                           <asp:Button id="ButtonCancelAddDish" Text="Cancelar" CssClass="btn btn-danger" runat="server" OnClick="ButtonCancelAddDish_Click"/>
                        </div>
                    </div>
                </div>
            </div>
        </div>

      <%-- /Modals --%>

      <!-- script -->
    <script type="text/javascript">

        $(document).ready(function () {
            setValue();
            ajaxRes();
        });

        function ajaxRes() {
            $('.table > tbody > tr > td:nth-child(3) > a')
                .click(function (e) {
                    e.preventDefault();
                    var prueba = document.getElementById("<%=HiddenFieldDishModifyId.ClientID%>").value;
                    var params = "{'Id':'" + prueba + "'}";
                    $.ajax({
                        type: "POST",
                        url: "Default.aspx/GetData",
                        data: params,
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (response) {
                            var local = response;
                            document.getElementById("<%=TextBoxModifyDishName.ClientID%>").value = local.d.Name;
                        },
                        failure: function (response) {
                            alert("_");
                        }
                    });
                });
            }

            function setValue() {
                $('.table > tbody > tr > td:nth-child(3) > a')
                .click(function () {
                    var padreId = $(this).parent().parent().attr("data-id");
                    document.getElementById("<%=HiddenFieldDishModifyId.ClientID%>").value = padreId;
            });
        }
    </script>

</asp:Content>
