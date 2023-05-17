using AeroHockey.Core.Interfaces;
using AeroHockey.Core.Types;
using AeroHockey.Settings;
using SFML.Graphics;
using SFML.System;

namespace AeroHockey.Objects;

public class Wall : IDrawable
{
	public Shape Shape { get; set; }

	public Wall(Direction direction)
	{
		switch (direction)
		{
			case Direction.Up:
				Shape = new RectangleShape(new Vector2f(Config.WindowWidth, 10))
				{
					Position = new Vector2f(0, 0),
					FillColor = Color.Red
				};
				break;
			case Direction.Down:
				Shape = new RectangleShape(new Vector2f(Config.WindowWidth, 10))
				{
					Position = new Vector2f(0, Config.WindowHeight - 10),
					FillColor = Color.Red
				};
				break;
			case Direction.Left:
				Shape = new RectangleShape(new Vector2f(10, Config.WindowHeight))
				{
					Position = new Vector2f(0, 0),
					FillColor = Color.Yellow
				};
				break;
			case Direction.Right:
				Shape = new RectangleShape(new Vector2f(10, Config.WindowHeight))
				{
					Position = new Vector2f(Config.WindowWidth - 10, 0),
					FillColor = Color.Yellow
				};
				break;
			default:
				throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
		}
	}

	public void Draw(RenderTarget target)
	{
		target.Draw(Shape);
	}
}