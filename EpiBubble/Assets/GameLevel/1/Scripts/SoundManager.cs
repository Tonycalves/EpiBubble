using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace com.alphakush.sounds{
  public class SoundManager : MonoBehaviour
    {
      public static SoundManager Instance;

      public AudioClip ShotBubbleSound;
      public AudioClip BubbleExplodeSound;
      public AudioClip Win;
      public AudioClip Loose;
/*      public AudioClip ButtonCliqueSound;
      public AudioClip GameMusicSound;*/

      void Awake()
      {
        if (Instance != null)
        {
          Debug.LogError("Multiple instances of SoundManager!");
        }
        Instance = this;
      }

      public void MakeBubbleExplodeSound()
      {
        //SoundManager.Instance.MakeBubbleExplodeSound();
        MakeSound(BubbleExplodeSound);
      }

      public void MakeShotBubbleSound()
      {
        ////SoundManager.Instance.MakeShotBubbleSound();
        MakeSound(ShotBubbleSound);
      }

      public void WinSound()
      {
        ////SoundManager.Instance.WinSound();
        MakeSound(Win);
      }
      public void LooseSound()
      {
        ////SoundManager.Instance.LooseSound();
        MakeSound(Loose);
      }

      private void MakeSound(AudioClip originalClip)
      {
        AudioSource.PlayClipAtPoint(originalClip, transform.position);
      }

    }
}
