<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FileProcessing.aspx.cs" Inherits="DataFileProcessing.FileProcessing" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="Label" Font-Bold="True" Font-Size="X-Large"></asp:Label>

        <br />
        <br />

        <asp:FileUpload ID="FileUpload1" runat="server" />

        <br />
        <br />

        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />

        <br />
        <br />

        <!-- ListView requires a template -->
        <asp:GridView ID="GridView1" runat="server"></asp:GridView>

        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server"></asp:ObjectDataSource>
    </div>
    </form>
</body>
</html>

