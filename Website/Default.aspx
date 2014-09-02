<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Website._Default" %>

<!DOCTYPE html>
<html lang="zh-CN">
<head>
<meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no" />
    <meta name="description" />
    <link rel="stylesheet" type="text/css" href="style.css" media="screen" />

    <script>

        var checkSubmitFlg = false; 

        function check() {

            if (checkSubmitFlg)
                return;

            if (document.getElementById("txtNickname").value == "") {
                alert("请输入昵称!");
                document.getElementById("txtNickname").focus();
                return false;
            }
            if (document.getElementById("txtContent").value == "") {
                alert("请输入内容!");
                document.getElementById("txtContent").focus();
                return false;
            }

            if (document.getElementById("txtContent").value.length > 30) {
                alert("内容最多输入30个字符!");
                document.getElementById("txtContent").focus();
                return false;
            }

            checkSubmitFlg = true;
            document.getElementById("Button1").value = " 发送中... "

            return true;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="main">

        <table Width="100%">
            <tr>
                <td style="text-align:left">昵称：</td><td><asp:TextBox ID="txtNickname" runat="server" Width="100%" Font-Size="120%"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align:left">字号：</td><td><asp:DropDownList ID="ddlFontSize" runat="server" Width="100" Font-Size="120%">
                        <asp:ListItem Value="0">小</asp:ListItem>
                        <asp:ListItem Value="1" Selected="True">中</asp:ListItem>
                        <asp:ListItem Value="2">大</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="text-align:left">颜色：</td><td><asp:DropDownList ID="ddlFontColor" runat="server" Width="100" Font-Size="120%">
                        <asp:ListItem Value="0" Selected="True">白</asp:ListItem>
                        <asp:ListItem Value="1">黑</asp:ListItem>
                        <asp:ListItem Value="2">红</asp:ListItem>
                        <asp:ListItem Value="3">蓝</asp:ListItem>
                        <asp:ListItem Value="4">绿</asp:ListItem>
                        <asp:ListItem Value="5">黄</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="text-align:left" colspan="2">输入内容：<br /><asp:TextBox ID="txtContent" runat="server" TextMode="MultiLine" Rows="5" Width="100%" Font-Size="150%" MaxLength="30"></asp:TextBox><br />（必填，最多输入30个字符）</td>
            </tr>
            <tr>
                <td style="text-align:center" colspan="2">
                    <asp:Button ID="Button1" runat="server" Text="　　发 送　　" OnClick="btnSubmit_Click" Font-Size="120%" OnClientClick="return check()" />
                </td>
            </tr>
        
        </table>
        </div>
    </form>
</body>
</html>
