using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evilify : MonoBehaviour
{
    public Sprite evilVersion;
    public void makeEvil()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = evilVersion;
    }
}
