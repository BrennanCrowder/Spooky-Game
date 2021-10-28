using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessScript : MonoBehaviour
{
    [SerializeField] private Day3Manager manager;
    [SerializeField] private bool smear = true;
    [SerializeField] private GameObject mop;
    
    public Sprite goodSolid;
    public Sprite evilSolid;
    public Sprite goodSmear;
    public Sprite evilSmear;

    void Start()
    {
        if (1 == 0) // if karma is large enough
        {
            evilify();
        }
        else
        {
            if (!smear)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = goodSolid;
            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = goodSmear;

            }
        }
        manager.addMess(this);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject == mop)
        {
            mop.GetComponent<MopScript>().dirtCount += 1;
            manager.removeMess(this);
            Destroy(this.gameObject);
        }
    }

    public void evilify()
    {
        if (!smear)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = evilSolid;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = evilSmear;

        }
    }

    public void createSmear(GameObject mopObj, Day3Manager man)
    {
        mop = mopObj;
        manager = man;
    }
}
