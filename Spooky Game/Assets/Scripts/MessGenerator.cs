using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessGenerator : MonoBehaviour
{
    [SerializeField] private GameObject messBase;
    [SerializeField] private Day3Manager manager;
    [SerializeField] private GameObject mop;

    [SerializeField] private float xMin = -4;
    [SerializeField] private float xMax = 4;
    [SerializeField] private float yMin = -3;
    [SerializeField] private float yMax = 3;

    [SerializeField] private int spawnCount = 150;
    private GameObject currentMess;

    void Awake()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            currentMess = Instantiate(messBase, new Vector3(Random.Range(xMin, xMax), Random.Range(yMin, yMax), 0), new Quaternion(0, 0, 0, 0));
            currentMess.GetComponent<MessScript>().createSmear(mop, manager);
        }
    }
}
