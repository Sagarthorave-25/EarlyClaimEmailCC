using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmailCC
{
    public partial class Mail : System.Web.UI.Page
    {
        
        CommFun comm = new CommFun();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                BindGridview();
            }
        }

       public void BindGridview()
        {
            DataSet ds = comm.Get_All_EMAILDATA();
            if (ds.Tables[0].Rows.Count > 0)
            {
                EmailGrid.DataSource = ds;
                EmailGrid.DataBind();
                lblSuccess.Text = "";
            }
            else {
                ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                EmailGrid.DataSource = ds;
                EmailGrid.DataBind();
                EmailGrid.Rows[0].Cells.Clear();
                EmailGrid.Rows[0].Cells.Add(new TableCell());
                EmailGrid.Rows[0].Cells[0].ColumnSpan = ds.Tables[0].Columns.Count;
                EmailGrid.Rows[0].Cells[0].Text = "No Data Found";
                EmailGrid.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;

            }
            
        }
        protected void EditMail(object sender, GridViewEditEventArgs e)
        {
            EmailGrid.EditIndex = e.NewEditIndex;
            GetDataItem();
            lblError.Text = "";
            lblSuccess.Text = "";
            BindGridview();
        }
        protected void DeleteMail(object sender, GridViewDeleteEventArgs e)
        {
           int id = Convert.ToInt32(EmailGrid.DataKeys[e.RowIndex].Value);
            comm.UpdateStatusInactive(id);
            BindGridview();
        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void EmailGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("AddItem"))
                {
                    TextBox txtEmail = (TextBox)EmailGrid.FooterRow.FindControl("Email");
                    DropDownList txtStatus = (DropDownList)EmailGrid.FooterRow.FindControl("Status");
                    string email = txtEmail.Text;
                    string status = txtStatus.Text;
                    Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                    Match match = regex.Match(email);
                    if (email == null || email == string.Empty || status == null || status == string.Empty)
                    {

                        lblError.Text = "Please fill all fields";
                    }
                    else
                    {
                        if (match.Success)
                        {
                            comm.InsertDataEmailCC(email, status, "MFL00886");
                            BindGridview();
                            lblError.Text = "";
                            lblSuccess.Text = "Record inserted successfully";

                        }
                        else
                        {
                            lblSuccess.Text = "";
                            lblError.Text = ("Please enter correct email !");
                        }
                    }
                }
            }
            catch (Exception ex) {
                lblSuccess.Text = "";
                lblError.Text = "Something went wrong! Please try again later";
            }
        }
        //protected void EmailGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        if ((e.Row.RowState & DataControlRowState.Edit) > 0)
        //        {
        //            DropDownList ddList = (DropDownList)e.Row.FindControl("StatusEdit");
        //            DataRowView dr = e.Row.DataItem as DataRowView;
        //            //ddList.SelectedValue = dr["StatusEdit"].ToString();
        //        }
        //    }
        //}
        protected void EmailGrid_RowEditing(object sender, GridViewEditEventArgs e)
        {
            EmailGrid.EditIndex = e.NewEditIndex;
            BindGridview();
            lblError.Text = "";
            lblSuccess.Text = "";
        }

        protected void EmailGrid_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            EmailGrid.EditIndex = -1;
            BindGridview();
            lblError.Text = "";
            lblSuccess.Text = "";
        }

        protected void EmailGrid_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = Convert.ToInt32(EmailGrid.DataKeys[e.RowIndex].Value);
            TextBox txtemail = EmailGrid.Rows[e.RowIndex].FindControl("EmailEdit") as TextBox;
            DropDownList drpgender = EmailGrid.Rows[e.RowIndex].FindControl("StatusEdit") as DropDownList;
            string updateEmail = txtemail.Text.Trim();
            string updateStatus= drpgender.Text.Trim();
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(updateEmail);
            if (match.Success)
            {
                comm.UpdateEmail(id, updateEmail, updateStatus, "Mfl00886");
                EmailGrid.EditIndex = -1;
                BindGridview();
                lblSuccess.Text = "Record updated successfully";
                lblError.Text = "";
            }
            else {
                lblError.Text = "Please enter valid email";
                lblSuccess.Text = "";
            }
        }
        protected void EmailGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(EmailGrid.DataKeys[e.RowIndex].Value);
            comm.UpdateStatusInactive(id);
            BindGridview();
            lblSuccess.Text = "Record deactive successfully";
            lblError.Text = "";

        }
    }
}