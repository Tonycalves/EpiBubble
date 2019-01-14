using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace com.alphakush {
	public class HUD : MonoBehaviour {
		
		public Game game;
		public Text scoreLabel;
		public Text bubblesDestroyedLabel;
		public Text TimePlayed;

		public Canvas CanvasGameEnd;
		
		private float _timeOffset;

		void Start () {
			CanvasGameEnd = GameObject.Find("Canvas").GetComponent<Canvas>();
			CanvasGameEnd.enabled = false;
			scoreLabel = GameObject.Find("score").GetComponent<Text>();
			bubblesDestroyedLabel = GameObject.Find("bubbledestroyed").GetComponent<Text>();
			TimePlayed = GameObject.Find("TimePlayed").GetComponent<Text>();
			_timeOffset = Time.timeSinceLevelLoad;
		}
		
		void Update () {
		}

		void OnGUI(){
			TimeSpan timeSpan = TimeSpan.FromSeconds(Time.timeSinceLevelLoad - _timeOffset);
			string timeText = string.Format("{0:D2}:{1:D2}:{2:D2}", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
			scoreLabel.text = game.score.ToString();
			bubblesDestroyedLabel.text = game.bubblesDestroyed.ToString();
			TimePlayed.text = timeText.ToString();
		}
	}
}
