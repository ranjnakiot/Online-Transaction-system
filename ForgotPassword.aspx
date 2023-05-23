<%@ Page Title="" Language="C#" MasterPageFile="~/TopHeader.Master" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="Online_Banking_Transaction.ForgotPassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table align="center">
        <tr>
            <td colspan="2">
               <h4>Forgot Password</h4>
            </td>
        </tr>
         <tr>
            <td style="width:160px;">
                <asp:Label ID="Label1" runat="server" Text="User Name"></asp:Label>
            </td>
             <td>
                 <asp:Label ID="lblUsername" runat="server" ></asp:Label>   
             </td>
        </tr>
             <tr>
            <td style="width:160px;">
                <asp:Label ID="Label2" runat="server" Text="security"></asp:Label>
            </td>
             <td>
                 <asp:Label ID="lblsecurity" runat="server" ></asp:Label>   
             </td>
        </tr>
           <tr>
            <td style="width:160px;">
                <asp:Label ID="Label3" runat="server" Text="Answer"></asp:Label>
                <asp:HiddenField ID="hdnAnswer" runat="server" />
            </td>
             <td>
                 <asp:TextBox ID="txtAnswer" runat="server"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*" ForeColor="Red" 
                  ControlToValidate="txtAnswer" SetFocusOnError="true" Display="Dynamic"  ></asp:RequiredFieldValidator>
               </td>
                </tr>
                  <tr>
                     <td align="center">
                      <asp:Button ID="btnForgotPassword" runat="server" Text="Forgot  Password" Height="28px" OnClick="btnForgotPassword_Click"/>
                    </td>
                    <td>
               <asp:Button ID="btnCancel" runat="server" Text="Cancel" Height="28px" OnClick="btnCancel_Click" CausesValidation="false"/>
            </td>
        </tr>
        <tr>
             <td colspan="2">
                <div id="error" runat="server" style="color:red">
              </div>
            </td>       
        </tr>
    </table>
</asp:Content>
