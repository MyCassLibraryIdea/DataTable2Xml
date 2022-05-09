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
        public DataTable CreateDataTable(string theTableName, List<string> theColumnArray, List<string[]> listOfData)
        {
            DataTable dt = new DataTable
            {
                TableName = theTableName
            };
            for (int i = 0; i < theColumnArray.Count; i++)
            {
                dt.Columns.Add(theColumnArray[i]);
            }
            DataRow dr;
            for (int i = 0; i < listOfData.Count; i++)
            {
                dr = dt.NewRow();
                for (int j = 0; j < theColumnArray.Count; j++)
                {
                    dr[j] = listOfData[i][j];
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }

        public string CreateXmlString(DataTable dt, string strOfElementGroupName, List<string> theColumnArray)
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
                for (int j = 2; j < theColumnArray.Count; j++)
                {
                    if (j == 2)
                    {
                        strContentInsideItem = "";
                    }
                    string strItemContent = theColumnArray[j] + " = '" + dt.Rows[i][j].ToString() + "'";
                    if (strContentInsideItem == "")
                    {
                        strContentInsideItem = "<"+ strOfElementGroupName + " " + strItemContent;
                    }
                    else
                    {
                        strContentInsideItem += " " + strItemContent;
                    }
                    if (j == theColumnArray.Count - 1)
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
