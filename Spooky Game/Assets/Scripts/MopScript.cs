using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MopScript : MonoBehaviour
{
    [SerializeField] private int dirtMax = 5;
    [SerializeField] private double smearCooldown = 1;
    private double smearTime = 0;
    [SerializeField] private GameObject smear;
    public int dirtCount = 0;
    public bool alreadyDirty;
    private bool evil = false;
    [SerializeField] private GameObject bucket;
    [SerializeField] private Day3Manager manager;
    private GameObject newSmear;

    [SerializeField] private Sprite mopClean;
    [SerializeField] private Sprite mopDirty;
    [SerializeField] private Sprite mopBloody;

    void Awake()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = mopClean;
    }

    // Update is called once per frame
    void Update()
    {
        if (dirtCount >= dirtMax)
        {
            if (!alreadyDirty)
            {
                if (evil) gameObject.GetComponent<SpriteRenderer>().sprite = mopBloody;
                else gameObject.GetComponent<SpriteRenderer>().sprite = mopDirty;
                alreadyDirty = true;
            }

            if (smearTime >= smearCooldown && !manager.flag)
            {
                newSmear = Instantiate(smear, this.gameObject.transform.position + new Vector3(1, 0, 0), this.gameObject.transform.rotation);
                newSmear.GetComponent<MessScript>().createSmear(this.gameObject, manager);
                if (evil) newSmear.GetComponent<MessScript>().evilify();
                smearTime = 0;
            }
            else
            {
                smearTime += Time.deltaTime;
            }
        }
        else smearTime = smearCooldown;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject == bucket)
        {
            dirtCount = 0;
            gameObject.GetComponent<SpriteRenderer>().sprite = mopClean;
            alreadyDirty = false;
        }
    }

    public void evilify()
    {
        evil = true;
        gameObject.GetComponent<SpriteRenderer>().sprite = mopBloody;
    }
}
