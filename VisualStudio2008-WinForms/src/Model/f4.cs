using System;
using System.Drawing;

namespace Draw
{
	/// <summary>
	/// Класът правоъгълник е основен примитив, който е наследник на базовия Shape.
	/// </summary>
	public class f4 : Shape
	{
		#region Constructor

		public f4(RectangleF rect) : base(rect)
		{
		}

		public f4(RectangleShape rectangle) : base(rectangle)
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

			grfx.FillRectangle(new SolidBrush(Color.FromArgb(Opacity, FillColor)), Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height);
			grfx.DrawRectangle(new Pen(BorderColor, BorderWidth), Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height);

			Point[] one = {
                new Point((int)(Rectangle.X + 100), (int)Rectangle.Y+50),
                new Point((int)(Rectangle.X + Rectangle.Width + 200), (int)(Rectangle.Bottom + 100))};
            grfx.DrawLines(new Pen(BorderColor), one);
            //lqv dolen radius
            Point[] two = {
                new Point((int)(Rectangle.X + 100), (int)Rectangle.Y+50),
                new Point((int)(Rectangle.X + Rectangle.Width  - 600 ), (int)(Rectangle.Bottom + 200))};
            grfx.DrawLines(new Pen(BorderColor), two);




		//	Point[] one = {
			//	new Point((int)(Rectangle.X + 100), (int)Rectangle.Y+50),
				//new Point((int)(Rectangle.X + Rectangle.Width - 200), (int)(Rectangle.Bottom - 100))};
	//		grfx.DrawLines(new Pen(BorderColor), one);
		//	//desen radius
			//Point[] two = {
				// new Point((int)(Rectangle.X + 100), (int)Rectangle.Y + 50),
				//new Point((int)(Rectangle.X + Rectangle.Width - 0), (int)(Rectangle.Bottom - 50))};
			//grfx.DrawLines(new Pen(BorderColor), two);//
			//desen dolen radius
			//Point[] three = {
				//new Point((int)(Rectangle.X + Rectangle.Width -100), (int)Rectangle.Bottom - 50),
				//new Point((int)(Rectangle.X + Rectangle.Width - 100), (int)(Rectangle.Y + 100))};
			//grfx.DrawLines(new Pen(BorderColor), three);





		}
	}
}
