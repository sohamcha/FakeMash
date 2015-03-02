<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Default2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body background="3D%20And%20Fantasy%20Girls%20(36).jpg">
    <form id="form1" runat="server">
    <div>
    
    </div>
    <p>
        <asp:Image ID="Image1" runat="server" ImageUrl="~/Stuff.jpg" 
            style="z-index: 1; left: 22px; top: 24px; position: absolute; height: 102px; width: 466px" />
    </p>
    <p>
        <asp:ImageButton ID="ImageButton1" runat="server" onclick="ImageButton1_Click" 
            
            style="z-index: 1; left: 19px; top: 190px; position: absolute; width: 262px; right: 746px; height: 230px;" />
        <asp:ImageButton ID="ImageButton2" runat="server" onclick="ImageButton2_Click" 
            
            style="z-index: 1; left: 372px; top: 191px; position: absolute; height: 224px; width: 253px" />
        <asp:Label ID="Label1" runat="server" ForeColor="#990033" 
            
            style="z-index: 1; left: 70px; top: 501px; position: absolute; height: 28px; width: 161px; right: 796px;"></asp:Label>
        <asp:Label ID="Label2" runat="server" ForeColor="Red" 
            style="z-index: 1; top: 506px; position: absolute; height: 25px; width: 131px; right: 544px"></asp:Label>
        <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Names="Arial Black" 
            Font-Size="Medium" ForeColor="#0066FF" 
            style="z-index: 1; left: 67px; top: 436px; position: absolute; height: 22px; width: 73px"></asp:Label>
        <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Names="Arial Black" 
            Font-Size="Medium" ForeColor="#FF6600" 
            style="z-index: 1; left: 416px; top: 438px; position: absolute; height: 23px; width: 73px"></asp:Label>
        <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Italic="False" 
            Font-Size="Small" ForeColor="#990033" 
            style="z-index: 1; left: 836px; top: 15px; position: absolute; height: 21px; width: 174px" 
            Text="Made by Soham Chakraborty"></asp:Label>
    </p>
    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
        style="z-index: 1; left: 245px; top: 565px; position: absolute; height: 31px; width: 108px" 
        Text="EXPECTATION" />
    <p>
        &nbsp;</p>
    <asp:Image ID="Image2" runat="server" ImageUrl="~/500x333_katy-perry-2.jpg" 
        style="z-index: 1; left: 843px; top: 51px; position: absolute; width: 290px; height: 217px" />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" 
        CellPadding="4" DataKeyNames="ID" DataSourceID="SqlDataSource1" 
        GridLines="Horizontal" 
        style="z-index: 1; left: 143px; top: 749px; position: absolute; height: 246px; width: 340px" 
        Visible="False">
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" 
                SortExpression="ID" />
            <asp:BoundField DataField="RATING" HeaderText="RATING" 
                SortExpression="RATING" />
            <asp:BoundField DataField="WIN" HeaderText="WIN" SortExpression="WIN" />
            <asp:BoundField DataField="LOST" HeaderText="LOST" SortExpression="LOST" />
        </Columns>
        <FooterStyle BackColor="White" ForeColor="#333333" />
        <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="White" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F7F7F7" />
        <SortedAscendingHeaderStyle BackColor="#487575" />
        <SortedDescendingCellStyle BackColor="#E5E5E5" />
        <SortedDescendingHeaderStyle BackColor="#275353" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:FACEMASH2ConnectionString %>" 
        SelectCommand="SELECT * FROM [MAIN]"></asp:SqlDataSource>
    <p>
        &nbsp;</p>
    <p>
        <asp:Button ID="Button2" runat="server" onclick="Button2_Click" 
            style="z-index: 1; left: 251px; top: 700px; position: absolute; height: 27px; width: 101px" 
            Text="GET RATINGS" />
    </p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <asp:Button ID="Button3" runat="server" onclick="Button3_Click" 
        style="z-index: 1; left: 950px; top: 364px; position: absolute; height: 31px; width: 107px" 
        Text="RANDOM" />
    <asp:Label ID="Label4" runat="server" Font-Italic="True" Font-Size="Large" 
        ForeColor="#CC3300" 
        
        style="z-index: 1; left: 920px; top: 300px; position: absolute; height: 25px; width: 247px" 
        BackColor="White" BorderColor="#FF6666"></asp:Label>
    </form>
</body>
</html>
