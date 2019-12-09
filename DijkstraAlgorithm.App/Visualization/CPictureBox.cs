namespace DijkstraAlgorithm.App.Visualization
{
    using System.Drawing;
    using System.Windows.Forms;
    using System.Drawing.Drawing2D;

    public class CPictureBox : PictureBox
    {
        protected override void OnPaint(PaintEventArgs pe)
        {
            pe.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Pen pen = new Pen(Color.FromArgb(217, 217, 217, 217));
            Rectangle rectangle = new Rectangle(0, 0, this.ClientSize.Width - 1, this.ClientSize.Height - 1);

            pe.Graphics.DrawRectangle(pen, rectangle);

            base.OnPaint(pe);
        }
    }
}
