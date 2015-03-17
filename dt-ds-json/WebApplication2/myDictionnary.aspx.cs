using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        

            Dictionary<int, string> myDictionary = new Dictionary<int, string>();// 实现IDictionary接口，IDictionary<Tkey,Tvalue>类
            // 添加键值对
            myDictionary.Add(1, "a");
            myDictionary.Add(2, "b");
            myDictionary.Add(3, "c");
            dic1.InnerHtml += "<ul>";
            foreach (int k in myDictionary.Keys)
            {
                dic1.InnerHtml += "<li>" + k + "</li>";
            }
            dic1.InnerHtml += "</ul>";

            foreach ( KeyValuePair<int, string> temp in myDictionary) {
                dic1.InnerHtml += temp.Key + temp.Value;
            }
           


           

        }
    }
}