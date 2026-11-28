using Godot;
using System;

namespace Boomeranger
{
    public partial class GameManager : Timer
    {
        // Create a globally accessible connection for other objects which use game tick
        public static GameManager Connection = new();
        
        // Set the TPS of the game
        [Export]
        private int ticksPerSecond = 3;

        public override void _Ready()
        {
            WaitTime = 1.0 / ticksPerSecond;
            Start();

            // Load a test map to check if things are working
            MapParser mapParser = new MapParser("res://test_map.json");
            new MapLoader(mapParser.Map, this);
        }

        // Creates a global tick update that can be connected to by other objects
        public static event Action GlobalTick;
        public void TickUpdate()
        {
            GlobalTick?.Invoke();
        }

    }
}
