using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cleanBinScript : MonoBehaviour
{

    private int cleanTools = 0;
    private int dirtyTools = 0;
    public Day2Manager day2Manager;


    //public GameObject[] toolsInBin;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.parent.GetComponent<ToolScript>().inBin)
        {
            return;
        }
        else if(other.transform.parent.GetComponent<SpriteRenderer>().sprite == other.transform.parent.GetComponent<ToolScript>().cleanVersion)
        {
            day2Manager.cleanTool();
        } 
        else
        {
            day2Manager.dirtyTool();
        }
        other.transform.parent.GetComponent<ToolScript>().inBin = true;
        Debug.Log("Tools in Bin: " + (cleanTools+dirtyTools));
    }
}
