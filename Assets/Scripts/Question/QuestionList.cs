using System.Collections.Generic;
using UnityEngine;

public class QuestionList : MonoBehaviour
{
    [SerializeField]
    private List<Question> AllQuestions = new List<Question>();

    public List<Question> FindQuestions(int NumberOfQuestions)
    {
        if (NumberOfQuestions > AllQuestions.Count)
        {
            Debug.Log($"Number of questions asked {NumberOfQuestions} is bigger than the number of questions we have {AllQuestions.Count}");
            return null;
        }

        List<Question> copyFromList = new List<Question>(AllQuestions);

        List<Question> returnedQuestions = new List<Question>();

        for (int index = 0; index < NumberOfQuestions; index++ )
        {
            int randomIndex = Mathf.FloorToInt( Random.Range(0, copyFromList.Count -1));
            returnedQuestions.Add(copyFromList[randomIndex]);
            copyFromList.RemoveAt(randomIndex);
        }

        return returnedQuestions;

    }

}
