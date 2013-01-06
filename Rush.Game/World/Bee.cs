using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Rush.Support;
using Rush.World.States;
using Rush.World.States.Bee;

namespace Rush.World
{
	public class Bee : Thing
	{
		#region State

		private readonly IBeeState[] States = {
			new Standby(),
			new Move(),
			new TestState()
		};

		private IBeeState _currentState;
		protected IBeeState CurrentState
		{
			get { return _currentState; }
			set
			{
				if (value == null)
					_currentState = States[0];
				else
					_currentState = value;
			}
		}

		#endregion

		public Hive CurrentHive { get; set; }
		public Texture2D SpriteTexture { get; set; }
		public double Speed { get; set; }

		public Bee() : base()
		{
			Speed = 1;
			CurrentState = States[0];
		}

		public void DoTest()
		{
			_currentState = States[2];

		}

		public override void Update(GameTime gameTime)
		{
			CurrentState.Update(this, gameTime);
			base.Update(gameTime);
		}

		public override void Draw(GraphicsDeviceManager gfx, SpriteBatch batch, GameTime gameTime)
		{
			base.Draw(gfx, batch, gameTime);

			Point baseLocation = CameraManager.GetPointInScreen(Position);
			baseLocation.X -= 4;
			baseLocation.Y -= 4;

			batch.Draw(SpriteTexture, new Rectangle(baseLocation.X, baseLocation.Y, 8, 8), Color.White);
		}
	}
}
