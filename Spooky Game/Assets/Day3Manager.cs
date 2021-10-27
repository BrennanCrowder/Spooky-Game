using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day3Manager : MonoBehaviour
{
    public GameObject background;
    public GameObject bucket;
    public GameObject mom;
    public GameObject[] dirt;
    public GameObject[] smear;



    public void setEvil()
    {
        background.GetComponent<Evilify>().makeEvil();
        background.GetComponent<Evilify>().makeEvil();
        background.GetComponent<Evilify>().makeEvil();

        foreach(GameObject items in dirt)
        {
            items.GetComponent<Evilify>().makeEvil();
        }

        foreach (GameObject items in smear)
        {
            items.GetComponent<Evilify>().makeEvil();
        }
    }
   
}
