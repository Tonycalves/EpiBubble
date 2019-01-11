using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace com.alphakush {
	public class HUD : MonoBehaviour {
		
		public Game game;
		
		private float _timeOffset;

		GUIStyle style = new GUIStyle();
		GUIStyle style2 = new GUIStyle();

		public float scalex = Screen.width / 1920.0f;
   		public float scaley = Screen.height / 1080.0f;

		void Start () {
			style.fontSize = 38;
			style2.fontSize = 30;
			style2.normal.textColor = Color.white;
			style.normal.textColor = Color.white;
			_timeOffset = Time.timeSinceLevelLoad;
		}
		
		void Update () {
		}

		void OnGUI(){
			
   			GUI.matrix = Matrix4x4.TRS(new Vector3(0, 0, 0), Quaternion.identity, new Vector3(scalex, scaley, 1));
			TimeSpan timeSpan = TimeSpan.FromSeconds(Time.timeSinceLevelLoad - _timeOffset);
			string timeText = string.Format("{0:D2}:{1:D2}:{2:D2}", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
			GUI.Label(new Rect(1590,70,200,30), "" + game.score, style);
			GUI.Label(new Rect(1720,140,200,30), "" + game.bubblesDestroyed, style2);
			GUI.Label(new Rect(230,1020,200,30), "" + timeText, style2);
		}
	}
}
