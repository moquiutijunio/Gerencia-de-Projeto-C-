<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="ConAluno.aspx.cs" Inherits="GerenciaProjeto.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="conteudo" runat="server">

    <form runat="server" id="form1" data-toggle="validator">
        <div class="col-md-10 col-lg-offset-1 col-sm-offset-1" >
            <div class="panel panel-primary" style="margin-top:15px;">
                <div class="panel-heading">
                    Consulta de Alunos
                </div>
                <div class="panel-body">
                    
                    <asp:GridView ID="GridViewAluno" runat="server" CssClass="table table-bordered table-hover" DataKeyNames="id" CellPadding="4" EnableModelValidation="True" ForeColor="#333333" GridLines="None" OnRowCommand="GridViewAluno_RowCommand" HeaderStyle-CssClass="active" RowStyle-CssClass="alert">
                        <Columns>
                            <asp:ButtonField ButtonType="Button" ControlStyle-CssClass="btn btn-danger" ItemStyle-HorizontalAlign="Center" HeaderText="Excluir" CommandName="Excluir" Text="X" />
                            <asp:ButtonField ButtonType="Button" ControlStyle-CssClass="btn btn-primary" CommandName="Editar" Text="Editar" HeaderText="Editar" />
                            <asp:ButtonField ButtonType="Button" ControlStyle-CssClass="btn btn-primary" CommandName="Matriculas" Text="Matriculas" HeaderText="Matriculas" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
            
        </div>
    </form>
</asp:Content>
