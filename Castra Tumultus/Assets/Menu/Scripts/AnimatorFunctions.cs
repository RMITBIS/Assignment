using UnityEngine;

public class AnimatorFunctions : MonoBehaviour
{ 

    MenuButtonController menuButtonController;
    public bool disableOnce;

    void PlaySound (AudioClip whichSound)
    {
        if (!disableOnce)
        {
            menuButtonController.audioSource.PlayOneShot(whichSound);
        }
        else
        {
            disableOnce = false;
        }
    }

}