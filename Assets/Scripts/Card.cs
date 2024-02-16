using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Card : MonoBehaviour
{
    public int Owner { get; set; }
    public bool IsFixed { get; set; }
    public SpriteRenderer sr { get; private set; }

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }
}
