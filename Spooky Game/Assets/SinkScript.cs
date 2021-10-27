using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinkScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Tool"))
        {
            Debug.Log("InWater...");
            other.gameObject.transform.parent.GetComponent<ToolScript>().clean();
        }
    }
}
