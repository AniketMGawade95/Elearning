<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Admin.Master" AutoEventWireup="true" CodeBehind="Materials.aspx.cs" Inherits="Elearning.Admin.Materials" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
    
    
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



   <%--  <div style="text-align:center"><h1>Add Material</h1></div>
 <div>Select Master Course
     <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"
         AutoPostBack="True"></asp:DropDownList>
 </div>
 <div>Select Sub Course
     <asp:DropDownList ID="DropDownList2" runat="server" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged"
         AutoPostBack="True"></asp:DropDownList>
 </div>
 <div>Select Topic
     <asp:DropDownList ID="DropDownList3" runat="server" ></asp:DropDownList> <!--OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged"
         AutoPostBack="True"-->
 &nbsp;
 </div>
 <div> <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="Red" Text="Upload less than 100 MB .pdf only"></asp:Label>
     <br />
     Add Assignmnet
     <asp:FileUpload ID="FileUpload1" runat="server"/> 
     <br />
</div>

 <h3>Add MCQs</h3>
 <div id="mcqContainer">
     <div class="mcq-block">
         Enter Question <input type="text" name="question" placeholder="Question" required style="width: 700px" />
         <br />
         Enter Option A <input type="text" name="optionA" placeholder="Option A" required style="width: 200px" />
         <br />
         Enter Option B <input type="text" name="optionB" placeholder="Option B" required style="width: 200px" />
         <br />
         Enter Option C <input type="text" name="optionC" placeholder="Option C" required style="width: 200px" />
         <br />
         Enter Option D <input type="text" name="optionD" placeholder="Option D" required style="width: 200px" />
         <br />
         Correct Answer<input type="text" name="answer" placeholder="Correct Answer" required style="width: 200px"/>
         <hr />
     </div>
 </div>

 <input type="button" value="Add Another MCQ" onclick="addMCQBlock()" />
 <asp:Button ID="Button1" runat="server" Text="Save" OnClick="Button1_Click"  />

 <script>
     function addMCQBlock() {
         var container = document.getElementById("mcqContainer");
         var html = `<div class='mcq-block'>
             Enter Question <input type='text' name='question' placeholder='Question' required style='width: 700px'/>
             <br />
             Enter Option A <input type='text' name='optionA' placeholder='Option A' required style='width: 200px'/>
             <br />
             Enter Option B <input type='text' name='optionB' placeholder='Option B' required style='width: 200px'/>
             <br />
             Enter Option C <input type='text' name='optionC' placeholder='Option C' required style='width: 200px'/>
             <br />
             Enter Option D <input type='text' name='optionD' placeholder='Option D' required style='width: 200px'/>
             <br />
             Correct Answer<input type='text' name='answer' placeholder='Correct Answer' required style='width: 200px'/>
             <hr />
         </div>`;
         container.insertAdjacentHTML('beforeend', html);
     }
 </script>
 <br />--%>



    <!-- Main Container -->
<div class="container mt-5 mb-5">
    <div class="card border-info shadow">
        <div class="card-header bg-info text-white text-center">
            <h4 class="mb-0 fw-bold">Add Material</h4>
        </div>
        <div class="card-body">

            <!-- Master Course Dropdown -->
            <div class="card border-info mb-3 shadow-sm">
                <div class="card-header bg-info text-white fw-semibold">
                    Select Master Course
                </div>
                <div class="card-body">
                    <asp:DropDownList ID="DropDownList1" runat="server"
                        CssClass="form-select form-select-lg border-primary"
                        OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                </div>
            </div>

            <!-- Sub Course Dropdown -->
            <div class="card border-info mb-3 shadow-sm">
                <div class="card-header bg-info text-white fw-semibold">
                    Select Sub Course
                </div>
                <div class="card-body">
                    <asp:DropDownList ID="DropDownList2" runat="server"
                        CssClass="form-select form-select-lg border-primary"
                        OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                </div>
            </div>

            <!-- Topic Dropdown -->
            <div class="card border-info mb-4 shadow-sm">
                <div class="card-header bg-info text-white fw-semibold">
                    Select Topic
                </div>
                <div class="card-body">
                    <asp:DropDownList ID="DropDownList3" runat="server"
                        CssClass="form-select form-select-lg border-primary"></asp:DropDownList>
                </div>
            </div>

            <!-- File Upload -->
            <div class="card border-info mb-4 shadow-sm">
                <div class="card-header bg-info text-white fw-semibold">
                    Upload Assignment
                </div>
                <div class="card-body">
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="Red"
                        CssClass="d-block mb-2" Text="Upload less than 100 MB .pdf only"></asp:Label>
                    <asp:FileUpload ID="FileUpload1" runat="server" CssClass="form-control form-control-lg border-primary" />
                </div>
            </div>

            <!-- MCQ Section -->
            <div class="mb-4">
                <h5 class="text-info fw-bold">Add MCQs</h5>
                <div id="mcqContainer">
                    <div class="mcq-block border border-info rounded p-4 mb-4 shadow-sm bg-light">
                        <label class="form-label">Enter Question</label>
                        <input type="text" name="question" class="form-control mb-2" placeholder="Question" required />

                        <label class="form-label">Enter Option A</label>
                        <input type="text" name="optionA" class="form-control mb-2" placeholder="Option A" required />

                        <label class="form-label">Enter Option B</label>
                        <input type="text" name="optionB" class="form-control mb-2" placeholder="Option B" required />

                        <label class="form-label">Enter Option C</label>
                        <input type="text" name="optionC" class="form-control mb-2" placeholder="Option C" required />

                        <label class="form-label">Enter Option D</label>
                        <input type="text" name="optionD" class="form-control mb-2" placeholder="Option D" required />

                        <label class="form-label">Correct Answer</label>
                        <input type="text" name="answer" class="form-control mb-2" placeholder="Correct Answer" required />
                    </div>
                </div>

                <input type="button" value="Add Another MCQ" onclick="addMCQBlock()" class="btn btn-outline-info mb-3" />
            </div>

            <!-- Save Button -->
            <div class="text-center mt-4">
                <asp:Button ID="Button1" runat="server" Text="Save" OnClick="Button1_Click"
                    CssClass="btn btn-lg btn-primary px-5" />
            </div>
        </div>
    </div>
</div>

<!-- JS to Add MCQ Block -->
<script>
    function addMCQBlock() {
        var container = document.getElementById("mcqContainer");
        var html = `
        <div class='mcq-block border border-info rounded p-4 mb-4 shadow-sm bg-light'>
            <label class='form-label'>Enter Question</label>
            <input type='text' name='question' class='form-control mb-2' placeholder='Question' required />
            <label class='form-label'>Enter Option A</label>
            <input type='text' name='optionA' class='form-control mb-2' placeholder='Option A' required />
            <label class='form-label'>Enter Option B</label>
            <input type='text' name='optionB' class='form-control mb-2' placeholder='Option B' required />
            <label class='form-label'>Enter Option C</label>
            <input type='text' name='optionC' class='form-control mb-2' placeholder='Option C' required />
            <label class='form-label'>Enter Option D</label>
            <input type='text' name='optionD' class='form-control mb-2' placeholder='Option D' required />
            <label class='form-label'>Correct Answer</label>
            <input type='text' name='answer' class='form-control mb-2' placeholder='Correct Answer' required />
        </div>`;
        container.insertAdjacentHTML('beforeend', html);
    }
</script>


</asp:Content>
