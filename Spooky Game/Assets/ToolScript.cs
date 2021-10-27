using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolScript : MonoBehaviour
{
    public Sprite cleanVersion;
    public bool inBin = false;

    private void Update()
    {
        if (transform.position.y < -10)
        {
            transform.position = new Vector2(transform.position.x, 12);
        }
        if (transform.position.x > 9 || transform.position.x < -9)
        {
            transform.position = new Vector2(5 * transform.position.normalized.x, transform.position.y);
        }
    }


    public void clean()
    {
        Debug.Log("Cleaning...");
        GetComponent<SpriteRenderer>().sprite = cleanVersion;
    }


}
