﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/User.Master" AutoEventWireup="true" CodeBehind="BuyCourses.aspx.cs" Inherits="Elearning.User.BuyCourses" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style>
    .course-card:hover {
        transform: translateY(-5px);
        transition: 0.3s ease-in-out;
        box-shadow: 0 8px 20px rgba(0, 123, 255, 0.2);
    }
</style>


        <title>Buy Courses</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
<script src="https://cdn.jsdelivr.net/npm/popper.js@1.12.9/dist/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
<script src="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>

</asp:Content>




<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


           <%-- <div class="mt-4">
            
                   <div class="container mt-4">
<div class="input-group mb-3">
    <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" Width="60%" height="30px" placeholder="Search courses..." />
    <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary input-group-append" Width="20%" height="30px" onClick="btnSearch_Click" />
</div>
                       
            <br />
            <br />
            <asp:DataList ID="DataList1" runat="server" RepeatDirection="Horizontal" RepeatColumns="4">
                <ItemTemplate>
                      <div class="card" style="width:18rem;">
                          

                          <asp:Image ID="imgCourse" runat="server" ImageUrl='<%# Eval("Picture") %>' CssClass="card-img-top" height="250" width="270" AlternateText="Course Image" />

                      
                      <div class="card-body">
                        <h5 class="card-title"><%#Eval("CourseName") %></h5>
                        <p class="card-text">Created at'<%#Eval("CreatedAt") %>'</p>
                          <asp:Button ID="btnViewSubcourses" runat="server" class="btn btn-primary" Text="Courses"  CommandName="ViewSubCourses"
                CommandArgument='<%# Eval("MasterCourseID") %>' 
                OnCommand="btnViewSubcourses_Command" />
                      </div>
                    </div>
                </ItemTemplate>
            </asp:DataList>
            <br />
            <br />
            
            </div>
            </div>
--%>


    <div class="container mt-5">
    <!-- Search bar -->
    <div class="input-group mb-4 shadow-sm">
        <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control form-control-lg rounded-start-pill" placeholder="Search courses..." />
        <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-info text-white rounded-end-pill" OnClick="btnSearch_Click" />
    </div>

    <!-- Courses Grid -->
    <div class="row g-4">
        <asp:DataList ID="DataList1" runat="server" RepeatDirection="Horizontal" RepeatColumns="3" CssClass="d-flex flex-wrap justify-content-start">
            <ItemTemplate>
                <div class="col">
                    <div class="card h-100 shadow-sm border-info course-card" style="width: 18rem;">
                        <asp:Image ID="imgCourse" runat="server" ImageUrl='<%# Eval("Picture") %>' CssClass="card-img-top img-fluid" AlternateText="Course Image" style="height: 200px; object-fit: cover;" />

                        <div class="card-body bg-light">
                            <h5 class="card-title text-info fw-bold text-truncate"><%# Eval("CourseName") %></h5>
                            <p class="card-text small text-muted mb-3">Created on <strong><%# Eval("CreatedAt") %></strong></p>
                            <asp:Button ID="btnViewSubcourses" runat="server" CssClass="btn btn-primary w-100" Text="View Subcourses" CommandName="ViewSubCourses" CommandArgument='<%# Eval("MasterCourseID") %>' OnCommand="btnViewSubcourses_Command" />
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:DataList>
    </div>
</div>



    



</asp:Content>
