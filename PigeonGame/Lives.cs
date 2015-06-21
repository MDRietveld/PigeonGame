using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PigeonGame
{
	public class Lives
	{
		/**
		 * What do I need to make lives?
		 * - World
		 * - How many lives?
		 * - Boolean check true/false
		 * 
		 * Description :
		 * - You lose 1 life when hitting Enemy
		 * - You retrieve 1 life back when you answer the question right.
		 **/

		private World _world;
		private Vector2 _position;
		private Texture2D _texture = Assets.Heart;
		private float _scale;

		public Lives (World world, Vector2 position)
		{
			_world = world;
			_position = position;
			_scale = 0.3f;
		}

		public void Update(GameTime gameTime, Pidgy pidgy)
		{
			
		}

		public void Draw(SpriteBatch spriteBatch) {
			spriteBatch.Draw(_texture, _position , null, Color.White, 0f, Vector2.Zero, _scale, SpriteEffects.None, 0f);
		}
	}
}