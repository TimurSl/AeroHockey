using AeroHockey.Settings;
using SFML.Graphics;
using SFML.System;

namespace AeroHockey.Core;

internal class Ball
{
	public Vector2f position;

	private readonly uint radius = 10;
	private Random random = new();
	public CircleShape shape;
	public Vector2f velocity;

	public Ball(float x, float y)
	{
		position = new Vector2f(x, y);

		shape = new CircleShape(radius)
		{
			Position = position,
			Origin = new Vector2f(radius, radius),
			FillColor = Color.Blue
		};

		velocity = new Vector2f(5, 5);
	}

	public void Update()
	{
		position += velocity;

		if (position.X < radius || position.X > Config.WindowWidth) velocity.X = -velocity.X;

		if (position.Y < radius || position.Y > Config.WindowHeight) velocity.Y = -velocity.Y * 1.02f;


		if (position.Y > Config.WindowHeight)
			position.Y = Config.WindowHeight;
		else if (position.Y < 0) position.Y = 0;

		shape.Position = position;
	}

	public void Draw(RenderTarget target, RenderStates states)
	{
		target.Draw(shape);
	}
}