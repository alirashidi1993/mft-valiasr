<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ContactUs.aspx.cs" Inherits="MFT.Training.ContactUs" MasterPageFile="~/template.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:FileUpload runat="server" ID="upl_avatar"  AllowMultiple="True" accept=".mp3" />
    <asp:Button Text="آپلود عکس" runat="server" ID="btn_upload" CssClass="btn btn-primary" OnClick="btn_upload_Click" />
</asp:Content>