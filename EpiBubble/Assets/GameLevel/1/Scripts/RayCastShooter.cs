using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using com.alphakush.events;
using com.alphakush.gui;
using com.alphakush.sounds;

namespace com.alphakush {
	public class RayCastShooter : MonoBehaviour {

		public GameObject[] colorsGO;
		public Ball.BALL_TYPE type;

		public Game _game;

		public GameObject dotPrefab;
		public Bullet bullet;
		public Grid grid;

		private List<Vector2> dots;
		private List<GameObject> dotsPool;
		private int maxDots = 26;

		private float dotGap = 0.42f;
		private float bulletProgress = 0.0f;
		private float bulletIncrement = 0.0f;

		// Use this for initialization
		void Start () {
			dots = new List<Vector2> ();
			dotsPool = new List<GameObject> ();

			var i = 0;
			var alpha = 1.0f / maxDots;
			var startAlpha = 1.0f;
			while (i < maxDots) {
				var dot = Instantiate (dotPrefab) as GameObject;
				var sp = dot.GetComponent<SpriteRenderer> ();
				var c = sp.color;

				c.a = startAlpha - alpha;
				startAlpha -= alpha;
				sp.color = c;

				dot.SetActive (false);
				dotsPool.Add (dot);
				i++;
			}
			RandomBubble();
		}
			
		public void HandleTouchUp (Vector2 touch) { // Tir de la boule
			if (bullet.gameObject.activeSelf)
				return;
			if (dots == null || dots.Count < 2)
				return;
			
			ClearShotPath ();
			
			bulletProgress = 0.0f;
			bullet.SetType(type);
			bullet.gameObject.SetActive (true);
			bullet.transform.position = transform.position;
			InitPath();
			RandomBubble();
		}
		
		public void RandomBubble() {
			foreach (var go in colorsGO) {
				go.SetActive(false);
			}
			type = (Ball. BALL_TYPE)Random.Range(0,5);
			colorsGO[(int) type].SetActive(true);
		}

		public void HandleTouchMove (Vector2 touch) {

			if (bullet.gameObject.activeSelf)
				return;
			if (dots == null) {
				return;
			}

			dots.Clear ();

			foreach (var d in dotsPool)
				d.SetActive (false);

			Vector2 point = Camera.main.ScreenToWorldPoint (touch);
			var direction = new Vector2 (point.x - transform.position.x, point.y - transform.position.y);

			RaycastHit2D hit = Physics2D.Raycast(transform.position, direction);


			if (hit.collider != null) {
				
				dots.Add (transform.position);

				if (hit.collider.tag == "SideWall") {
					DoRayCast (hit, direction);
				} else {
					dots.Add (hit.point);
					DrawPaths ();
				}
			} 
		}

		public void ClearShotPath () {
			foreach (var d in dotsPool)
				d.SetActive (false);
		}

		void DoRayCast (RaycastHit2D previousHit, Vector2 directionIn) {

			dots.Add (previousHit.point);

			var normal = Mathf.Atan2 (previousHit.normal.y, previousHit.normal.x);
			var newDirection = normal + (  normal - Mathf.Atan2(directionIn.y, directionIn.x) );
			var reflection = new Vector2 (-Mathf.Cos (newDirection), -Mathf.Sin (newDirection));
			var newCastPoint = previousHit.point + (2 * reflection);


			var hit2 = Physics2D.Raycast(newCastPoint, reflection);
			if (hit2.collider != null) {
				if (hit2.collider.tag == "SideWall") {
					DoRayCast (hit2, reflection);
				} else {
					dots.Add (hit2.point);
					DrawPaths ();
				}
			} else {
				DrawPaths ();
			}
		}

		// Update is called once per frame
		void Update () {
			if (bullet.gameObject.activeSelf) {
				bulletProgress += bulletIncrement;
				if (bulletProgress > 1) {
					dots.RemoveAt (0);
					if (dots.Count < 2) {
						bullet.gameObject.SetActive (false);
						dots.Clear ();
						return;
					} else {
						InitPath ();
					}
				}
				var px = dots [0].x + bulletProgress * (dots [1].x - dots [0].x);
				var py = dots [0].y + bulletProgress * (dots [1].y - dots [0].y);
				bullet.transform.position = new Vector2 (px, py);
			}
		}

		void DrawPaths () {
			if (dots.Count > 1) {

				foreach (var d in dotsPool)
					d.SetActive (false);

				int index = 0;

				for (var i = 1; i < dots.Count; i++) {
					DrawSubPath (i - 1, i, ref index);
				}
			}
		}

		void DrawSubPath (int start, int end, ref int index) {
			var pathLength = Vector2.Distance (dots [start], dots [end]);

			int numDots = Mathf.RoundToInt ( (float)pathLength / dotGap );
			float dotProgress = 1.0f / numDots;

			var p = 0.0f;

			while (p < 1) {
				var px = dots [start].x + p * (dots [end].x - dots [start].x);
				var py = dots [start].y + p * (dots [end].y - dots [start].y);

				if (index < maxDots) {
					var d = dotsPool [index];
					d.transform.position = new Vector2 (px, py);
					d.SetActive (true);
					index++;
				}

				p += dotProgress;
			}
		}

		void InitPath () {
			SoundManager.Instance.MakeShotBubbleSound();
			var start = dots [0];
			var end = dots [1];
			var length = Vector2.Distance (start, end);
			var iterations = length / 0.15f;
			bulletProgress = 0.0f;
			bulletIncrement = 1.0f / iterations;
		}
	}
}
