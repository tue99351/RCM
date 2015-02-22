using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Utilities;

namespace RCM_NEW
{
    public class RetrieveFromDB
    {

        DBConnect objDB = new DBConnect();
        public DataTable DisplayRevenueExpenseSummaryReport(String fiscalYear)
        {
            SqlCommand objcomm = new SqlCommand();

            objcomm.CommandType = CommandType.StoredProcedure;
            objcomm.CommandText = "GenerateRevenueExpenseSummary";

            objcomm.Parameters.Add("fiscalYear", fiscalYear);

            DataSet ds = objDB.GetDataSetUsingCmdObj(objcomm);

            TransposeTable tt = new TransposeTable();
            DataTable st = tt.GenerateTransposedTable(ds.Tables[0]);

            DataTable stCloned = st.Clone();
            stCloned.Columns[1].DataType = typeof(Double);
            foreach (DataRow row in st.Rows)
            {
                stCloned.ImportRow(row);
            }

            stCloned.Columns.Add("RevenueExpense", typeof(String));

            stCloned.Rows[0]["RevenueExpense"] = "Gross Revenue";
            stCloned.Rows[1]["RevenueExpense"] = "Net Revenue";
            stCloned.Rows[2]["RevenueExpense"] = "Assestments";
            stCloned.Rows[3]["RevenueExpense"] = "Allocated Costs";
            stCloned.Rows[4]["RevenueExpense"] = "Direct Expenditures";
            stCloned.Rows[5]["RevenueExpense"] = "Net Surplus/Deficit";

            stCloned.Columns[1].ColumnName = "Amount";

            return stCloned;
        }

        public DataTable DisplayTuitionRevenueBreakDown(String fiscalYear)
        {

            SqlCommand objcomm = new SqlCommand();

            objcomm.CommandType = CommandType.StoredProcedure;
            objcomm.CommandText = "GenerateTuitionRevenueBreakdown";

            objcomm.Parameters.Add("@fiscalYear", fiscalYear);

            DataSet ds = objDB.GetDataSetUsingCmdObj(objcomm);

            DataTable tbl = new DataTable();

            tbl.Columns.Add("TuitionRevenue", typeof(String));
            tbl.Columns.Add("Amount", typeof(Double));

            DataRow dr = tbl.NewRow();

            dr["TuitionRevenue"] = "Undergraduate Gross Revenue";
            dr["Amount"] = Double.Parse(ds.Tables[0].Rows[0][0].ToString());
            tbl.Rows.Add(dr);

            DataRow dr1 = tbl.NewRow();

            dr1["TuitionRevenue"] = "Graduate Gross Revenue";
            dr1["Amount"] = Double.Parse(ds.Tables[0].Rows[1][0].ToString());
            tbl.Rows.Add(dr1);

            DataRow dr2 = tbl.NewRow();

            dr2["TuitionRevenue"] = "Total Gross Revenue";
            dr2["Amount"] = Double.Parse(ds.Tables[0].Rows[1][0].ToString()) + Double.Parse(ds.Tables[0].Rows[0][0].ToString());
            tbl.Rows.Add(dr2);

            DataRow dr3 = tbl.NewRow();

            dr3["TuitionRevenue"] = "Undergraduate Exported Revenue";
            dr3["Amount"] = Double.Parse(ds.Tables[0].Rows[2][0].ToString()) * -1;
            tbl.Rows.Add(dr3);

            DataRow dr4 = tbl.NewRow();

            dr4["TuitionRevenue"] = "Graduate Exported Revenue";
            dr4["Amount"] = Double.Parse(ds.Tables[0].Rows[3][0].ToString()) * -1;
            tbl.Rows.Add(dr4);

            DataRow dr5 = tbl.NewRow();

            dr5["TuitionRevenue"] = "Total Exported Revenue";
            dr5["Amount"] = (Double.Parse(ds.Tables[0].Rows[2][0].ToString()) + Double.Parse(ds.Tables[0].Rows[3][0].ToString())) * -1;
            tbl.Rows.Add(dr5);

            DataRow dr6 = tbl.NewRow();

            dr6["TuitionRevenue"] = "Undergraduate Net Revenue";
            dr6["Amount"] = Double.Parse(ds.Tables[0].Rows[0][0].ToString()) - Double.Parse(ds.Tables[0].Rows[2][0].ToString());
            tbl.Rows.Add(dr6);

            DataRow dr7 = tbl.NewRow();

            dr7["TuitionRevenue"] = "Graduate Net Revenue";
            dr7["Amount"] = Double.Parse(ds.Tables[0].Rows[1][0].ToString()) - Double.Parse(ds.Tables[0].Rows[3][0].ToString());
            tbl.Rows.Add(dr7);

            DataRow dr8 = tbl.NewRow();

            dr8["TuitionRevenue"] = "Total Net Revenue";
            dr8["Amount"] = (Double.Parse(ds.Tables[0].Rows[0][0].ToString()) - Double.Parse(ds.Tables[0].Rows[2][0].ToString())) + (Double.Parse(ds.Tables[0].Rows[1][0].ToString()) - Double.Parse(ds.Tables[0].Rows[3][0].ToString()));
            tbl.Rows.Add(dr8);

            return tbl;

        }

