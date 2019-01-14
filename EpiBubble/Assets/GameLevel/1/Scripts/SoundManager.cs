using UnityEngine;
using System.Collections;

namespace com.alphakush.sounds{
  public class SoundManager : MonoBehaviour
    {
      public static SoundManager Instance;

      public AudioClip ShotBubbleSound;
      public AudioClip BubbleExplodeSound;

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

      private void MakeSound(AudioClip originalClip)
      {
        AudioSource.PlayClipAtPoint(originalClip, transform.position);
      }
    }
}
