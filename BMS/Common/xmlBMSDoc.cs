using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Data;
using System.Xml;
using System.Xml.Linq;


namespace BetteryMonitoringSystem.Common
{
    class xmlBMSDoc
    {
        private string mLineInfoPath = Application.StartupPath + "\\config\\LineInfo.xml";
        private XmlDocument mLineInfoXMLDoc = new XmlDocument();
        private DataSet mLineInfoDataSet = new DataSet("LineInfo");
        private DataTable mLineInfoDataTable = new DataTable("LINE");

        private string mBMSInfoPath = Application.StartupPath + "\\config\\BMSInfo.xml";
        private XmlDocument mBMSInfoXMLDoc = new XmlDocument();
        private DataSet mBMSInfoDataSet = new DataSet("BMSInfo");
        




        public xmlBMSDoc()
        {

        }
        
        public DataTable ReadLineInfoXMLFile()
        {
            try
            {
                mLineInfoXMLDoc.Load(mLineInfoPath);

                XmlNodeList nodelist = mLineInfoXMLDoc.SelectNodes("LineInfo/LINE");

                DataColumn column;

                // Create column 1.
                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "COM";

                // Add the column to the DataTable.Columns collection.
                mLineInfoDataTable.Columns.Add(column);


                // Create column 2.
                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "BaudRate";

                // Add the column to the DataTable.Columns collection.
                mLineInfoDataTable.Columns.Add(column);

                // Create column 3.
                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "LineName";

                // Add the column to the DataTable.Columns collection.
                mLineInfoDataTable.Columns.Add(column);

                // Create column 4.
                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "Interval";

                // Add the column to the DataTable.Columns collection.
                mLineInfoDataTable.Columns.Add(column);

                // Make the ID column the primary key column.
                DataColumn[] PrimaryKeyColumns = new DataColumn[1];
                PrimaryKeyColumns[0] = mLineInfoDataTable.Columns["COM"];
                mLineInfoDataTable.PrimaryKey = PrimaryKeyColumns;


                foreach (XmlNode node in nodelist)
                {
                    DataRow row1 = mLineInfoDataTable.NewRow();

                    row1[0] = node.SelectSingleNode("COM").InnerText;
                    row1[1] = node.SelectSingleNode("BaudRate").InnerText;
                    row1[2] = node.SelectSingleNode("LineName").InnerText;
                    row1[3] = node.SelectSingleNode("Interval").InnerText;

                    mLineInfoDataTable.Rows.Add(row1);
                }

                return mLineInfoDataTable;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }


        }


