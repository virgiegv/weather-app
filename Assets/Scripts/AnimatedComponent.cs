using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedComponent : MonoBehaviour
{
    public void startAnimation()
    {
        gameObject.GetComponent<Animator>().SetBool("Paused", false);
    }

    public void pauseAnimation()
    {
        gameObject.GetComponent<Animator>().SetBool("Paused", true);
    }

}
