using AeroHockey.Input;
using AeroHockey.Settings;
using SFML.Graphics;
using SFML.System;

namespace AeroHockey.Core.Types;

public class Player
{
	public Vector2f Position;
	public readonly RectangleShape Shape;

	private uint score;
	private readonly Text scoreText;
	private IInput input;

	public Player(float x, float y, IInput input)
	{
		Position = new Vector2f(x, y);

		Shape = new RectangleShape(new Vector2f(Config.PlayerWidth, Config.PlayerHeight))
		{
			Position = Position,
			FillColor = Color.White
		};

		var font = new Font("C:\\Windows\\Fonts\\arial.ttf");
		scoreText = new Text(score.ToString (), font, 20)
		{
			Position = new Vector2f(Position.X, Position.Y - Config.PlayerHeight - 10),
			FillColor = Color.Green
		};
		
		this.input = input;
	}

	public void Update(Vector2f ballPosition)
	{
		var movement = input.GetMovement (Position, ballPosition);
		Position = movement;
		Shape.Position = Position;
		
		scoreText.Position = new Vector2f(Position.X, Position.Y - Config.PlayerHeight - 10);
		scoreText.DisplayedString = score.ToString ();
	}
	
	public void AddScore()
	{
		score++;
	}


	public void Draw(RenderTarget target, RenderStates states)
	{
		target.Draw(Shape);
		target.Draw(scoreText);
	}

}