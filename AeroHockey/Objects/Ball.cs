using AeroHockey.Core.Interfaces;
using AeroHockey.Settings;
using SFML.Graphics;
using SFML.System;

namespace AeroHockey.Objects;

internal class Ball : IDrawable, IUpdatable
{
	public Vector2f Position;
	public Vector2f Velocity;

	public readonly uint radius = 10;
	public Shape Shape { get; set; }

	private Random random = new();

	public Ball(float x, float y)
	{
		Position = new Vector2f(x, y);

		Shape = new CircleShape(radius)
		{
			Position = Position,
			Origin = new Vector2f(radius, radius),
			FillColor = Color.Blue
		};

		Velocity = new Vector2f(5, 5);
	}

	public void Update()
	{
		Position += Velocity;

		if (Position.X < radius || Position.X > Config.WindowWidth)
		{
			Velocity.X = -Velocity.X;
		}

		if (Position.Y < radius || Position.Y > Config.WindowHeight)
		{
			Velocity.Y = -Velocity.Y * 1.02f;
		}


		if (Position.Y > Config.WindowHeight)
			Position.Y = Config.WindowHeight;
		else if (Position.Y < 0) 
			Position.Y = 0;
		
		if (Position.X > Config.WindowWidth)
			Position.X = Config.WindowWidth;
		else if (Position.X < 0) 
			Position.X = 0;

		Shape.Position = Position;
	}

	public void Update(Vector2f ballPosition)
	{
		
	}
	
	public void Draw(RenderTarget target)
	{
		target.Draw(Shape);
	}
}