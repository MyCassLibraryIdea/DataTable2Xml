using ClassLibraryDataTable2Xml;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace ConsoleApp4DataTable2Xml
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Create New Data List String Array(list)
            List<string[]> listOfData = new List<string[]>
            {
                new string[] { "1", "CID1", "VID1-1", "ZID1-2" },
                new string[] { "2", "CID1", "VID1-2", "ZID1-3" },
                new string[] { "3", "CID1", "VID1-3", "ZID1-4" },
                new string[] { "4", "CID1", "VID1-4", "ZID1-5" },
                new string[] { "5", "CID1", "VID1-5", "ZID1-6" },
                new string[] { "6", "CID2", "VID2-1", "ZID2-2" },
                new string[] { "7", "CID2", "VID2-2", "ZID2-3" },
                new string[] { "8", "CID2", "VID2-3", "ZID2-4" },
                new string[] { "9", "CID2", "VID2-4", "ZID2-5" },
                new string[] { "10", "CID2", "VID2-5", "ZID2-6" }
            };
            #endregion
            Class4Event myEvent = new Class4Event();
            #region Create New Data Table(dt) And Inport Data List String Array(listOfData)
            string theTableName = "DemoDataTable";
            List<string> theColumnArray = new List<string> { "ID", "CID", "VID", "ZID" };
            DataTable dt = myEvent.CreateDataTable(theTableName, theColumnArray, listOfData);
            #endregion
            #region Read Data Table(dt) To Xml String(strXml)
            string strOfElementGroupName = "Item";
            string strXml = myEvent.CreateXmlString(dt, strOfElementGroupName, theColumnArray);
            #endregion
            #region Read Xml String(strXml) To Save Xml File
            string theTargetOfXml = @".\MyNewXml.xml";
            XmlDocument xd = new XmlDocument();
            xd.LoadXml(strXml);
            xd.Save(theTargetOfXml);
            #endregion
            #region Try To Read Xml File
            DBTableSchema.XmlEvent xmlEvent = new DBTableSchema.XmlEvent();
            List<string> theXmlElementArray = new List<string> { "VID", "ZID" };
            List<string[]> ResultOfReadXml = xmlEvent.ReadSingleNodeOfXmlWithElementList(theTargetOfXml, "CID1", "Item", theXmlElementArray);
            for (int i = 0; i < ResultOfReadXml.Count; i++)
            {
                for (int j = 0; j < theXmlElementArray.Count; j++)
                {
                    Console.WriteLine("{0}的第{1}個{2} : {3}", "CID1", i + 1, theXmlElementArray[j], ResultOfReadXml[i][j]);
                }
            }
            Console.ReadLine();
            #endregion
        }
    }
}
