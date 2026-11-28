// This class is responsible for reading a map from a file
// Actual map loading is handled elsewhere to work with random map generation

using Godot;
using Godot.Collections;
using System.IO;
using System.Text.Json;

namespace Boomeranger
{
	public partial class MapParser : Node
    {
        public static Dictionary<Vector2, Tiles.Tile> _map = [];

        MapParser(string mapPath)
        { 
            if (!Godot.FileAccess.FileExists(mapPath))
            {
                GD.Print("Map file doesn't exist");
                return;
            }

            using FileStream openStream = File.OpenRead(mapPath);
            _map = JsonSerializer.Deserialize<Dictionary<Vector2, Tiles.Tile>>(openStream);

            GD.Print(_map);
        }

	}
}
