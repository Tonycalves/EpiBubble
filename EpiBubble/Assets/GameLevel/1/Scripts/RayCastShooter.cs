using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using com.alphakush.events;
using com.alphakush.gui;
using com.alphakush.sounds;
using UnityEngine.UI;

namespace com.alphakush {
	public class RayCastShooter : MonoBehaviour {

		[HideInInspector]

		public GameObject[] colorsGO;
		public GameObject[] colorsGO2;

		public Ball.BALL_TYPE type;
		public Ball.BALL_TYPE Nexttype;

		public Game _game;

		public GameObject dotPrefab;
		public Bullet bullet;
		public Bullet Nextbullet;
		public Grid grid;

		private bool RandomColourReady;

		private List<Vector2> dots;
		private List<GameObject> dotsPool;
		private int maxDots = 26;

		private float dotGap = 0.42f;
		private float bulletProgress = 0.0f;
		private float bulletIncrement = 0.0f;
		private float xArrow;
		private float yArrow;
		public Text BubleColourLabel;
		public Text BubleColourActu;

		// Use this for initialization
		void Start () {
			xArrow = 0.0f;
			yArrow = 3.21f;
			RandomColourReady = false;
			dots = new List<Vector2> ();
			dotsPool = new List<GameObject> ();
			BubleColourLabel = GameObject.Find("Colour").GetComponent<Text>();
			BubleColourActu = GameObject.Find("ColourActuel").GetComponent<Text>();

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
			RandomNextBubble();
		}

		public void HandleTouchUp () { // Tir de la boule
			if (bullet.gameObject.activeSelf)
				return;
			if (dots == null || dots.Count < 2)
				return;

			ClearShotPath ();
			bulletProgress = 0.0f;
			bullet.SetType(type);
			bullet.gameObject.SetActive (true);
			bullet.transform.position = transform.position;
			if (RandomColourReady == true){
				type = Nexttype;
				SetBubbleColour();
			} else{
				RandomBubble();
			}
			InitPath();
			RandomNextBubble();
		}

		public void RandomBubble() {
			foreach (var go in colorsGO) {
				go.SetActive(false);
			}
			type = (Ball. BALL_TYPE)Random.Range(0,12);
			colorsGO[(int) type].SetActive(true);
			if (type == Ball.BALL_TYPE.TYPE_1){
				BubleColourActu.text = "Blue";
			} else if (type == Ball.BALL_TYPE.TYPE_2) {
				BubleColourActu.text = "Green";
			} else if (type == Ball.BALL_TYPE.TYPE_3){
				BubleColourActu.text = "White";
			} else if (type == Ball.BALL_TYPE.TYPE_4) {
				BubleColourActu.text = "Red";
			} else if (type == Ball.BALL_TYPE.TYPE_5){
				BubleColourActu.text = "Yellow";
			} else if (type == Ball.BALL_TYPE.TYPE_6) {
				BubleColourActu.text = "Maroon";
			} else if (type == Ball.BALL_TYPE.TYPE_7) {
				BubleColourActu.text = "Cyan";
			} else if (type == Ball.BALL_TYPE.TYPE_8){
				BubleColourActu.text = "Fuchsia";
			} else if (type == Ball.BALL_TYPE.TYPE_9) {
				BubleColourActu.text = "Grey";
			} else if (type == Ball.BALL_TYPE.TYPE_10) {
				BubleColourActu.text = "Lime";
			} else if (type == Ball.BALL_TYPE.TYPE_11) {
				BubleColourActu.text = "Noir";
			} else if (type == Ball.BALL_TYPE.TYPE_12) {
				BubleColourActu.text = "Purple";
			} else if (type == Ball.BALL_TYPE.TYPE_13) {
				BubleColourActu.text = "Silver";
			}
		}

