using System.Reflection;
using SFML.Graphics;

namespace AeroHockey.Settings;

public class Config
{
	public const uint WindowWidth = 400;
	public const uint WindowHeight = 600;
	public static float PlayerWidth = 100f;
	public static float PlayerHeight = 20f;

	public static Font Font = new("C:\\Windows\\Fonts\\arial.ttf"); // TODO: Change this to resource in Fonts/arial.ttf
}