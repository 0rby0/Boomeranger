// This class takes in a map (dictionary of positions and tiles) and creates each tile.

using Godot;
using System.Collections.Generic;

namespace Boomeranger
{
	public partial class MapLoader : Node
	{
		public MapLoader(Dictionary<Vector2, Tiles.Tile> map, Node parent) 
		{
			Tiles t = new Tiles();

			foreach (Vector2 position in map.Keys)
			{
				MeshInstance3D tile = (MeshInstance3D)((PackedScene)GD.Load("res://Objects/Tile/Tile.tscn")).Instantiate();

				tile.Position = new Vector3(position.X, 0, position.Y);

				parent.CallDeferred("add_child", tile);
				GD.Print(t.TileDetails[map[position]]);
			}
		}

	}
}
