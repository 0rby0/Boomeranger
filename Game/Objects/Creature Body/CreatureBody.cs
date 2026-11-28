using Godot;

namespace Boomeranger
{
	public partial class CreatureBody : CharacterBody3D
	{
		private bool _isAssigned = false;

		public void SetController(ControllerBase controller)
		{
			if (!_isAssigned)
			{
				CallDeferred("add_child", controller);
				controller.Body = this;
				_isAssigned = true;
			}
			else
			{
				GD.Print("Controller already assigned");
			}
		}

	}
}