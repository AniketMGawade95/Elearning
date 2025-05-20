<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Admin.Master" AutoEventWireup="true" CodeBehind="subcrripstionList.aspx.cs" Inherits="Elearning.Admin.subcrripstionList" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.5.0/css/all.min.css" rel="stylesheet" />

    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>


    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>

    <style>
        .table th, .table td {
            vertical-align: middle !important;
        }

        .form-check-inline {
            margin-right: 15px;
        }

        .modal-body .form-label {
            font-weight: 500;
        }

        .checklist-container .form-check {
            display: inline-block;
            margin-right: 15px;
        }
    </style>

</asp:Content>





<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">




    <div class="container my-4">
    <h3 class="mb-4">Subscription Plans</h3>
    <asp:GridView ID="gvSubscriptions" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered" OnRowCommand="gvSubscriptions_RowCommand">
        <Columns>
            <asp:BoundField DataField="PlanName" HeaderText="Plan Name" />
            <asp:BoundField DataField="CourseName" HeaderText="Master Course" />
            <asp:BoundField DataField="Price" HeaderText="Price" />
            <asp:BoundField DataField="Validity" HeaderText="Validity (days)" />
            <asp:TemplateField HeaderText="Actions">
                <ItemTemplate>




                   <%-- <asp:Button ID="btnEdit" runat="server" Text="Edit" CssClass="btn btn-primary btn-sm me-2"
                        CommandName="EditSubscription" CommandArgument='<%# Eval("SubscriptionPlanID") %>' />--%>




                    <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-danger btn-sm"
                        CommandName="DeleteSubscription" CommandArgument='<%# Eval("SubscriptionPlanID") %>' 
                        OnClientClick="return confirm('Are you sure you want to delete this subscription?');" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</div>

<!-- Edit Modal -->
<div class="modal fade" id="editModal" tabindex="-1" aria-labelledby="editModalLabel" aria-hidden="true">
    <div class="modal-dialog modal-lg">
        <div class="modal-content">
            <div class="modal-header bg-primary text-white">
                <h5 class="modal-title" id="editModalLabel">Edit Subscription</h5>
                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
            </div>
            <div class="modal-body">

                <asp:HiddenField ID="hfSubscriptionID" runat="server" />

                <div class="mb-3">
                    <label class="form-label">Plan Name</label>
                    <asp:DropDownList ID="ddlPlanName" runat="server" CssClass="form-select"></asp:DropDownList>
                </div>

                <div class="mb-3">
                    <label class="form-label">Master Course</label>
                    <asp:DropDownList ID="ddlMasterCourse" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlMasterCourse_SelectedIndexChanged" CssClass="form-select"></asp:DropDownList>
                </div>

                <div class="mb-3">
                    <label class="form-label">Sub Courses</label>
                    <asp:CheckBoxList ID="cblSubCourses" runat="server" RepeatDirection="Horizontal" RepeatLayout="Table" CssClass="form-check">
                    </asp:CheckBoxList>
                </div>

                <div class="mb-3">
                    <label class="form-label">Price</label>
                    <asp:TextBox ID="txtPrice" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                </div>

                <div class="mb-3">
                    <label class="form-label">Validity (days)</label>
                    <asp:TextBox ID="txtValidity" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                </div>

            </div>
            <div class="modal-footer">
                <asp:Button ID="btnUpdate" runat="server" CssClass="btn btn-success" Text="Update" OnClick="btnUpdate_Click" />
                <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cancel</button>
            </div>
        </div>
    </div>
</div>




</asp:Content>
