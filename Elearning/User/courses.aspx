﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/User.Master" AutoEventWireup="true" CodeBehind="courses.aspx.cs" Inherits="Elearning.User.courses" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

        <title>Courses</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous"/>
<script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
<script src="https://cdn.jsdelivr.net/npm/popper.js@1.12.9/dist/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
<script src="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



<%--            <div class="mt-4">

           <div class="container mt-4">
    <div class="input-group mb-3">
        <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" Width="60%" height="30px" placeholder="Search courses..." />
        <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary input-group-append" Width="20%" height="30px" onClick="btnSearch_Click" />
    </div>
</div>

 <br />
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
    <li class="list-group-item">Level: Beginner</li>--%>


       <%--<li class="list-group-item">Topics: <%#Eval("NumberOfTopics") %></li>--%>


   <%-- <li class="list-group-item">⭐ <%#Eval("Rating") %></li>
  </ul>
  <div class="card-body" style="display: flex; justify-content: space-between; align-items: center;">
<asp:Button ID="btnBuyCourse" runat="server" Text="Add To Cart" CssClass="btn btn-primary" CommandName="Buy" CommandArgument='<%# Eval("SubCourseID") %>' OnCommand="btnBuyCourse_Command" />
                <asp:Label ID="Label1" runat="server" Text='<%# "  " + "Rs/- " + Eval("Price") %>'></asp:Label>

  </div>
                                        </div>
</div>
                        
                </ItemTemplate>
            </asp:DataList>




        </div>--%>






    <div class="container mt-5">

    <!-- Search Bar -->
    <div class="input-group mb-4">
        <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" placeholder="Search courses..." />
        <div class="input-group-append">
            <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-info" OnClick="btnSearch_Click" />
        </div>
    </div>

    <!-- Course Cards -->
    <asp:DataList ID="DatalistCourse" runat="server" RepeatDirection="Horizontal" RepeatColumns="3" CssClass="row g-4">
        <ItemTemplate>
            <div class="col">
                <div class="card h-100 shadow border-info">
                    <asp:Image 
    ID="imgCourse" 
    runat="server" 
    ImageUrl='<%# Eval("Picture") %>' 
    CssClass="card-img-top img-fluid" 
    Style="height: 200px; object-fit: cover;" 
    AlternateText="Course Image" />


                    <div class="card-body bg-light">
                        <h5 class="card-title text-primary fw-bold"><%# Eval("SubCourseName") %></h5>
                    </div>

                    <ul class="list-group list-group-flush">
                        <li class="list-group-item">⏱ Duration: Hrs&nbsp<%# Eval("Duration") %></li>
                        <li class="list-group-item">📘 Level: <span class="text-info fw-semibold">Beginner</span></li>
                        <li class="list-group-item">⭐ Rating: <%# Eval("Rating") %></li>
                    </ul>

                    <div class="card-body d-flex justify-content-between align-items-center">
                        <asp:Button ID="btnBuyCourse" runat="server" Text="Add To Cart" CssClass="btn btn-primary" CommandName="Buy" CommandArgument='<%# Eval("SubCourseID") %>' OnCommand="btnBuyCourse_Command" />
                        <asp:Label ID="Label1" runat="server" CssClass="fw-bold text-danger" Text='<%# "Rs. " + Eval("Price") %>'></asp:Label>
                    </div>
                </div>
            </div>
        </ItemTemplate>
    </asp:DataList>

</div>








</asp:Content>
