<%@ Page Title="Subscription Plans" Language="C#" MasterPageFile="~/MasterPages/User.Master" AutoEventWireup="true" CodeBehind="membership.aspx.cs" Inherits="Elearning.User.membership" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">




    <%--<div class="container mt-5">
        <h2 class="text-center mb-4">Subscription Plans</h2>
        <div class="row">
            <asp:Repeater ID="rptPlans" runat="server">
                <ItemTemplate>
                    <div class="col-md-4 mb-4">
                        <div class="card shadow h-100">
                            <div class="card-body">
                                <h5 class="card-title text-primary"><%# Eval("PlanName") %></h5>
                                <p class="card-text"><%# Eval("Features").ToString().Replace(";", "<br/>") %></p>
                                <h6>Price: ₹<%# Eval("Price") %></h6>
                                <h6>Validity: <%# Eval("Validity") %></h6>
                                <a href='BuySubscription.aspx?PlanID=<%# Eval("SubscriptionPlanID") %>' class="btn btn-success mt-2">Buy</a>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>--%>





</asp:Content>
