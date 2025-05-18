<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Admin.Master" AutoEventWireup="true" CodeBehind="Membership.aspx.cs" Inherits="Elearning.Admin.Membership" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet">

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <div class="container p-4 border border-info rounded bg-light shadow-sm mt-4">

    <h4 class="text-primary mb-4">
        <i class="bi bi-gear-fill me-2"></i>Plan Configuration
    </h4>

    <!-- Plan Name -->
    <div class="mb-3">
        <label class="form-label text-primary fw-semibold">Select Plan Name</label>
        <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-select border-info shadow-sm">
            <asp:ListItem>Select Plans</asp:ListItem>
            <asp:ListItem>Bronze</asp:ListItem>
            <asp:ListItem>Silver</asp:ListItem>
            <asp:ListItem>Gold</asp:ListItem>
        </asp:DropDownList>
    </div>

    <!-- Master Course -->
    <div class="mb-3">
        <label class="form-label text-primary fw-semibold">Select Master Course</label>
        <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="true"
            OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" CssClass="form-select border-info shadow-sm">
        </asp:DropDownList>
    </div>

    <!-- Sub Courses -->
    <div class="mb-3">
        <label class="form-label text-primary fw-semibold">Select Sub Courses</label>
        <asp:CheckBoxList ID="CheckBoxList1" runat="server" RepeatDirection="Vertical" CssClass="form-check">
        </asp:CheckBoxList>
        <asp:Button ID="Button2" runat="server" Text="+" OnClick="Button2_Click" CssClass="btn btn-info btn-sm mt-2" />
    </div>

    <!-- Validity -->
    <div class="mb-3">
        <label class="form-label text-primary fw-semibold">Enter Validity (in days)</label>
        <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control border-info shadow-sm"></asp:TextBox>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
            ControlToValidate="TextBox1" ErrorMessage="Enter Number Only" ForeColor="Red"
            ValidationExpression="^\d+(\.\d+)?$" CssClass="form-text text-danger"></asp:RegularExpressionValidator>
        <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="TextBox1"
            ErrorMessage="Validity should be greater than 0" ForeColor="Red" MaximumValue="1000000"
            MinimumValue="1" Type="Integer" CssClass="form-text text-danger"></asp:RangeValidator>
    </div>

    <!-- Price -->
    <div class="mb-3">
        <label class="form-label text-primary fw-semibold">Enter Price</label>
        <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control border-info shadow-sm"></asp:TextBox>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
            ControlToValidate="TextBox2" ErrorMessage="Enter Number Only" ForeColor="Red"
            ValidationExpression="^\d+(\.\d+)?$" CssClass="form-text text-danger"></asp:RegularExpressionValidator>
        <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="TextBox2"
            ErrorMessage="Price should be greater than 0" ForeColor="Red" MaximumValue="1000000"
            MinimumValue="1" Type="Integer" CssClass="form-text text-danger"></asp:RangeValidator>
    </div>

    <!-- Submit Button -->
    <asp:Button ID="Button1" runat="server" Text="Save" OnClick="Button1_Click" CssClass="btn btn-primary px-4" />

</div>


</asp:Content>