        public DataTable ReadBMSInfoXMLFile()
        {

            try
            {
                DataTable mBMSInfoDataTable = new DataTable("BMS");
                mBMSInfoXMLDoc.Load(mBMSInfoPath);

                XmlNodeList nodelist = mBMSInfoXMLDoc.SelectNodes("BMSInfo/BMS");

                mBMSInfoDataTable.Columns.Add("COM");
                mBMSInfoDataTable.Columns.Add("ID");
                mBMSInfoDataTable.Columns.Add("Name");
                mBMSInfoDataTable.Columns.Add("Contact1");
                mBMSInfoDataTable.Columns.Add("Contact2");
                mBMSInfoDataTable.Columns.Add("Contact3");
                mBMSInfoDataTable.Columns.Add("Contact4");
                //mBMSInfoDataTable.Columns.Add("IDX");
                //mBMSInfoDataTable.Columns.Add("ERR");

                //int rowIndex = 0;

                foreach (XmlNode node in nodelist)
                {

                    DataRow row1 = mBMSInfoDataTable.NewRow();

                    row1[0] = node.SelectSingleNode("COM").InnerText;
                    row1[1] = node.SelectSingleNode("ID").InnerText;
                    row1[2] = node.SelectSingleNode("Name").InnerText;
                    row1[3] = node.SelectSingleNode("Contact1").InnerText;
                    row1[4] = node.SelectSingleNode("Contact2").InnerText;
                    row1[5] = node.SelectSingleNode("Contact3").InnerText;
                    row1[6] = node.SelectSingleNode("Contact4").InnerText;
                    //row1[7] = rowIndex++;
                    //row1[8] = 0;
                    mBMSInfoDataTable.Rows.Add(row1);

                }

                return mBMSInfoDataTable;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public DataTable ReadBMSInfoXMLFile(string com)
        {
            DataTable mBMSInfoDataTable = new DataTable("BMS");
            mBMSInfoXMLDoc.Load(mBMSInfoPath);

            XmlNodeList nodelist = mBMSInfoXMLDoc.SelectNodes("BMSInfo/BMS");

            mBMSInfoDataTable.Columns.Add("COM");
            mBMSInfoDataTable.Columns.Add("ID");
            mBMSInfoDataTable.Columns.Add("Name");
            mBMSInfoDataTable.Columns.Add("Contact1");
            mBMSInfoDataTable.Columns.Add("Contact2");
            mBMSInfoDataTable.Columns.Add("Contact3");
            mBMSInfoDataTable.Columns.Add("Contact4");
            //mBMSInfoDataTable.Columns.Add("IDX");
            //mBMSInfoDataTable.Columns.Add("ERR");



            // Make the ID column the primary key column.
            DataColumn[] PrimaryKeyColumns = new DataColumn[1];
            PrimaryKeyColumns[0] = mBMSInfoDataTable.Columns["ID"];
            mBMSInfoDataTable.PrimaryKey = PrimaryKeyColumns;


            //int rowIndex = 0;

            foreach (XmlNode node in nodelist)
            {

                if (node.SelectSingleNode("COM").InnerText.Equals(com))
                {
                    DataRow row1 = mBMSInfoDataTable.NewRow();

                    row1[0] = node.SelectSingleNode("COM").InnerText;
                    row1[1] = node.SelectSingleNode("ID").InnerText;
                    row1[2] = node.SelectSingleNode("Name").InnerText;
                    row1[3] = node.SelectSingleNode("Contact1").InnerText;
                    row1[4] = node.SelectSingleNode("Contact2").InnerText;
                    row1[5] = node.SelectSingleNode("Contact3").InnerText;
                    row1[6] = node.SelectSingleNode("Contact4").InnerText;
                    //row1[7] = rowIndex++;
                    //row1[8] = 0;
                    try
                    {
                        mBMSInfoDataTable.Rows.Add(row1);
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }

                }

            }

            return mBMSInfoDataTable;
        }
        public void InsertDefaultErrorSetInfo(XmlDocument xmlDoc, string com, string id)
        {

            string[] sensorList = new string[] { "VOLT", "CURRENT", "TEMP1", "TEMP2", "TEMP3", "TEMP4", "TEMP5", "TEMP6" };

            
            
            XmlNode rootNode = xmlDoc.DocumentElement;
                
            XmlElement elem = xmlDoc.CreateElement("ERRORSET");

            XmlAttribute rootAttribute = xmlDoc.CreateAttribute("Com");
            rootAttribute.Value = com;
            elem.Attributes.Append(rootAttribute);
            
            rootAttribute = xmlDoc.CreateAttribute("Id");
            rootAttribute.Value = id;
            elem.Attributes.Append(rootAttribute);
            xmlDoc.AppendChild(rootNode);

            foreach( string sensor in sensorList )
            {
                XmlNode userNode = xmlDoc.CreateElement(sensor);
                XmlAttribute attribute = xmlDoc.CreateAttribute("Status");
                attribute.Value = "None";
                userNode.Attributes.Append(attribute);
                attribute = xmlDoc.CreateAttribute("Enable");
                attribute.Value = "Enable";
                userNode.Attributes.Append(attribute);
                if( sensor == "VOLT")
                {
                    attribute = xmlDoc.CreateAttribute("UpperLimit");
                    attribute.Value = "600.0";
                    userNode.Attributes.Append(attribute);
                    attribute = xmlDoc.CreateAttribute("LowLimit");
                    attribute.Value = "100.0";
                    userNode.Attributes.Append(attribute);
                }
                else if (sensor == "CURRENT")
                {
                    attribute = xmlDoc.CreateAttribute("UpperLimit");
                    attribute.Value = "4000.0";
                    userNode.Attributes.Append(attribute);
                    attribute = xmlDoc.CreateAttribute("LowLimit");
                    attribute.Value = "-1000.0";
                    userNode.Attributes.Append(attribute);
                }
                else
                {
                    attribute = xmlDoc.CreateAttribute("UpperLimit");
                    attribute.Value = "40.0";
                    userNode.Attributes.Append(attribute);
                    attribute = xmlDoc.CreateAttribute("LowLimit");
                    attribute.Value = "5.0";
                    userNode.Attributes.Append(attribute);
                }

                elem.AppendChild(userNode);
            }
 

            rootNode.InsertAfter(elem, rootNode.LastChild);
            
            
        }


        public void UpdateErrorSetInfoXMLFile(DataTable table, string path, string dataSet, string dataTable, string com, string id)
        {

            string[] sensorList = new string[] { "VOLT", "CURRENT", "TEMP1", "TEMP2", "TEMP3", "TEMP4", "TEMP5", "TEMP6" };
            string xmlPath = Application.StartupPath + path;
            
            XmlDocument xmlDoc = new XmlDocument();

            xmlDoc.Load(xmlPath);

            XmlNodeList nodelist = xmlDoc.SelectNodes(dataSet + "/" + dataTable);


            foreach (XmlNode node in nodelist)
            {

                if (node.Attributes["Com"].Value.Equals(com) && node.Attributes["Id"].Value.Equals(id))
                {
                    
                    foreach (XmlNode childNode in node.ChildNodes)
                    {
                        
                        foreach( DataRow row in table.Rows )
                        {
                            if (childNode.Name.ToUpper().Equals(row["Name"]))
                            {
                                childNode.Attributes["Status"].Value = row["Status"].ToString();
                                childNode.Attributes["Enable"].Value = row["Enable"].ToString();
                                childNode.Attributes["UpperLimit"].Value = row["Upper Limit"].ToString();
                                childNode.Attributes["LowLimit"].Value = row["Low Limit"].ToString();

                                break;
                            }
                        }
                        
                    }

                    break;
                }

            }
            xmlDoc.Save(xmlPath);

        }

        
        public DataTable ReadErrorSetInfoXMLFile(string path, string dataSet, string dataTable, string com, string id)
        {
            bool exist = false;
            string xmlPath = Application.StartupPath + path;
            
            DataSet xmlDataSet = new DataSet(dataSet);
            DataTable xmlDataTable = new DataTable(dataTable);

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlPath);

            XmlNodeList nodelist = xmlDoc.SelectNodes(dataSet + "/" + dataTable);
            
            xmlDataTable.Columns.Add("Name");
            xmlDataTable.Columns.Add("Status");
            xmlDataTable.Columns.Add("Enable");
            xmlDataTable.Columns.Add("Upper Limit");
            xmlDataTable.Columns.Add("Low Limit");

            foreach (XmlNode node in nodelist)
            {

                if( node.Attributes["Com"].Value.Equals(com) && node.Attributes["Id"].Value.Equals(id) )
                {
                    exist = true;
                    foreach (XmlNode childNode in node.ChildNodes)
                    {
                        DataRow row1 = xmlDataTable.NewRow();

                        if( childNode.Name.ToUpper() == "VOLT" ||
                            childNode.Name.ToUpper() == "CURRENT" ||
                            childNode.Name.ToUpper() == "TEMP1" ||
                            childNode.Name.ToUpper() == "TEMP2" ||
                            childNode.Name.ToUpper() == "TEMP3" ||
                            childNode.Name.ToUpper() == "TEMP4" ||
                            childNode.Name.ToUpper() == "TEMP5" ||
                            childNode.Name.ToUpper() == "TEMP6" )
                        {
                            row1[0] = childNode.Name;
                            row1[1] = childNode.Attributes["Status"].Value;
                            row1[2] = childNode.Attributes["Enable"].Value;
                            row1[3] = childNode.Attributes["UpperLimit"].Value;
                            //childNode.Attributes["LowLimit"].Value = "10.11";
                            row1[4] = childNode.Attributes["LowLimit"].Value;

                            xmlDataTable.Rows.Add(row1);
                        }
                        
                    }

                    break;
                }


            }

            if( !exist )
            {
                // write default errorSetInfo
                InsertDefaultErrorSetInfo(xmlDoc, com, id);

                xmlDoc.Save(xmlPath);

                return null;
            }
            

            return xmlDataTable;

        }
  

        public void WriteLineInfoXMLFile(DataTable table)
        {
            try
            {
                this.mLineInfoDataSet.Tables.Add(table);
                this.mLineInfoDataSet.WriteXml(this.mLineInfoPath);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void WriteBMSInfoXMLFile(DataTable table)
        {
            try
            {
                mBMSInfoDataSet = new DataSet("BMSInfo");
                this.mBMSInfoDataSet.Tables.Add(table);
                this.mBMSInfoDataSet.WriteXml(this.mBMSInfoPath);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