        public DataSet DisplayTuitionDifferentialRevenue(String fiscalYear)
        {
            SqlCommand objcomm = new SqlCommand();

            objcomm.CommandType = CommandType.StoredProcedure;
            objcomm.CommandText = "GenerateDifferentialRevenue";

            objcomm.Parameters.Add("@fiscalYear", fiscalYear);

            DataSet ds = objDB.GetDataSetUsingCmdObj(objcomm);


            ds.Tables[0].Columns.Add("tuitionDifferentialRevenue", typeof(String));

            ds.Tables[0].Rows[0]["TuitionDifferentialRevenue"] = "Undergraduate Students";
            ds.Tables[0].Rows[1]["TuitionDifferentialRevenue"] = "Graduate Students";

            return ds;

        }

        public DataSet DisplayTuitionRevenueByCategory(String fiscalYear, String category)
        {
            DataSet ds = new DataSet();
            String storeProcedure = "";

            if (category == "Gross/Undergraduate")
            {
                storeProcedure = "GenerateGrossTuitionRevenueUndergrad";
            }
            else if (category == "Gross/Graduate")
            {
                storeProcedure = "GenerateGrossTuitionRevenueGrad";
            }
            else if (category == "Exported/Undergraduate")
            {
                storeProcedure = "GenerateExportedTuitionRevenueUndergrad";
            }
            else if (category == "Exported/Graduate")
            {
                storeProcedure = "GenerateExportedTuitionRevenueGrad";
            }

            SqlCommand objcomm = new SqlCommand();

            objcomm.CommandType = CommandType.StoredProcedure;
            objcomm.CommandText = storeProcedure;

            objcomm.Parameters.Add("fiscalYear", fiscalYear);

            ds = objDB.GetDataSetUsingCmdObj(objcomm);


            return ds;
        }

        public DataTable DisplayAssessments(String fiscalYear)
        {
            SqlCommand objcomm = new SqlCommand();

            objcomm.CommandType = CommandType.StoredProcedure;
            objcomm.CommandText = "GenerateAssessments";

            objcomm.Parameters.Add("@fiscalYear", fiscalYear);

            DataSet ds = objDB.GetDataSetUsingCmdObj(objcomm);


            DataTable dt = new DataTable();

            dt.Columns.Add("Assessments", typeof(String));
            dt.Columns.Add("UndergraduatePercentage", typeof(double));
            dt.Columns.Add("UndergraduateDollars", typeof(double));
            dt.Columns.Add("GraduatePercentage", typeof(double));
            dt.Columns.Add("GraduateDollars", typeof(double));


            DataRow newRow = dt.NewRow();

            newRow["Assessments"] = ds.Tables[0].Rows[0][0];
            newRow["UndergraduatePercentage"] = ds.Tables[0].Rows[0][2];
            newRow["UndergraduateDollars"] = ds.Tables[0].Rows[0][3];
            newRow["GraduatePercentage"] = ds.Tables[0].Rows[2][2];
            newRow["GraduateDollars"] = ds.Tables[0].Rows[2][3];

            dt.Rows.Add(newRow);

            DataRow newRow1 = dt.NewRow();
            newRow1["Assessments"] = ds.Tables[0].Rows[1][0];
            newRow1["UndergraduatePercentage"] = ds.Tables[0].Rows[1][2];
            newRow1["UndergraduateDollars"] = ds.Tables[0].Rows[1][3];
            newRow1["GraduatePercentage"] = ds.Tables[0].Rows[3][2];
            newRow1["GraduateDollars"] = ds.Tables[0].Rows[3][3];

            dt.Rows.Add(newRow1);

            DataRow newRow2 = dt.NewRow();
            newRow2["Assessments"] = "Subtotal Assessments";
            newRow2["UndergraduatePercentage"] = double.Parse(ds.Tables[0].Rows[0][2].ToString()) + double.Parse(ds.Tables[0].Rows[1][2].ToString());
            newRow2["UndergraduateDollars"] = double.Parse(ds.Tables[0].Rows[0][3].ToString()) + double.Parse(ds.Tables[0].Rows[1][3].ToString());
            newRow2["GraduatePercentage"] = double.Parse(ds.Tables[0].Rows[2][2].ToString()) + double.Parse(ds.Tables[0].Rows[3][2].ToString());
            newRow2["GraduateDollars"] = double.Parse(ds.Tables[0].Rows[2][3].ToString()) + double.Parse(ds.Tables[0].Rows[3][3].ToString());

            dt.Rows.Add(newRow2);

            return dt;

        }

