using SFML.System;

namespace AeroHockey.Core.Interfaces;

public interface IUpdatable
{
	public void Update();
	public void Update(Vector2f ballPosition);
}