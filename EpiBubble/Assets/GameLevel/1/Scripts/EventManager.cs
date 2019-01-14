using UnityEngine;
using System.Collections;

namespace com.alphakush.events{
	public class EventManager : MonoBehaviour {

		public delegate void Event_ShootBall ();
		public static event Event_ShootBall  OnShootBall;

		/* Handler pour la suppression des bulles pour compter les points */
		public delegate void BubblesRemovedHandler (int bubbleCount, bool exploded);
		public static event BubblesRemovedHandler OnBubblesRemoved;


		public delegate void DisableCursorHandler ();
		public static event DisableCursorHandler OnDisableCursor;
		
		public static void DisableCursor(){
			if (OnDisableCursor != null){
				OnDisableCursor();
			}
		}

		/*Handler pour compter le nombre de tir*/
		public delegate void NumberOfShootHandler ();
		public static event NumberOfShootHandler OnNumberOfShoot;

		public static void BubblesRemoved(int bubbleCount, bool exploded){
			if (OnBubblesRemoved != null){
				OnBubblesRemoved(bubbleCount, exploded);
			}
		}

		public static void NbrOfShoot (){
			if (OnNumberOfShoot != null) {
				OnNumberOfShoot();
			}
		}

		public static void ShootBall () {
		if (OnShootBall != null)
			OnShootBall ();
		}

		public delegate void GameFinishedHandler (GameState state);
		public static event GameFinishedHandler OnGameFinished;
		
		public static void GameFinished(GameState state){
			if (OnGameFinished != null){
				OnGameFinished(state);
			}
		}
	}
}