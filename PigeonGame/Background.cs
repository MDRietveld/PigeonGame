using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace PigeonGame
{
	
	public class Background
	{
		private Texture2D _texture;
		private	Vector2 _position;
//		private Game1 game;
		private float _scale;


		public Background (Game1 game, Texture2D texture)
		{
			_position = new Vector2(0, 0);
			_texture = texture;

			_scale = game.GraphicsDevice.Viewport.Height/ _texture.Height;

		}

		public void Update(){
			// TODO laat de weg naar links bewegen

		}

		public void Draw(SpriteBatch spriteBatch){
			spriteBatch.Draw (_texture, _position, null, Color.White, 0f, Vector2.Zero, _scale, SpriteEffects.None, 0f);
		}
	}
}

