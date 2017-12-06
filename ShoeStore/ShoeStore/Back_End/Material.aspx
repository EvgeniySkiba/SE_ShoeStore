<%@ Page Title="" Language="C#" MasterPageFile="~/Back_End/Admin.Master" AutoEventWireup="true"
    CodeBehind="Material.aspx.cs" Inherits="ShoeStore.Back_End.Material" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>
        Редактирование текущих материалов</h3>
    <br />
    <asp:Panel ID="pnlColors" runat="server" Visible="true" ClientIDMode="AutoID" Width="100px">
        <asp:GridView ID="GridView1" runat="server" GridLines="None" AutoGenerateColumns="False"
            BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2"
            ForeColor="Black" AllowPaging="True" DataKeyNames="ID" OnDataBinding="GridView1_DataBinding"
            OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing"
            OnRowDeleted="GridView1_RowDeleted" OnRowDeleting="GridView1_RowDeleting" OnRowUpdating="GridView1_RowUpdating">
            <AlternatingRowStyle BackColor="PaleGoldenrod" />
            <Columns>
                <asp:CommandField ShowEditButton="True" ButtonType="Link" EditText="Редактировать" />
                <asp:CommandField ShowDeleteButton="True" ButtonType="Link" />
                <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="true" />
                <asp:BoundField DataField="MaterialType" HeaderText="Название материала" ControlStyle-Width="300" />
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
        <asp:Button ID="btnCreate" runat="server" Text="Создать запись" OnClick="btnCreate_Click" />
    </asp:Panel>
    <br />
    <asp:Panel runat="server" ID="pnlCreate" Visible="false" ClientIDMode="AutoID">
        <fieldset>
            <legend>Добавление нового элемента</legend>
            <div style="margin: 10px;">
                <asp:Label ID="lblValue" runat="server" Text="Введите название материала" AssociatedControlID="tbxValue"
                    ClientIDMode="AutoID" Width="150px" /><br />
                <asp:TextBox ID="tbxValue" Text="Material_Name" runat="server" Width="270px" ClientIDMode="AutoID" />
                <br />
                <div style="float: inherit; margin: 10px; width: 250px;">
                    <div style="width: 100px; float: left; margin-right: 1px;">
                        <asp:Button ID="btnSave" runat="server" Width="100px" Text="Сохранить" OnClick="btnSave_Click" />
                    </div>
                    <div style="width: 100px; margin-left: 110px;">
                        <asp:Button ID="btnCancel" Width="100px" runat="server" Text="Назад" OnClick="btnCancel_Click" />
                    </div>
                </div>
            </div>
        </fieldset>
    </asp:Panel>
    <asp:Panel ID="pnlError" runat="server" Visible="false">
        <asp:Label ID="lblErrorDB" runat="server" Text=" " />
    </asp:Panel>
    <asp:SqlDataSource ID="manufactureDataSource" runat="server"></asp:SqlDataSource>
</asp:Content>
