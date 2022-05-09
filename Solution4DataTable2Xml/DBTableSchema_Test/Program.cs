using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBTableSchema_Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string TableSchemaPath = @".\TableSchema.xml";
            List<string> listOfElement = new List<string>() { "ColumnName", "Name", "DataPropertyName", "Visible", "ColumnType" };
            DBTableSchema.XmlEvent xmlEvent = new DBTableSchema.XmlEvent();

            #region Test ReadSingleNodeOfXml(string XmlFile, string RootName)
            List<string[]> ColHeadTextOf1stTest = xmlEvent.ReadSingleNodeOfXml(TableSchemaPath, "Table001");
            Console.WriteLine("ReadSingleNodeOfXml的測試結果\n");
            string ResultOf1stTest = "";
            foreach (var item in ColHeadTextOf1stTest)
            {
                for (int i = 0; i < listOfElement.Count; i++)
                {
                    ResultOf1stTest += listOfElement[i] + " = " + item[i];
                    if (i < (listOfElement.Count - 1))
                    {
                        ResultOf1stTest += "\t";
                    }
                    else
                    {
                        ResultOf1stTest += "\n";
                    }
                }
            }
            Console.WriteLine(ResultOf1stTest);
            #endregion

            #region Test ReadMultiNodOfXml(string XmlFile, string RootName)
            List<List<string[]>> ColHeadTextOf2ndTest = xmlEvent.ReadMultiNodOfXml(TableSchemaPath, "Table016");
            Console.WriteLine("ReadMultiNodOfXml的測試結果\n");
            string ResultOf2ndTest = "";
            for (int i = 0; i < ColHeadTextOf2ndTest.Count; i++)
            {
                ResultOf2ndTest += "Part" + i.ToString() + ":\n";
                foreach (var item in ColHeadTextOf2ndTest[i])
                {
                    for (int j = 0; j < listOfElement.Count; j++)
                    {
                        ResultOf2ndTest += listOfElement[j] + " = " + item[j];
                        if (j < (listOfElement.Count - 1))
                        {
                            ResultOf2ndTest += "\t";
                        }
                        else
                        {
                            ResultOf2ndTest += "\n";
                        }
                    }
                }
            }
            Console.WriteLine(ResultOf2ndTest);
            #endregion

            #region Test ReadSingleNodeOfXmlWithElementList(string XmlFile, string RootName, string nameOfElementGroup, List<string> listOfElement)
            List<string[]> ColHeadTextOf3rdTest = xmlEvent.ReadSingleNodeOfXmlWithElementList(TableSchemaPath, "Table002", "Item", listOfElement);
            Console.WriteLine("ReadSingleNodeOfXmlWithElementList的測試結果\n");
            string ResultOf3rdTest = "";
            foreach (var item in ColHeadTextOf3rdTest)
            {
                for (int i = 0; i < listOfElement.Count; i++)
                {
                    ResultOf3rdTest += listOfElement[i] + " = " + item[i];
                    if (i < (listOfElement.Count - 1))
                    {
                        ResultOf3rdTest += "\t";
                    }
                    else
                    {
                        ResultOf3rdTest += "\n";
                    }
                }
            }
            Console.WriteLine(ResultOf3rdTest);
            #endregion

            #region Test ReadMultiNodeOfXmlWithElementList(string XmlFile, string RootName, string nameOfElementGroup, string nameOfElementPart, List<string> listOfElement)
            List<List<string[]>> ColHeadTextOf4thTest = xmlEvent.ReadMultiNodeOfXmlWithElementList(TableSchemaPath, "Table017", "Item", "Part", listOfElement);
            Console.WriteLine("ReadMultiNodeOfXmlWithElementList的測試結果\n");
            string ResultOf4thTest = "";
            for (int i = 0; i < ColHeadTextOf4thTest.Count; i++)
            {
                ResultOf4thTest += "Part" + i.ToString() + ":\n";
                foreach (var item in ColHeadTextOf4thTest[i])
                {
                    for (int j = 0; j < listOfElement.Count; j++)
                    {
                        ResultOf4thTest += listOfElement[j] + "=" + item[j];
                        if (j < (listOfElement.Count - 1))
                        {
                            ResultOf4thTest += "\t";
                        }
                        else
                        {
                            ResultOf4thTest += "\n";
                        }
                    }
                }
            }
            Console.WriteLine(ResultOf4thTest);
            #endregion

            Console.ReadLine();
        }
    }
}
