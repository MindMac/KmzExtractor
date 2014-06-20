using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WriteCsv
{
    public class CsvRow : List<string>
    {
        public string LineText { get; set; }
    }


    /// Class to write data to a CSV file
    public class CsvFileWriter
    {
        private FileStream fileStream = null;
        private StreamWriter streamWriter = null;

        public CsvFileWriter(String fileName, FileMode writeMode)
        {
            fileStream = new FileStream(fileName, writeMode);
            streamWriter = new StreamWriter(fileStream);
        }

        public void WriteRow(CsvRow row)
        {
            StringBuilder builder = new StringBuilder();
            bool firstColumn = true;
            foreach (string value in row)
            {
                // Add separator if this isn't the first value
                if (!firstColumn)
                    builder.Append(',');
                // Implement special handling for values that contain comma or quote
                // Enclose in quotes and double up any double quotes
                if (value.IndexOfAny(new char[] { '"', ',' }) != -1)
                    builder.AppendFormat("\"{0}\"", value.Replace("\"", "\"\""));
                else
                    builder.Append(value);
                firstColumn = false;
            }
            row.LineText = builder.ToString();
            streamWriter.Write(row.LineText + Environment.NewLine);
        }

        public void releaseResource()
        {
            if (streamWriter != null)
            {
                streamWriter.Close();
            }
            if (fileStream != null)
            {
                fileStream.Close();
            }
            
        }
    }

}