using SFML.System;

namespace AeroHockey.Input;

public interface IInput
{
	public Vector2f GetMovement(Vector2f position, Vector2f ballPosition);
}