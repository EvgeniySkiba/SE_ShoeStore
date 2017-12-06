<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Store.aspx.cs" Inherits="ShoeStore.Store" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        #top
        {
            height: 150px;
        }
        
        data-table
        {
            width: 100%;
        }
        .data-table th
        {
            border: 1px solid #DDDDDD;
            font-weight: bold;
            padding: 5px;
            white-space: nowrap;
        }
        .data-table td
        {
            border: 1px solid #DDDDDD;
            font-size: 12px;
            padding: 5px;
        }
        .data-table thead
        {
            background-color: #F2F2F2;
        }
        .data-table tbody
        {
        }
        .data-table tfoot
        {
        }
        .data-table tr.first
        {
        }
        .data-table tr.last
        {
        }
        .data-table tr.odd
        {
        }
        .data-table tr.even
        {
            background-color: white;
        }
        .data-table tbody.odd
        {
        }
        .data-table tbody.odd td
        {
            border-width: 0 1px;
        }
        .data-table tbody.even
        {
            background-color: #F6F6F6;
        }
        .data-table tbody.even td
        {
            border-width: 0 1px;
        }
        .data-table tbody.odd tr.border td, .data-table tbody.even tr.border td
        {
            border-bottom-width: 1px;
        }
        .data-table th .tax-flag
        {
            font-weight: normal;
            white-space: nowrap;
        }
        .data-table td.label, .data-table th.label
        {
            background-color: #F6F6F6;
            font-weight: bold;
        }
        .data-table td.value
        {
        }
        
        .product-view .product-shop
        {
            float: right;
            width: 445px;
        }
        
        .products-list .product-shop
        {
            margin-left: 150px;
        }
        
        
        product-options
        {
            background-color: #F6F6F6;
            padding: 7px 11px;
        }
        .product-options dt label
        {
            font-weight: bold;
        }
        .product-options dt .qty-holder
        {
            float: right;
        }
        .product-options dt .qty-holder label
        {
            vertical-align: middle;
        }
        .product-options dt .qty-disabled
        {
            background: none repeat scroll 0 0 transparent;
            border: 0 none;
            color: #000000;
            padding: 3px;
        }
        .product-options dd
        {
            margin: 10px 0;
        }
        .product-options dl.last dd.last
        {
            margin: 0;
        }
        .product-options dl
        {
            margin: 0;
        }
        .product-options dd input.input-text
        {
            width: 98%;
        }
        .product-options dd input.datetime-picker
        {
            width: 150px;
        }
        .product-options dd .time-picker
        {
            display: inline-block;
            padding: 2px 0;
            vertical-align: middle;
        }
        .product-options dd textarea
        {
            height: 8em;
            width: 98%;
        }
        .product-options dd select
        {
            width: 100%;
        }
        .product-options .options-list
        {
        }
        .product-options .options-list input.radio
        {
            float: left;
            margin: 3px -18px 0 0;
        }
        .product-options .options-list input.checkbox
        {
            float: left;
            margin: 3px -20px 0 0;
        }
        .product-options .options-list .label
        {
            display: block;
            margin-left: 20px;
        }
        .product-options ul.validation-failed
        {
            padding: 0 7px;
        }
        .product-options p.required
        {
            margin: 0;
            padding: 0;
        }
        .product-options-bottom
        {
            -moz-border-bottom-colors: none;
            -moz-border-left-colors: none;
            -moz-border-right-colors: none;
            -moz-border-top-colors: none;
            border-color: -moz-use-text-color #DDDDDD #DDDDDD;
            border-image: none;
            border-right: 0 solid #DDDDDD;
            border-style: none solid solid;
            border-width: 0;
            padding: 10px;
        }
        .product-options-bottom .price-box
        {
            margin: 10px 0;
        }
        
        .pager
        {
            background-image: url("/Styles/css/images/toolbar-back.gif");
            background-position: center top;
            background-repeat: repeat-x;
            margin: 3px 0;
            text-align: center;
        }
    </style>

        <div id="divInfo" style="width:200px; color:Red;">
            <asp:Label ID="lblInfo" runat=server Width=200 Text="" Visible=false />
            </div>

    <div style="float: left;">
        <div class="product-img-box" style="width: 250px; padding-right: 20px; padding-top: 20px;">
            <!-- Begin magicthumb -->
            <div class="MagicToolboxContainer" style="width: 250px; border: 1px;">
                <img id="mainImage" runat="server" width="250" alt="No image"></img>
            </div>
            <!-- End magicthumb -->
        </div>
        <br />
        <div class="product-shop" style="float: left;">
            <div class="product-name">
                <h1>
                    <asp:Label runat="server" ID="lblName" Text="" />
                </h1>
            </div>
            <span>
                <p>
                    <asp:Label ID="lblExist" runat="server" Visible="false" Text="Есть в наличии" />
                </p>
            </span>
            <br />
            <div class="price-box">
                <asp:Label ID="lblPrice" runat="server" Text="Стоимость" />
                <asp:Label ID="lblPriceValue" runat="server" Text="" />
            </div>
            <br />
            <div class="product-options-bottomc">
                <asp:Label ID="lblSizeTitle" runat="server" Text="Выберите размер" AssociatedControlID="ddlSize" />
                <asp:DropDownList ID="ddlSize" Width="92" runat="server" DataValueField="ID" DataTextField="Size" />
            </div>
            <br />
            <asp:Label ID="lblCount" runat="server" Text="Количество" AssociatedControlID="tbxCount" />
            <asp:TextBox ID="tbxCount" runat="server" Text="" />
            <br />
            <br />
            <asp:Button runat="server" Text="Добавить в корзину" ID="btnAddToCart" OnClick="btnAddToCart_Click" />
        </div>
    </div>
    <div class="box-collateral box-additional" style="padding-left: 100px;">
            <br />
       
       
        <h2>
            Дополнительная информация</h2>
        <table class="data-table" id="product-attribute-specs-table">
            <col width="35%" />
            <col />
            <tbody>
                <tr>
                    <th class="label">
                        <asp:Label ID="lblBrand" runat="server" Text="Бренд" />
                    </th>
                    <td class="data">
                        <asp:Label ID="lblBrandValue" runat="server" />
                    </td>
                </tr>
                <tr>
                    <th class="label">
                        <asp:Label ID="lblCountry" runat="server" Text="Страна производства" />
                    </th>
                    <td class="data">
                        <asp:Label ID="lblCountryValue" runat="server" />
                    </td>
                </tr>
                <tr>
                    <th class="label">
                        <asp:Label ID="lblShoeType" runat="server" Text="Тип обуви" />
                    </th>
                    <td class="data">
                        <asp:Label ID="lblShoeTypeValue" runat="server" />
                    </td>
                </tr>
                <tr>
                    <th class="label">
                        <asp:Label ID="lblSeason" runat="server" Text="Тип сезона" />
                    </th>
                    <td class="data">
                        <asp:Label ID="lblSeasonValue" runat="server" Text="" />
                    </td>
                </tr>
                <tr>
                    <th class="label">
                        <asp:Label ID="lblColor" runat="server" Text="Цвет" />
                    </th>
                    <td class="data">
                        <asp:Label ID="lblColorValue" runat="server" />
                    </td>
                </tr>
                <tr>
                    <th class="label">
                        <asp:Label ID="lblMaterial" runat="server" Text="Материал" />
                    </th>
                    <td class="data">
                        <asp:Label ID="lblMaterialValue" runat="server" />
                    </td>
                </tr>
                <th class="label">
                    <asp:Label ID="lblInnerCode" runat="server" Text="Вн. код" />
                </th>
                <td class="data">
                    <asp:Label ID="lblInnerCodeValue" runat="server" />
                </td>
                </tr>
                <tr>
                    <th class="label">
                        <asp:Label ID="lblSize" Text="Размер" runat="server" />
                    </th>
                    <td class="data">
                        <asp:Label ID="lblSizeValue" runat="server" />
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    <br />
    <hr />
    <div style="width: 550px; padding-left: 260px;">
        <fieldset>
            <legend>
                <h2>
                    Описание</h2>
            </legend>
            <div style="padding-left: 20px; padding-top: 10px; padding-right: 20px; padding-bottom: 10px">
                <asp:Label ID="lblDescription" runat="server" Width="500" Height="400" />
                </div>
        </fieldset>
    </div>
    <br />
    <hr />
    <br />
    <div id="customer-reviews" style="padding: 20px; width: 560px;">
        <h2>
            Отзывы пользователей</h2>
    </div>
            <asp:SqlDataSource runat=server ID="SqlDataSource1"            
                    SelectCommand="SELECT [ID], [UserName], [ReviewText], [CreationDate], [ProductId] FROM [Review] WHERE ([ProductId] = @ProductId)" 
                 >   
                <SelectParameters>
                    <asp:QueryStringParameter DefaultValue="" Name="ProductId" 
                        QueryStringField="id" Type="Int32" />
                </SelectParameters>
                </asp:SqlDataSource>

            <div>
            <br />
            <br />
                <asp:Repeater ID="rprReview" runat="server" DataSourceID="SqlDataSource1">
                    <ItemTemplate>
                      <div style="border: solid 1px black; ">
                           <b>
                        <asp:Label ID="lblUer" runat="server" Text='<%# Eval("UserName") %>' ClientIDMode="AutoID" />
                        </b>
                        <br />
                        <asp:Label ID="lblUsersReview" runat="server" Text='<%# Eval("ReviewText") %>' ClientIDMode="AutoID" />
                         <br />
                         <asp:Label ID="lblReviewDate" runat="server" Text='<%# Eval("CreationDate") %>' />
                        </div>
                        <br />
                    </ItemTemplate>
                </asp:Repeater>
              <%--  </div>--%>
            </div>
        </div>
    </div>
    <div style="">
        <fieldset id="createFeedBack" runat="server" visible="false" style="padding: 20px;
            width: 450px; margin-left: 100px;">
            <legend>Добавить отзыв </legend>
            <asp:TextBox ID="tbxReview" runat="server" TextMode="MultiLine" Height="200" Width="469" />
            <br />
            <div style="float: right; padding-top: 10px;">
                <asp:Button ID="btnCreateDescription" runat="server" Text="Добавить отзыв" OnClick="btnCreateDescription_Click" />
            </div>
        </fieldset>
    </div>
    <br />
    <br />
    <br />
    <br />
    <br />
</asp:Content>
