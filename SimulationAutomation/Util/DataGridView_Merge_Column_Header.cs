using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimulationAutomation.Util
{
    class DataGridView_Merge_Column_Header
    {
        #region
        public class MultiHeader
        {
            public string Text { get; set; }
            public int FirstColumn { get; set; }
            public int LastColumn { get; set; }
            public int Level { get; set; }
            public Color BackColor { get; set; }
            public Color ForeColor { get; set; }
            public Font Font { get; set; }
        }

        public class MultiHeaderRenderer
        {
            private List<MultiHeader> headers;
            private int levels;

            private int hdrHeight;
            public MultiHeaderRenderer(System.Windows.Forms.DataGridView dgv, List<MultiHeader> topHeaders)
            {
                headers = topHeaders;
                levels = (from h in topHeaders select h.Level).Max() + 2;
                hdrHeight = 20;// dgv.ColumnHeadersHeight;
                dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
                dgv.ColumnHeadersHeight = hdrHeight * levels;
                dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
                dgv.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dgv.Paint += DGV_Paint;
                dgv.Scroll += DGV_Scroll;
                dgv.ColumnWidthChanged += DGV_ColumnWidthChanged;
            }

            private void DGV_ColumnWidthChanged(object sender, System.Windows.Forms.DataGridViewColumnEventArgs e)
            {
                RefreshTop((System.Windows.Forms.DataGridView)sender);
            }

            private void DGV_Scroll(object sender, System.Windows.Forms.ScrollEventArgs e)
            {
                RefreshTop((System.Windows.Forms.DataGridView)sender);
            }

            private void RefreshTop(System.Windows.Forms.DataGridView dgv)
            {
                var rtTop = dgv.DisplayRectangle;
                rtTop.Height = hdrHeight * (levels - 1);
                dgv.Invalidate(rtTop, true);
            }

            private void DGV_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
            {
                try
                {
                    var dgv = (System.Windows.Forms.DataGridView)sender;
                    foreach (MultiHeader h in headers)
                    {
                        int firstIdx = dgv.FirstDisplayedCell.ColumnIndex;
                        if (firstIdx > h.LastColumn) continue;
                        int idx = Math.Max(firstIdx, h.FirstColumn);
                        Rectangle cellRect = dgv.GetCellDisplayRectangle(idx, -1, true);
                        int w = 0;
                        for (int i = idx; i <= h.LastColumn; i++)
                        {
                            w += dgv.GetCellDisplayRectangle(i, -1, true).Width;
                        }
                        //Rectangle rc = new Rectangle(cellRect.Left + 1, h.Level * hdrHeight + 1, w - 2, hdrHeight - 2);
                        Rectangle rc = new Rectangle(cellRect.Left + 1, h.Level * 0/*hdrHeight */+ 1, w - 2, hdrHeight - 2);
                        var hdrStyle = dgv.ColumnHeadersDefaultCellStyle;
                        Color clr = h.ForeColor.IsEmpty ? hdrStyle.ForeColor : h.ForeColor;
                        Color bkClr = h.BackColor.IsEmpty ? hdrStyle.BackColor : h.BackColor;
                        Font fnt = h.Font == null ? hdrStyle.Font : h.Font;
                        StringFormat format = new StringFormat
                        {
                            Alignment = StringAlignment.Center,
                            LineAlignment = StringAlignment.Center
                        };
                        e.Graphics.FillRectangle(new SolidBrush(bkClr), rc);
                        e.Graphics.DrawString(h.Text, fnt, new SolidBrush(clr), rc, format);
                        rc.Inflate(0, 1);
                        e.Graphics.DrawRectangle(Pens.Black, rc);
                    }
                }
                catch { }
            }
        }
    }
        #endregion
}