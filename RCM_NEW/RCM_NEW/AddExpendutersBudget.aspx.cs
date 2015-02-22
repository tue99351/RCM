using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RCM_NEW
{
    public partial class WebForm7 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RetrieveFromDB rtrvDB = new RetrieveFromDB();

                DataSet ds = rtrvDB.GetInstractionalComensationExpenseTypes();
                DataSet ds2 = rtrvDB.GetNonInstractionalComensationExpenseTypes();
                DataSet ds3 = rtrvDB.GetNonComensationExpenseTypes();
                InstractionalCompensationGridView.DataSource = ds;
                InstractionalCompensationGridView.DataBind();
                NonInstractionalCompensationGridView.DataSource = ds2;
                NonInstractionalCompensationGridView.DataBind();
                NonCompensationGridView.DataSource = ds3;
                NonCompensationGridView.DataBind();
            }
        }
        protected void InstractionalCompensationButton_click(object sender, EventArgs e)
        {

           InstractionalCompensationPanel.Visible = true;
           NonInstractionalCompensationPanel.Visible = false;
           NonCompensationPanel.Visible = false;
           InstractionalCompensationLink.Attributes["class"] = "active";
           NonInstractionalCompensationLink.Attributes["class"] = "";
           NonCompensationLink.Attributes["class"] = "";
        }
        protected void NonInstractionalCompensationLinkButton_click(object sender, EventArgs e)
        {
            InstractionalCompensationPanel.Visible = false;
            NonInstractionalCompensationPanel.Visible = true;
            NonCompensationPanel.Visible = false;
            InstractionalCompensationLink.Attributes["class"] = "";
            NonInstractionalCompensationLink.Attributes["class"] = "active";
            NonCompensationLink.Attributes["class"] = "";
        }
        protected void NonCompensationLinkButton_click(object sender, EventArgs e)
        {
            InstractionalCompensationPanel.Visible = false;
            NonInstractionalCompensationPanel.Visible = false;
            NonCompensationPanel.Visible = true;
            InstractionalCompensationLink.Attributes["class"] = "";
            NonInstractionalCompensationLink.Attributes["class"] = "";
            NonCompensationLink.Attributes["class"] = "active";
        }
        protected void SubmitYearButton_Click(object sender, EventArgs e)
        {

        }    
    }
}