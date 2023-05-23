<%@ Page Title="" Language="C#" MasterPageFile="~/MenuHeader.master" AutoEventWireup="true" CodeBehind="MyCredits.aspx.cs" Inherits="Online_Banking_Transaction.MyCredits" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPH" runat="server">
  
      <div>
        <div align="center">
            <h4> My Credits </h4>
        </div>
        <asp:GridView ID="gvMyCredits" runat="server" AutoGenerateColumns="false">
          <Columns>
                <asp:TemplateField HeaderText="To Account">
                    <ItemTemplate>
                        <asp:Label ID="accNum" runat="server" Text='<%#Eval("AccountNumber") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
               <asp:TemplateField HeaderText="Payee Name">
                    <ItemTemplate>
                        <asp:Label ID="payeeName" runat="server" Text='<%#Eval("UserName") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
               <asp:TemplateField HeaderText="Amaunt">
                    <ItemTemplate>
                        <asp:Label ID="amaunt" runat="server" Text='<%#Eval("Amaunt") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
               <asp:TemplateField HeaderText="Remarks">
                    <ItemTemplate>
                        <asp:Label ID="remarks" runat="server" Text='<%#Eval("Remarks") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <div id="error" runat="server" style="color:red"></div>
    </div>
</asp:Content>
