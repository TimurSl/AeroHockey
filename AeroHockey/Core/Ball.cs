using AeroHockey.Settings;
using SFML.Graphics;
using SFML.System;

namespace AeroHockey.Core;

class Ball
{
	public Shape shape;
	public Vector2f position;
	public Vector2f velocity;

	private uint radius = 10;
	public Ball(float x, float y)
	{
		shape = new CircleShape(radius);
		shape.FillColor = Color.White;
		position = new Vector2f(x, y);
		shape.Position = position;
		velocity = new Vector2f(5, 5);
	}

	public void Update()
	{
		position += velocity;

		if (position.X < 0 || position.X > Config.WindowWidth)
		{
			velocity.X = -velocity.X;
		}

		if (position.Y < 0 || position.Y > Config.WindowHeight)
		{
			velocity.Y = -velocity.Y;
		}

		shape.Position = position;
	}

	public void Draw(RenderTarget target, RenderStates states)
	{
		target.Draw(shape);
	}
}