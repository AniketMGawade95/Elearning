<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/User.Master" AutoEventWireup="true" CodeBehind="CoursesDetails.aspx.cs" Inherits="Elearning.User.CoursesDetails" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



       <!-- Dropdown and GridView -->
    <div class="container mt-5 mb-4">
        <div class="row">
            <div class="col-md-6">
                <label for="ddlMasterCourses"><strong>Select Master Course:</strong></label>
                <asp:DropDownList ID="ddlMasterCourses" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlMasterCourses_SelectedIndexChanged" CssClass="form-control">
                </asp:DropDownList>
            </div>
        </div>

        <div class="row mt-4">
            <div class="col-md-8">
                <asp:GridView ID="gvCourseDetails" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered">
                    <Columns>
                        <asp:BoundField DataField="SubCourseName" HeaderText="Sub Course" />
                        <asp:BoundField DataField="NumberOfTopics" HeaderText="Number of Topics" />
                        <asp:BoundField DataField="Duration" HeaderText="Total Duration (Hours)" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>

   <%-- <!-- Header Start -->
    <div class="jumbotron jumbotron-fluid page-header position-relative overlay-bottom" style="margin-bottom: 90px;">
        <div class="container text-center py-5">
            <h1 class="text-white display-1">Course Detail</h1>
            <div class="d-inline-flex text-white mb-5">
                <p class="m-0 text-uppercase"><a class="text-white" href="default.aspx">Home</a></p>
                <i class="fa fa-angle-double-right pt-1 px-3"></i>
                <p class="m-0 text-uppercase">Course Detail</p>
            </div>
            <div class="mx-auto mb-5" style="width: 100%; max-width: 600px;">
                <div class="input-group">
                    <div class="input-group-prepend">
                        <button class="btn btn-outline-light bg-white text-body px-4 dropdown-toggle" type="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Courses</button>
                        <div class="dropdown-menu">
                            <a class="dropdown-item" href="#">Courses 1</a>
                            <a class="dropdown-item" href="#">Courses 2</a>
                            <a class="dropdown-item" href="#">Courses 3</a>
                        </div>
                    </div>
                    <input type="text" class="form-control border-light" style="padding: 30px 25px;" placeholder="Keyword">
                    <div class="input-group-append">
                        <button class="btn btn-secondary px-4 px-lg-5">Search</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Header End -->--%>

    <!-- The rest of the content (Course Detail, Features, Categories, Related/Recent Courses) remains unchanged -->



</asp:Content>
