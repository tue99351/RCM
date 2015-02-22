using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RCM_NEW
{
    public partial class WebForm8 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable chg = DTable();
            //DataTable chg2 = DifferentialRevenueTbl();
            AcademicSupportGridView.DataSource = chg;
            AcademicSupportGridView.DataBind();
           AdvancementGridView.DataSource = chg;
           AdvancementGridView.DataBind();
        
        }

        private static DataTable DTable()
        {
            DataTable chg = new DataTable();

            chg.Columns.Add("metricType", typeof(String));

            DataRow row = chg.NewRow();
            row["metricType"] = "CHGs G";

            chg.Rows.Add(row);
            DataRow row1 = chg.NewRow();
            row1["metricType"] = "CHGs UG";

            chg.Rows.Add(row1);
            return chg;
        }
        
        protected void SubmitYearButton_Click(object sender, EventArgs e)
        {

        }
    
    }
}