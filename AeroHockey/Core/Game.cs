using AeroHockey.Core.Types;
using AeroHockey.Input;
using AeroHockey.Settings;
using SFML.Graphics;
using SFML.Window;

namespace AeroHockey.Core;

internal class Game
{
	private readonly Ball ball;
	private readonly Player bot;
	private readonly Player player;
	private readonly RenderWindow window;

	public Game(GameLaunchParams @params)
	{
		window = new RenderWindow(new VideoMode(@params.Width, @params.Height), @params.Title);
		window.SetVerticalSyncEnabled(true);
		window.SetFramerateLimit(60);

		ball = new Ball(@params.Width / 2, @params.Height / 2);
		
		player = new Core.Types.Player(
			@params.Width / 4, 
			@params.Height - Config.PlayerHeight - 30, 
			new PlayerInput ());
		
		bot = new Core.Types.Player(
			@params.Width * 3 / 4 - Config.PlayerWidth, 
			30, 
			new BotInput ());
	}

	public void Run()
	{
		window.Closed += (sender, e) => window.Close ();
		while (window.IsOpen)
		{
			window.DispatchEvents ();
			window.Clear(Color.Black);

			ball.Draw(window, RenderStates.Default);
			ball.Update ();

			player.Draw(window, RenderStates.Default);
			player.Update (ball.position);

			bot.Draw(window, RenderStates.Default);
			bot.Update(ball.position);

			if (CheckCollision(ball.shape, player.Shape))
			{
				ball.velocity.Y = -ball.velocity.Y;
				ball.position.Y = player.Position.Y - ball.shape.Radius;
				ball.velocity.X = (ball.position.X - player.Position.X) / 10;
			}

			if (CheckCollision(ball.shape, bot.Shape))
			{
				ball.velocity.Y = -ball.velocity.Y;
				ball.position.Y = bot.Position.Y + Config.PlayerHeight + ball.shape.Radius;
				ball.velocity.X = (ball.position.X - bot.Position.X) / 10;
			}

			if (ball.shape.Position.Y < ball.shape.Radius)
				player.AddScore ();
			else if (ball.shape.Position.Y > window.Size.Y - ball.shape.Radius) bot.AddScore ();

			window.Display ();
		}
	}

	private bool CheckCollision(Shape shape1, Shape shape2)
	{
		var rect1 = shape1.GetGlobalBounds ();
		var rect2 = shape2.GetGlobalBounds ();

		return rect1.Intersects(rect2);
	}
}