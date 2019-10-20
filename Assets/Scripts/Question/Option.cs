using UnityEngine;
using UnityEngine.UI;

public class Option : MonoBehaviour
{
    [SerializeField]
    private bool RightAnswer;

    [SerializeField]
    private string text;

    [SerializeField]
    [Range(0,3)]
    private int index;

    private Text textField;

    public void Allocate()
    {
        string flag = "";

        switch (index)
        {
            case 0:
                flag = "FirstOption";
                break;
            case 1:
                flag = "SecondOption";
                break;
            case 2:
                flag = "ThirdOption";
                break;
            case 3:
                flag = "FourthOption";
                break;
        }

        textField = GameObject.FindGameObjectWithTag(flag).GetComponent<Text>();
        textField.text = text;
    }

    public bool isRight()
    {
        return RightAnswer;
    }

    public int GetIndex()
    {
        return index;
    }
}
