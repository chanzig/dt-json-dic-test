using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using System.Text;

namespace WebApplication2
{
    public partial class myRepeater_update : System.Web.UI.Page
    {
        DataTable m_dt = new DataTable();
        int m_iID = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                Repeater1.DataSource = this.InitDataTable();
                Repeater1.DataBind();
            }
        }
        protected DataTable InitDataTable()
        {
            m_dt.Columns.Add("ID");
            m_dt.Columns.Add("a");
            m_dt.Columns.Add("b");
            m_dt.Columns.Add("c");

            DataRow dr;
            for (int i = 1; i <= 10; i++)
            {
                dr = m_dt.NewRow();

                dr["ID"] = i.ToString();
                dr["a"] = "A" + ((i * 10).ToString());
                dr["b"] = "B" + ((i * 100).ToString());
                dr["c"] = "C" + ((i * 1000).ToString());

                m_dt.Rows.Add(dr);
            }

            return m_dt;
        }


        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                if (m_dt.Rows[e.Item.ItemIndex]["ID"].ToString() != m_iID.ToString())
                {
                    ((Panel)e.Item.FindControl("plItem")).Visible = true;
                    ((Panel)e.Item.FindControl("plEdit")).Visible = false;
                }
                else
                {
                    ((Panel)e.Item.FindControl("plItem")).Visible = false;
                    ((Panel)e.Item.FindControl("plEdit")).Visible = true;
                }
            }
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                m_iID = int.Parse(e.CommandArgument.ToString());
            }
            else if (e.CommandName == "Cancel")
            {
                m_iID = -1;
            }
            else if (e.CommandName == "Update")
            {
                //Update.......

                string sA = ((TextBox)this.Repeater1.Items[e.Item.ItemIndex].FindControl("txtA")).Text.Trim();
                string sB = ((TextBox)this.Repeater1.Items[e.Item.ItemIndex].FindControl("txtB")).Text.Trim();
                string sC = ((TextBox)this.Repeater1.Items[e.Item.ItemIndex].FindControl("txtC")).Text.Trim();

                this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "key", "alert('更新ID：" +
                    e.CommandArgument + "；页面值：A," + sA + "----B," + sB + "----C," + sC + "');", true);
            }
            else if (e.CommandName == "Delete")
            {
                //Delete.......           
                this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "key", "alert('删除ID：" + e.CommandArgument + "');", true);
            }

            Repeater1.DataSource = this.InitDataTable();
            Repeater1.DataBind();
        }
    }
}