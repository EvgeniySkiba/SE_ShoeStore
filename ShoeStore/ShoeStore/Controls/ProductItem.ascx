<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductItem.ascx.cs"
    Inherits="ShoeStore.Controls.ProductItem" %>

<%--<div class="items">--%>
<div>
    <ul>
        <li>
            <div class="image">
                <asp:HyperLink ID="hlkImage" runat="server" Text="">
                    <asp:Image ID="ImgProduct" runat="server" ClientIDMode="AutoID" />
                </asp:HyperLink>
            </div>
            <p>
                Item Number: <span>
                    <asp:Label ID="lblCode" runat="server"></asp:Label>
                </span>
                <br />
                Material : <span>
                    <asp:Label ID="lblSize" runat="server"></asp:Label>
                </span>
                <br />
                Brand Name: <span>
                    <asp:Label ID="lblBrand" runat="server"></asp:Label>
                </span>
            </p>
            <p class="price">
                Wholesale Price: <strong>
                    <asp:Label ID="lblCost" runat="server"></asp:Label>
                </strong>
            </p>
        </li>
    </ul>
</div>
