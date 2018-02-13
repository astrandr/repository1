using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataGridView
{
    public partial class Form1 : Form
    {

        Rectangle buttonRectangle = Rectangle.Empty;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.SuspendLayout();
            int tickStart = Environment.TickCount;
            for (int i = 0; i < 400; i++)
            {
                DataRow newRow = dataTable1.NewRow();
                newRow["X"] = 1;
                newRow["Y"] = 1;
                dataTable1.Rows.Add(newRow);
            }
            int tickEnd = Environment.TickCount;
            int tickSpam = tickEnd - tickStart;

            dataGridView1.ResumeLayout();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.SuspendLayout();
            dataGridView1.DataSource = null;
            int tickStart = Environment.TickCount;
            for (int i = 0; i < 400; i++)
            {
                dataGridView1.Rows.Add(new float[] { 1, 1 });
            }
            int tickEnd = Environment.TickCount;
            int tickSpam = tickEnd - tickStart;

            dataGridView1.ResumeLayout();
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == -1)
            {
                e.Graphics.FillRectangle(
                        new LinearGradientBrush(
                            new Point(e.CellBounds.Left, e.CellBounds.Top),
                            new Point(e.CellBounds.Left, e.CellBounds.Bottom),
                            Color.FromArgb(255, 160, 160, 160),
                            Color.FromArgb(255, 190, 190, 190)
                            ),
                            e.CellBounds);
                if (e.RowIndex >= 0)
                {
                    e.Graphics.DrawString((e.RowIndex + 1).ToString(), new Font("Arial", 10), new SolidBrush(Color.Black),
                                            e.CellBounds.Right - e.Graphics.MeasureString((e.RowIndex + 1).ToString(), new Font("Arial", 10)).Width-4,
                                            (e.CellBounds.Top + e.CellBounds.Bottom) / 2 - e.Graphics.MeasureString(e.ColumnIndex.ToString(), new Font("Arial", 10)).Height / 2);
                }
                else
                {
                    e.Graphics.DrawString("Row", new Font("Arial", 10), new SolidBrush(Color.Black),
                                            e.CellBounds.Right - e.Graphics.MeasureString("Row", new Font("Arial", 10)).Width-4,
                                            (e.CellBounds.Top + e.CellBounds.Bottom) / 2 - e.Graphics.MeasureString(e.ColumnIndex.ToString(), new Font("Arial", 10)).Height / 2);
                }
            }
            else
                if (e.RowIndex == -1)
                {
                    e.Graphics.FillRectangle(
                            new LinearGradientBrush(
                                new Point(e.CellBounds.Left, e.CellBounds.Top),
                                new Point(e.CellBounds.Left, e.CellBounds.Bottom),
                                Color.FromArgb(255, 180, 180, 180),
                                Color.FromArgb(255, 220, 220, 220)
                                ),
                                e.CellBounds);
                }
            else
                if (e.State.HasFlag(DataGridViewElementStates.Selected))
                {
                    e.Graphics.FillRectangle(
                        new LinearGradientBrush(
                            new Point(e.CellBounds.Left, e.CellBounds.Top),
                            new Point(e.CellBounds.Left, e.CellBounds.Bottom),
                            Color.FromArgb(255, 200, 200, 250),
                            Color.FromArgb(255, 190, 190, 250)
                            ),
                            e.CellBounds);
                }
                else
                {
                    e.Graphics.FillRectangle(
                        new LinearGradientBrush(
                            new Point(e.CellBounds.Left, e.CellBounds.Top),
                            new Point(e.CellBounds.Left, e.CellBounds.Bottom),
                            Color.FromArgb(255, 240, 240, 240),
                            Color.FromArgb(255, 250, 250, 250)),
                            e.CellBounds);
                }
            Rectangle cellRect = e.CellBounds;  cellRect.Offset(-1, -1);

            e.Graphics.DrawRectangle(new Pen(Color.DarkGray, 2), cellRect);
            cellRect.Inflate(-1, -1);
            e.Graphics.DrawRectangle(new Pen(Color.Black, 1), cellRect);
            e.PaintContent(e.CellBounds);
            e.Handled = true;
        }

        private void button1_Paint(object sender, PaintEventArgs e)
        {

            buttonRectangle = e.ClipRectangle;

            e.Graphics.FillRectangle(new LinearGradientBrush(
                                                            new Point(e.ClipRectangle.Left, e.ClipRectangle.Top),
                                                            new Point(e.ClipRectangle.Left, e.ClipRectangle.Bottom),
                                                            Color.FromArgb(255, 180, 180, 180),
                                                            Color.FromArgb(255, 220, 220, 220)), e.ClipRectangle);
            e.Graphics.DrawRectangle(new Pen(Color.Gray, 2), e.ClipRectangle);
            buttonRectangle.Offset(-1, -1);
            e.Graphics.DrawRectangle(new Pen(Color.Gray, 1), buttonRectangle);
            e.Graphics.DrawString("Calculate",
                                    new Font("Arial", 11, FontStyle.Bold | FontStyle.Italic),
                                    new SolidBrush(Color.FromArgb(255, 80, 80, 80)),
                                    new Point(e.ClipRectangle.Left + 8, e.ClipRectangle.Top + 3));
            buttonRectangle.Offset(1, 1);
        }

        private void button1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            Graphics buttonGraphics = this.button1.CreateGraphics();
            buttonGraphics.FillRectangle(new LinearGradientBrush(
                                                            new Point(buttonRectangle.Left, buttonRectangle.Top),
                                                            new Point(buttonRectangle.Left, buttonRectangle.Bottom),
                                                            Color.FromArgb(255, 200, 200, 200),
                                                            Color.FromArgb(255, 250, 250, 250)), buttonRectangle);
            buttonGraphics.DrawLine(new Pen(Color.Gray, 2), buttonRectangle.Left + 2, buttonRectangle.Bottom - 1, buttonRectangle.Right, buttonRectangle.Bottom - 1);
            buttonGraphics.DrawLine(new Pen(Color.Gray, 2), buttonRectangle.Right - 1, buttonRectangle.Bottom, buttonRectangle.Right - 1, buttonRectangle.Top + 2);
            buttonGraphics.DrawString("Calculate",
                                    new Font("Arial", 11, FontStyle.Bold | FontStyle.Italic),
                                    new SolidBrush(Color.FromArgb(255, 20, 20, 20)),
                                    new Point(buttonRectangle.Left + 8, buttonRectangle.Top + 3));
        }


        private void dataGridView1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyValue == 46 && dataGridView1.CurrentCell != null && dataGridView1.CurrentCell.RowIndex < dataGridView1.Rows.Count-1)
            {
                dataGridView1.Rows.RemoveAt(dataGridView1.CurrentCell.RowIndex);
            }
        }
    }
}
