using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryDataTable2Xml
{
    public class Class4Event
    {
        /// <summary>
        /// 新增所需要的資料表
        /// </summary>
        /// <param name="theTableName">資料表名稱</param>
        /// <param name="theColumnList">資料表欄位清單</param>
        /// <param name="theDataList">資料表資料清單</param>
        /// <returns>回傳資料表</returns>
        public DataTable CreateDataTable(string theTableName, List<string> theColumnList, List<string[]> theDataList)
        {
            DataTable dt = new DataTable
            {
                TableName = theTableName
            };
            for (int i = 0; i < theColumnList.Count; i++)
            {
                dt.Columns.Add(theColumnList[i]);
            }
            DataRow dr;
            for (int i = 0; i < theDataList.Count; i++)
            {
                dr = dt.NewRow();
                for (int j = 0; j < theColumnList.Count; j++)
                {
                    dr[j] = theDataList[i][j];
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }

        /// <summary>
        /// 從資料表轉成XML字串
        /// </summary>
        /// <param name="dt">所需要的資料表</param>
        /// <param name="strOfElementGroupName">XML元素集合名稱</param>
        /// <param name="theColumnList">資料表欄位清單</param>
        /// <returns>回傳XML字串</returns>
        public string CreateXmlString(DataTable dt, string strOfElementGroupName, List<string> theColumnList)
        {
            string strXml = "";
            string strRowData = "";
            string strContentInsideRoot = "";
            string strContentInsideItem = "";
            string strRootStart = "";
            string strRootEnd = "";
            strXml += "<Root>";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (strContentInsideRoot == "")
                {
                    strContentInsideRoot = strRootStart + strContentInsideItem;
                }
                else
                {
                    strContentInsideRoot += strContentInsideItem;
                }
                if (strRowData != dt.Rows[i][1].ToString())
                {
                    strRowData = dt.Rows[i][1].ToString();
                    strRootStart = "<" + strRowData + ">";
                    strRootEnd = "</" + strRowData + ">";
                    strContentInsideItem = "";
                }
                for (int j = 2; j < theColumnList.Count; j++)
                {
                    if (j == 2)
                    {
                        strContentInsideItem = "";
                    }
                    string strItemContent = theColumnList[j] + " = '" + dt.Rows[i][j].ToString() + "'";
                    if (strContentInsideItem == "")
                    {
                        strContentInsideItem = "<"+ strOfElementGroupName + " " + strItemContent;
                    }
                    else
                    {
                        strContentInsideItem += " " + strItemContent;
                    }
                    if (j == theColumnList.Count - 1)
                    {
                        strContentInsideItem += "/>";
                    }
                }
                if (i > 0)
                {
                    if (i <= dt.Rows.Count - 1)
                    {
                        if (i == dt.Rows.Count - 1)
                        {
                            strContentInsideRoot += strContentInsideItem + strRootEnd;
                            strXml += strContentInsideRoot;
                            strContentInsideRoot = "";
                        }
                        else if (dt.Rows[i][1] != dt.Rows[i - 1][1])
                        {
                            strContentInsideRoot += "</" + dt.Rows[i - 1][1].ToString() + ">";
                            strXml += strContentInsideRoot;
                            strContentInsideRoot = "";
                        }
                    }
                }
            }
            strXml += "</Root>";
            return strXml;
        }
    }
}
