<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="ConMatricula.aspx.cs" Inherits="GerenciaProjeto.ConMatricula" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="conteudo" runat="server">
    <form runat="server" id="form1" data-toggle="validator">
        <div class="col-md-12">
            <div class="col-lg-6">
                <div style="margin-top:10px; margin-left:5px;" >
                    <asp:DropDownList CssClass="form-control" ID="dropdownDisciplina" runat="server"  onselectedindexchanged="dropdownDisciplina_SelectedIndexChanged" AutoPostBack="True"/>
                </div>
                <div style="margin-top:10px; margin-left:5px;" >
                    <asp:DropDownList CssClass="form-control" ID="dropdownAluno" runat="server"  onselectedindexchanged="dropdownAluno_SelectedIndexChanged" AutoPostBack="True"/>
                </div>
                <div style="margin-top:10px; margin-left:5px;" >
                    <asp:Button runat="server" ID="filtrar" CssClass="btn btn-primary" Text="Filtrar" OnClick="filtrar_Click"/>
                </div>
            </div>
            <div class="col-lg-2">
                <div style="margin-top:10px; margin-left:5px;" >
                    <asp:CheckBox CssClass="checkbox" ID="maioresNotas" runat="server" Checked="false" Text="Maiores Notas"/>
                </div>
            </div>
            <div class="col-lg-8" >
                <div class="panel panel-primary" style="margin-top:15px;">
                    <div class="panel-heading">
                        Consulta de Matrículas
                    </div>
                    <div class="panel-body">
                    
                        <asp:GridView ID="GridViewMatricula" runat="server" CssClass="table table-bordered table-hover" DataKeyNames="id" CellPadding="4" EnableModelValidation="True" ForeColor="#333333" GridLines="None" OnRowCommand="GridViewMatricula_RowCommand" HeaderStyle-CssClass="active" RowStyle-CssClass="alert">
                            <Columns>
                                <asp:ButtonField ButtonType="Button" ControlStyle-CssClass="btn btn-danger" ItemStyle-HorizontalAlign="Center" HeaderText="Excluir" CommandName="Excluir" Text="X" />
                                <asp:ButtonField ButtonType="Button" ControlStyle-CssClass="btn btn-primary" CommandName="Editar" Text="Editar" HeaderText="Editar" />
                                <asp:ButtonField ButtonType="Button" ControlStyle-CssClass="btn btn-primary" CommandName="Notas" Text="Notas" HeaderText="Notas" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            
            </div>
            <div class="col-sm-4" >
                <div class="panel panel-primary" style="margin-top:15px;">
                    <div class="panel-heading">
                        Notas
                    </div>
                    <div class="panel-body">
                        <asp:GridView ID="GridViewNotas" runat="server" CssClass="table table-bordered table-hover" DataKeyNames="id" CellPadding="4" EnableModelValidation="True" ForeColor="#333333" GridLines="None" HeaderStyle-CssClass="active" RowStyle-CssClass="alert"></asp:GridView>
                    </div>
                </div>
            
            </div>
        </div>
    </form>
</asp:Content>
