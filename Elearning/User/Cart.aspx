<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/User.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="Elearning.User.Cart" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


        <title>Cart</title>
        <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous"/>
<script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
<script src="https://cdn.jsdelivr.net/npm/popper.js@1.12.9/dist/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
<script src="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>
    <script src="https://checkout.razorpay.com/v1/checkout.js"></script>


</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


<%--            <div>
            <div>
               <h1>
My Cart
               </h1> 
            </div>
            <br />



                        <asp:DataList ID="DatalistCourse" runat="server" RepeatDirection="Horizontal" RepeatColumns="3">
                <ItemTemplate>

                    <div class="card" style="width: 25rem;">
                            <div class="card-container">

 <asp:Image ID="imgCourse" runat="server" ImageUrl='<%# Eval("Picture") %>' CssClass="card-img-top" height="250" width="270" AlternateText="Course Image" />
                                </div>

                                    <div class="card-content">

  <div class="card-body">

    <h5 class="card-title"><%#Eval("SubCourseName") %></h5>
  </div>
  <ul class="list-group list-group-flush">
    <li class="list-group-item">⏱: <%#Eval("Duration") %></li>
    <li class="list-group-item">Level: Beginner</li>
    <li class="list-group-item">⭐ <%#Eval("Rating") %></li>
  </ul>
  <div class="card-body" style="display: flex; justify-content: space-between; align-items: center;">
      <asp:Button ID="btnRemove" runat="server" Text="Remove"
    CssClass="btn btn-danger"
    CommandName="Remove"
    CommandArgument='<%# Eval("CartID") %>'
    OnCommand="btnRemove_Command" />



                <asp:Label ID="Label1" runat="server" Text='<%# "  " + "Rs/- " + Eval("Price") %>'></asp:Label>

  </div>
                                        </div>
</div>
                        
                </ItemTemplate>
            </asp:DataList>

        </div>
        <br />

        <!-- GridView Section - BELOW DataList -->
 <asp:GridView ID="GridViewCart" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered mt-4">
            <Columns>
                <asp:BoundField DataField="SubCourseName" HeaderText="Course Name" />
                <asp:BoundField DataField="Price" HeaderText="Price (Rs)" />
            </Columns>
        </asp:GridView>
        <br />

        <!-- Total Price Label Below GridView -->
        <div class="text-left mt-3">
            <strong>Total Price: Rs/- </strong>
            <asp:Label ID="lblTotalPrice" runat="server" Font-Bold="true" ForeColor="Green"></asp:Label>
        </div>
        <div class="text-right mt-3">
                <asp:Button ID="btnPay" runat="server" Text="Proceed to Pay" CssClass="btn btn-success" OnClick="btnPay_Click"/>
            </div>
--%>






    <div class="container my-5">
    <!-- Cart Heading -->
    <div class="text-center mb-4">
        <h1 class="text-primary fw-bold">My Cart</h1>
    </div>

    <!-- DataList: Cart Items -->
    <asp:DataList ID="DatalistCourse" runat="server" RepeatDirection="Horizontal" RepeatColumns="3" CssClass="row row-cols-1 row-cols-md-3 g-4">
        <ItemTemplate>
            <div class="col">
                <div class="card h-100 shadow border-info">
                    <!-- Course Image -->
                    <asp:Image ID="imgCourse" runat="server" ImageUrl='<%# Eval("Picture") %>'
                        CssClass="card-img-top img-fluid"
                        Style="height: 200px; object-fit: cover;"
                        AlternateText="Course Image" />

                    <!-- Course Content -->
                    <div class="card-body bg-light">
                        <h5 class="card-title text-primary fw-semibold"><%# Eval("SubCourseName") %></h5>
                    </div>

                    <!-- Course Details -->
                    <ul class="list-group list-group-flush">
                        <li class="list-group-item">⏱ Duration: <%# Eval("Duration") %></li>
                        <li class="list-group-item">📘 Level: <span class="text-info">Beginner</span></li>
                        <li class="list-group-item">⭐ Rating: <%# Eval("Rating") %></li>
                    </ul>

                    <!-- Actions -->
                    <div class="card-body d-flex justify-content-between align-items-center">
                        <asp:Button ID="btnRemove" runat="server" Text="Remove"
                            CssClass="btn btn-danger"
                            CommandName="Remove"
                            CommandArgument='<%# Eval("CartID") %>'
                            OnCommand="btnRemove_Command" />
                        <asp:Label ID="Label1" runat="server" CssClass="fw-bold text-dark"
                            Text='<%# "Rs. " + Eval("Price") %>'></asp:Label>
                    </div>
                </div>
            </div>
        </ItemTemplate>
    </asp:DataList>

    <!-- Spacer -->
    <hr class="my-4" />

    <!-- GridView: Summary -->
    <asp:GridView ID="GridViewCart" runat="server" AutoGenerateColumns="False"
        CssClass="table table-bordered table-hover border-primary">
        <Columns>
            <asp:BoundField DataField="SubCourseName" HeaderText="Course Name" />
            <asp:BoundField DataField="Price" HeaderText="Price (Rs)" />
        </Columns>
    </asp:GridView>






        <div class="container my-4">
    <div class="card shadow p-4">
        <h4 class="text-primary mb-3">Apply Your Offer Captcha</h4>

        <div class="row align-items-center">
            <div class="col-md-6 mb-2">
                <asp:TextBox 
                    ID="txtOfferCaptcha" 
                    runat="server" 
                    Placeholder="Enter Offer Captcha" 
                    CssClass="form-control" />
            </div>

            <div class="col-md-3 mb-2">
                <asp:Button 
                    ID="btnApplyOffer" 
                    runat="server" 
                    Text="Apply Offer" 
                    OnClick="btnApplyOffer_Click" 
                    CssClass="btn btn-success w-100" />
            </div>

            <div class="col-md-12 mt-2">
                <asp:Label 
                    ID="lblDiscountMsg" 
                    runat="server" 
                    CssClass="text-success fw-semibold" />
            </div>
        </div>
    </div>
</div>










    <!-- Total Price -->
    <div class="row mt-4">
        <div class="col-md-6">
            <strong class="text-info">Total Price: Rs. </strong>
            <asp:Label ID="lblTotalPrice" runat="server" CssClass="fw-bold text-success"></asp:Label>
        </div>
        <div class="col-md-6 text-end">
            <asp:Button ID="btnPay" runat="server" Text="Proceed to Pay"
                CssClass="btn btn-success px-4" OnClick="btnPay_Click" />
        </div>
    </div>
</div>


</asp:Content>
