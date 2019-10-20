using UnityEngine;

public class QuestionController : MonoBehaviour
{
    private MessageFeedback messageFeedback;

    [SerializeField]
    private Caracteristics visitedPlanet;

    [SerializeField]
    private QuestionForm form;

    private void Start()
    {
        messageFeedback = GetComponent<MessageFeedback>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !(visitedPlanet is null))
        {
            StartQuestionnaire();
        }
    }

    public void SetPlanet(Caracteristics planet)
    {
        visitedPlanet = planet;
    }

    public void LeavePlanet()
    {
        visitedPlanet = null;
    }

    private void StartQuestionnaire()
    {
        visitedPlanet.ResetQuestionnaire();
        form.StartQuestionnaire(visitedPlanet);
    }
}
