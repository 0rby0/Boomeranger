// This class takes in a map (dictionary of positions and tiles) and creates each tile.

using Godot;
using System.Collections.Generic;

namespace Boomeranger
{
	public partial class MapLoader : Node
	{
		public MapLoader(Dictionary<Vector2, Tiles.Tile> map) 
		{
			foreach (Vector2 position in map.Keys)
			{
				GD.Print(position);
			}
		}

	}
}
