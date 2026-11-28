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

				tile.Position = new Vector3(position.X, -1, position.Y);

				parent.CallDeferred("add_child", tile);
			}

			CharacterBody3D creature = (CharacterBody3D)(GD.Load<PackedScene>("res://Objects/Creature Body/CreatureBody.tscn")).Instantiate();
            BoomerangerController playerController = new BoomerangerController();
            ((CreatureBody)creature).SetController(playerController);
			parent.CallDeferred("add_child", creature);
		}

	}
}
