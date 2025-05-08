using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private MessageViewer _messageViewer;
    [SerializeField] private List<TutorialPart> _tutorialParts;

    private int _tutorialIndex;

    private void Start()
    {
        TimeManager.Pause();

        StartTutorial();
    }

    private void OnEnable() => 
        _messageViewer.MessagesOut += StartNextTutorial;

    private void OnDisable() => 
        _messageViewer.MessagesOut -= StartNextTutorial;

    private void StartNextTutorial()
    {
        if (_tutorialIndex < _tutorialParts.Count)
        {
            StartTutorial();

            _tutorialIndex++;
        }
    }

    private void StartTutorial() => 
        StartCoroutine(_messageViewer.TypeMessage(_tutorialParts[_tutorialIndex]));
}
