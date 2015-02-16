using System;

namespace StarboundAnimator
{
	public class Vector2
	{
		public float X;
		public float Y;

		public Vector2()
		{
			X = 0f;
			Y = 0f;
		}

		public Vector2(float x, float y)
		{
			X = x;
			Y = y;
		}

		public Vector2(Vector2 v)
		{
			X = v.X;
			Y = v.Y;
		}

		public void Set(float x, float y)
		{
			X = x;
			Y = y;
		}

		public void Set(Vector2 v)
		{
			X = v.X;
			Y = v.Y;
		}

		public bool IsZero()
		{
			return ((X == 0) && (Y == 0));
		}

		public float Length()
		{
			return (float)Math.Sqrt(X * X + Y * Y);
		}

		public float LengthSquared()
		{
			return X * X + Y * Y;
		}

		public static float DistanceBetween(Vector2 v1, Vector2 v2)
		{
			return (float)Math.Sqrt((v1.X - v2.X) * (v1.X - v2.X) + (v1.Y - v2.Y) * (v1.Y - v2.Y));
		}

		public static float DistanceBetweenSquared(Vector2 v1, Vector2 v2)
		{
			return (v1.X - v2.X) * (v1.X - v2.X) + (v1.Y - v2.Y) * (v1.Y - v2.Y);
		}

		public float DistanceTo(Vector2 v)
		{
			return (float)Math.Sqrt((v.X - X) * (v.X - X) + (v.Y - Y) * (v.Y - Y));
		}

		public float DistanceToSquared(Vector2 v)
		{
			return (v.X - X) * (v.X - X) + (v.Y - Y) * (v.Y * Y);
		}

		public Vector2 Normal()
		{
			Vector2 v = new Vector2(this);
			v.SetLength(1f);

			return v;
		}

		public void SetLength(float l)
		{
			if (l == 0) return;

			float f = Length();
			if (f != 0) Multiply(l / f);
		}

		public void MirrorByNormal(Vector2 v)
		{
			float dot = -X * v.X - Y * v.Y;
			X += 2 * v.X * dot;
			Y += 2 * v.Y * dot;
		}

		public static Vector2 operator +(Vector2 v1, Vector2 v2)
		{
			return new Vector2(v1.X + v2.X, v1.Y + v2.Y);
		}

		public void Add(Vector2 v)
		{
			X += v.X;
			Y += v.Y;
		}

		public void Add(float x, float y)
		{
			X += x;
			Y += y;
		}

		public static Vector2 operator -(Vector2 v1, Vector2 v2)
		{
			return new Vector2(v1.X - v2.X, v1.Y - v2.Y);
		}

		public void Subtract(Vector2 v)
		{
			X -= v.X;
			Y -= v.Y;
		}

		public void Subtract(float x, float y)
		{
			X -= x;
			Y -= y;
		}

		public static Vector2 operator *(Vector2 v, float f)
		{
			return new Vector2(v.X * f, v.Y * f);
		}

		public void Multiply(float f)
		{
			X *= f;
			Y *= f;
		}

		public void Multiply(float x, float y)
		{
			X *= x;
			Y *= y;
		}

		public static Vector2 operator /(Vector2 v, float f)
		{
			return new Vector2(v.X / f, v.Y / f);
		}

		public void Divide(float f)
		{
			X /= f;
			Y /= f;
		}

		public void Divide(float x, float y)
		{
			X /= x;
			Y /= y;
		}

		// dot product operator
		public static float operator |(Vector2 v1, Vector2 v2)
		{
			return v1.X * v2.X + v1.Y * v2.Y;
		}

		public float Dot(Vector2 v)
		{
			return v.X * X + v.Y * Y;
		}

		public Vector2 Cross(bool CW)
		{
			return (CW ? new Vector2(Y, -X) : new Vector2(-Y, X));
		}
	}
}

