using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimulationAutomation.Util
{
    public static class CommonUtil
    {
        /// <summary>
        /// Draws parent header in dataGridView.
        /// </summary>
        /// <param name="columnIndex">Start/beginning col index(from datagridview) of where to paint the parent header.</param>
        /// <param name="headerText">Parent header title/text.</param>
        /// <param name="e">Paint event args.</param>
        /// <param name="datagrid">Datagridview to paint.</param>
        /// <param name="addIndex">Number of columns to be painted.</param>
        /// <param name="rowIndex">Row index(from datagridview) of where to paint the parent header.</param>
        public static void DrawRectangle(int columnIndex, string headerText, PaintEventArgs e, DataGridView datagrid, int addIndex = 2, int rowIndex = -1)
        {
            StringFormat format = new StringFormat();
            int width = 0;
            int startingColumn = -1;

            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Center;

            for (int i = columnIndex; i < columnIndex + addIndex; i++)
            {
                width += datagrid.GetColumnDisplayRectangle(i, true).Width;

                if (startingColumn == -1 && width > 0)
                {
                    startingColumn = i;
                }
            }

            if (width > 3)
            {
                Rectangle rect = datagrid.GetCellDisplayRectangle(startingColumn, rowIndex, true);
                rect.X += 1;
                rect.Y += 1;
                rect.Width = width - 3;
                rect.Height = (datagrid.GetCellDisplayRectangle(startingColumn, rowIndex, true).Height) / 2;

                e.Graphics.FillRectangle(
                    new SolidBrush(datagrid.ColumnHeadersDefaultCellStyle.BackColor),
                    rect);
                e.Graphics.DrawString(headerText,
                    datagrid.DefaultCellStyle.Font,
                    new SolidBrush(datagrid.ColumnHeadersDefaultCellStyle.ForeColor),
                    rect, format);

                // draw bottom border and top border
                // transparent border for left and right
                ControlPaint.DrawBorder(e.Graphics, rect,
                    Color.Transparent, 0, ButtonBorderStyle.None,
                    datagrid.GridColor, 1, ButtonBorderStyle.Solid,
                    Color.Transparent, 0, ButtonBorderStyle.None,
                    datagrid.GridColor, 1, ButtonBorderStyle.Solid);
            }
        }

        /// <summary>
        /// Minimizes flicker when repainting the headers.
        /// </summary>
        /// <param name="datagrid">Datagridview to invoke double buffer</param>
        public static void InvokeDgvDoubleBuffered(DataGridView datagrid)
        {
            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.SetProperty, null,
            datagrid, new object[] { true });
        }
    }
}
