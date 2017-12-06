<%@ Page Title="" Language="C#" MasterPageFile="~/Back_End/Admin.Master" AutoEventWireup="true"
    CodeBehind="Manufacture.aspx.cs" Inherits="ShoeStore.Back_End.Manufacture" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>
        Редактирование текущих производителей</h3>
    <br />
    <asp:Panel ID="pnlColors" runat="server" Visible="true" ClientIDMode="AutoID" Width="100px">
        <asp:GridView ID="GridView1" runat="server" GridLines="None" AutoGenerateColumns="False"
            BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2"
            ForeColor="Black" AllowPaging="True" DataKeyNames="ID"
            OnDataBinding="GridView1_DataBinding"
            OnRowCancelingEdit="GridView1_RowCancelingEdit"
            OnRowEditing="GridView1_RowEditing"
            OnRowDeleted="GridView1_RowDeleted" 
            OnRowDeleting="GridView1_RowDeleting" 
            OnRowUpdating="GridView1_RowUpdating"
            OnRowUpdated="GridView1_RowUpdated">
            <AlternatingRowStyle BackColor="PaleGoldenrod" />
            <Columns>
                <asp:CommandField ShowEditButton="True" ButtonType="Link" EditText="Редактировать" />
                <asp:CommandField ShowDeleteButton="True" ButtonType="Link" />
                <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="true" />
                <asp:BoundField DataField="Name" HeaderText="Название производителя" />
                <asp:BoundField DataField="Country" HeaderText="Страна" />
                <asp:BoundField DataField="CreationDate" HeaderText="Дата Основания" DataFormatString="{0:d}" />
                <asp:BoundField DataField="Code" HeaderText="Код" />
                <asp:BoundField DataField="Description" HeaderText="Код" />
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
                <asp:Label ID="lblValue" runat="server" Text="Введите название производителя" AssociatedControlID="tbxValue"
                    ClientIDMode="AutoID" Width="150px" /><br />
                <asp:TextBox ID="tbxValue" Text="Manufacture_Name" runat="server" Width="270px" ClientIDMode="AutoID" />
                <asp:RequiredFieldValidator ID="vldName" runat="server" ClientIDMode="AutoID" ControlToValidate="tbxValue"
                    ErrorMessage="Поле обязательно для заполнения" />
                <br />
                <br />
                <asp:Label ID="lblCountry" runat="server" Text="Введите страну производителя" AssociatedControlID="tbxCountry"
                    ClientIDMode="AutoID" Width="150px" /><br />
                <asp:TextBox ID="tbxCountry" Text="Country_Name" runat="server" Width="270px" ClientIDMode="AutoID" />
                <asp:RequiredFieldValidator ID="vlrCountry" runat="server" ClientIDMode="AutoID"
                    ControlToValidate="tbxCountry" ErrorMessage="Поле обязательно для заполнения" />
                <br />
                <br />
                <asp:Label ID="lblCreationDate" runat="server" Text="Выбор даты основания" AssociatedControlID="clrCreationDate"
                    ClientIDMode="AutoID" Width="150px" /><br />
                <asp:Calendar ID="clrCreationDate" runat="server" ClientIDMode="AutoID" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ClientIDMode="AutoID"
                    ControlToValidate="tbxCountry" ErrorMessage="Необходимо выбрать дату" />
                <br />
                <br />
                <asp:Label ID="lblCode" runat="server" Text="Введите код для прозводителя" AssociatedControlID="tbxCode"
                    ClientIDMode="AutoID" Width="150px" /><br />
                <asp:TextBox ID="tbxCode" runat="server" Width="270px" ClientIDMode="AutoID" Text="123456789" />
                <asp:RequiredFieldValidator ID="vlrCode" runat="server" ClientIDMode="AutoID" ControlToValidate="tbxCode"
                    ErrorMessage="Поле обязательно для заполнения" />
                <br />
                <br />
                <asp:Label ID="lblDescription" runat="server" Text="Введите описание прозводителя"
                    AssociatedControlID="tbxDescription" ClientIDMode="AutoID" /><br />
                <asp:TextBox ID="tbxDescription" TextMode="MultiLine" runat="server" Width="454px"
                    ClientIDMode="AutoID" Height="191px" />
                <br />
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
