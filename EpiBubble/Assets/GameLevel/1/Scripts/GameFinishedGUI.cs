using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using com.alphakush.sounds;

namespace com.alphakush.gui{
	public class GameFinishedGUI : MenuGUI {
		
		public Game game;

		public Canvas mycanvas;
		public Text Resultgame;

		protected override void  Start () {
			mycanvas = GameObject.Find("Canvas").GetComponent<Canvas>();
			Resultgame = GameObject.Find("GameState").GetComponent<Text>();
			if (game.Win = true){
				SoundManager.Instance.WinSound();
				} else {
					SoundManager.Instance.LooseSound();
				}
			Resultgame.text = "You " + game.state;
			base.Start();
		}
			
			protected override void Update () {
				base.Update ();
			}
			
			protected override void  OnGUI(){
				mycanvas.enabled = true;
			}
		}
}