using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private MessageViewer _messageViewer;

    private void Start()
    {
        TimeManager.Pause();
    }

    private void OnEnable() => 
        _messageViewer.MessagesOut += CloseTutorial;

    private void OnDisable() => 
        _messageViewer.MessagesOut -= CloseTutorial;

    private void CloseTutorial()
    {
        gameObject.SetActive(false);
    }
}
