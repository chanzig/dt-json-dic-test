using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class 临时数据存储 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var tempData = new
            {
                name = "bill",
                age = 20,
            };

            nameSpan.InnerText = tempData.name;
            ageSpan.InnerText = tempData.age.ToString();

            dynamic TD = new
            {
                name="arev",
                age=60,
            };
            dname.InnerText = TD.name;
            dage.InnerText = TD.age.ToString();

            //非数字过滤
            int tempValue=0;
            List<string> monitotOrPort = new List<string>() { "22344dsfsdf" };
            for (int i=0; i < monitotOrPort.Count; i++) { 
            if(!int.TryParse(monitotOrPort[i],out tempValue)){
                //do
            }
            }

            List<string> newName1=new List<string>();
            List<string> names = new List<string>(){
            "long","li","sheng"
          };
            //在 LINQ 中，查询变量本身不执行任何操作并且不返回任何数据。它只是存储在以后某个时刻执行查询时为生成结果而必需的信息。
            IEnumerable<string> nameQuery = from name in names
                                            where name.Contains("l")
                                            select name;
            //遍历方法
            //foreach (var n in nameQuery)
            //{
            //    newName.Add(n);
            //}

            //1
            newName1 = nameQuery.ToList();

            //2
            List<string> newName2 = (from name in names
                                    where name.Contains("l")
                                    select name)
                                    .ToList();


          
        }
    }
}