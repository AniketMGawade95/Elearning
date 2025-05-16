<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/User.Master" AutoEventWireup="true" CodeBehind="mycourses.aspx.cs" Inherits="Elearning.User.mycourses" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

        <title></title>
            <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous"/>
<script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
<script src="https://cdn.jsdelivr.net/npm/popper.js@1.12.9/dist/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
<script src="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


            <div>

            <div>
                <h1>My Courses</h1><br />
            </div>

                                    <asp:DataList ID="DatalistCourse" runat="server" RepeatDirection="Horizontal" RepeatColumns="3" >
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
    <li class="list-group-item">Topics: <%#Eval("NumberOfTopics") %></li>
          <li class="list-group-item">Deadline: <%#Eval("Deadline") %></li>

  </ul>
  <div class="card-body" style="display: flex; justify-content: space-between; align-items: center;">
      <asp:Button ID="btnGetCourse" runat="server" Text="Get Into Course"
    CssClass="btn btn-primary"
    CommandName="GetCourse"
    CommandArgument='<%# Eval("SubCourseID") %>'
    OnCommand="btnGetCourse_Command" /><br />
      <div>

      </div>





  </div>
                                        </div>
</div>
                        
                </ItemTemplate>
            </asp:DataList>

        </div>

</asp:Content>
