using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunFases : MonoBehaviour
{
    [SerializeField]
    private GameObject[] sunfases = new GameObject[8];

    private int ActiveFase = 0;

    void Start()
    {
        ActivateFase();
    }

    public void NextFase()
    {
        sunfases[ActiveFase].SetActive(false);
        ActiveFase += 1;
        ActivateFase();
    }

    void ActivateFase()
    {
        sunfases[ActiveFase].SetActive(true);
    }

}
