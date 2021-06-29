using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class AnimationController : MonoBehaviour
{
    private AnimatedComponent[] animatedComponents;
    private void Awake()
    {
        animatedComponents = gameObject.transform.GetComponentsInChildren<AnimatedComponent>();
    }

    public void StartAnimation()
    {

        foreach (AnimatedComponent animatedComponent in animatedComponents)
        {
            animatedComponent.startAnimation();
        }
    }
    
    public void StopAnimation()
    {
        foreach (AnimatedComponent animatedComponent in animatedComponents)
        {
            animatedComponent.pauseAnimation();
        }
    }
}
