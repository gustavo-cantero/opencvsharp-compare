<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="OpenCV.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        Imagen1: <asp:FileUpload runat="server" ID="file1" accept="image/*" />
        Imagen2: <asp:FileUpload runat="server" ID="file2" accept="image/*" />
        <asp:Button runat="server" Text="Comparar" OnClick="Process_Click" />
        <br />
        <br />
        <asp:Image runat="server" Visible='<%# ok %>' ImageUrl="comp1-out.jpg" Width="32%" />
        <asp:Image runat="server" Visible='<%# ok %>' ImageUrl="comp2-out.jpg" Width="32%" />
        <asp:Image runat="server" Visible='<%# ok %>' ImageUrl="comp-out.jpg" Width="32%" />
    </form>
</body>
</html>
