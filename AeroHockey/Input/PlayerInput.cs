using AeroHockey.Settings;
using SFML.System;
using SFML.Window;

namespace AeroHockey.Input;

public class PlayerInput : IInput
{
	public float Speed = 5f;
	
	public Vector2f GetMovement(Vector2f position, Vector2f ballPosition)
	{
		var velocity = new Vector2f(0, 0);

		if (Keyboard.IsKeyPressed(Keyboard.Key.Left))
		{
			velocity.X = -Speed;
		}
		else if (Keyboard.IsKeyPressed(Keyboard.Key.Right))
		{
			velocity.X = Speed;
		}
		else if (Keyboard.IsKeyPressed(Keyboard.Key.Up))
		{
			velocity.Y = -Speed;
			if (position.Y < Config.WindowHeight * 0.5f) position.Y = Config.WindowHeight * 0.5f;
		}
		else if (Keyboard.IsKeyPressed(Keyboard.Key.Down))
		{
			velocity.Y = Speed;
			if (position.Y > Config.WindowHeight - Config.PlayerHeight)
				position.Y = Config.WindowHeight - Config.PlayerHeight;
		}

		position += velocity;

		if (position.X < 0)
			position.X = 0;
		else if (position.X > Config.WindowWidth - Config.PlayerWidth)
			position.X = Config.WindowWidth - Config.PlayerWidth;
		
		return position;
	}
}