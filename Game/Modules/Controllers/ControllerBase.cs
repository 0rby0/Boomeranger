using Godot;

namespace Boomeranger
{
	public partial class ControllerBase : Node
    {
        // The body which this controller instance is handling
        internal CharacterBody3D _body;
        public CharacterBody3D Body { set => _body = value; }
    }
}
