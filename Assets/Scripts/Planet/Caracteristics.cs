using System;
using System.Collections.Generic;
using UnityEngine;

public class Caracteristics : MonoBehaviour
{
    public bool Answered;

    [SerializeField]
    private string PlanetName;

    [SerializeField]
    [Range(1,8)]
    private int PlanetIndex;

    [SerializeField]
    private GameObject brokenImage;

    [SerializeField]
    private GameObject normalImage;

    [SerializeField]
    public int NumberOfWrongs = 0;

    [SerializeField]
    private int NumberOfRights = 0;

    [SerializeField]
    private int MaxNumberOfQuestions = 4;

    [SerializeField]
    private QuestionList AllQuestions;

    private Sinalizer sinalizer;

    public int ActualQuestionIndex = 0;

    private List<Question> chosedQuestions;

    public void Start()
    {
        Answered = false;
        sinalizer = GameObject.FindGameObjectWithTag("Sinalizer").GetComponent<Sinalizer> ();
    }

    public void MissQuestion()
    {
        sinalizer.SetWrong();
        ActualQuestionIndex += 1;
        NumberOfWrongs += 1;
        if (NumberOfWrongs > 2)
        {
            throw new System.Exception();
        }
        validate();

    }

    internal int GetIndex()
    {
        return PlanetIndex;
    }

    public void GetQuestionRight()
    {
        sinalizer.SetRight();
        ActualQuestionIndex += 1;
        NumberOfRights += 1;
        validate();

    }

    public void validate()
    {
        if (NumberOfRights + NumberOfWrongs == MaxNumberOfQuestions && NumberOfRights > NumberOfWrongs)
        {
            RevivePlanet();
        }
    }
    public void ResetQuestionnaire()
    {
        NumberOfRights = 0;
        NumberOfWrongs = 0;
        ActualQuestionIndex = 0;
        chosedQuestions = AllQuestions.FindQuestions(4);
    }

    public Question GetNextQuestion()
    {
        if (ActualQuestionIndex > MaxNumberOfQuestions)
        {
            return null;
        }
        return chosedQuestions[ActualQuestionIndex];
    }

    public void RevivePlanet()
    {
        Answered = true;
        FindObjectOfType<SunFases>().NextFase();
        brokenImage.SetActive(false);
        normalImage.SetActive(true);
    }

    public string GetPlanet()
    {
        return PlanetName;
    }

    public GameObject GetProjectImage()
    {
        return brokenImage;
    }

}
