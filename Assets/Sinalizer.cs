using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sinalizer : MonoBehaviour
{
    public GameObject[] rights = new GameObject[4];

    public GameObject[] wrongs = new GameObject[4];

    public int index = 0;

    void Start()
    {
        
    }

    public void SetRight()
    {
        rights[index].SetActive(true);
        index += 1;
    }

    public void SetWrong()
    {
        wrongs[index].SetActive(true);
        index += 1;
    }

    public void ResetAll()
    {
        foreach (GameObject item in rights)
        {
            item.SetActive(false);
        }

        foreach (GameObject item in wrongs)
        {
            item.SetActive(false);
        }

        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
