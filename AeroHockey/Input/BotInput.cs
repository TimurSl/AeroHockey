using AeroHockey.Settings;
using SFML.System;

namespace AeroHockey.Input;

public class BotInput : IInput
{
	private Random random = new();

	public Vector2f GetMovement(Vector2f position, Vector2f ballPosition)
	{
		float randomValue = (float) random.Next(7, 8) / 10;
		
		position.X = ballPosition.X / randomValue - Config.PlayerWidth / 2;
		
		if (position.X < 0)
			position.X = 0;
		else if (position.X > Config.WindowWidth - Config.PlayerWidth)
			position.X = Config.WindowWidth - Config.PlayerWidth;

		return position;
	}
}