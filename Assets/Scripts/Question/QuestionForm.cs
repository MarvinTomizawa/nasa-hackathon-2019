using System;
using UnityEngine;

public class QuestionForm : MonoBehaviour
{
    [SerializeField]
    private GameObject form;

    [SerializeField]
    private Caracteristics planetCaracteristics;

    private Question question;

    private PLayerMovement player;

    private void Start()
    {
        player = FindObjectOfType<PLayerMovement>();
        form.SetActive(false);
    }

    public void StartQuestionnaire(Caracteristics caracteristics)
    {
        this.planetCaracteristics = caracteristics;
        StartQuestion(caracteristics.GetNextQuestion());
    }

    public void StartQuestion(Question question)
    {
        Debug.LogError("Oi");
        player.StopMovement();
        form.SetActive(true);

        if (question is null)
        {
            
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

            Debug.Log(index);


            Question question = planetCaracteristics.GetNextQuestion();

            if (question is null)
            {
                CompleteQuestion();
            }

            StartQuestion(question);
        }
        catch (Exception e )
        {
            Debug.Log("Finished this");
            Debug.Log(e.Message);
            Debug.Log(planetCaracteristics.ActualQuestionIndex);

            FailQuestion();
        }
        
    }

    public void CompleteQuestion()
    {
        planetCaracteristics.RevivePlanet();
        form.SetActive(false);
        player.LetMove();

    }

    public void FailQuestion()
    {
        form.SetActive(false);
        player.LetMove();
    }
}
