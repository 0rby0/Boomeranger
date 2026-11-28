using Godot;

namespace Boomeranger
{
    public partial class BoomerangerController : ControllerBase
    {
        // Player Health Variables
        private int _maxHealth = 10;
        private int _currentHealth = 10;

        public int HealthStat { get => _maxHealth; set => _maxHealth = value; }


        // Player Defence Variables
        private int _defence = 0;

        public int DefenceStat { get => _defence; set => _defence = value; }


        // Player Technique Variables
        private int _technique = 0;

        public int TechniqueStat { get => _technique; set => _technique = value; }


        // Player Strength Variables
        private int _strength = 0;

        public int StrengthStat { get => _strength; set => _strength = value; }


        // Player Input Handling
        private float _speed = 1.0f;
        public override void _Process(double delta)
        {
            // Handle 2D movement
            Vector3 velocity = new();

            if (Input.IsActionPressed("ui_up"))
            {
                velocity.Z -= _speed;
            }

            if (Input.IsActionPressed("ui_down"))
            {
                velocity.Z += _speed;
            }

            if (Input.IsActionPressed("ui_left"))
            {
                velocity.X -= _speed;
            }

            if (Input.IsActionPressed("ui_right"))
            {
                velocity.X += _speed;
            }

            velocity.Y -= 0.1f;

            _body.MoveAndCollide(velocity);
        }

    }
}