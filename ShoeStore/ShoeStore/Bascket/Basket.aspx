<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Basket.aspx.cs" Inherits="ShoeStore.Basket" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        #top
        {
            height: 150px;
        }
    </style>

         
         <asp:Label ID=lblInfo runat="server" />
         <br />

         <asp:GridView ID="grdCart" runat=server onrowdeleting="grdCart_RowDeleting" 
        DataKeyNames="ProductId"   AutoGenerateColumns=false >
             <Columns>
                 <asp:CommandField ButtonType="Button" ShowDeleteButton="True" />
                   <asp:BoundField Visible=false  />
               <asp:BoundField DataField="ProductId"  HeaderText="номер продукта" ReadOnly="True"   />  
               <asp:BoundField DataField="Quantity"  HeaderText="  Количество " ReadOnly="True"   /> 
               <asp:BoundField DataField="ProductName"  HeaderText="Название" ReadOnly="True"   />  
               <asp:BoundField DataField="Manufacture"  HeaderText=" Производитель " ReadOnly="True"  />  
               <asp:BoundField DataField="Country"  HeaderText="Страна" ReadOnly="True"  />  
              
                  
             </Columns>
    </asp:GridView>

         <br />

         <asp:Label ID="lblTotalValueText" runat=server Text="Общая стоимость" />
         <asp:Label ID="lblTotalValue" runat=server Text="" />
         <br />
         <asp:Button ID="btnPay" runat=server Text="Оплата" 
        onclick="btnPay_Click" /> 
</asp:Content>
