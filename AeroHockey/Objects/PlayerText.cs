using AeroHockey.Core.Interfaces;
using AeroHockey.Settings;
using SFML.Graphics;
using SFML.System;

namespace AeroHockey.Objects;

public class PlayerText
{
	public Text Text { get; set; }
	
	public PlayerText(string text, Vector2f position)
	{
		Text = new Text(text, Config.Font)
		{
			Position = position,
			CharacterSize = 20,
			FillColor = Color.White,
		};
		Text.Origin = new Vector2f(Text.GetLocalBounds().Width / 2, Text.GetLocalBounds().Height / 2);
	}
	
	public void Draw(RenderTarget target)
	{
		target.Draw(Text);
	}
	
	public void Update(string text, Vector2f position)
	{
		Text.Position = position;
		Text.DisplayedString = text;
	}
}