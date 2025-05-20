<%@ Page Title="Subscription Plans" Language="C#" MasterPageFile="~/MasterPages/User.Master" AutoEventWireup="true" CodeBehind="membership.aspx.cs" Inherits="Elearning.User.membership" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />

     <script src="https://checkout.razorpay.com/v1/checkout.js"></script>

        <!-- Bootstrap 5 CDN -->
<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
<style>
    body {
        font-family: 'Segoe UI', sans-serif;
        background-color: #f5f5f5;
        margin: 0;
        padding: 20px;
    }

    .card-container {
        display: flex;
        flex-wrap: wrap;
        gap: 20px;
        justify-content: center;
    }

    .card {
        width: 300px;
        padding: 20px;
        border-radius: 12px;
        box-shadow: 0 4px 12px rgba(0, 0, 0, 0.1);
        transition: transform 0.3s ease, box-shadow 0.3s ease;
        color: #fff;
    }

    .card:hover {
        transform: translateY(-5px);
        box-shadow: 0 6px 16px rgba(0, 0, 0, 0.2);
    }

    .gold {
        background-color: #FFD700;
        color: #000;
    }

    .silver {
        background-color: #C0C0C0;
        color: #000;
    }

    .bronze {
        background-color: #CD7F32;
        color: #fff;
    }

    .card h2 {
        margin-top: 0;
        font-size: 22px;
    }

    .card p {
        margin: 6px 0;
        font-weight: 500;
    }

    .price {
        font-size: 18px;
        font-weight: bold;
    }

    .buy-button {
        margin-top: 10px;
        padding: 10px 15px;
        border: none;
        border-radius: 5px;
        font-weight: bold;
        cursor: pointer;
        width: 100%;
        transition: opacity 0.3s ease;
    }

    .gold .buy-button {
        background-color: #e6be00;
        color: #000;
    }

    .silver .buy-button {
        background-color: #b0b0b0;
        color: #000;
    }

    .bronze .buy-button {
        background-color: #a0522d;
        color: #fff;
    }

    .buy-button:hover {
        opacity: 0.9;
    }
</style>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">




 <%-- <div>
    <asp:Repeater ID="Repeater1" runat="server" >
        <ItemTemplate>
            <div class="plan-card" style="border:1px solid #ccc; padding:15px; margin:10px; border-radius:8px;">
                <h3><%# Eval("PlanName") %> Plan</h3>
                <!--<p><strong>Master Course:</strong> <%# Eval("MasterCourse") %></p>-->
                <p><strong>Features:</strong> <%# Eval("Features") %></p>
                <p><strong>SubCourses:</strong> <%# Eval("SubCourses") %></p>
                <p><strong>Validity:</strong> <%# Eval("Validity") %> Days</p>
                <p><strong>Price:</strong> ₹<%# Eval("Price") %></p>
                <asp:Button ID="btnBuy" runat="server" Text="Buy Now" CssClass="buy-btn" CommandArgument='<%# Eval("Price") %>' OnClick="btnBuy_Click" />
            </div>
        </ItemTemplate>
    </asp:Repeater>


</div>--%>




    <div class="card-container">
    <asp:DataList ID="DataList1" runat="server" OnItemCommand="DataList1_ItemCommand" RepeatDirection="Horizontal" RepeatColumns="3" CellPadding="10">
        <ItemTemplate>
            <div class='<%# GetPlanClass(Eval("PlanName").ToString()) %> card'>
                <h2><%# Eval("MasterCourseName") %> - <%# Eval("PlanName") %></h2>
                <hr />
                <p>Features: <%# Eval("Features") %></p>
                <p>Price: <strong class="price">₹ <%# Eval("Price") %></strong></p>
                <p>Validity: <%# Eval("Validity") %> days</p>
                <asp:Button ID="btnBuy" runat="server" Text="Buy" CssClass="buy-button" CommandName="BuyNow"
                    CommandArgument='<%# Eval("MasterCourseName") + "|" + Eval("SubscriptionPlanID") + "|" + Eval("PlanName") + "|" + Eval("Price") + "|" + Eval("Validity") %>' />
            </div>
        </ItemTemplate>
    </asp:DataList>
</div>





</asp:Content>
