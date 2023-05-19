using SFML.System;

namespace AeroHockey.Input.Interfaces;

public interface IInput
{
	public Vector2f GetMovement(Vector2f position, Vector2f ballPosition);
}