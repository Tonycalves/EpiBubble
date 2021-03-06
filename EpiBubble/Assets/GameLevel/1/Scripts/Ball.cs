﻿using UnityEngine;
using System.Collections;

namespace com.alphakush{
	public class Ball : MonoBehaviour {

		public enum BALL_TYPE {
			NONE = -1, // Aucun
			TYPE_1, // Bleu
			TYPE_2, //Vert
			TYPE_3, //pink
			TYPE_4,//red
			TYPE_5,//yellow
			TYPE_6,//marron
			TYPE_7,//cyan
			TYPE_8,//fuchia
			TYPE_9,//gris
			TYPE_10,//lime
			TYPE_11,//noir
			TYPE_12,//purple
			TYPE_13//silver
		}
		public GameObject[] colorsGO;
		[HideInInspector]
		public int row;
		[HideInInspector]
		public int column;
		[HideInInspector]
		public BALL_TYPE type;
		[HideInInspector]
		public bool visited;
		[HideInInspector]
		public bool connected;
		private Vector3 ballPosition;
		private Grid grid;

		public void SetBallPosition (Grid grid, int column, int row)
		{
			this.grid = grid;
			this.column = column;
			this.row = row;

			ballPosition = new Vector3 ( 
				(column * grid.TILE_SIZE) - grid.GRID_OFFSET_X , 
				 (row * grid.TILE_SIZE),0);
			if (column % 2 == 0) {
				ballPosition.y -= grid.TILE_SIZE * 0.5f;
			}

			transform.localPosition = ballPosition;

			foreach (var go in colorsGO) {
				go.SetActive(false);
			}
		}

		void OnTriggerEnter2D(Collider2D other) { // Fonction pour accrocher la balle sur la grille
			if (other.tag == "bullet") {
				var b = other.gameObject.GetComponent<Bullet>();
                grid.AddBall (this, b);
			}
		}

		public void SetType (BALL_TYPE type) {

			foreach (var go in colorsGO) {
				go.SetActive(false);
			}

			this.type = type;

			if (type == BALL_TYPE.NONE)
				return;

			colorsGO [(int)type].SetActive(true);
		}
	}
}

