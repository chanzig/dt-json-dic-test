using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //模拟dataTable 1
            DataTable dt1 = new DataTable("myTable1");
            dt1.Columns.Add("ID", typeof(Int32));
            dt1.Columns.Add("name", typeof(string));
            dt1.Columns.Add("description", typeof(string));
            for (int i = 1; i < 10; i++)
            {
                DataRow dr = dt1.NewRow();
                dr["ID"] = "007" + i;
                dr["name"] = "我是00" + i;
                dr["description"] = "描述" + i;
                dt1.Rows.Add(dr);
            }
            //模拟dataTable 2
            DataTable dt2 = new DataTable("myTable2");
            dt2.Columns.Add("ID", typeof(Int32));
            dt2.Columns.Add("name", typeof(string));
            dt2.Columns.Add("description", typeof(string));
            for (int i = 1; i < 10; i++)
            {
                DataRow dr = dt2.NewRow();
                dr["ID"] = "007" + i;
                dr["name"] = "我是00" + i;
                dr["description"] = "描述" + i;
                dt2.Rows.Add(dr);
            }
            //模拟dataSet
            DataSet ds = new DataSet();
            ds.Tables.Add(dt1); 
            ds.Tables.Add(dt2);

           dtJson.InnerHtml = ToJson(dt1);
           dsJson.InnerHtml = ToJson(ds);
           
            //将字符串保存到本地的json
            fileJson(ToJson(ds));
        }
        
        public bool fileJson(string file) {
                FileStream fs = new FileStream("e://Login.json", FileMode.Create);
                StreamWriter sw = new StreamWriter(fs);
                sw.Write(file);
                sw.Flush();
                sw.Close();
                fs.Close();
                return true;
        }
        public static string ToJson(DataTable dt)
        {
            StringBuilder jsonBuilder = new StringBuilder();
            jsonBuilder.Append("{");
            jsonBuilder.Append(singleDtToJson(dt));
            jsonBuilder.Append("}");
            return jsonBuilder.ToString();
        }

        public static string ToJson(DataSet ds)
        {
            StringBuilder json = new StringBuilder();
            json.Append("{");
            foreach (DataTable dt in ds.Tables)
            {      
                json.Append(singleDtToJson(dt));
                json.Append(",");
            }
            json.Remove(json.Length - 1, 1);
            json.Append("}");
            return json.ToString();
        }
        //为了配合dataset，将datatable固定成一个格式，利于dataset拼接成数组
        public static string singleDtToJson(DataTable dt)
        {
            StringBuilder jsonBuilder = new StringBuilder();
            jsonBuilder.Append("\"");
            jsonBuilder.Append(dt.TableName.ToString());
            jsonBuilder.Append("\":[");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                jsonBuilder.Append("{");
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    jsonBuilder.Append("\"");
                    jsonBuilder.Append(dt.Columns[j].ColumnName);
                    jsonBuilder.Append("\":\"");
                    jsonBuilder.Append(dt.Rows[i][j].ToString());
                    jsonBuilder.Append("\",");
                }
                jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
                jsonBuilder.Append("},");
            }
            jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
            jsonBuilder.Append("]");
            return jsonBuilder.ToString();
        }
    }
}
