<%@ Page Title="" Language="C#" MasterPageFile="~/Back_End/Admin.Master" AutoEventWireup="true" CodeBehind="Type.aspx.cs" Inherits="ShoeStore.Back_End.Type" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<asp:Panel ID=pnlColors runat=server Visible=true ClientIDMode=AutoID>
    
    <asp:GridView ID="GridView1"  runat="server" GridLines="None" AutoGenerateColumns="False"
            BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2"
            ForeColor="Black" AllowPaging="True" DataKeyNames="ID"
        OnRowDeleting="GridView1_RowDeleting"
         ondatabinding="GridView1_DataBinding" 
            onrowediting="GridView1_RowEditing" 
            onrowupdating="GridView1_RowUpdating" 
            onrowcancelingedit="GridView1_RowCancelingEdit">
        <AlternatingRowStyle BackColor="PaleGoldenrod" />
        <Columns>
            <asp:CommandField ShowEditButton="True" ButtonType="Link" />
            <asp:CommandField ShowDeleteButton="True" ButtonType="Link" />
            <asp:BoundField DataField="ID" ReadOnly="true" HeaderText="ID" />
            <asp:BoundField DataField="TypeItem" HeaderText="Название" />
        </Columns>
        <FooterStyle BackColor="Tan" />
        <HeaderStyle BackColor="Tan" Font-Bold="True" />
        <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
        <SortedAscendingCellStyle BackColor="#FAFAE7" />
        <SortedAscendingHeaderStyle BackColor="#DAC09E" />
        <SortedDescendingCellStyle BackColor="#E1DB9C" />
        <SortedDescendingHeaderStyle BackColor="#C2A47B" />
    </asp:GridView>
    <br />
    <asp:Button ID=btnCreate runat=server Text="Создать запись" 
        onclick="btnCreate_Click" />
    </asp:Panel>
    <br />
    <asp:Panel runat="server" ID="pnlCreate" Visible=false ClientIDMode="AutoID">
        <fieldset>
            <legend>Добавление нового элемента</legend>
            <asp:Label ID="lblValue" runat="server" Text="Введите значение" AssociatedControlID="tbxValue"
                ClientIDMode="AutoID" Width="150px" /><br />
            <asp:TextBox ID="tbxValue" runat="server" Width="230" ClientIDMode="AutoID" />
            <br />
            <div style="float: inherit; margin:10px; width: 250px;">
                <div style="width: 100px; float: left; margin-right: 1px;">
                    <asp:Button ID="Button1" runat="server" Width="100px" Text="Сохранить" OnClick="Unnamed1_Click" />
                </div>
                <div style="width: 100px; margin-left: 110px; ">
                    <asp:Button ID="Button2" Width="100px" runat="server" Text="Назад" OnClick="Button1_Click" />
                </div>
            </div> 
        </fieldset>
    </asp:Panel>

    <asp:Panel ID="pnlError" runat="server" Visible=false>
        <asp:Label ID="lblErrorDB" runat="server" Text="" />
    </asp:Panel>
</asp:Content>
