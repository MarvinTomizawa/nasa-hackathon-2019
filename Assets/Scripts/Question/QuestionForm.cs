using System;
using UnityEngine;
using UnityEngine.UI;

public class QuestionForm : MonoBehaviour
{
    [SerializeField]
    private GameObject form;

    [SerializeField]
    private Caracteristics planetCaracteristics;

    private Question question;

    private PLayerMovement player;

    [SerializeField]
    public Text PlanetName;

    [SerializeField]
    public GameObject[] planets = new GameObject[8];

    [SerializeField]
    private SunFases SunFases;

    private int PlanetIndex = 0;

    private void Start()
    {
        player = FindObjectOfType<PLayerMovement>();
        form.SetActive(false);
    }

    public void StartQuestionnaire(Caracteristics caracteristics)
    {
        foreach (GameObject planet in planets)
        {
            planet.SetActive(false);
        }
        PlanetName.text = caracteristics.GetPlanet();
        PlanetIndex = caracteristics.GetIndex();
        planets[PlanetIndex - 1].SetActive(true);
        this.planetCaracteristics = caracteristics;
        StartQuestion(caracteristics.GetNextQuestion());
    }

    public void DisableActualSelectedPlanet()
    {
    }

    public void StartQuestion(Question question)
    {
        player.StopMovement();
        form.SetActive(true);

        if (question is null)
        {
            CompleteQuestion();
        }
        else
        {
            this.question = question;
            question.AllocateFields();
        }
    }

    public void AnswerOption(int index)
    {
        try
        {
            if (this.question.ValidateIfRight(index))
            {
                planetCaracteristics.GetQuestionRight();

            }
            else
            {
                planetCaracteristics.MissQuestion();
            }

            Question question = planetCaracteristics.GetNextQuestion();

            if (question is null)
            {
                CompleteQuestion();
            }

            StartQuestion(question);
        }
        catch (Exception)
        {
            FailQuestion();
        }
        
    }

    public void CompleteQuestion()
    {
        planetCaracteristics.RevivePlanet();
        form.SetActive(false);
        SunFases.NextFase();
        player.LetMove();

    }

    public void FailQuestion()
    {
        foreach (GameObject planet in planets)
        {
            planet.SetActive(false);
        }
        form.SetActive(false);
        player.LetMove();
    }
}
