<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Admin.Master" AutoEventWireup="true" CodeBehind="AddTopic.aspx.cs" Inherits="Elearning.Admin.AddTopic" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


     <div style="text-align:center"> Add Topics</div>
 <br />
 Select Master Course<asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
 <br />
 Select Sub Course <asp:DropDownList ID="DropDownList2" runat="server"></asp:DropDownList>
 <br />
 Enter Topic Name <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
 <br />
 Add Video link <asp:TextBox ID="TextBox2" runat="server" TextMode="MultiLine" ValidateRequestMode="Disabled"></asp:TextBox>
 <br />
 Add Video Duration in Seconds <asp:TextBox  ID="TextBox3" runat="server"></asp:TextBox>
 <br />
 <asp:Button ID="Button1" runat="server" Text="Add"  OnClick="Button1_Click" />


</asp:Content>