        public DataTable DisplayDirectExpenses(String fiscalYear)
        {
            SqlCommand objcomm = new SqlCommand();

            objcomm.CommandType = CommandType.StoredProcedure;
            objcomm.CommandText = "GenerateDirectExpenses";

            objcomm.Parameters.Add("@fiscalYear", fiscalYear);

            DataSet ds = objDB.GetDataSetUsingCmdObj(objcomm);

            DataTable tbl = new DataTable();

            tbl.Columns.Add("ExpenseType", typeof(String));
            tbl.Columns.Add("Amount", typeof(Double));

            DataRow dr = tbl.NewRow();

            dr["ExpenseType"] = "Sub-total Instructional Compensation";
            dr["Amount"] = Double.Parse(ds.Tables[0].Rows[0][0].ToString());
            tbl.Rows.Add(dr);

            DataRow dr1 = tbl.NewRow();

            dr1["ExpenseType"] = "Sub-total Non-Instructional Compensation";
            dr1["Amount"] = Double.Parse(ds.Tables[0].Rows[1][0].ToString());
            tbl.Rows.Add(dr1);

            DataRow dr2 = tbl.NewRow();

            dr2["ExpenseType"] = "Total Compensation";
            dr2["Amount"] = Double.Parse(ds.Tables[0].Rows[1][0].ToString()) + Double.Parse(ds.Tables[0].Rows[0][0].ToString());
            tbl.Rows.Add(dr2);

            DataRow dr3 = tbl.NewRow();

            dr3["ExpenseType"] = "Fringe Benefits";
            dr3["Amount"] = Double.Parse(ds.Tables[0].Rows[2][0].ToString()) + Double.Parse(ds.Tables[0].Rows[3][0].ToString());
            tbl.Rows.Add(dr3);

            DataRow dr4 = tbl.NewRow();

            dr4["ExpenseType"] = "Total Compensation + Benefits";
            dr4["Amount"] = Double.Parse(ds.Tables[0].Rows[1][0].ToString()) + Double.Parse(ds.Tables[0].Rows[0][0].ToString()) + Double.Parse(ds.Tables[0].Rows[2][0].ToString()) + Double.Parse(ds.Tables[0].Rows[3][0].ToString());
            tbl.Rows.Add(dr4);

            DataRow dr5 = tbl.NewRow();

            dr5["ExpenseType"] = "Total Non-Compensation";
            dr5["Amount"] = Double.Parse(ds.Tables[0].Rows[4][0].ToString());
            tbl.Rows.Add(dr5);

            return tbl;
        }

        public DataSet DisplayCompensation(String fiscalYear, String compensationType)
        {
            String storedProcedure = "";

            if (compensationType == "Instractional")
            {
                storedProcedure = "GenerateInstractionalCompensation";
            }
            else if (compensationType == "NonInstractional")
            {
                storedProcedure = "GenerateNonInstractionalCompensation";
            }
            SqlCommand objcomm = new SqlCommand();

            objcomm.CommandType = CommandType.StoredProcedure;
            objcomm.CommandText = storedProcedure;

            objcomm.Parameters.Add("@fiscalYear", fiscalYear);

            DataSet ds = objDB.GetDataSetUsingCmdObj(objcomm);

            return ds;
        }

