using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day3Manager : MonoBehaviour
{
    public GameObject background;
    public GameObject bucket;
    public GameObject mom;
    public GameObject mop;
    private List<MessScript> messList = new List<MessScript>();



    public GameManager gameMan;

    private void OnLevelWasLoaded(int level)
    {
        gameMan = GameManager.GM;
    }

    public void setEvil()
    {
        background.GetComponent<Evilify>().makeEvil();
        bucket.GetComponent<Evilify>().makeEvil();
        mom.GetComponent<Evilify>().makeEvil();
        mop.GetComponent<MopScript>().evilify();

        foreach(MessScript item in messList)
        {
            item.evilify();
        }
    }
   
    public void addMess(MessScript mess)
    {
        messList.Add(mess);
    }

    public void removeMess(MessScript mess)
    {
        messList.Remove(mess);
    }

    public void setEvilObjects()
    {
        bucket.GetComponent<Evilify>().makeEvil();
        mop.GetComponent<MopScript>().evilify();
        foreach (MessScript item in messList)
        {
            item.evilify();
        }
    }
}
