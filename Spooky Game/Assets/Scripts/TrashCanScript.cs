using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TrashCanScript : MonoBehaviour
{
    public UnityEvent trashAway;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Destroying...");
        trashAway.Invoke();
        Destroy(collision.gameObject);
        
    }
}
