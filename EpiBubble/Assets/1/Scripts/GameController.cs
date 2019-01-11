using UnityEngine;
using System.Collections;
using com.alphakush.events;
using com.alphakush.gui;

namespace com.alphakush{

	public class GameController : MonoBehaviour {

	public RayCastShooter[] shooters;
	private RayCastShooter selectedShooter;
	private bool mouseDown = false;
	protected Game _game;
	private HUD _hud;
	private GameObject _camera;

	void Awake(){
		_game = new com.alphakush.Game();	
	}

	void Start () {
		_camera = GameObject.Find("Main Camera");
		_hud = _camera.AddComponent<HUD>();
		_hud.game = this._game;
	}

	void OnEnable(){
			EventManager.OnBubblesRemoved += onBubblesRemoved;
			EventManager.OnNumberOfShoot += onNumberOfShoot;
	}
	void OnDisable(){
		EventManager.OnBubblesRemoved -= onBubblesRemoved;
		EventManager.OnNumberOfShoot -= onNumberOfShoot;
	}
	//Update is called once per frame
	void Update () {
		selectedShooter = shooters[0];
		TouchMove(Input.mousePosition);
		if (Input.touches.Length > 0) {
			Touch touch = Input.touches [0];
			if (touch.phase == TouchPhase.Canceled || touch.phase == TouchPhase.Ended) {
				TouchUp (Input.mousePosition);
			} else if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary) {
				TouchMove (touch.position);
			}
			TouchMove (touch.position);
			return;
		} else if (Input.GetMouseButtonUp (0)) {
			mouseDown = false;
			TouchUp (Input.mousePosition);
		} else if (mouseDown) {
			TouchMove (Input.mousePosition);
		}
	}

	protected virtual void onBubblesRemoved(int bubbleCount, bool exploded){
		this._game.destroyBubbles(bubbleCount, exploded);
	}

	protected virtual void onNumberOfShoot(){
		this._game.NbrOfShoot();
	}


	void TouchUp (Vector2 touch) {
		if (selectedShooter == null)
			return;
		selectedShooter.HandleTouchUp (touch);
	}

	void TouchMove (Vector2 touch) {
		if (selectedShooter == null)
			return;
		selectedShooter.HandleTouchMove (touch);
	}
}
}