using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RCM_NEW
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void GenerateReportLinkButton_Click(object sender, EventArgs e)
        {
            Server.Transfer("GenerateReport.aspx", true);
        }

        protected void CompareReportsLinkButton_Click(object sender, EventArgs e)
        {
            //Server.Transfer("CompareReports.aspx", true);

        }
        protected void ModelDataLinkButton_Click(object sender, EventArgs e)
        {
            //Server.Transfer("ModelData.aspx", true);

        }
    
    
    }
}