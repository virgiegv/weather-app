using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class RainData
{
    public string request;

    [SerializeField]
    public Days[] days;
}

[Serializable]
public class Days
{
    public int day;
    public int amount;
}