using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Velarde.DatabaseApplication
{
    class ErrorLogger
    {
        //constructor-----------------------------------------------------------------------------
        public ErrorLogger()
        { }
        //constructor-----------------------------------------------------------------------------

        //==========================================================================================================================
        //METHODS
        //==========================================================================================================================

        /// <summary>
        /// Appends a detailed message to a log.txt file that describes the error that occurred. 
        /// These details include the Inner Exception, Target Site, Message, Stack Trace, Source, 
        /// and a help link.
        /// </summary>
        /// <author>Adrian Velarde</author>
        /// <date>September 13, 2015</date>
        /// <param name="date">Usually passed as 'DateTime.Now' to specify the exact time the error
        /// occurred</param>
        /// <param name="x">The exception that was thrown to gather detailed information about it.
        /// </param>
        /// <param name="errorMsg">Opportunity to provide a custom error message to present to the
        /// user, or to provide the System message.</param>
        public void logError(DateTime date, Exception x, string errorMsg)
        {
            MessageBox.Show(String.Format("{0}\nCheck \"log.txt\" for details.\n\n...\\bin\\Debug\\log.txt", errorMsg), "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            string logFileName = "log.txt";
            StringBuilder sb = new StringBuilder();
            StreamWriter sw = null;

            sb.AppendLine(date.ToString());
            sb.AppendLine(String.Format("Exception Type: {0}", x.InnerException));
            sb.AppendLine(String.Format("Occurred in method: {0}", x.TargetSite));
            sb.AppendLine(String.Format("Error Message: {0}", x.Message));
            sb.AppendLine(String.Format("Stack Trace: {0}", x.StackTrace));
            sb.AppendLine(String.Format("Source: {0}", x.Source));
            sb.AppendLine(String.Format("Find help at: {0}", x.HelpLink));
            sb.AppendLine("");

            try
            {
                if (!File.Exists(logFileName))
                {
                    // Create a file to write to
                    using (sw = File.CreateText(logFileName))
                    { sw.WriteLine(sb.ToString()); }
                }
                else using (sw = File.AppendText(logFileName))
                    { sw.WriteLine(sb.ToString()); }
            }
            catch (Exception ex)    //do NOT call logError in this Exception. Will cause endless loop
            { MessageBox.Show(String.Format("Error writing to log file.\n{0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
            finally
            {
                if (sw != null)
                { sw.Close(); }
            }
        }

        /// <summary>
        /// Deletes the log file
        /// </summary>
        /// <author>Adrian Velarde</author>
        /// <date>September 13, 2015</date>
        /// <param name="date">Usually passed as 'DateTime.Now' to specify the exact time the error
        /// occurred</param>
        /// <param name="x">The exception that was thrown to gather detailed information about it.
        /// </param>
        /// <param name="errorMsg">Opportunity to provide a custom error message to present to the
        /// user, or to provide the System message.</param>
        public void purgeLogFile()
        {
            MessageBox.Show(String.Format("{0}\nCheck \"log.txt\" for details.\n\n...\\bin\\Debug\\log.txt", errorMsg), "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            string logFileName = "log.txt";
            StringBuilder sb = new StringBuilder();
            StreamWriter sw = null;

            sb.AppendLine(date.ToString());
            sb.AppendLine(String.Format("Exception Type: {0}", x.InnerException));
            sb.AppendLine(String.Format("Occurred in method: {0}", x.TargetSite));
            sb.AppendLine(String.Format("Error Message: {0}", x.Message));
            sb.AppendLine(String.Format("Stack Trace: {0}", x.StackTrace));
            sb.AppendLine(String.Format("Source: {0}", x.Source));
            sb.AppendLine(String.Format("Find help at: {0}", x.HelpLink));
            sb.AppendLine("");

            try
            {
                if (!File.Exists(logFileName))
                {
                    // Create a file to write to
                    using (sw = File.CreateText(logFileName))
                    { sw.WriteLine(sb.ToString()); }
                }
                else using (sw = File.AppendText(logFileName))
                    { sw.WriteLine(sb.ToString()); }
            }
            catch (Exception ex)    //do NOT call logError in this Exception. Will cause endless loop
            { MessageBox.Show(String.Format("Error writing to log file.\n{0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
            finally
            {
                if (sw != null)
                { sw.Close(); }
            }
        }
    }
}
