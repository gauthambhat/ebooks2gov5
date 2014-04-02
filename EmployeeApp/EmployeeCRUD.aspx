<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeCRUD.aspx.cs" Inherits="EmployeeApp.EmployeeCRUD" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table>
        <thead>Employee CRUD</thead>
        <tr>
            <td>Employee Type</td>
            <td>
                <asp:DropDownList ID="ddlEmpType" runat="server"></asp:DropDownList></td>
        </tr>
        <tr>
            <td>Employee Name</td>
            <td>
                <asp:TextBox ID="txtempname" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Employee Salary</td>
            <td>
                <asp:TextBox ID="txtsalary" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btnEmpAdd" OnClick="btnEmpAdd_Click" runat="server" Text="Button" />
            </td>
        </tr>
    </table>

        <table>
            <thead>Employee List</thead>
            <tr>
                <td>
                    <asp:GridView ID="gvEmpList" AutoGenerateColumns="false" runat="server" OnRowDeleting="gvEmpList_RowDeleting">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Label ID="lblempId" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:CommandField ButtonType="Button" HeaderText="Delete"  ShowDeleteButton="True" ShowHeader="True"  />
                            <asp:BoundField  DataField="Name"/>
                            <asp:BoundField DataField="Salary"/>                           
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
