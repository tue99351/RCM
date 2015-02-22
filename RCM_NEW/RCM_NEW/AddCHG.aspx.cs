using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace RCM_NEW
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                DataTable chg = GrossExportedCHGTbl();
                DataTable chg2 = DifferentialRevenueTbl();
                
                GrossCHGGridView.DataSource = chg;
                GrossCHGGridView.DataBind();
                ExportedCHGGridView.DataSource = chg;
                ExportedCHGGridView.DataBind();
                DifferentialRevenueGridView.DataSource = chg2;
                DifferentialRevenueGridView.DataBind();
            }


        }

        private static DataTable GrossExportedCHGTbl()
        {
            DataTable chg = new DataTable();

            chg.Columns.Add("Term", typeof(String));
            
            DataRow row = chg.NewRow();
            row["Term"] = "SS2 2013";

            chg.Rows.Add(row);
            DataRow row1 = chg.NewRow();
            row1["Term"] = "Fall 2013";

            chg.Rows.Add(row1);
            DataRow row2 = chg.NewRow();
            row2["Term"] = "Spring 2014";

            chg.Rows.Add(row2);
            DataRow row3 = chg.NewRow();
            row3["Term"] = "SS1 2014";

            chg.Rows.Add(row3);
            return chg;
        }

        private static DataTable DifferentialRevenueTbl()
        {
            DataTable chg = new DataTable();

            chg.Columns.Add("differentialRevenue", typeof(String));
            
            DataRow row = chg.NewRow();
            row["differentialRevenue"] = "Differential Revenue ";

            chg.Rows.Add(row);
            
            return chg;
        }
        protected void GrossCHGLinkButton_click(object sender, EventArgs e)
        {
            
            GrossCHGPanel.Visible = true;
            ExportedCHGPanel.Visible = false;
            DifferentialRevenuePanel.Visible = false;
            GrossCHGLink.Attributes["class"] = "active";
            ExportedCHGLink.Attributes["class"] = "";
            DifferentialRevenueLink.Attributes["class"] = "";
        }
        protected void ExportedCHGLinkButton_click(object sender, EventArgs e)
        {

            GrossCHGPanel.Visible = false;
            ExportedCHGPanel.Visible = true;
            DifferentialRevenuePanel.Visible = false;
            GrossCHGLink.Attributes["class"] = "";
            ExportedCHGLink.Attributes["class"] = "active";
            DifferentialRevenueLink.Attributes["class"] = "";
        }
        protected void DifferentialRevenueLinkButton_click(object sender, EventArgs e)
        {
            GrossCHGPanel.Visible = false;
            ExportedCHGPanel.Visible = false;
            DifferentialRevenuePanel.Visible = true;
            GrossCHGLink.Attributes["class"] = "";
            ExportedCHGLink.Attributes["class"] = "";
            DifferentialRevenueLink.Attributes["class"] = "active";
        }
        protected void SubmitYearButton_Click(object sender, EventArgs e)
        {

        }
    
    }
}