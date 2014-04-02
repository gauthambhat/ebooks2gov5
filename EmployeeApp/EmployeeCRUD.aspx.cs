using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeeApp
{
    public partial class EmployeeCRUD : System.Web.UI.Page
    {
        List<Employee> EmpLst = new List<Employee>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindDDL();
                if(Session["SEmplst"]!=null)
                BindEmplist();
            }
        }


        /* Click Event for Adding Employee to List*/
        protected void btnEmpAdd_Click(object sender, EventArgs e)
        {
            if (Session["SEmplst"] == null)
            {
                
                Session["SEmplst"] = AddtoEmplist(EmpLst);
            }
            else
            {
                Session["SEmplst"] = AddtoEmplist((List<Employee>)Session["SEmplst"]);
            }
            BindEmplist();
        }
        /* End*/


        /* Adding the Employee to List*/
        private List<Employee> AddtoEmplist(List<Employee> _Emplst)
        {
            Employee EmpObj;
            if (ddlEmpType.SelectedItem.Text.ToUpper() == "BOSS")
            {
                EmpObj = new Boss();
                EmpObj.Name = txtempname.Text;
                EmpObj.basicsalary = Convert.ToDouble(txtsalary.Text);
               
            }
            else if (ddlEmpType.SelectedItem.Text.ToUpper() == "MANAGER")
            {
                EmpObj = new Manager();
                EmpObj.Name = txtempname.Text;
                EmpObj.basicsalary = Convert.ToDouble(txtsalary.Text);
            }
            else
            {
                EmpObj = new storekeeper();
                EmpObj.Name = txtempname.Text;
                EmpObj.basicsalary = Convert.ToDouble(txtsalary.Text);
            }

            _Emplst.Add(EmpObj);
            return _Emplst;
        }
        /* End*/


        #region Bind Employee Type DropdownList
        protected void BindDDL()
        {
            List<Type> derivedTypes = VType.GetDerivedTypes(typeof(Employee),
              Assembly.GetExecutingAssembly());
            foreach (Type t in derivedTypes)
            {
                ddlEmpType.Items.Add(t.Name);
            }

        }

        #endregion

        #region Bind Employee List
        private void BindEmplist()
        {
            gvEmpList.DataSource = (Session["SEmplst"] != null) ? (List<Employee>)Session["SEmplst"] : (List<Employee>)null;
            gvEmpList.DataBind();
        }
        #endregion

       

        protected void gvEmpList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            EmpLst=(List<Employee>)Session["SEmplst"];
            Label lblIndx = (Label)gvEmpList.Rows[e.RowIndex].FindControl("lblempId");
            EmpLst.RemoveAt(Convert.ToInt16(lblIndx.Text)-1);
            Session["SEmplst"] = EmpLst;
            gvEmpList.EditIndex = -1;
            BindEmplist();

        }

       
    }
}