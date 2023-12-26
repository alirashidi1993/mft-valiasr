<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="ManageCustomers.aspx.cs" MasterPageFile="~/template.Master" Inherits="MFT.Training.ManageCustomers" %>

<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div class="customers-grid m-4 py-2 px-3">
        <div class="grid-title-text">
            مدیریت مشتری ها
        </div>
        <div class="row search-box">
            <div class="col-md-10 mb-2">
                <asp:TextBox runat="server" placeholder="جستجو" ID="txt_search" CssClass="form-control" OnTextChanged="txt_search_TextChanged"></asp:TextBox>
            </div>
            <div class="col-md-2">
                <a href="UpsertCustomers.aspx" class="btn btn-primary w-100">ایجاد مشتری جدید</a>
            </div>
        </div>
        <div class="grid-content">
            <asp:GridView ID="grid_customers" runat="server" AutoGenerateColumns="False" CssClass="w-100 table table-bordered jadval-khatkhati" EmptyDataText="مشتری ای یافت نشد" DataKeyNames="Id" OnRowDeleting="grid_customers_RowDeleting" OnRowEditing="grid_customers_RowEditing" OnRowUpdating="grid_customers_RowUpdating" OnRowCancelingEdit="grid_customers_RowCancelingEdit" AllowPaging="True" PageSize="3" OnPageIndexChanging="grid_customers_PageIndexChanging">
                <Columns>
                    <asp:BoundField DataField="Id" Visible="False" />
                    <asp:BoundField DataField="FirstName" HeaderText="نام" />
                    <asp:BoundField DataField="LastName" HeaderText="نام خانوادگی" />
                    <asp:BoundField DataField="CodeMelli" HeaderText="کد ملی" />
                    <asp:BoundField DataField="Mobile" HeaderText="شماره همراه" />
                    <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Media/Images/delete.png" DeleteText="" HeaderText="حذف" ShowDeleteButton="True">
                        <ControlStyle Height="48px" Width="48px" />
                    </asp:CommandField>
                    <asp:CommandField ButtonType="Image" CancelText="" EditImageUrl="~/Media/Images/edit.png" EditText="" HeaderText="ویرایش" ShowEditButton="True" UpdateText="" CancelImageUrl="~/Media/Images/cancel.png" UpdateImageUrl="~/Media/Images/save.png">
                        <ControlStyle Height="48px" Width="48px" CssClass="ms-1" />
                    </asp:CommandField>
                    <asp:HyperLinkField DataNavigateUrlFields="Id" DataNavigateUrlFormatString="UpsertCustomers.aspx?customerId={0}" HeaderText="ویرایش جدا" Text="اصلاح" />
                </Columns>
                <EmptyDataTemplate>
                    <div class="alert alert-warning">
                        <b>هیچ مشتری ای پیدا نشد</b>
                    </div>
                </EmptyDataTemplate>
               
            </asp:GridView>
        </div>
    </div>
</asp:Content>
