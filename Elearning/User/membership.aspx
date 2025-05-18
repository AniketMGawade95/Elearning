<%@ Page Title="Subscription Plans" Language="C#" MasterPageFile="~/MasterPages/User.Master" AutoEventWireup="true" CodeBehind="membership.aspx.cs" Inherits="Elearning.User.membership" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />

     <script src="https://checkout.razorpay.com/v1/checkout.js"></script>

        <style>
        .plan-card {
    transition: 0.3s;
    box-shadow: 2px 2px 10px #ddd;
}

.plan-card:hover {
    transform: scale(1.02);
    box-shadow: 3px 3px 15px #bbb;
}

.buy-btn {
    background-color: #007bff;
    color: white;
    border: none;
    padding: 8px 16px;
    border-radius: 5px;
}

    </style>


</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">




  <div>
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


</div>





</asp:Content>
