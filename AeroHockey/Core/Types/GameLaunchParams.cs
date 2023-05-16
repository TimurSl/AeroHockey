using AeroHockey.Settings;

namespace AeroHockey.Core.Types;

public struct GameLaunchParams
{
	public uint Width = Config.WindowWidth;
	public uint Height = Config.WindowHeight;

	public string Title { get; set; } = "Aero Hockey";

	public GameLaunchParams()
	{
	}
}