<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="ShoeStore.Default" %>

<%@ Register Src="Controls/ProductItem.ascx" TagName="ProductItem" TagPrefix="uc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="HeaderContent" runat="server">
    <div id="slider">
        <div id="slider-holder">
            <ul>
                <li><a href="#">
                    <img src="Styles/css/images/slide1.jpg" alt="" /></a></li>
                <li><a href="#">
                    <img src="Styles/css/images/slide2.jpg" alt="" /></a></li>
                <li><a href="#">
                    <img src="Styles/css/images/slide1.jpg" alt="" /></a></li>
                <li><a href="#">
                    <img src="Styles/css/images/slide2.jpg" alt="" /></a></li>
                <li><a href="#">
                    <img src="Styles/css/images/slide1.jpg" alt="" /></a></li>
                <li><a href="#">
                    <img src="Styles/css/images/slide2.jpg" alt="" /></a></li>
            </ul>
        </div>
        <div id="slider-nav">
            <a href="#" class="prev">Previous</a> <a href="#" class="next">Next</a>
        </div>
    </div>
</asp:Content>
<asp:Content ID="content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="cntMain" ContentPlaceHolderID="MainContent" runat="server">
    <%--  <form id="form1" runat="server">--%>
    <div id="content">
        <!-- Tabs -->
        <div class="tabs">
            <ul>
                <li><a href="#" class="active"><span>Текущие предложения</span></a></li>
                <li><a href="#"><span>Мужская обувь</span></a></li>
                <li><a href="#" class="red"><span>Женская обувь</span></a></li>
            </ul>
        </div>
        <!-- Tabs -->
        <!-- Container -->
        <div id="container">
            <div class="tabbed">
                <!-- First Tab Content -->
                <div class="tab-content" style="display: block;">
                    <div class="items">
                        <div class="cl">
                            &nbsp;</div>
                        <asp:Repeater ID="Repeater1" runat="server" DataSourceID="dsrcProducts" OnItemDataBound="Repeater1_ItemDataBound">
                            <ItemTemplate>
                                <uc1:ProductItem ID="ProductItem1" runat="server" />
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                    <div class="cl">
                        &nbsp;</div>
                </div>
                <!-- End First Tab Content -->
                <!-- Second Tab Content -->
                <div class="tab-content">
                    <div class="items">
                        <div class="cl">
                            &nbsp;</div>
                        <asp:Repeater ID="Repeater2" runat="server" DataSourceID="SqlDataSourceMan" OnItemDataBound="Repeater2_ItemDataBound">
                            <ItemTemplate>
                                <uc1:ProductItem ID="ProductItemMan" runat="server" />
                            </ItemTemplate>
                        </asp:Repeater>
                        <div class="cl">
                            &nbsp;</div>
                    </div>
                </div>
                <!-- End Second Tab Content -->
                <!-- Third Tab Content -->
                <div class="tab-content">
                    <div class="items">
                        <div class="cl">
                            &nbsp;</div>
                        <asp:Repeater ID="Repeater3" runat="server" DataSourceID="SqlDataSourceWoman" OnItemDataBound="Repeater1_ItemDataBound">
                            <ItemTemplate>
                                <uc1:ProductItem ID="ProductItem1" runat="server" />
                            </ItemTemplate>
                        </asp:Repeater>
                        <div class="cl">
                            &nbsp;</div>
                    </div>
                </div>
            </div>
            <!-- End Third Tab Content -->
        </div>
    </div>
    <!-- Brands -->
    <div class="brands">
        <h3>
            Brands</h3>
        <div class="logos">
            <a href="#">
                <img src="Styles/css/images/logo1.gif" alt="" /></a> <a href="#" />
            <img src="Styles/css/images/logo2.gif" alt="" /></a> <a href="#" />
            <img src="Styles/css/images/logo3.gif" alt="" /></a> <a href="#" />
            <img src="Styles/css/images/logo4.gif" alt="" /></a> <a href="#" />
            <img src="Styles/css/images/logo5.gif" alt="" /></a>
        </div>
    </div>
    <!-- End Brands -->
    <!-- Footer -->
    <div id="footer">
        <div class="left">
            <a href="#">Home</a> <span>|</span> <a href="#">Support</a> <span>|</span> <a href="#">
                My Account</a> <span>|</span> <a href="#">The Store</a> <span>|</span> <a href="#">Contact</a>
        </div>
        <div class="right">
            &copy; Sitename.com. Design by
        </div>
    </div>
    <!-- End Footer -->
    </div>
    <!-- End Container -->
    <%--    </form>--%>
    <asp:SqlDataSource ID="dsrcProducts" runat="server"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSourceMan" runat="server"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSourceWoman" runat="server"></asp:SqlDataSource>
</asp:Content>
