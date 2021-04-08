using System;
using System.Drawing;

namespace Draw
{
	/// <summary>
	/// Класът правоъгълник е основен примитив, който е наследник на базовия Shape.
	/// </summary>
	public class Figura7 : Shape
	{
		#region Constructor

		public Figura7(RectangleF rect) : base(rect)
		{
		}

		public Figura7(RectangleShape rectangle) : base(rectangle)
		{
		}

		#endregion

		/// <summary>
		/// Проверка за принадлежност на точка point към правоъгълника.
		/// В случая на правоъгълник този метод може да не бъде пренаписван, защото
		/// Реализацията съвпада с тази на абстрактния клас Shape, който проверява
		/// дали точката е в обхващащия правоъгълник на елемента (а той съвпада с
		/// елемента в този случай).
		/// </summary>
		public override bool Contains(PointF point)
		{
			if (base.Contains(point))
				// Проверка дали е в обекта само, ако точката е в обхващащия правоъгълник.
				// В случая на правоъгълник - директно връщаме true
				return true;
			else
				// Ако не е в обхващащия правоъгълник, то неможе да е в обекта и => false
				return false;
		}

		/// <summary>
		/// Частта, визуализираща конкретния примитив.
		/// </summary>
		public override void DrawSelf(Graphics grfx)
		{
			base.DrawSelf(grfx);
			base.RotateShape(grfx);

			grfx.FillEllipse(new SolidBrush(Color.FromArgb(Opacity, FillColor)), Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height);
			grfx.DrawEllipse(new Pen(BorderColor, BorderWidth), Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height);


			Point[] one = {
				new Point((int)(Rectangle.X + 50), (int)Rectangle.Y),
				new Point((int)(Rectangle.X + 50), (int)(Rectangle.Y+Rectangle.Height))};
			grfx.DrawLines(new Pen(BorderColor), one);

			//lqv dolen radius
			Point[] two = {
				new Point((int)(Rectangle.X + Rectangle.Width), (int)Rectangle.Bottom-50),
				new Point((int)(Rectangle.X + Rectangle.Width-50), (int)(Rectangle.Y+Rectangle.Height-50))};
			grfx.DrawLines(new Pen(BorderColor), two);


			//desen dolen radius
			Point[] three = {
				new Point((int)(Rectangle.X + Rectangle.Width -50), (int)Rectangle.Bottom - 50),
				new Point((int)(Rectangle.X + Rectangle.Width - 100), (int)(Rectangle.Y +75))};
			grfx.DrawLines(new Pen(BorderColor), three);

			Point[] four = {
				new Point((int)(Rectangle.X+90), (int)Rectangle.Y+100),
				new Point((int)(Rectangle.X+10), (int)Rectangle.Y +100)};
			grfx.DrawLines(new Pen(BorderColor), four);



		}
	}
}
