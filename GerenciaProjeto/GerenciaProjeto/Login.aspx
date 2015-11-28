<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="GerenciaProjeto.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link href="Content/css/bootstrap.css" rel="stylesheet" media="screen" type="text/css" />

    <script type="text/javascript" src="Content/js/jquery-1.11.3.js"></script>
    <script type="text/javascript" src="Content/js/bootstrap.js"></script>
</head>
<body>
    <div class="container">

            <div class="col-md-6 col-md-offset-3" id="loginbox" style="margin-top:45px;" >    
                                
                <div class="panel panel-info">
                    <div class="panel-heading">
                        <div class="panel-title">Bem-Vindo Professor(a)!</div>
                    </div>     

                    <div class="panel-body" style="padding-top:30px" >    
                                       
                        <form class="form-horizontal" id="loginform" runat="server">    
                                             
                            <div class="input-group" style="margin-bottom: 25px" >
                                <span class="input-group-addon">
                                    <i class="glyphicon glyphicon-user"></i>
                                </span>
                                <asp:TextBox CssClass="form-control" id="usuario" placeholder="usuario"  runat="server"/>                                        
                            </div>
                                
                            <div class="input-group" style="margin-bottom: 25px" >
                                <span class="input-group-addon">
                                    <i class="glyphicon glyphicon-lock"></i>
                                </span>
                                <asp:TextBox CssClass="form-control" id="senha" TextMode="Password"  placeholder="senha" runat="server" />
                            </div>
        
                            <div class="checkbox">
                                <label>
                                    <asp:CheckBox id="remember" type="checkbox" name="remember" value="" runat="server"  /> Lembrar Minha Senha
                                </label>
                            </div>

                            <div class="form-group" style="margin-top:10px" >
                                <!-- Button -->
                                <div class="col-sm-12 controls">
                                    <asp:Button runat="server" ID="acessar" CssClass="btn btn-success"  OnClick="acessar_login" Text="Acessar"/>
                                    <asp:Label runat="server" class="alert alert-danger" ID="alerta" Visible="false" Text="" style="margin-left:100px;"></asp:Label>
                                </div>
                            </div>

                        </form>   
                          
                    </div>    
                                     
                </div>  
                <div id="msgErro" class="alert alert-danger" runat="server">
                    <a href="#" class="close" data-dismiss="alert">&times;</a>
                    <strong><asp:Label ID="lblErro" runat="server" Text="Usuário e senha inválidos!"></asp:Label></strong>
                </div>
            </div>

        </div>
</body>
</html>
