using Godot;
using System.Collections.Generic;

namespace Boomeranger
{
	public partial class Tiles : Node
	{
		public enum Tile
		{
			Ground,
			Wall
		}

		public readonly record struct _tilePaths(string modelpath, string texturepath);

		private Dictionary<Tile, _tilePaths> _tileDetails = new()
		{
			[Tile.Ground] = new _tilePaths (
				modelpath: "res://Assets/The_Cube.glb",
				texturepath: "res://Assets/No_Texture.png"
				),

			[Tile.Wall] = new _tilePaths (
				modelpath: "res://Assets/The_Cube.glb",
				texturepath: "res://Assets/No_Texture.png"
				),
		};

		public Dictionary<Tile, _tilePaths> TileDetails { get => _tileDetails; }

	}
}
