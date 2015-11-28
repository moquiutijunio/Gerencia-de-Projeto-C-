<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="CadMatricula.aspx.cs" Inherits="GerenciaProjeto.CadMatricula" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="conteudo" runat="server">
    <form runat="server" id="form1" data-toggle="validator">
        <div class="col-md-6 col-md-offset-3" >
            <div class="panel panel-primary" style="margin-top:15px;">
                <div class="panel-heading">
                    Cadastro de Matrícula
                </div>
                <div class="panel-body">
                    <div style="margin-top:10px; margin-left:5px;" >
                        <asp:DropDownList CssClass="form-control" ID="dropdownDisciplina" runat="server"  onselectedindexchanged="dropdownDisciplina_SelectedIndexChanged" AutoPostBack="True"/>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Preencha o campo Disciplina" ControlToValidate="dropdownDisciplina" InitialValue="0">*</asp:RequiredFieldValidator>
                    </div>
                    <div style="margin-top:10px; margin-left:5px;" >
                        <asp:DropDownList CssClass="form-control" ID="dropdownAluno" runat="server"  onselectedindexchanged="dropdownAluno_SelectedIndexChanged" AutoPostBack="True"/>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Preencha o campo Aluno" ControlToValidate="dropdownAluno" InitialValue="0">*</asp:RequiredFieldValidator>
                    </div>
                    <div style="margin-top:10px; margin-left:5px;" >
                        <asp:TextBox runat="server" id="prova1" CssClass="form-control" placeholder="Nota P1"/>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Preencha o campo Nota P1" ControlToValidate="prova1">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Preencha o campo Nota P1 apenas com números" ControlToValidate="prova1" ValidationExpression="^[0,1,2,3,4,5,6,7,8,9]+$">*</asp:RegularExpressionValidator>
                        
                        <asp:TextBox runat="server" id="prova2" CssClass="form-control" placeholder="Nota P2"/>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Preencha o campo Nota P2" ControlToValidate="prova2">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Preencha o campo Nota P2 apenas com números" ControlToValidate="prova2" ValidationExpression="^[0,1,2,3,4,5,6,7,8,9]+$">*</asp:RegularExpressionValidator>
                                                
                        <asp:TextBox runat="server" id="trabalho" CssClass="form-control" placeholder="Nota Trabalho"/>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Preencha o campo Nota Trabalho" ControlToValidate="trabalho">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Preencha o campo Nota Trabalho apenas com números" ControlToValidate="trabalho" ValidationExpression="^[0,1,2,3,4,5,6,7,8,9]+$">*</asp:RegularExpressionValidator>
                        
                    </div>
                    <div class="btn-group-sm" style="margin-top:15px; margin-left:5px;">
                        <asp:Button runat="server" ID="cadastrar" CssClass="btn btn-success" Text="Cadastrar" OnClick="cadastrar_Click"/>
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