using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Draw
{
	/// <summary>
	/// Върху главната форма е поставен потребителски контрол,
	/// в който се осъществява визуализацията
	/// </summary>
	public partial class MainForm : Form
	{
		/// <summary>
		/// Агрегирания диалогов процесор във формата улеснява манипулацията на модела.
		/// </summary>
		private DialogProcessor dialogProcessor = new DialogProcessor();
		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}

		/// <summary>
		/// Изход от програмата. Затваря главната форма, а с това и програмата.
		/// </summary>
		void ExitToolStripMenuItemClick(object sender, EventArgs e)
		{
			Close();
		}
		
		/// <summary>
		/// Събитието, което се прихваща, за да се превизуализира при изменение на модела.
		/// </summary>
		void ViewPortPaint(object sender, PaintEventArgs e)
		{
			dialogProcessor.ReDraw(sender, e);
		}
		
		/// <summary>
		/// Бутон, който поставя на произволно място правоъгълник със зададените размери.
		/// Променя се лентата със състоянието и се инвалидира контрола, в който визуализираме.
		/// </summary>
		void DrawRectangleSpeedButtonClick(object sender, EventArgs e)
		{
			dialogProcessor.AddRandomRectangle();
			
			statusBar.Items[0].Text = "Последно действие: Рисуване на правоъгълник";
			
			viewPort.Invalidate();
		}

		/// <summary>
		/// Прихващане на координатите при натискането на бутон на мишката и проверка (в обратен ред) дали не е
		/// щракнато върху елемент. Ако е така то той се отбелязва като селектиран и започва процес на "влачене".
		/// Промяна на статуса и инвалидиране на контрола, в който визуализираме.
		/// Реализацията се диалогът с потребителя, при който се избира "най-горния" елемент от екрана.
		/// </summary>
		void ViewPortMouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{

			if (pickUpSpeedButton.Checked)
			{
				var sel = dialogProcessor.ContainsPoint(e.Location);

				if (sel != null)
				{
					if (dialogProcessor.Selection.Contains(sel))
						dialogProcessor.Selection.Remove(sel);
					else
						dialogProcessor.Selection.Add(sel);

					statusBar.Items[0].Text = "Последно действие: Селекция на примитив";
					dialogProcessor.IsDragging = true;
					dialogProcessor.LastLocation = e.Location;
					viewPort.Invalidate();
				}
			}
		}

		/// <summary>
		/// Прихващане на преместването на мишката.
		/// Ако сме в режм на "влачене", то избрания елемент се транслира.
		/// </summary>
		void ViewPortMouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (dialogProcessor.IsDragging) {
				if (dialogProcessor.Selection != null) statusBar.Items[0].Text = "Последно действие: Влачене";
				dialogProcessor.TranslateTo(e.Location);
				viewPort.Invalidate();
			}
		}

		/// <summary>
		/// Прихващане на отпускането на бутона на мишката.
		/// Излизаме от режим "влачене".
		/// </summary>
		void ViewPortMouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			dialogProcessor.IsDragging = false;
		}

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
			dialogProcessor.AddRandomEllipse();
			statusBar.Items[0].Text = "Последно действие: Рисуване на Елипса";

			viewPort.Invalidate();
		}

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
			dialogProcessor.AddRandomTriangle();

			statusBar.Items[0].Text = "Последно действие: Рисуване на триъгълник";

			viewPort.Invalidate();
		}

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
			dialogProcessor.SetOpacity(trackBar1.Value);
			statusBar.Items[0].Text = "Последно действие: Добавяне на прозрачност";
			viewPort.Invalidate();
		}

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
			dialogProcessor.SetBorderWidth((float)trackBar2.Value);
			statusBar.Items[0].Text = "Последно действие: Промяна на дебелината на линията";
			viewPort.Invalidate();
		}

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
			dialogProcessor.Rotate((float)trackBar3.Value);
			statusBar.Items[0].Text = "Действие завъртане";
			viewPort.Invalidate();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
			dialogProcessor.AddRandomRec();

			statusBar.Items[0].Text = "Последно действие: Рисуване на нов примитив!";

			viewPort.Invalidate();
		}

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
			dialogProcessor.AddRandomFigura4();

			statusBar.Items[0].Text = "Последно действие: Рисуване на нов примитив!";

			viewPort.Invalidate();

		}

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
			dialogProcessor.AddRandomFigura7();

			statusBar.Items[0].Text = "Последно действие: Рисуване на нов примитив!";

			viewPort.Invalidate();
		}

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
			dialogProcessor.AddRandomLine();

			statusBar.Items[0].Text = "Последно действие: Рисуване на нов примитив!";

			viewPort.Invalidate();
		}

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
			dialogProcessor.AddRandomf4();

			statusBar.Items[0].Text = "Последно действие: Рисуване на нов примитив!";

			viewPort.Invalidate();
		}
    }
}
