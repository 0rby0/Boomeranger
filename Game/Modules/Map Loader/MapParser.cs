// This class is responsible for reading a map from a file
// Actual map loading is handled elsewhere to work with random map generation

using Godot;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Boomeranger
{
	public partial class MapParser : Node
	{
		public Dictionary<Vector2, Tiles.Tile> Map = [];

		public MapParser(string mapPath)
		{
			if (!FileAccess.FileExists(mapPath))
			{
				GD.Print("Map file doesn't exist");
				return;
			}

			var mapFile = FileAccess.Open(mapPath, FileAccess.ModeFlags.Read);
			string jsonString = mapFile.GetAsText();

			var options = new JsonSerializerOptions();
			options.Converters.Add(new Vector2JsonConverter());
			options.Converters.Add(new JsonStringEnumConverter());

			Map = JsonSerializer.Deserialize<Dictionary<Vector2, Tiles.Tile>>(jsonString, options) ?? [];
		}

	}
}
