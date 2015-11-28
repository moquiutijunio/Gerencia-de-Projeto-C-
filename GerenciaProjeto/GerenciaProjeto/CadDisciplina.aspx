<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="CadDisciplina.aspx.cs" Inherits="GerenciaProjeto.CadDisciplina" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="conteudo" runat="server">
    <form runat="server" id="form1" data-toggle="validator">
        <div class="col-md-6 col-md-offset-3" >
            <div class="panel panel-primary" style="margin-top:15px;">
                <div class="panel-heading">
                    Cadastrar Disciplina
                </div>
                <div class="panel-body">
                    <div style="margin-top:10px; margin-left:5px;" >
                        <asp:TextBox runat="server" id="nome" CssClass="form-control" placeholder="Nome"/>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Preencha o campo Nome" ControlToValidate="nome">*</asp:RequiredFieldValidator>
                    </div>                    
                    <div style="margin-top:10px; margin-left:5px;" >
                        <asp:TextBox runat="server" id="descricao" CssClass="form-control" placeholder="Descrição"/>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Preencha o campo Descrição" ControlToValidate="descricao">*</asp:RequiredFieldValidator>
                    </div>   
                    <div class="btn-group-sm" style="margin-top:15px; margin-left:5px;">
                        <asp:Button runat="server" ID="cadastrar" CssClass="btn btn-success" Text="Cadastrar" OnClick="Cadastrar"/>
                        <asp:Button runat="server" ID="limpar" CssClass="btn btn-danger" Text="Limpar" OnClick="LimparCtrl" ValidationGroup="false"/>
                    </div>

                    <div style="margin-top:20px;">
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
                        <asp:Label ID="lblMensagem" runat="server" Text="" Visible="false"/>
                    </div>
                </div>
            </div>
            
        </div>
    </form>
</asp:Content>
