using System.Collections;
using UnityEngine;

namespace com.alphakush{

	public enum GameState {Playing, Loose, Win};
	public class Game {
		/* Constants */
		
		public const int PointsPerExplosion = 20;
		public const int PointsPerFall = 25;
		
		
		/* Public properties */
		public GameState state;
		
		/* Private iVars */
		private int _points;
		private int _bubblesDestroyed;
		private int _shootnumber;
		
		public Game(){
			this._points = 0;
			this._bubblesDestroyed = 0;
			this._shootnumber = 0;
		}

		/* The score of the current game
		 * Read-only
		 */
		public int score{
			get{
				return this._points;
			}
		}
		public int shoot{
			get{
				return this._shootnumber;
			}
		}
		
		/* The amount of bubbles that have been destroyed throughout the game
		 * Read-only
		 */
		public int bubblesDestroyed{
			get{
				return this._bubblesDestroyed;
			}
		}
		
		public void destroyBubbles(int bubbleCount, bool exploded){
			this._points += 1;
			//this._points +=  exploded ? bubbleCount * PointsPerExplosion : bubbleCount * PointsPerFall;
			this._bubblesDestroyed += bubbleCount;	
		}

		public void NbrOfShoot(){
			this._shootnumber += 1;
		}
	}
}

