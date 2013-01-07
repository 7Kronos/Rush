using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Rush.World.States.Bee
{
	public interface IBeeState
	{
		void Initialyze();
		void Update(Rush.World.Bee thing, GameTime gameTime);
		void Draw(GraphicsDeviceManager gfx, SpriteBatch batch, GameTime gameTime);
	}

	public class Empty : IBeeState
	{

		public void Initialyze()
		{
		}

		public void Update(World.Bee thing, GameTime gameTime)
		{
		}

		public void Draw(GraphicsDeviceManager gfx, SpriteBatch batch, GameTime gameTime)
		{
		}
	}

	public class Standby : IBeeState
	{
		private long AngleCounter;
		private uint CircleRadius;
		private int RotationDirection;

		private Vector2 VecteurDirecteur;

		public Standby()
		{
			Initialyze();
		}

		public void Initialyze()
		{
			AngleCounter = 0;
			CircleRadius = 10;
			RotationDirection = 1;
		}

		public void Update(Rush.World.Bee bee, GameTime gameTime)
		{
			// équation paramètrique double'une droite'
			// x = x0 + t * a
			// y = y0 + t * b
			if (bee.Destination.HasValue)
			{
				float t = (float)gameTime.ElapsedGameTime.TotalSeconds;
				// on deplace l'abeille 
				float x = bee.Position.X + t * VecteurDirecteur.X;
				float y = bee.Position.Y + t * VecteurDirecteur.Y;

				Vector2 newPos = new Vector2(x, y);

				// on calcul la distance entre la position courante et la destination
				double AB = CalculateDistance(bee.Position, bee.Destination.Value);
				// on calcul la distance entre la position courante et la nouvelle position
				double AC = CalculateDistance(bee.Position, newPos);

				// si AC est plus grand sa veut dire qu'on a dépassé la destination et que donc on la atteinte
				if (AC >= AB)
					CalculateNewDestination(bee);
				
				bee.Position = newPos;
			}
			else
				CalculateNewDestination(bee);
		}

		private float CalculateVector(float A, float B)
		{
			return B - A;
		}

		private double CalculateDistance(Vector2 A, Vector2 B)
		{
			return Math.Sqrt(Math.Pow(B.X - A.X, 2) + Math.Pow(B.Y - A.Y, 2));
		}

		private void CalculateNewDestination(Rush.World.Bee thing)
		{
			Vector2 centralpoint = (thing.CurrentHive == null) ? new Vector2(0, 0) : thing.CurrentHive.Position;

			thing.Destination = DeterminePositionInCircle(centralpoint, CircleRadius, 360 / 3 * (AngleCounter % 10));

			AngleCounter = AngleCounter + RotationDirection;

			VecteurDirecteur = CalculateVecteurDirecteur(thing.Destination.Value, thing.Position, thing.Speed);
		}

		private Vector2 CalculateVecteurDirecteur(Vector2 destination, Vector2 position, float speed)
		{
			// on détermine le vecteur directeur grâce à l'équation paramétrique de la droite
			// X = X0 + T * Ax devient Ax = (X - X0) / T
			// ou
			// X = destination.X
			// X0 = position.X
			// T = speed
			float Ax = (destination.X - position.X) / speed;
			float Ay = (destination.Y - position.Y) / speed;
			return new Vector2(Ax, Ay);
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

		public void Draw(GraphicsDeviceManager gfx, SpriteBatch batch, GameTime gameTime)
		{
		}
	}

	public class Move : IBeeState
	{
		public void Update(Rush.World.Bee thing, GameTime gameTime)
		{

		}

		public void Draw(GraphicsDeviceManager gfx, SpriteBatch batch, GameTime gameTime)
		{

		}

		public void Initialyze()
		{
		}
	}
}
