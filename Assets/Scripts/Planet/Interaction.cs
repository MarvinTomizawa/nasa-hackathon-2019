using UnityEngine;

public class Interaction : MonoBehaviour
{
    [SerializeField]
    private QuestionController questionController;

    [SerializeField]
    private Caracteristics caracteristics;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            questionController.SetPlanet(caracteristics);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            questionController.LeavePlanet();
        }
    }
}
