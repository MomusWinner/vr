using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player singaleton { get; private set; }

    private void Awake()
    {
        singaleton = this;
    }
}