		public void SetBubbleColour() {
			foreach (var go in colorsGO) {
				go.SetActive(false);
			}
			colorsGO[(int) type].SetActive(true);
			if (type == Ball.BALL_TYPE.TYPE_1){
				BubleColourActu.text = "Blue";
			} else if (type == Ball.BALL_TYPE.TYPE_2) {
				BubleColourActu.text = "Green";
			} else if (type == Ball.BALL_TYPE.TYPE_3){
				BubleColourActu.text = "White";
			} else if (type == Ball.BALL_TYPE.TYPE_4) {
				BubleColourActu.text = "Red";
			} else if (type == Ball.BALL_TYPE.TYPE_5){
				BubleColourActu.text = "Yellow";
			} else if (type == Ball.BALL_TYPE.TYPE_6) {
				BubleColourActu.text = "Maroon";
			} else if (type == Ball.BALL_TYPE.TYPE_7) {
				BubleColourActu.text = "Cyan";
			} else if (type == Ball.BALL_TYPE.TYPE_8){
				BubleColourActu.text = "Fuchsia";
			} else if (type == Ball.BALL_TYPE.TYPE_9) {
				BubleColourActu.text = "Grey";
			} else if (type == Ball.BALL_TYPE.TYPE_10) {
				BubleColourActu.text = "Lime";
			} else if (type == Ball.BALL_TYPE.TYPE_11) {
				BubleColourActu.text = "Noir";
			} else if (type == Ball.BALL_TYPE.TYPE_12) {
				BubleColourActu.text = "Purple";
			} else if (type == Ball.BALL_TYPE.TYPE_13) {
				BubleColourActu.text = "Silver";
			}
		}

		public void RandomNextBubble() {
			Nexttype = (Ball. BALL_TYPE)Random.Range(0,12);
			Nextbullet.SetType(Nexttype);
			Nextbullet.gameObject.SetActive (true);
			RandomColourReady = true;
			if (Nexttype == Ball.BALL_TYPE.TYPE_1){
				BubleColourLabel.text = "Blue";
			} else if (Nexttype == Ball.BALL_TYPE.TYPE_2) {
				BubleColourLabel.text = "Green";
			} else if (Nexttype == Ball.BALL_TYPE.TYPE_3){
				BubleColourLabel.text = "White";
			} else if (Nexttype == Ball.BALL_TYPE.TYPE_4) {
				BubleColourLabel.text = "Red";
			} else if (Nexttype == Ball.BALL_TYPE.TYPE_5){
				BubleColourLabel.text = "Yellow";
			} else if (Nexttype == Ball.BALL_TYPE.TYPE_6) {
				BubleColourLabel.text = "Maroon";
			} else if (Nexttype == Ball.BALL_TYPE.TYPE_7) {
				BubleColourLabel.text = "Cyan";
			} else if (Nexttype == Ball.BALL_TYPE.TYPE_8){
				BubleColourLabel.text = "Fuchsia";
			} else if (Nexttype == Ball.BALL_TYPE.TYPE_9) {
				BubleColourLabel.text = "Grey";
			} else if (Nexttype == Ball.BALL_TYPE.TYPE_10) {
				BubleColourLabel.text = "Lime";
			} else if (Nexttype == Ball.BALL_TYPE.TYPE_11) {
				BubleColourLabel.text = "Noir";
			} else if (Nexttype == Ball.BALL_TYPE.TYPE_12) {
				BubleColourLabel.text = "Purple";
			} else if (Nexttype == Ball.BALL_TYPE.TYPE_13) {
				BubleColourLabel.text = "Silver";
			}
			
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

			Vector2 point = Camera.main.ScreenToWorldPoint(touch);
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

		public void HandleTouchMoveKeyBoard () {

			if (bullet.gameObject.activeSelf)
				return;
			if (dots == null) {
				return;
			}

			dots.Clear ();
			foreach (var d in dotsPool)
				d.SetActive (false);
			var direction = new Vector2 (xArrow, yArrow);
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

		public void HandleTouchMoveKeyBoardRight () {
			if (bullet.gameObject.activeSelf)
				return;
			if (dots == null) {
				return;
			}
			dots.Clear ();
			foreach (var d in dotsPool)
				d.SetActive (false);

			var direction = new Vector2 (xArrow + 0.05f, yArrow + 0.0f);
			xArrow = direction.x;
			yArrow = direction.y;
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

		public void HandleTouchMoveKeyBoardLeft () {
			if (bullet.gameObject.activeSelf)
				return;
			if (dots == null) {
				return;
			}
			dots.Clear ();
			foreach (var d in dotsPool)
				d.SetActive (false);

			var direction = new Vector2 (xArrow - 0.05f, yArrow + 0.0f);
			xArrow = direction.x;
			yArrow = direction.y;
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
