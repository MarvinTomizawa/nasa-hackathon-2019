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
        player.StopMovement();
        form.SetActive(true);

        this.question = question;
        if (question is null)
        {
            CompleteQuestion();
        }
        else
        {
            question.AllocateFields();
        }
    }

    public void AnswerOption(int index)
    {
        try
        {
            if (question.ValidateIfRight(index))
            {
                Debug.LogError("jasbdajsbdajsbhd");
                planetCaracteristics.GetQuestionRight();
                Debug.LogError("jasbdajsbdajsbhd");

            }
            else
            {
                planetCaracteristics.MissQuestion();
            }

            StartQuestion(planetCaracteristics.GetNextQuestion());
        }
        catch (Exception)
        {
            FailQuestion();
        }
        
    }

    public void CompleteQuestion()
    {
        form.SetActive(false);
        player.LetMove();

    }

    public void FailQuestion()
    {
        form.SetActive(false);
        player.LetMove();
    }
}
