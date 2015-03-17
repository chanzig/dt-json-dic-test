using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data; 

namespace WebApplication2
{
    public partial class myRepeater : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitData();
                DataBinds();
            }
        }
      protected void InitData()
        {
            DateTime time = DateTime.Now;
  
            DataTable dt = new DataTable();
  
            dt.Columns.Add("ID",typeof(string));
            dt.Columns.Add("Name",typeof(string));
            dt.Columns.Add("Telephone",typeof(string));
            dt.Columns.Add("RegisterDate", typeof(string));
  
            for (int i = 0; i < 2; i++)
            {
                DataRow dr=dt.NewRow();
                dr["ID"] = i + 1;
                dr["Name"] = "user" + (i + 1);
                dr["Telephone"] = "123456";
                dr["RegisterDate"] =time.AddDays(i * 10).ToString("yyyy-MM-dd");
                dt.Rows.Add(dr);
            }
  
            ViewState.Add("Data",dt);
        }
  
        protected void DataBinds()
        {
            rpCustomerInfo.DataSource=ViewState["Data"] as DataTable;
            rpCustomerInfo.DataBind();
        }
  
        protected DataTable CopyFormData()
        {
            DataTable dt = (ViewState["Data"] as DataTable).Clone();
  
            foreach (RepeaterItem ri in rpCustomerInfo.Items)
            {
                DataRow dr = dt.NewRow();
  
                dr["ID"]=(ri.FindControl("TextBox1") as TextBox).Text;
                dr["Name"] = (ri.FindControl("TextBox2") as TextBox).Text;
                dr["Telephone"] = (ri.FindControl("TextBox3") as TextBox).Text;
                dr["RegisterDate"] = (ri.FindControl("TextBox4") as TextBox).Text;
                dt.Rows.Add(dr);
            }
  
            return dt;
        }
  
        protected void btnNew_OnClick(object sender, EventArgs e)
        {
            DataTable dt = CopyFormData();
  
            DataRow dr = dt.NewRow();
  
            dt.Rows.Add(dr);
  
            ViewState.Add("Data",dt);
  
            DataBinds();
        }
  
        protected void rpCustomerInfo_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName=="Delete")
            {
                DataTable dt = CopyFormData();
  
                dt.Rows.RemoveAt(e.Item.ItemIndex);
  
                ViewState.Add("Data", dt);
  
                DataBinds();
            }
        }
    }
}