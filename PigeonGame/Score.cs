using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace PigeonGame
{
	public class Score
	{
		private int 			_score = 0;
		private SpriteFont 		Font1;
		private Vector2			_position;
		private Game1			_game;

		public Score (Game1 game)
		{
			Font1 = game.Content.Load<SpriteFont> ("Verdana");
			_position = new Vector2 (800, 25);
			_game = game;
		}

		public void Update(GameTime gameTime){
			_score += 15;
			Assets.Score += 15;
		}

		public void Draw(SpriteBatch spriteBatch){
			spriteBatch.DrawString (Font1, "Score: "+_score.ToString(), _position, Color.Black);
		}
	}
}

