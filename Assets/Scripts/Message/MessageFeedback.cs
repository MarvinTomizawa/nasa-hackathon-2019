using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageFeedback : MonoBehaviour
{
    [SerializeField]
    private GameObject Messagebox;

    [SerializeField]
    private Text Text;

    public void ShowError(string message)
    {
        Messagebox.SetActive(true);
        Text.text = message;
        StartCoroutine(HideError());
    }

    IEnumerator HideError()
    {
        yield return new WaitForSeconds(7);
        Messagebox.SetActive(false);
    }
}
