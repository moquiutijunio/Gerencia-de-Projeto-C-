<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="CadAluno.aspx.cs" Inherits="GerenciaProjeto.CadAluno" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="conteudo" runat="server">
    <form runat="server" id="form1" data-toggle="validator">
        <div class="col-md-6 col-md-offset-3" >
            <div class="panel panel-primary" style="margin-top:15px;">
                <div class="panel-heading">
                    Cadastrar Aluno
                </div>
                <div class="panel-body">
                    <div style="margin-top:10px; margin-left:5px;" >
                        <asp:TextBox runat="server" id="nome" CssClass="form-control" placeholder="Nome Completo"/>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Preencha o campo Nome" ControlToValidate="nome">*</asp:RequiredFieldValidator>
                    </div>                    

                    <div style="margin-top:10px; margin-left:5px;" >
                        <asp:TextBox runat="server" id="cidade" CssClass="form-control" placeholder="Cidade"/>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Preencha o campo Cidade" ControlToValidate="cidade">*</asp:RequiredFieldValidator>
                    </div>  

                    <div style="margin-left:5px;margin-top:15px;">
                        <asp:DropDownList ID="estado" runat="server" CssClass="form-control" placeholder="Estado">
                            <asp:ListItem Value="0" >Escolha o Estado</asp:ListItem>
	                        <asp:ListItem value="AC">Acre</asp:ListItem>
	                        <asp:ListItem value="AL">Alagoas</asp:ListItem>
	                        <asp:ListItem value="AP">Amapá</asp:ListItem>
	                        <asp:ListItem value="AM">Amazonas</asp:ListItem>
	                        <asp:ListItem value="BA">Bahia</asp:ListItem>
	                        <asp:ListItem value="CE">Ceará</asp:ListItem>
	                        <asp:ListItem value="DF">Distrito Federal</asp:ListItem>
	                        <asp:ListItem value="ES">Espirito Santo</asp:ListItem>
	                        <asp:ListItem value="GO">Goiás</asp:ListItem>
	                        <asp:ListItem value="MA">Maranhão</asp:ListItem>
	                        <asp:ListItem value="MT">Mato Grosso</asp:ListItem>
	                        <asp:ListItem value="MS">Mato Grosso do Sul</asp:ListItem>
	                        <asp:ListItem value="MG">Minas Gerais</asp:ListItem>
	                        <asp:ListItem value="PA">Pará</asp:ListItem>
	                        <asp:ListItem value="PB">Paraiba</asp:ListItem>
	                        <asp:ListItem value="PR">Paraná</asp:ListItem>
	                        <asp:ListItem value="PE">Pernambuco</asp:ListItem>
	                        <asp:ListItem value="PI">Piauí</asp:ListItem>
	                        <asp:ListItem value="RJ">Rio de Janeiro</asp:ListItem>
	                        <asp:ListItem value="RN">Rio Grande do Norte</asp:ListItem>
	                        <asp:ListItem value="RS">Rio Grande do Sul</asp:ListItem>
	                        <asp:ListItem value="RO">Rondônia</asp:ListItem>
	                        <asp:ListItem value="RR">Roraima</asp:ListItem>
	                        <asp:ListItem value="SC">Santa Catarina</asp:ListItem>
	                        <asp:ListItem value="SP">São Paulo</asp:ListItem>
	                        <asp:ListItem value="SE">Sergipe</asp:ListItem>
	                        <asp:ListItem value="TO">Tocantis</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Preencha o campo Estado" ControlToValidate="estado" InitialValue="0">*</asp:RequiredFieldValidator>
                    </div>
                   
                    <div style="margin-left:5px;margin-top:15px;">
                        <asp:RadioButtonList ID="listSexo" runat="server">
                            <asp:ListItem Value="M"  Text="Masculino" runat="server"/>
                            <asp:ListItem Value="F"  Text="Femino" runat="server"/>
                        </asp:RadioButtonList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Preencha o campo Sexo" ControlToValidate="listSexo">*</asp:RequiredFieldValidator>
                    
                    </div>
                    
                    <div class="btn-group-sm" style="margin-top:15px; margin-left:5px;">
                        <asp:Button runat="server" ID="cadastrar" CssClass="btn btn-success" Text="Cadastrar" OnClick="Cadastrar"/>
                        <asp:Button runat="server" ID="limpar" CssClass="btn btn-danger" Text="Limpar" OnClick="Limpar" ValidationGroup="false"/>
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