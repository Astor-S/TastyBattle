using System;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private Instruction _messageViewer;
    [SerializeField] private List<TutorialPart> _tutorialParts;

    private int _tutorialIndex;

    private void Start()
    {
        TimeManager.Pause();

        StartNextTutorial();
    }

    private void OnEnable() =>
        _messageViewer.MessagesOut += StartNextTutorial;

    private void OnDisable() =>
        _messageViewer.MessagesOut -= StartNextTutorial;

    private void StartNextTutorial()
    {
        if (_tutorialIndex < _tutorialParts.Count)
        {
            _messageViewer.SetTutorialPart(_tutorialParts[_tutorialIndex]);

            _tutorialIndex++;
        }
        else
        {
            CloseTutorial();
        }
    }

    private void CloseTutorial() =>
        TimeManager.Unpause();
}
