using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
  public AudioClip GameSong;

    public static SoundController soundcontroller;
    // Start is called before the first frame update
    void Awake(){
      if (soundcontroller == null){
        DontDestroyOnLoad(gameObject);
        soundcontroller = this;
      } else if (soundcontroller != this){
        Destroy(gameObject);
      }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
