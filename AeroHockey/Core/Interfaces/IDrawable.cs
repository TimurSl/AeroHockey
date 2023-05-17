using SFML.Graphics;

namespace AeroHockey.Core.Interfaces;

public interface IDrawable
{
	public Shape Shape { get; set; }
	public void Draw(RenderTarget target);
}