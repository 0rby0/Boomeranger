using Godot;

namespace Boomeranger
{
    public partial class BoomerangerController : Node
    {
        // Assign a body to control
        [Export]
        private CharacterBody2D body;


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
        public override void _Process(double delta)
        {
            // Send a message and don't try to parse movement if no body has been given to control
            if (body is null)
            {
                GD.Print("Debug: Unassigned Body");
                return;
            }

            // Handle 2D movement
            Vector2 velocity = new();

            if (Input.IsActionPressed("ui_up"))
            {
                velocity.Y -= 1.0f;
            }

            if (Input.IsActionPressed("ui_down"))
            {
                velocity.Y += 1.0f;
            }

            if (Input.IsActionPressed("ui_left"))
            {
                velocity.X -= 1.0f;
            }

            if (Input.IsActionPressed("ui_right"))
            {
                velocity.X += 1.0f;
            }

            body.MoveAndCollide(velocity);
        }

    }
}