        public DataSet DisplayNonCompensationExpenses(String fiscalYear)
        {
            SqlCommand objcomm = new SqlCommand();

            objcomm.CommandType = CommandType.StoredProcedure;
            objcomm.CommandText = "GenerateNonCompensationExpenses";

            objcomm.Parameters.Add("fiscalYear", fiscalYear);

            DataSet ds = objDB.GetDataSetUsingCmdObj(objcomm);

            return ds;
        }

        public DataTable DisplayAllocatedCostsSummary(String fiscalYear)
        {
            SqlCommand objcomm = new SqlCommand();

            objcomm.CommandType = CommandType.StoredProcedure;
            objcomm.CommandText = "GenerateAllocatedCostsSummary";

            objcomm.Parameters.Add("@fiscalYear", fiscalYear);

            DataSet ds = objDB.GetDataSetUsingCmdObj(objcomm);

            double val = objDB.DoUpdateUsingCmdObj(objcomm);

            DataTable tbl = new DataTable();

            tbl.Columns.Add("AllocatedCost", typeof(String));

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                int var = 0;

                for (int i = 0; i < tbl.Columns.Count; i++)
                {
                    if (tbl.Columns[i].ColumnName.ToString() == row[1].ToString())
                    {
                        var = 1;
                    }
                }

                if (var != 1)
                {
                    tbl.Columns.Add(row[1].ToString(), typeof(double));
                    var = 0;

                }
            }

            int index = 0;
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                DataRow dr = tbl.NewRow();
                dr[0] = row[0];
                for (int i = 0; i < tbl.Columns.Count; i++)
                {
                    if (tbl.Columns[i].ColumnName.ToString() == row[1].ToString())
                    {
                        dr[i] = row[2];
                    }
                }

                tbl.Rows.Add(dr);
                index++;

            }

            for (int i = 1; i < tbl.Rows.Count; i++)
            {
                int count = 0;
                foreach (DataColumn column in tbl.Columns)
                {
                    if (tbl.Rows[i][column].ToString() == "")
                    {
                        count++;
                    }
                }
                if (count == tbl.Columns.Count - 1)
                {
                    tbl.Rows[i].Delete();
                    i = i - 1;
                }
            }

            for (int i = 1; i < tbl.Rows.Count; i++)
            {

                if (tbl.Rows[i][0].ToString() == tbl.Rows[i - 1][0].ToString())
                {
                    foreach (DataColumn column in tbl.Columns)
                    {
                        if (tbl.Rows[i][column].ToString() != "")
                        {
                            tbl.Rows[i - 1][column] = tbl.Rows[i][column];
                        }
                    }
                    tbl.Rows[i].Delete();
                    i = i - 1;
                }
            }

            tbl.Columns.Add("Amount", typeof(Double));


            foreach (DataRow row in tbl.Rows)
            {
                double total = 0;
                foreach (DataColumn col in tbl.Columns)
                {
                    if (!row.IsNull(col))
                    {
                        string stringValue = row[col].ToString();
                        double d;
                        if (double.TryParse(stringValue, out d))
                            total += d;
                    }
                }
                row.SetField("Amount", total);
            }

