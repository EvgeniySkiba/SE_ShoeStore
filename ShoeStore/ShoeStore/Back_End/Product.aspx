<%@ Page Title="" Language="C#" MasterPageFile="~/Back_End/Admin.Master" AutoEventWireup="true" CodeBehind="Product.aspx.cs" Inherits="ShoeStore.Back_End.Product" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<asp:SqlDataSource ID="dataSourceProducts" runat="server"        
        ProviderName="System.Data.SqlClient" SelectCommand="GetProductsInfoList" 
        SelectCommandType="StoredProcedure" DeleteCommand="deleteProduct" DeleteCommandType="StoredProcedure" >
      
      <%--  <DeleteParameters>
              <asp:Parameter Name="@ProductId" Type="Int32"/>
        </DeleteParameters>--%>

        </asp:SqlDataSource>

        <asp:Button ID="btnCreateProduct" runat=server Text="Создать" 
         style="height: 26px" onclick="btnCreateProduct_Click1" />

 <asp:GridView ID="grdProducts" runat=server DataSourceID="dataSourceProducts" 
        AutoGenerateColumns="false"                             
        AllowPaging=true AllowSorting=true  DataKeyNames="ID"
        onselectedindexchanged="grdProducts_SelectedIndexChanged" 
        onrow onrowdeleting="grdProducts_RowDeleting"               
        >  
     <Columns>
        <asp:CommandField ShowSelectButton="True" ButtonType="Button" SelectText="Выбрать" />
        <asp:CommandField ShowDeleteButton="True" ButtonType="Button" DeleteText="Удалить" />
          <asp:BoundField DataField="ID"  HeaderText="ID" ReadOnly="True" SortExpression="ID"  />
         <asp:BoundField DataField="Name"  HeaderText="Название"  SortExpression="Name"  />
         <asp:BoundField DataField="Manufacture"  HeaderText="Производитель"  SortExpression="Manufacture"  />
         <asp:BoundField DataField="MaterialType"  HeaderText="Материал" ReadOnly="True" SortExpression="MaterialType"  />
         <asp:BoundField DataField="Color"  HeaderText="Цвет" ReadOnly="True" SortExpression="Color"  />
         <asp:BoundField DataField="SexName"  HeaderText="пол" ReadOnly="True" SortExpression="SexName"  />
         <asp:BoundField DataField="TypeItem"  HeaderText="Тип " ReadOnly="True" SortExpression="TypeItem"  />

     </Columns>
    </asp:GridView>


</asp:Content>
