using System;
using System.Collections.Generic;
using SplashKitSDK;

namespace MyGame
{
	public class FruitKarate
	{
		private List<Fruit> _fruit;

		public FruitKarate()
        {
			_fruit = new List<Fruit>();
		}

		public void LaunchFruit()
        {
			Fruit f;
            float p = SplashKit.Rnd();

            if (p < 0.8)
            {
                f = new Fruit();
            }
            else
            {
                f = new ToughFruit();
            }

			_fruit.Add(f);
        }

		public void Update()
        {
			foreach (Fruit f in _fruit)
            {
				f.Update();
            }
        }

		public void Draw()
        {
			foreach (Fruit f in _fruit)
            {
				f.Draw();
            }
        }

		public void Slash(Point2D pt)
        {
            List<Fruit> toRemove = new List<Fruit>();

			foreach (Fruit f in _fruit)
            {
				if (f.IsAt(pt))
                {
                    if (f.Splat())
                    {
                        toRemove.Add(f);
                    }
                }
            }

            foreach (Fruit f in toRemove)
            {
                _fruit.Remove(f);
            }
        }
    }
}
