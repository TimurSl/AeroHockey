using SFML.Graphics;
using SFML.Window;

namespace AeroHockey.Core;

class Game
{
	private RenderWindow window;
	
	private Ball ball;

	public Game(uint width, uint height, string title)
	{
		window = new RenderWindow(new VideoMode(width, height), title);
		window.SetVerticalSyncEnabled(true);
		window.SetFramerateLimit(60);
		ball = new Ball(width / 2, height / 2);
	}


	public void Run()
	{
		window.Closed += (sender, e) => window.Close();
		while (window.IsOpen)
		{
			window.DispatchEvents();
			window.Clear(Color.Black);
			
			ball.Draw(window, RenderStates.Default);
			ball.Update();
			
			window.Display();
		}
	}

}