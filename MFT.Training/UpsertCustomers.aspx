<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpsertCustomers.aspx.cs" Inherits="MFT.Training.Customers" MasterPageFile="~/template.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    
    <div class="card m-4 w-50 mx-auto">
        <div class="card-header fw-bold">
            <asp:Label ID="lbl_title" runat="server" Text=""></asp:Label>
        </div>
        <div class="card-body">
            <div class="row">
                <div class="col-md-3">
                    <label class="mb-1">نام</label>
                    <asp:TextBox ID="txt_firstname" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" CssClass="mt-1" runat="server" ErrorMessage="نام اجباری می باشد" Display="Dynamic" ControlToValidate="txt_firstname" ForeColor="Maroon"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-9">
                    <label class="mb-1">نام خانوادگی</label>
                    <asp:TextBox ID="txt_lastname" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" CssClass="mt-1" runat="server" ErrorMessage="نام خانوادگی اجباری می باشد" Display="Dynamic" ControlToValidate="txt_lastname" ForeColor="Maroon"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row mt-3">
                <div class="col-md-6">
                    <label class="mb-1">کد ملی</label>
                    <asp:TextBox ID="txt_codeMelli" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic" ErrorMessage="کد ملی اجباری است" ForeColor="Maroon" ControlToValidate="txt_codeMelli"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" Display="Dynamic" runat="server" ForeColor="Maroon" ControlToValidate="txt_codeMelli" ErrorMessage="کد ملی نامعتبر است" ValidationExpression="^\d{10}$"></asp:RegularExpressionValidator>
                </div>
                <div class="col-md-6">
                    <label class="mb-1">شماره همراه</label>
                    <asp:TextBox ID="txt_mobile" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row mt-3">
                <div class="col-md-6">
                    <label class="mb-1">استان محل سکونت</label>
                    <asp:DropDownList ID="drp_ostans" CssClass="form-select" runat="server" AutoPostBack="True" DataTextField="Name" DataValueField="Id" OnSelectedIndexChanged="drp_ostans_SelectedIndexChanged">
                       
                    </asp:DropDownList>
                </div>
                <div class="col-md-6">
                    <label class="mb-1">شهر محل سکونت</label>
                    <asp:DropDownList ID="drp_shahrs" CssClass="form-select" runat="server" DataTextField="Name" DataValueField="Id">
                       
                    </asp:DropDownList>
                </div>
            </div>
            <div class="row mt-3" runat="server" id="div_password">
                <div class="col-md-6">
                    <label class="mb-1">کلمه ی عبور</label>
                    <asp:TextBox ID="txt_password" TextMode="Password" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" Display="Dynamic" ForeColor="Maroon" ControlToValidate="txt_password" runat="server" ErrorMessage="کلمه ی عبور بایستی حداقل 8 کاراکتر باشد" ValidationExpression="[A-Za-z\d]{8,}$"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Display="Dynamic" ForeColor="Maroon" ControlToValidate="txt_password" ErrorMessage="کلمه ی عبور الزامی می باشد"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-6">
                    <label class="mb-1">تکرار کلمه ی عبور</label>
                    <asp:TextBox ID="TextBox6" TextMode="Password" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" Display="Dynamic" ForeColor="Maroon" ControlToValidate="TextBox6" ErrorMessage="تکرار کلمه ی عبور الزامی می باشد"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txt_password" Display="Dynamic" ForeColor="Maroon" ErrorMessage="کلمه ی عبور تکراری مطابقت ندارد" ControlToValidate="TextBox6"></asp:CompareValidator>
                </div>
            </div>
            <div class="alert alert-success mt-3" runat="server" id="lbl_success">
                مشتری با موفقیت ایجاد شد
            </div>
            <div class="buttons mt-3">
                <asp:Button ID="Button1" runat="server" Text="افزودن"
                    CssClass="btn btn-primary" OnClick="Button1_Click" />
                <a href="Default.aspx" class="btn btn-danger">بازگشت</a>
            </div>
        </div>
    </div>
</asp:Content>
