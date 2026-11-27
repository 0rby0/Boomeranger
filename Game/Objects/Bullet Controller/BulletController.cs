using Godot;
using System;

namespace Boomeranger
{
	public partial class BulletController : Node
	{
		private CharacterBody2D _body;
		private float _speedMult;
		private float _sizeMult;
		private float _rotation;
        private Vector2 _velocity = new();

        // Take a body to control, speed, size, and direction when creating a new bullet
        public BulletController (CharacterBody2D body, float speedMult = 1.0f, float sizeMult = 1.0f, float direction = 0.0f)
		{
			_body = body;
			_speedMult = speedMult;
			_sizeMult = sizeMult;
			_rotation = direction;
		}

		// Bullet Movement Handler
		public override void _Ready()
		{
			// Make the bullet the correct scale
			_body.Scale = new Vector2(_sizeMult, _sizeMult);

			// Turn the bullet sprite in the right direction
			_body.Rotation = _rotation;
			
			// Get the velocity of the bullet for the direction it will move
			_velocity.X = (float)Math.Cos(_rotation);
			_velocity.Y = (float)Math.Sin(_rotation);

			// Normalise the vector to avoid diagonals moving too fast
			Vector2 velNorm = _velocity.Normalized();

			// Multiply the entire thing by the speed the bullet should be moving
			_velocity.X = velNorm.X * _speedMult;
			_velocity.Y = velNorm.Y * _speedMult;

			_body.MoveAndCollide(_velocity);
		}

	}
}
