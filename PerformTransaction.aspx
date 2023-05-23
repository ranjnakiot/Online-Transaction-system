<%@ Page Title="" Language="C#" MasterPageFile="~/MenuHeader.master" AutoEventWireup="true" CodeBehind="PerformTransaction.aspx.cs" Inherits="Online_Banking_Transaction.PerformTransaction" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPH" runat="server">

    <table align="center">
        <tr>
            <td colspan="2" align="center">
                <h4>PerformTransaction</h4>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Payee Account Number"></asp:Label>
            </td>
          <td>
              <asp:DropDownList ID="ddlPayeeAccountNumber" runat="server" Height="28px" width="208px" AppendDataBoundItems="true">
                  <asp:ListItem Value="0">Please select Account Number</asp:ListItem>
              </asp:DropDownList>
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ForeColor="Red" 
                  ControlToValidate="ddlPayeeAccountNumber" SetFocusOnError="true" Display="Dynamic" InitialValue="0"></asp:RequiredFieldValidator>
             </td>
            </tr>
                <tr>
                  <td>
                <asp:Label ID="Label3" runat="server" Text="Payeee Name"></asp:Label>
               </td>
               <td>
               <asp:TextBox ID="txtPayeeName" runat="server" Height="28px" Width="200px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red" 
                  ControlToValidate="txtPayeeName"
                  SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                <div>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ErrorMessage="Minimum payee name lenght must be 6 characters(alphanumeric)" ControlToValidate="txtPayeeName" 
                    ForeColor="Red"  SetFocusOnError="true" ValidationExpression="^[a-zA-Z0-9\s]{6,15}$"></asp:RegularExpressionValidator>
                 </div>
            </td>
        </tr>
         <tr>
             <td>
                <asp:Label ID="Label2" runat="server" Text="Mobile Number"></asp:Label>
               </td>
               <td>
               <asp:TextBox ID="txtMobileNumber" runat="server" Height="28px" Width="200px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ForeColor="Red" 
                  ControlToValidate="txtMobileNumber"  SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                <div>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                    ErrorMessage="Mobile No. must be of 10 digits" ControlToValidate="txtMobileNumber" 
                    ForeColor="Red"  SetFocusOnError="true"  ValidationExpression="[0-9]{10}"></asp:RegularExpressionValidator>
                 </div>
            </td>
        </tr>
           <tr>
              <td >
                 <asp:Label ID="Label11" runat="server" Text="Amaunt"></asp:Label>
                </td>
                  <td>
                 <asp:TextBox ID="txtAmaunt" runat="server" Height="28px" Width="200px" TextMode="Number"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*" ForeColor="Red" 
                  ControlToValidate="txtAmaunt"
                  SetFocusOnError="true" Display="Dynamic"  ></asp:RequiredFieldValidator>
                      <div>
                  <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" 
                    ErrorMessage="Amaunt length must be between 1 to 5  digits" ControlToValidate="txtAmaunt" 
                    ForeColor="Red"  SetFocusOnError="true" ValidationExpression="\d{1,5}"></asp:RegularExpressionValidator>
                  </div>
              </td>
         </tr>
               <tr>
              <td style="width:50%">
                 <asp:Label ID="Label10" runat="server" Text="Remarks"></asp:Label>
                </td>
                  <td>
                 <asp:TextBox ID="txtRemarks" runat="server" Height="28px" Width="200px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*" ForeColor="Red" 
                  ControlToValidate="txtRemarks" SetFocusOnError="true" Display="Dynamic"  ></asp:RequiredFieldValidator>
                   </td>
               </tr>
             <tr>
                <td align="center">
                  <asp:Button ID="btnSend" runat="server" Text="Send" Height="28px" OnClick="btnSend_Click"/>
             </td>
            <td>
               <asp:Button ID="btnCancel" runat="server" Text="Cancel" Height="28px" OnClick="btnCancel_Click"  CausesValidation="false"/>
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
