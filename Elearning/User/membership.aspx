


<%@ Page Title="Subscription Plans" Language="C#" MasterPageFile="~/MasterPages/User.Master" AutoEventWireup="true" CodeBehind="membership.aspx.cs" Inherits="Elearning.User.membership" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Bootstrap & Font Awesome -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.0/css/all.min.css" rel="stylesheet" />

    <!-- Razorpay -->
    <script src="https://checkout.razorpay.com/v1/checkout.js"></script>

    <style>
        body {
            font-family: 'Segoe UI', sans-serif;
            background-color: #f8f9fa;
        }

        .card-container {
            display: flex;
            flex-wrap: wrap;
            gap: 20px;
            justify-content: center;
            margin-top: 30px;
        }

        .card {
            width: 320px;
            border: none;
            border-radius: 15px;
            color: #fff;
            padding: 20px;
            transition: transform 0.3s ease, box-shadow 0.3s ease;
        }

        .card:hover {
            transform: translateY(-5px);
            box-shadow: 0 6px 20px rgba(0, 0, 0, 0.15);
        }

        .gold { background-color: #FFD700; color: #000; }
        .silver { background-color: #C0C0C0; color: #000; }
        .bronze { background-color: #CD7F32; color: #fff; }

        .card h2 {
            font-size: 22px;
            margin-bottom: 10px;
        }

        .card p {
            margin: 8px 0;
            font-weight: 500;
        }

        .price {
            font-size: 20px;
            font-weight: bold;
        }

        .buy-button {
            margin-top: 15px;
            width: 100%;
            padding: 10px;
            font-weight: 600;
            border: none;
            border-radius: 8px;
            transition: background-color 0.3s ease;
        }

        .gold .buy-button {
            background-color: #e6be00;
            color: #000;
        }

        .silver .buy-button {
            background-color: #a9a9a9;
            color: #000;
        }

        .bronze .buy-button {
            background-color: #a0522d;
            color: #fff;
        }

        .buy-button i {
            margin-right: 8px;
        }

        @media screen and (max-width: 768px) {
            .card { width: 100%; }
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="text-center mt-4">
        <h2 class="fw-bold">Choose Your Plan</h2>
        <p class="text-muted">Unlock access to premium courses with a plan that suits you.</p>
    </div>

    <div class="card-container">
        <asp:DataList ID="DataList1" runat="server" OnItemCommand="DataList1_ItemCommand" RepeatDirection="Horizontal" RepeatColumns="3" CellPadding="10">
            <ItemTemplate>
                <div class='<%# GetPlanClass(Eval("PlanName").ToString()) %> card'>
                    <h2><i class="fa-solid fa-book-open-reader me-1"></i><%# Eval("MasterCourseName") %> - <%# Eval("PlanName") %></h2>
                    <hr class="border-white" />
                    <p><i class="fa-solid fa-list-check me-1"></i> Features: <%# Eval("Features") %></p>
                    <p><i class="fa-solid fa-calendar-days me-1"></i> Validity: <%# Eval("Validity") %> days</p>
                    <p><i class="fa-solid fa-indian-rupee-sign me-1"></i> Price: <span class="price">₹ <%# Eval("Price") %></span></p>
                    <asp:Button ID="btnBuy" runat="server" Text='<%# "Buy Now" %>' CssClass="buy-button" CommandName="BuyNow"
                        CommandArgument='<%# Eval("MasterCourseName") + "|" + Eval("SubscriptionPlanID") + "|" + Eval("PlanName") + "|" + Eval("Price") + "|" + Eval("Validity") %>'>
                    </asp:Button>
                </div>
            </ItemTemplate>
        </asp:DataList>
    </div>
</asp:Content>
