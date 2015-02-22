using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RCM_NEW
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        if (!IsPostBack)
            {
                DataTable chg = AssessmentsRatesTbl();

                AssessmentRatesGridView.DataSource = chg;
                AssessmentRatesGridView.DataBind();
               
            }


        }

        private static DataTable AssessmentsRatesTbl()
        {
            DataTable chg = new DataTable();

            chg.Columns.Add("assessments", typeof(String));
            
            DataRow row = chg.NewRow();
            row["assessments"] = "Financial Aid";

            chg.Rows.Add(row);
            DataRow row1 = chg.NewRow();
            row1["assessments"] = "Pland Fund Fee";

            chg.Rows.Add(row1);
            
            return chg;
        }

        
        protected void SubmitButton_Click(object sender, EventArgs e)
        {

        }
    }
}