<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Admin.Master" AutoEventWireup="true" CodeBehind="Allcourseslist.aspx.cs" Inherits="Elearning.Admin.Allcourseslist" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <title>View All CourseList</title>

    <style>
    body { font-family: Arial; margin: 20px; }
    .container { width: 90%; margin: auto; }
    .filter-row { margin-bottom: 20px; }
    .filter-row select, .filter-row button { margin-right: 10px; }
    table { width: 100%; border-collapse: collapse; margin-top: 20px; }
    th, td { border: 1px solid #ccc; padding: 10px; text-align: center; }
    th { background-color: #f2f2f2; }
</style>
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="container">
     <h2>All CourseList</h2>
     <div class="filter-row">
         <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="false"></asp:DropDownList>
         <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="false"></asp:DropDownList>
         <asp:DropDownList ID="DropDownList3" runat="server" AutoPostBack="false"></asp:DropDownList>
         <asp:Button ID="Button1" runat="server" Text="Search" OnClick="Button1_Click" />
     </div>

     <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowDeleting="GridView1_RowDeleting">
         <Columns>
             <asp:BoundField DataField="CourseName" HeaderText="Course Name" />
             <asp:BoundField DataField="SubCourseName" HeaderText="SubCourse Name" />
             <asp:BoundField DataField="Price" HeaderText="Price (₹)" />
             <asp:BoundField DataField="NumberOfTopics" HeaderText="Number of Topics" />
             <asp:BoundField DataField="FormattedDuration" HeaderText="Total Duration (hh:mm:ss)" />
             <asp:BoundField DataField="NumberOfAssignments" HeaderText="Number of Assignments" />
             <asp:BoundField DataField="NumberOfMCQs" HeaderText="Number of MCQs" />
             <asp:TemplateField HeaderText="Action">
                 <ItemTemplate>
                     <asp:Button ID="Button2" runat="server" Text="Delete" CommandArgument='<%#Eval("SubCourseID") %>' CommandName="Delete" />
                 </ItemTemplate>
             </asp:TemplateField>
         </Columns>
     </asp:GridView>

 </div>




</asp:Content>