            return tbl;
        }

        public DataTable DisplaySupportUnit(String fiscalYear, String supportUnit)
        {
            SqlCommand objcomm = new SqlCommand();

            objcomm.CommandType = CommandType.StoredProcedure;
            objcomm.CommandText = "GenerateSupportUnit";

            objcomm.Parameters.Add("@fiscalYear", fiscalYear);
            objcomm.Parameters.Add("@supportUnit", supportUnit);

            DataSet ds = objDB.GetDataSetUsingCmdObj(objcomm);

            double val = objDB.DoUpdateUsingCmdObj(objcomm);

            DataTable tbl = new DataTable();

            tbl.Columns.Add("AllocatedCost", typeof(String));

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                int var = 0;

                for (int i = 0; i < tbl.Columns.Count; i++)
                {
                    if (tbl.Columns[i].ColumnName.ToString() == row[1].ToString())
                    {
                        var = 1;
                    }
                }

                if (var != 1)
                {
                    tbl.Columns.Add(row[1].ToString(), typeof(double));
                    var = 0;

                }
            }

            int index = 0;
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                DataRow dr = tbl.NewRow();
                dr[0] = row[0];
                for (int i = 0; i < tbl.Columns.Count; i++)
                {
                    if (tbl.Columns[i].ColumnName.ToString() == row[1].ToString())
                    {
                        dr[i] = row[2];
                    }
                }

                tbl.Rows.Add(dr);
                index++;

            }

            for (int i = 1; i < tbl.Rows.Count; i++)
            {
                int count = 0;
                foreach (DataColumn column in tbl.Columns)
                {
                    if (tbl.Rows[i][column].ToString() == "")
                    {
                        count++;
                    }
                }
                if (count == tbl.Columns.Count - 1)
                {
                    tbl.Rows[i].Delete();
                    i = i - 1;
                }
            }

            for (int i = 1; i < tbl.Rows.Count; i++)
            {

                if (tbl.Rows[i][0].ToString() == tbl.Rows[i - 1][0].ToString())
                {
                    foreach (DataColumn column in tbl.Columns)
                    {
                        if (tbl.Rows[i][column].ToString() != "")
                        {
                            tbl.Rows[i - 1][column] = tbl.Rows[i][column];
                        }
                    }
                    tbl.Rows[i].Delete();
                    i = i - 1;
                }
            }

            tbl.Columns.Add("Amount", typeof(Double));


            foreach (DataRow row in tbl.Rows)
            {
                double total = 0;
                foreach (DataColumn col in tbl.Columns)
                {
                    if (!row.IsNull(col))
                    {
                        string stringValue = row[col].ToString();
                        double d;
                        if (double.TryParse(stringValue, out d))
                            total += d;
                    }
                }
                row.SetField("Amount", total);
            }

            foreach (var column in tbl.Columns.Cast<DataColumn>().ToArray())
            {
                if (tbl.AsEnumerable().All(dr => dr.IsNull(column)))
                    tbl.Columns.Remove(column);
            }


            DataTable tbl2 = new DataTable();

            foreach (DataColumn column in tbl.Columns)
            {
                tbl2.Columns.Add(column.ColumnName.ToString(), typeof(String));

            }

            foreach (DataRow row in tbl.Rows)
            {
                DataRow row2 = tbl2.NewRow();
                row2[0] = row[0].ToString();

                for (int i = 1; i < tbl2.Columns.Count; i++)
                {

                    row2[i] = String.Format("{0:C}", double.Parse(row[i].ToString()));
                }

                tbl2.Rows.Add(row2);

            }
            return tbl2;
        }

        public DataSet DisplaySupportUnitMetrics(String fiscalYear, String supportUnit)
        {
            SqlCommand objcomm = new SqlCommand();

            objcomm.CommandType = CommandType.StoredProcedure;
            objcomm.CommandText = "GenerateSupportUnitMetrics";

            objcomm.Parameters.Add("@fiscalYear", fiscalYear);
            objcomm.Parameters.Add("@supportUnit", supportUnit);

            DataSet ds = objDB.GetDataSetUsingCmdObj(objcomm);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                if (row[5].ToString() == "")
                {
                    row.Delete();
                }
            }
            return ds;
        }

        public DataSet GetInstractionalComensationExpenseTypes()
        {
            SqlCommand objcomm = new SqlCommand();

            objcomm.CommandType = CommandType.StoredProcedure;
            objcomm.CommandText = "GenerateInstractionalCompensationTypes";

            DataSet ds = objDB.GetDataSetUsingCmdObj(objcomm);

            return ds;
        }
        public DataSet GetNonInstractionalComensationExpenseTypes()
        {
            SqlCommand objcomm = new SqlCommand();

            objcomm.CommandType = CommandType.StoredProcedure;
            objcomm.CommandText = "GenerateNonInstractionalCompensationTypes";

            DataSet ds = objDB.GetDataSetUsingCmdObj(objcomm);

            return ds;
        }
        public DataSet GetNonComensationExpenseTypes()
        {
            SqlCommand objcomm = new SqlCommand();

            objcomm.CommandType = CommandType.StoredProcedure;
            objcomm.CommandText = "GenerateNonCompensationTypes";

            DataSet ds = objDB.GetDataSetUsingCmdObj(objcomm);

            return ds;
        }
    }
}