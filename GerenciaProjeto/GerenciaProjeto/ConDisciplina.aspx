<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="ConDisciplina.aspx.cs" Inherits="GerenciaProjeto.ConDisciplina" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="conteudo" runat="server">

    <form runat="server" id="form1" data-toggle="validator">
        <div class="col-md-6 col-md-offset-3" >
            <div class="panel panel-primary" style="margin-top:15px;">
                <div class="panel-heading">
                    Consulta Disciplina
                </div>
                <div class="panel-body">
                                       
                    <asp:GridView ID="GridViewDisciplina" runat="server" CssClass="table table-bordered table-hover" DataKeyNames="id" CellPadding="4" EnableModelValidation="True" ForeColor="#333333" GridLines="None" OnRowCommand="GridViewDisciplina_RowCommand" HeaderStyle-CssClass="active" RowStyle-CssClass="alert">
                        <Columns>
                            <asp:ButtonField ButtonType="Button" ControlStyle-CssClass="btn btn-danger" ItemStyle-HorizontalAlign="Center" HeaderText="Excluir" CommandName="Excluir" Text="X" />
                            <asp:ButtonField ButtonType="Button" ControlStyle-CssClass="btn btn-primary" CommandName="Editar" Text="Editar" HeaderText="Editar" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
            
        </div>
    </form>
</asp:Content>
