using System.Collections.Generic;
using UnityEngine;

public class Caracteristics : MonoBehaviour
{
    public bool Answered;

    [SerializeField]
    public int NumberOfWrongs = 0;

    [SerializeField]
    private int NumberOfRights = 0;

    [SerializeField]
    private int MaxNumberOfQuestions = 4;

    [SerializeField]
    private QuestionList AllQuestions;

    private int ActualQuestionIndex = 0;

    private List<Question> chosedQuestions;

    public void Start()
    {
        Answered = false;
    }

    public void MissQuestion()
    {
        ActualQuestionIndex += 1;
        Debug.LogError(NumberOfWrongs);
        NumberOfWrongs += 1;
        if (NumberOfWrongs > 2)
        {
            throw new System.Exception();
        }
    }

    public void GetQuestionRight()
    {
        ActualQuestionIndex += 1;
        NumberOfRights += 1;
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

}
