using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RCM_NEW
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable years = new DataTable();

                years.Columns.Add("Text", typeof(String));
                years.Columns.Add("Value", typeof(String));
                
                DataRow row = years.NewRow();
                row["Text"] = "Select";
                row["Value"] = "Select";
                years.Rows.Add(row);
                
                for (int i = 0; i <= 20; i++)
                {
                    int year = 2010;

                    DataRow row2 = years.NewRow();

                    row2["Text"] = (year + i).ToString();
                    row2["Value"] = (year + i).ToString();

                    years.Rows.Add(row2);
                }
                
                
                YearDropDownList.DataSource = years;
                YearDropDownList.DataTextField = "Text";
                YearDropDownList.DataValueField = "Value";
                YearDropDownList.DataBind();
            
            }

        }
        protected void SubmitYearButton_Click(object sender, EventArgs e)
        {
           
        }
    }
}