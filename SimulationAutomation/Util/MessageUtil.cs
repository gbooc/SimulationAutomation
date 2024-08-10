using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimulationAutomation.Util
{
    public static class MessageUtil
    {
        /// <summary>
        /// Displays all errors in the error list as a message box.
        /// </summary>
        /// <param name="errorList"></param>
        public static void DisplayErrorList(string[] errorList)
        {
            try
            {
                // append the errors
                // limit is up to 20 errors only
                StringBuilder strBuilder = new StringBuilder();
                for (int i = 0; i < 20 && i < errorList.Length; i++)
                {
                    strBuilder.AppendLine(errorList[i]);
                }

                // append ellipsis if the number of errors is more than 20
                if (20 < errorList.Length)
                {
                    strBuilder.AppendLine("...");
                }

                // show the errors
                if (0 < strBuilder.Length)
                {
                    MessageBox.Show(strBuilder.ToString(),
                        Messages.ERROR_TITLE,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error,
                        MessageBoxDefaultButton.Button1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                        Messages.ERROR_TITLE,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Displays all errors in the error list as a message box.
        /// </summary>
        /// <param name="errorList"></param>
        public static void DisplayErrorList(List<string> errorList)
        {
            try
            {
                // append the errors
                // limit is up to 20 errors only
                StringBuilder strBuilder = new StringBuilder();
                for (int i = 0; i < 20 && i < errorList.Count; i++)
                {
                    strBuilder.AppendLine(errorList[i]);
                }

                // append ellipsis if the number of errors is more than 20
                if (20 < errorList.Count)
                {
                    strBuilder.AppendLine("...");
                }

                // show the errors
                if (0 < strBuilder.Length)
                {
                    MessageBox.Show(strBuilder.ToString(),
                        Messages.ERROR_TITLE,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                        Messages.ERROR_TITLE,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Shows error message.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="title"></param>
        public static void ShowError(string message, string title = "")
        {
            if (string.IsNullOrEmpty(title))
            {
                title = Messages.ERROR_TITLE;
            }

            MessageBox.Show(message,
                title,
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1);
        }

        /// <summary>
        /// Shows warning message.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="title"></param>
        public static void ShowWarning(string message, string title = "")
        {
            if (string.IsNullOrEmpty(title))
            {
                title = Messages.WARNING_TITLE;
            }

            MessageBox.Show(message,
                title,
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button1);
        }

        /// <summary>
        /// Shows info message.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="title"></param>
        public static void ShowInfo(string message, string title = "")
        {
            if (string.IsNullOrEmpty(title))
            {
                title = Messages.SUCESS_TITLE;
            }

            MessageBox.Show(message,
                title,
                MessageBoxButtons.OK,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1);
        }

        /// <summary>
        /// Shows confirmation message and returns the result
        /// </summary>
        /// <param name="message"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public static DialogResult Confirm(string message, string title,
            MessageBoxButtons buttons = MessageBoxButtons.YesNo,
            MessageBoxDefaultButton defaultButton = MessageBoxDefaultButton.Button1)
        {
            return MessageBox.Show(message,
                title,
                buttons,
                MessageBoxIcon.Question,
                defaultButton);
        }
    }
}
