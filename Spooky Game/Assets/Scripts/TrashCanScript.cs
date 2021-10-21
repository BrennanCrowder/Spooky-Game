using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCanScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Destroying...");
        Destroy(collision.gameObject);
    }
}
