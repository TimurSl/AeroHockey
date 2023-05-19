using AeroHockey.Core.Interfaces;
using AeroHockey.Input;
using AeroHockey.Input.Interfaces;
using AeroHockey.Settings;
using SFML.Graphics;
using SFML.System;

namespace AeroHockey.Objects;

public class Player : IDrawable, IUpdatable
{
	public Vector2f Position;
	public Shape Shape { get; set; }
	
	private uint score;
	
	private readonly PlayerText scoreText;
	private readonly IInput input;

	public Player(float x, float y, IInput input)
	{
		Position = new Vector2f(x, y);

		Shape = new RectangleShape(new Vector2f(Config.PlayerWidth, Config.PlayerHeight))
		{
			Position = Position,
			FillColor = Color.White
		};

		scoreText = new PlayerText(score.ToString(), new Vector2f(Position.X, Position.Y - Config.PlayerHeight - 10));
		
		this.input = input;
	}

	public void Update(Vector2f ballPosition)
	{
		var movement = input.GetMovement (Position, ballPosition);
		Position = movement;
		Shape.Position = Position;
	}
	
	public void AddScore()
	{
		score++;
	}

	public void Draw(RenderTarget target)
	{
		target.Draw(Shape);
		scoreText.Draw(target);
	}

	public void Update()
	{
		scoreText.Update(score.ToString(), new Vector2f(Position.X, Position.Y - Config.PlayerHeight - 10));
	}
}