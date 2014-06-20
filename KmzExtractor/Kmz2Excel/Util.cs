using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using ICSharpCode.SharpZipLib;
using ICSharpCode.SharpZipLib.Zip;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;
using System.Xml;
using WriteCsv;

namespace KmzExtractor
{
    class Util
    {
        public static String KMZ_EXTENSION = ".kmz";
        public static String CSV_EXTENSION = ".csv";
        public static String KMZ_FILE_TITLE = "Choose Kmz File";
        public static String EXCEL_FILE_TITLE = "Choose File Save Location";
        public static String INVALID_KMZ_FILE_ERROR = "Not Kmz File";
        public static String KMZ_NOT_EXISTS_ERROR = "Kmz File Not Exists";
        public static String INVALID_EXCEL_FILE_ERROR = "Should Save as CSV file";

        public static String KMZ_NOT_SELECTED = "No Kmz File Selected";
        public static String EXCEL_NOT_SELECTED =  "No Save Location Selected";
        public static String WORK_HARD_MSG = "Working Hard to Extract...";
        public static String UNKNOWN_ERROR = "Unknown Error";
        public static String SUCCESS_MSG = "Done";

        public static String CONVERTING_MSG = "Extracting From";
        public static String HARD_WORKING_MSG = "Working Hard to Extract...";

        private static String XML_COORDINATE_NAME = "coordinates";


        public static void setRichTextBoxColor(String msg, RichTextBox richTextBox)
        {
            richTextBox.AppendText(msg);
            int startIndex = richTextBox.Text.IndexOf(msg);
            int endIndex = msg.Length;
            richTextBox.Select(startIndex, endIndex);
            richTextBox.SelectionColor = Color.Red;
            richTextBox.Refresh();
        }

        private static void storeCoordinates(Stream stream, String saveFilePath, FileMode fileMode)
        {
            ArrayList coordinateList = new ArrayList();

            XmlTextReader xmlTextReader = new XmlTextReader(stream);
            while (xmlTextReader.Read())
            {
                if (xmlTextReader.NodeType == XmlNodeType.Element)
                {
                    if (xmlTextReader.Name.Equals(XML_COORDINATE_NAME, StringComparison.InvariantCultureIgnoreCase))
                    {
                        String coordinateText = xmlTextReader.ReadElementString().Trim();
                        if (coordinateText != null)
                        {
                            String[] coordinateArrays = coordinateText.Split();
                            foreach(String cooridinateInfo in coordinateArrays)
                            {
                                String[] coordinateItems = cooridinateInfo.Split(',');
                                if (coordinateItems.Length >= 2)
                                {
                                    Coordinate coordinate = new Coordinate(coordinateItems[0].Trim(), coordinateItems[1].Trim());
                                    coordinateList.Add(coordinate);
                                }
                            }
                        }
                    }
                }
            }

            CsvFileWriter csvFileWriter = new CsvFileWriter(saveFilePath, fileMode);
            foreach(Coordinate coordinate in coordinateList)
            {
                CsvRow row = new CsvRow();
                row.Add(coordinate.getLongitude());
                row.Add(coordinate.getLatitude());
                csvFileWriter.WriteRow(row);
            }
            csvFileWriter.releaseResource();
        }

        public static void startConvert(String kmzFilePath, String saveFilePath, FileMode fileMode)
        {
            if (!File.Exists(kmzFilePath))
                return;
            Stream kmlStream = null;

            FileStream inputStream = null;
            ZipFile zipFile = null;
            try
            {
                inputStream = File.OpenRead(kmzFilePath);
                zipFile = new ZipFile(inputStream);
                String fileExtension = null;
                foreach (ZipEntry zipEntry in zipFile)
                {
                    if (!zipEntry.IsFile)
                        continue;

                    String fileName = zipEntry.Name;
                    if (fileName != String.Empty)
                    {
                        fileExtension = Path.GetExtension(fileName);
                        if (fileExtension.Equals(".kml", StringComparison.InvariantCultureIgnoreCase))
                        {
                            kmlStream = zipFile.GetInputStream(zipEntry);
                            storeCoordinates(kmlStream, saveFilePath, fileMode);
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                
            }
            finally
            {
                if (zipFile != null)
                {
                    zipFile.IsStreamOwner = true;
                    zipFile.Close();
                }
            }
            
        }
    }
}


