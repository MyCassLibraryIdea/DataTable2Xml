using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace DBTableSchema
{
    public class XmlEvent
    {
        /// <summary>
        /// 從XML檔案讀取TableSchema所用到的二維列表清單
        /// </summary>
        /// <param name="XmlFile">欲讀取的XML檔案</param>
        /// <param name="RootName">欲解析的XML檔案之Root標的名稱</param>
        /// <returns>回傳的二維列表清單</returns>
        public List<string[]> ReadSingleNodeOfXml(string XmlFile, string RootName)
        {
            XDocument theXmlDoc = XDocument.Load(XmlFile);

            List<string[]> list = new List<string[]>();

            foreach (var item in theXmlDoc.Descendants(RootName))
            {
                foreach (var item1 in item.Descendants("Item"))
                {
                    string[] thisItem = new string[5];
                    thisItem[0] = item1.Attribute("ColumnName").Value;
                    thisItem[1] = item1.Attribute("Name").Value;
                    thisItem[2] = item1.Attribute("DataPropertyName").Value;
                    thisItem[3] = item1.Attribute("Visible").Value;
                    thisItem[4] = item1.Attribute("ColumnType").Value;
                    list.Add(thisItem);
                }
            }

            return list;
        }

        /// <summary>
        /// 從XML檔案讀取TableSchema所用到的三維列表清單
        /// </summary>
        /// <param name="XmlFile">欲讀取的XML檔案</param>
        /// <param name="RootName">欲解析的XML檔案之Root標的名稱</param>
        /// <returns>回傳的三維列表清單</returns>
        public List<List<string[]>> ReadMultiNodOfXml(string XmlFile, string RootName)
        {
            XDocument theXmlDoc = XDocument.Load(XmlFile);

            List<List<string[]>> allList = new List<List<string[]>>();

            foreach (var part in theXmlDoc.Descendants(RootName))
            {
                int countOfPart = theXmlDoc.Descendants(RootName).Elements().Count();
                for (int i = 0; i < countOfPart; i++)
                {
                    foreach (var item in part.Descendants("Part"+i.ToString()))
                    {
                        List<string[]> list = new List<string[]>();

                        foreach (var item1 in item.Descendants("Item"))
                        {
                            string[] thisItem = new string[5];
                            thisItem[0] = item1.Attribute("ColumnName").Value;
                            thisItem[1] = item1.Attribute("Name").Value;
                            thisItem[2] = item1.Attribute("DataPropertyName").Value;
                            thisItem[3] = item1.Attribute("Visible").Value;
                            thisItem[4] = item1.Attribute("ColumnType").Value;
                            list.Add(thisItem);
                        }
                        allList.Add(list);
                    }
                }
            }

            return allList;
        }

        /// <summary>
        /// 從XML檔案讀取TableSchema所用到的二維列表清單
        /// </summary>
        /// <param name="XmlFile">欲讀取的XML檔案</param>
        /// <param name="RootName">欲解析的XML檔案之Root標的名稱</param>
        /// <param name="nameOfElementGroup">欲解析的XML檔案之主元素名稱</param>
        /// <param name="listOfElement">欲解析的XML檔案之次元素名稱清單</param>
        /// <returns>回傳的二維列表清單</returns>
        public List<string[]> ReadSingleNodeOfXmlWithElementList(string XmlFile, string RootName, string nameOfElementGroup, List<string> listOfElement)
        {
            XDocument theXmlDoc = XDocument.Load(XmlFile);

            List<string[]> list = new List<string[]>();

            foreach (var item in theXmlDoc.Descendants(RootName))
            {
                foreach (var item1 in item.Descendants(nameOfElementGroup))
                {
                    string[] thisItem = new string[listOfElement.Count];
                    for (int i = 0; i < listOfElement.Count; i++)
                    {
                        thisItem[i] = item1.Attribute(listOfElement[i]).Value;
                    }
                    list.Add(thisItem);
                }
            }

            return list;
        }

        /// <summary>
        /// 從XML檔案讀取TableSchema所用到的三維列表清單
        /// </summary>
        /// <param name="XmlFile">欲讀取的XML檔案</param>
        /// <param name="RootName">欲解析的XML檔案之Root標的名稱</param>
        /// <param name="nameOfElementGroup">欲解析的XML檔案之主元素名稱</param>
        /// <param name="nameOfElementPart">欲解析的XML檔案之次元素名稱</param>
        /// <param name="listOfElement">欲解析的XML檔案之次次元素名稱清單</param>
        /// <returns>回傳的三維列表清單</returns>
        public List<List<string[]>> ReadMultiNodeOfXmlWithElementList(string XmlFile, string RootName, string nameOfElementGroup, string nameOfElementPart, List<string> listOfElement)
        {
            XDocument theXmlDoc = XDocument.Load(XmlFile);

            List<List<string[]>> allList = new List<List<string[]>>();

            foreach (var part in theXmlDoc.Descendants(RootName))
            {
                int countOfPart = theXmlDoc.Descendants(RootName).Elements().Count();
                for (int i = 0; i < countOfPart; i++)
                {
                    foreach (var item in part.Descendants(nameOfElementPart + i.ToString()))
                    {
                        List<string[]> list = new List<string[]>();

                        foreach (var item1 in item.Descendants(nameOfElementGroup))
                        {
                            string[] thisItem = new string[listOfElement.Count];
                            for (int j = 0; j < listOfElement.Count; j++)
                            {
                                thisItem[j] = item1.Attribute(listOfElement[j]).Value;
                            }
                            list.Add(thisItem);
                        }
                        allList.Add(list);
                    }
                }
            }

            return allList;
        }
    }
}
