<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/User.Master" AutoEventWireup="true" CodeBehind="LearningPage.aspx.cs" Inherits="Elearning.User.LearningPage" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--<style>
        .topic-list {
            width: 20%;
            float: right;
        }
        .content-pane {
            width: 75%;
            float: left;
        }
        iframe {
            width: 100%;
            height: 400px;
        }
    </style>--%>

    <style>
        .card-body::-webkit-scrollbar {
            width: 6px;
        }
        .card-body::-webkit-scrollbar-thumb {
            background-color: #007bff;
            border-radius: 3px;
        }
    </style>


</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%--<asp:HiddenField ID="hfSubCourseID" runat="server" />

        <div class="content-pane">
            <asp:Literal ID="ltVideo" runat="server"></asp:Literal>
            <br /><br />
            <asp:Button ID="btnDownloadAssignment" runat="server" Text="Download Assignment" OnClick="btnDownloadAssignment_Click" />
            <asp:Button ID="btnMCQTest" runat="server" Text="Take MCQ Test" OnClick="btnMCQTest_Click" />
            <asp:Button ID="btnDownloadCertificate" runat="server" Text="Download Certificate" OnClick="btnDownloadCertificate_Click" Visible="false" />
        </div>

        <div class="topic-list">
            <asp:Repeater ID="rptTopics" runat="server" OnItemCommand="rptTopics_ItemCommand">
                <ItemTemplate>
                    <asp:LinkButton ID="lnkTopic" runat="server" Text='<%# Eval("TopicName") %>' CommandArgument='<%# Eval("TopicID") %>' CommandName="Select" />
                    <br />
                </ItemTemplate>
            </asp:Repeater>
        </div>--%>
        


    
    <asp:HiddenField ID="hfSubCourseID" runat="server" />

    <div class="container mt-4">
        <div class="row">
            <!-- Left: Main Video -->
            <div class="col-md-8">
                <div class="ratio ratio-16x9 border border-primary rounded shadow-sm mb-3">
                    <asp:Literal ID="ltVideo" runat="server"></asp:Literal>
                </div>

                <!-- Action Buttons -->
                <div class="d-flex gap-2">
                    <asp:Button ID="btnDownloadAssignment" runat="server" Text="Download Assignment" CssClass="btn btn-outline-primary" OnClick="btnDownloadAssignment_Click" />
                    <asp:Button ID="btnMCQTest" runat="server" Text="Take MCQ Test" CssClass="btn btn-outline-info" OnClick="btnMCQTest_Click" />
                    <asp:Button ID="btnDownloadCertificate" runat="server" Text="Download Certificate" CssClass="btn btn-outline-success" OnClick="btnDownloadCertificate_Click" Visible="false" />
                </div>
            </div>

            <!-- Right: Playlist -->
            <div class="col-md-4">
                <div class="card shadow-sm border-primary">
                    <div class="card-header bg-primary text-white fw-bold">
                        Playlist
                    </div>
                    <div class="card-body" style="max-height: 400px; overflow-y: auto;">
                        <asp:Repeater ID="rptTopics" runat="server" OnItemCommand="rptTopics_ItemCommand">
                            <ItemTemplate>
                                <asp:LinkButton 
                                    ID="lnkTopic" 
                                    runat="server" 
                                    CssClass="list-group-item list-group-item-action" 
                                    Text='<%# Eval("TopicName") %>' 
                                    CommandArgument='<%# Eval("TopicID") %>' 
                                    CommandName="Select">
                                </asp:LinkButton>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </div>
        </div>
    </div>





    <hr />
<div class="mt-4">
    <h5>Leave a Review</h5>
    <asp:Label ID="lblRatingMessage" runat="server" CssClass="text-success"></asp:Label>

    <div class="mb-2">
        <label for="ddlRating">Rating (1-5):</label>
        <asp:DropDownList ID="ddlRating" runat="server" CssClass="form-select w-auto">
            <asp:ListItem Text="Select Rating" Value="" />
            <asp:ListItem Text="1" Value="1" />
            <asp:ListItem Text="2" Value="2" />
            <asp:ListItem Text="3" Value="3" />
            <asp:ListItem Text="4" Value="4" />
            <asp:ListItem Text="5" Value="5" />
        </asp:DropDownList>
    </div>

    <div class="mb-2">
        <label for="txtReview">Review:</label>
        <asp:TextBox ID="txtReview" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3" />
    </div>

    <asp:Button ID="btnSubmitRating" runat="server" Text="Submit Review" CssClass="btn btn-primary" OnClick="btnSubmitRating_Click" />
</div>







    <asp:Button ID="btnShowMCQs" runat="server" Text="Show MCQs" CssClass="btn btn-outline-warning" OnClick="btnShowMCQs_Click" />

<asp:Panel ID="pnlMCQs" runat="server" Visible="false" CssClass="mt-4">

    <asp:Repeater ID="rptMCQs" runat="server">
        <ItemTemplate>
            <div class="mb-3 border p-3 rounded">
                <strong>Q<%# Container.ItemIndex + 1 %>: <%# Eval("Question") %></strong>

                <div class="form-check">
                    <asp:CheckBox ID="chkOptionA" runat="server" Text='<%# Eval("OptionA") %>' GroupName='<%# "q" + Container.ItemIndex %>' />
                </div>
                <div class="form-check">
                    <asp:CheckBox ID="chkOptionB" runat="server" Text='<%# Eval("OptionB") %>' GroupName='<%# "q" + Container.ItemIndex %>' />
                </div>
                <div class="form-check">
                    <asp:CheckBox ID="chkOptionC" runat="server" Text='<%# Eval("OptionC") %>' GroupName='<%# "q" + Container.ItemIndex %>' />
                </div>
                <div class="form-check">
                    <asp:CheckBox ID="chkOptionD" runat="server" Text='<%# Eval("OptionD") %>' GroupName='<%# "q" + Container.ItemIndex %>' />
                </div>



                




            </div>
        </ItemTemplate>
    </asp:Repeater>

    <asp:Button ID="btnSubmitMCQAnswers" runat="server" Text="Submit Answers" CssClass="btn btn-success mt-3" OnClick="btnSubmitMCQAnswers_Click" />

    <asp:Panel ID="pnlMCQResult" runat="server" CssClass="mt-3">
    <asp:Literal ID="ltMCQResult" runat="server"></asp:Literal>
</asp:Panel>


</asp:Panel>


</asp:Content>
