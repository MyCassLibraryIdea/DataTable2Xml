using ClassLibraryDataTable2Xml;

using System;
using System.Collections.Generic;
using System.Data;
using System.Xml;

namespace ConsoleApp4DataTable2Xml
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region 產生新資料字串清單(theDataList)
            //TODO: 確認資料字串清單的格式是否和此範例一致
            //TODO: 請確認作為相同集合的第二個欄位資料是否一致
            List<string[]> theDataList = new List<string[]>
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
            #region 產生新資料表(dt)並且匯入資料字串清單(theDataList)
            string theTableName = "DemoDataTable";
            //TODO: 請確認作為相同集合的欄位資料應該為第二個欄位，第一個欄位是Key，第三個欄位以後才是每一個集合的資料。
            List<string> theColumnArray = new List<string> { "ID", "CID", "VID", "ZID" };
            //TODO: 請參考此行程式帶入正確的參數到CreateDataTable函式。
            DataTable dt = myEvent.CreateDataTable(theTableName, theColumnArray, theDataList);
            #endregion
            #region 讀取資料表(dt)並轉成XML字串(strXml)
            //TODO: 對XML的每一筆資料的開頭，請設定一個固定的字串。
            string strOfElementGroupName = "Item";
            //TODO: 請參考此行程式帶入正確的參數到CreateXmlString函式。
            string strXml = myEvent.CreateXmlString(dt, strOfElementGroupName, theColumnArray);
            //TODO: 請確認產出的字串是否為如下之未斷行結果。
            /*
             * <Root>
             *  <CID1>
             *      <Item VID = 'VID1-1' ZID = 'ZID1-2'/>
             *      <Item VID = 'VID1-2' ZID = 'ZID1-3'/>
             *      <Item VID = 'VID1-3' ZID = 'ZID1-4'/>
             *      <Item VID = 'VID1-4' ZID = 'ZID1-5'/>
             *      <Item VID = 'VID1-5' ZID = 'ZID1-6'/>
             *  </CID1>
             *  <CID2>
             *      <Item VID = 'VID2-1' ZID = 'ZID2-2'/>
             *      <Item VID = 'VID2-2' ZID = 'ZID2-3'/>
             *      <Item VID = 'VID2-3' ZID = 'ZID2-4'/>
             *      <Item VID = 'VID2-4' ZID = 'ZID2-5'/>
             *      <Item VID = 'VID2-5' ZID = 'ZID2-6'/>
             *  </CID2>
             * </Root>
             */
            #endregion
            #region 讀取XML字串(strXml)並存成XML檔案
            //TODO: 請將所得到之字串結果轉存成XML檔案。
            string theTargetOfXml = @".\MyNewXml.xml";
            XmlDocument xd = new XmlDocument();
            xd.LoadXml(strXml);
            xd.Save(theTargetOfXml);
            #endregion
            #region 嘗試讀取XML檔案
            //TODO: 經過驗證後，前面的程式所產出的XML檔案式正確的。
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
