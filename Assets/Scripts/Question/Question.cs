using System.Linq;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Question : MonoBehaviour
{
    [SerializeField]
    public Option[] options = new Option[4];

    [SerializeField]
    public string text;

    public Text textField;

    public void AllocateFields()
    {
        textField = GameObject.FindGameObjectWithTag("QuestionText").GetComponent<Text>();
        textField.text = text;
        foreach (Option option in options)
        {
            option.Allocate();
        }
    }

    public bool ValidateIfRight(int optionNumber)
    {
        return options.Where(x => x.GetIndex().Equals(optionNumber)).FirstOrDefault().isRight();
    }
}
