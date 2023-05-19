using AeroHockey.Core.Interfaces;
using AeroHockey.Core.Types;
using AeroHockey.Input;
using AeroHockey.Objects;
using AeroHockey.Settings;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace AeroHockey.Core;

internal class Game
{
	private readonly Ball ball;
	private readonly Player bot;
	private readonly Player player;
	private readonly RenderWindow window;
	private readonly Random random = new();

	private List<IDrawable?> drawables = new();
	private List<IUpdatable?> updatables = new();

	public Game(GameLaunchParams @params)
	{
		window = new RenderWindow(new VideoMode(@params.Width, @params.Height), @params.Title);
		window.SetVerticalSyncEnabled(true);
		window.SetFramerateLimit(60);

		ball = new Ball(@params.Width / 2, @params.Height / 2);

		player = new Player(@params.Width / 4, @params.Height - Config.PlayerHeight - 50, new PlayerInput ());
		bot = new Player(@params.Width * 3 / 4 - Config.PlayerWidth, 50, new BotInput ());
		
		CreateObject(player, player);
		CreateObject(bot, bot);
		CreateObject(ball, ball);

		Direction[] directions = { Direction.Up, Direction.Down };
		
		for (var i = 0; i < directions.Length; i++)
		{
			CreateObject(new Wall(directions[i]));
		}
	}

	public void Run()
	{
		window.Closed += (sender, e) => window.Close ();
		while (window.IsOpen)
		{
			window.DispatchEvents ();
			window.Clear(Color.Black);
			
			DrawObjects ();
			UpdateObjects ();
			
			if (CheckCollision(ball.Shape, player.Shape)) // Player
			{
				ball.Velocity.Y = -ball.Velocity.Y;
				ball.Position.Y = player.Position.Y - ball.radius;
				ball.Velocity.X = (ball.Position.X - player.Position.X) / 10;
			}

			if (CheckCollision(ball.Shape, bot.Shape)) // Bot
			{
				ball.Velocity.Y = -ball.Velocity.Y;
				ball.Position.Y = bot.Position.Y + Config.PlayerHeight + ball.radius;
				ball.Velocity.X = (ball.Position.X - bot.Position.X) / 10;
			}

			if (ball.Shape.Position.Y < ball.radius)
			{
				player.AddScore ();
				RespawnBall (1);
			}
			else if (ball.Shape.Position.Y > window.Size.Y - ball.radius)
			{
				bot.AddScore ();
				RespawnBall (-1);
			}
			
			window.Display ();
		}
	}

	private bool CheckCollision(Shape shape1, Shape shape2)
	{
		var rect1 = shape1.GetGlobalBounds ();
		var rect2 = shape2.GetGlobalBounds ();

		return rect1.Intersects(rect2);
	}
	
	private void CreateObject(IDrawable? drawable = null, IUpdatable? updatable = null)
	{
		if (drawable != null)
			drawables.Add(drawable);
		
		if (updatable != null)
			updatables.Add(updatable);
	}
	
	private void DrawObjects()
	{
		foreach (var drawable in drawables)
		{
			drawable?.Draw(window);
		}
	}
	
	private void UpdateObjects()
	{
		foreach (var updatable in updatables)
		{
			updatable?.Update();
			updatable?.Update(ball.Position);
		}
	}
	
	private void RespawnBall(int yVelocity = 0)
	{
		int x = random.Next(-10, 10);

		ball.Position = new Vector2f(window.Size.X / 2, window.Size.Y / 2);
		ball.Velocity = new Vector2f(x, yVelocity * 5);
	}
	
}