using UnityEngine;
using System.Collections;

namespace com.alphakush.events{
	public class EventManager : MonoBehaviour {

		public delegate void Event_ShootBall ();
		public static event Event_ShootBall  OnShootBall;

		/* Handler pour la suppression des bulles pour compter les points */
		public delegate void BubblesRemovedHandler (int bubbleCount, bool exploded);
		public static event BubblesRemovedHandler OnBubblesRemoved;
		
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
	}
}