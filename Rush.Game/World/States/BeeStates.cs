using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Rush.World.States.Bee
{
	public interface IBeeState
	{
		void Initialyze();
		void Update(Rush.World.Bee thing, GameTime gameTime);
		void Draw(Rush.World.Bee thing, GameTime gameTime);
	}

	public class TestState : IBeeState
	{
		private long AngleCounter;
		private uint CircleRadius;
		private int RotationDirection;

		public TestState()
		{
			Initialyze();
		}

		public void Initialyze()
		{
			AngleCounter = 0;
			CircleRadius = 10;
			RotationDirection = 1;
		}

		public void Update(Rush.World.Bee thing, GameTime gameTime)
		{
			// équation paramètrique double'une droite'
			// x = x0 + t * a
			// y = y0 + t * b
			if (thing.Destination.HasValue)
			{
				double t = thing.Speed * gameTime.ElapsedGameTime.TotalSeconds;
				// on deplace l'abeille 
				double x = thing.Position.X + t * thing.Destination.Value.X;
				double y = thing.Position.Y + t * thing.Destination.Value.Y;

				thing.Position = new Vector2((float)x, (float)y);

				// si l'abeille a atteint sa destination on calcul un nouvelle trajectoire
				double absx = Math.Abs(x - thing.Destination.Value.X);
				double absy = Math.Abs(y - thing.Destination.Value.Y);
				if (absx <= 5 && absy <= 5)
					CalculateNewDestination(thing);
			}
			else
				CalculateNewDestination(thing);
		}

		private void CalculateNewDestination(Rush.World.Bee thing)
		{
			Vector2 centralpoint = (thing.CurrentHive == null) ? new Vector2(0, 0) : thing.CurrentHive.Position;

			thing.Destination = DeterminePositionInCircle(centralpoint, CircleRadius, 360 / 3 * (AngleCounter % 6));

			AngleCounter = AngleCounter + RotationDirection;
		}

		private Vector2 DeterminePositionInCircle(Vector2 Centralpoint, uint radius, float angle)
		{
			// équation paramètrique d'un cercle
			// x(t) = r cos(t) + j
			// y(t) = r sin(t) + k
			float x = radius * (float)Math.Cos(angle) + Centralpoint.X;
			float y = radius * (float)Math.Sin(angle) + Centralpoint.Y;
			Vector2 res = new Vector2(x, y);
			return res;
		}

		public void Draw(Rush.World.Bee thing, GameTime gameTime)
		{

		}
	}

	public class Standby : IBeeState
	{
		public void Update(Rush.World.Bee thing, GameTime gameTime)
		{

		}

		public void Draw(Rush.World.Bee thing, GameTime gameTime)
		{

		}

		public void Initialyze()
		{
		}
	}

	public class Move : IBeeState
	{
		public void Update(Rush.World.Bee thing, GameTime gameTime)
		{

		}

		public void Draw(Rush.World.Bee thing, GameTime gameTime)
		{

		}

		public void Initialyze()
		{
		}
	}
}
