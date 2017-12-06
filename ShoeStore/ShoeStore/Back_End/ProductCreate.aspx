<%@ Page Title="" Language="C#" MasterPageFile="~/Back_End/Admin.Master" AutoEventWireup="true"
    CodeBehind="ProductCreate.aspx.cs" Inherits="ShoeStore.Back_End.ProductCreate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:SqlDataSource ID="ProductDataSource" runat="server"></asp:SqlDataSource>
    <fieldset id="fltInfo" runat="server" visible="false" style="width: 600;">
        <legend>Инфо </legend>
        <asp:Label ID="lblInfo" runat="server" ClientIDMode="AutoID" />
    </fieldset>
    <fieldset runat="server" style="width: 500px;">
        <legend>Основные данные</legend>
        <asp:Label ID="lblName" runat="server" Text="Название" AssociatedControlID="tbxName" />
        <br />
        <asp:TextBox ID="tbxName" runat="server" Width="207px" />
        <br />
        <br />
        <asp:Label ID="lblCode" runat="server" Text="Внутренний код" AssociatedControlID="tbxCode" />
        <br />
        <asp:TextBox ID="tbxCode" runat="server" Width="207px" />
        <br />
        <br />
        <asp:Label ID="lblManufacture" runat="server" Text="Производитель" AssociatedControlID="ddlManufacture" />
        <br />
        <asp:DropDownList ID="ddlManufacture" runat="server" ClientIDMode="AutoID" DataSourceID="dsrcManufacture"
            DataValueField="ID" DataTextField="Name" Height="20px" Width="212px" />
        <br />
        <br />
        <asp:Label ID="lblColor" runat="server" Text="Цвет" AssociatedControlID="drlColors" />
        <br />
        <asp:DropDownList ID="drlColors" runat="server" ClientIDMode="AutoID" DataSourceID="ColorDataSource"
            DataValueField="ID" DataTextField="ColorName" Height="20px" Width="209px" />
        <br />
        <br />
        <asp:Label ID="lblMaterial" runat="server" Text="Материал" AssociatedControlID="drlColors" />
        <br />
        <asp:DropDownList ID="ddlMaterial" runat="server" ClientIDMode="AutoID" DataSourceID="dsrcMaterial"
            DataValueField="ID" DataTextField="MaterialType" Height="20px" Width="209px" />
        <br />
       <br />
        <table>
            <tr>
                <td>
                    <asp:Label ID="lblSize" runat="server" Text="Размер" AssociatedControlID="ddlSize" />
                </td>
                <td>
                <asp:Label ID="lblSizecount" runat="server" Text="количество для выбранного размера" />
                </td>
                 <td>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:DropDownList ID="ddlSize" runat="server" ClientIDMode="AutoID" DataSourceID="dsrcSize"
                        DataValueField="ID" DataTextField="Size" Height="20px" Width="209px" />
                </td>
                <td>
                <asp:TextBox ID="tbxCountSize" runat="server" Width="233px" />
                </td>
                <td>
                    <asp:Button ID="btnAddSize" runat="server" Text="Добавить размер" 
                        onclick="btnAddSize_Click" />
                </td>
            </tr>
        </table>
        <br />
        <asp:GridView ID="grdSize" runat="server" AutoGenerateColumns="false" AllowPaging="true"
            AllowSorting="true"  OnRowDeleting="grdProducts_RowDeleting"
            OnDataBinding="grdSize_DataBinding">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ButtonType="Button" DeleteText="Удалить" />
                <asp:BoundField DataField="SizeId" HeaderText="ID" ReadOnly="True" />
                <asp:BoundField DataField="Size" HeaderText="Размер"  />
                <asp:BoundField DataField="Count" HeaderText="Количество для размера" />
            </Columns>
        </asp:GridView>
        <br />
        <asp:Label ID="lblSex" runat="server" Text="Пол" AssociatedControlID="ddlSex" />
        <br />
        <asp:DropDownList ID="ddlSex" runat="server" ClientIDMode="AutoID" DataSourceID="dsrcSex"
            DataValueField="ID" DataTextField="SexName" Height="20px" Width="209px" />
        <br />
        <br />
        <asp:Label ID="lblSeason" runat="server" Text="Сезон" AssociatedControlID="ddlSeason" />
        <br />
        <asp:DropDownList ID="ddlSeason" runat="server" ClientIDMode="AutoID" DataSourceID="dsrcSeason"
            DataValueField="ID" DataTextField="Name" Height="20px" Width="209px" />
        <br />
        <br />
        <asp:Label ID="lblType" runat="server" Text="Тип" AssociatedControlID="ddlSex" />
        <br />
        <asp:DropDownList ID="ddlTypeItem" runat="server" ClientIDMode="AutoID" DataSourceID="dsrcType"
            DataValueField="ID" DataTextField="TypeItem" Height="20px" Width="209px" />
        <br />
        <br />
        <asp:Label ID="lblDescription" runat="server" Text="Описание продукта" AssociatedControlID="tbxDescription" />
        <br />
        <asp:TextBox ID="tbxDescription" runat="server" Width="721px" TextMode="MultiLine"
            Height="223px" />
        <br />
        <br />
        <asp:Label ID="lblCost" runat="server" Text="Стоимость" AssociatedControlID="tbxCost" />
        <br />
        <asp:TextBox ID="tbxCost" runat="server" Width="209px" />
        <br />
        <br />
        <asp:Label ID="lblCount" Visible=false runat="server" Text="количество" AssociatedControlID="tbxCost" />
        <br />
        <asp:TextBox ID="tbxCount" Visible=false runat="server" Width="209px" Text=" " />
    </fieldset>
    <br />
    <br />
    <fieldset id="fldCurrFoto" style="width: 258px;">
        <legend>Текущее заглавное фото </legend>
        <asp:Image ID="imgTitle" runat="server" BorderColor="Black" />
    </fieldset>
    <asp:Button runat="server" ID="btnSaveProduct" Text="Сохранить" OnClick="btnSaveProduct_Click" />
    .
    <asp:Button runat="server" Visible="false" ID="btnDownPicture" Text="Сменить фото"
        OnClick="btnDownPicture_Click" />
    <br />
    <br />
    <asp:SqlDataSource ID="ColorDataSource" runat="server" SelectCommand="SELECT [ID], [ColorName] FROM [ColorType]">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="dsrcManufacture" runat="server" SelectCommand="SELECT [ID], [Name] FROM [Manufacture]">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="dsrcMaterial" runat="server" SelectCommand="SELECT [ID], [MaterialType] FROM [MaterialType]">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="dsrcSize" runat="server" SelectCommand="SELECT [ID], [Size] FROM [Size]">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="dsrcSex" runat="server" SelectCommand="SELECT [ID], [SexName] FROM [TypeSex]">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="dsrcSeason" runat="server" SelectCommand="SELECT [ID], [Name] FROM [SeasonalType]">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="dsrcType" runat="server" SelectCommand="SELECT [ID], [TypeItem] FROM [TypeItem]">
    </asp:SqlDataSource>
</asp:Content>
