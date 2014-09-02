<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Debug.aspx.cs" Inherits="Website.Debug" %>

<!DOCTYPE html>
<html lang="zh-CN">
<head>
<meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no" />
    <meta name="description" />
    <link rel="stylesheet" type="text/css" href="style.css" media="screen" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="main">

        <table Width="100%">
            <tr>
                <td style="text-align:left">昵称:<br /><asp:TextBox ID="txtNickname" runat="server" Width="100%" Font-Size="120%"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align:left">输入内容:<br /><asp:TextBox ID="txtContent" runat="server" TextMode="MultiLine" Rows="5" Width="100%" Font-Size="120%" MaxLength="30"></asp:TextBox><br />（最多输入30个字符）</td>
            </tr>
            <tr>
                <td style="text-align:center">
                    <asp:Button ID="Button1" runat="server" Text=" 发 送 " OnClick="btnSubmit_Click" Font-Size="120%" OnClientClick="return check()" />
                </td>
            </tr>
        
        </table>
        </div>
    </form>
</body>
</html>
