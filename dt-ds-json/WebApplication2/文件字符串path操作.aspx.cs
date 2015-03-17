using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class 文件字符串path操作 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string filePath = @"C:\test\test2\test3.txt";

            //通过substring加indexof方式获取文件信息test3.txt
            string fileName = filePath.Substring(filePath.LastIndexOf('\\') + 1);

            //通过substring加indexof方式获取文件后缀信息txt
            string fileExtenstion = filePath.Substring(filePath.LastIndexOf('.') + 1);

            //通过substring加indexof方式获取文件名称信息text3
            string fileNameWithOutExtenstion = filePath.Substring(
                filePath.LastIndexOf('\\') + 1,
                filePath.LastIndexOf('.') - filePath.LastIndexOf('\\') - 1);

            string newFileName = Path.GetFileName(filePath);                    //test3.txt
            string newFileExtestion = Path.GetExtension(filePath);              //.txt
            string newFileFullName = Path.GetFullPath(filePath);                //C:\test\test2\test3.txt
            string newFileNameWithExtension = Path.GetFileNameWithoutExtension(filePath);  //test3
        }
    }
}