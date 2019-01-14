using UnityEngine;
using System.Collections;
using com.alphakush.events;
using com.alphakush.gui;
using com.alphakush.sounds;
using UnityEngine.UI;

namespace com.alphakush{
	public class GameController : MonoBehaviour {

	
	public RayCastShooter[] shooters;
	private RayCastShooter selectedShooter;
	private bool mouseDown = false;
	protected Game _game;
	private HUD _hud;
	private GameObject _camera;
	
	private bool isAiming = false;
	private bool isPlaying = false;

	public Text Mouspos;

	public Image BorderRight;
	public Image BorderLeft;
	public Image BorderBottom;

	void Awake(){
		_game = new com.alphakush.Game();	
	}

	void Start () {
		BorderRight = GameObject.Find("BorderRight").GetComponent<Image>();
		BorderLeft = GameObject.Find("BorderLeft").GetComponent<Image>();
		BorderBottom = GameObject.Find("BorderBottom").GetComponent<Image>();
		Mouspos = GameObject.Find("Mousepos").GetComponent<Text>();
		BorderRight.enabled = false;
		BorderLeft.enabled = false;
		BorderBottom.enabled = false;
		this.isAiming = true;
		this.isPlaying = true;
		_camera = GameObject.Find("Main Camera");
		_hud = _camera.AddComponent<HUD>();
		_hud.game = this._game;
	}

	void OnEnable(){
			EventManager.OnBubblesRemoved += onBubblesRemoved;
			EventManager.OnNumberOfShoot += onNumberOfShoot;
			EventManager.OnGameFinished += onGameFinished;
			EventManager.OnDisableCursor += onDisableCursor;
	}

	void OnDisable(){
		EventManager.OnBubblesRemoved -= onBubblesRemoved;
		EventManager.OnNumberOfShoot -= onNumberOfShoot;
		EventManager.OnGameFinished -=onGameFinished;
		EventManager.OnDisableCursor -=onDisableCursor;
	}

	//Update is called once per frame
	void Update () {
		if (isPlaying == true) {
			if (Input.mousePosition.x >= BorderRight.transform.position.x || Input.mousePosition.x <= BorderLeft.transform.position.x || Input.mousePosition.y <= BorderBottom.transform.position.y) {
				EventManager.DisableCursor();
			} else {
				isAiming = true;
			}
		}
		Mouspos.text = Input.mousePosition.ToString();
		if (isAiming) {
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
	}

	protected virtual void onBubblesRemoved(int bubbleCount, bool exploded){
		this._game.destroyBubbles(bubbleCount, exploded);
	}

	protected virtual void onNumberOfShoot(){
		this._game.NbrOfShoot();
	}

	protected virtual void onDisableCursor(){
		this.isAiming = false;
	}

	protected virtual void onGameFinished(GameState state){
		GameFinishedGUI finishedGUI =  _camera.AddComponent<GameFinishedGUI>();
		this._game.state = state;
		finishedGUI.game = this._game;
		this.isPlaying = false;
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