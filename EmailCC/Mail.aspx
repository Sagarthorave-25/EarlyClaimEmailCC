<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Mail.aspx.cs" Inherits="EmailCC.Mail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>
<style>
    #heading {
        margin-top:30px;
        margin-bottom:10px;
    }
</style>
</head>
<body>
    <form id="form1" runat="server">    
            <div >
                  <div class="text-center font-weight-bold  text-dark" id="heading" ">
                <asp:Label runat="server">Add, Update,Delete Email CC for Eary Claim Email Automation</asp:Label>
            </div>
                 <div class="text-center font-weight-bold  text-dark" >
                <asp:Label ID="lblSuccess" runat="server" Text="" ForeColor="Green"/><br />

                <asp:Label ID="lblError" runat="server" Text="" ForeColor="Red"/>
             </div>
                <br />
                    <asp:GridView runat="server"  HorizontalAlign="Center"  Id="EmailGrid"  AutoGenerateColumns="False" Height="80px" BackColor="White"  BorderColor="#CCCCCC" 
                        BorderStyle="None" BorderWidth="1px" CellPadding="3" Width="680px"  DataKeyNames="Id"  OnRowCommand="EmailGrid_RowCommand" 
                        OnRowEditing="EmailGrid_RowEditing" ShowFooter="true" OnRowCancelingEdit="EmailGrid_RowCancelingEdit" OnRowDeleting="EmailGrid_RowDeleting"
                        OnRowUpdating="EmailGrid_RowUpdating" ShowHeaderWhenEmpty="true"> 
                        <Columns>
                            <asp:TemplateField HeaderText="Sr.No">
                                <ItemTemplate>
                                    <asp:Label Text='<%# Eval("Id") %>' runat="server" ID="Id" ></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <%--<asp:TextBox Text='<%# Eval("Id") %>' runat="server"></asp:TextBox>--%>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Email">
                                <ItemTemplate>
                                    <asp:Label Text='<%# Eval("Email") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox Text='<%# Eval("Email") %>'  runat="server" ID="EmailEdit"></asp:TextBox>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:textbox AutoCompleteType="Email" ID="Email" placeholder="Email" runat="server"/>
                                  </FooterTemplate>
                               </asp:TemplateField>
                            <asp:TemplateField HeaderText="Status">
                                <ItemTemplate>
                                    <asp:Label Text='<%# Eval("Status") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:DropDownList runat="server"  ID="StatusEdit"  >
                                         <asp:ListItem >Active</asp:ListItem>
                                         <asp:ListItem  >InActive</asp:ListItem>
                                     </asp:DropDownList>
                                </EditItemTemplate>
                                <FooterTemplate>
                                     <asp:DropDownList runat="server" ID="Status">
                                         <asp:ListItem Value="Active" Text="Active">Active</asp:ListItem>
                                         <asp:ListItem Value="InActive" Text="InActive">InActive</asp:ListItem>
                                     </asp:DropDownList>
                                  </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Actions" ItemStyle-CssClass="text-center" FooterStyle-CssClass="text-center">
                                <ItemTemplate >
                                    <asp:Button CommandName="Edit" runat="server" Text="Edit" CssClass="btn btn-success rounded"/>
                                    <asp:Button CommandName="Delete" runat="server" Text="DeActive" CssClass="btn btn-danger rounded"/>
                                </ItemTemplate>
                                <EditItemTemplate>
                                     <asp:Button CommandName="Update" runat="server" Text="Update" CssClass="btn btn-success rounded"/>
                                    <asp:Button CommandName="Cancel" runat="server" Text="Cancel" CssClass="btn btn-dark rounded"/>
                 
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:Button CommandName="AddItem" runat="server" Text="Add" CssClass="btn btn-info rounded"/>
                                 </FooterTemplate>

                            </asp:TemplateField>
                          
                           <%--<asp:CommandField ShowDeleteButton="true" ControlStyle-CssClass="btn btn-danger" HeaderText="DeActive Record" />
                            <asp:CommandField ShowEditButton="true"  ControlStyle-CssClass="btn btn-success" HeaderText="Edit Record" />
    --%>                        </Columns>
                                    <FooterStyle BackColor="White" ForeColor="#000066" />
                                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                    <RowStyle ForeColor="#000066" />
                                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                    </asp:GridView>
                <br />
            
           </div>
        
     
    </form>
</body>
</html>
