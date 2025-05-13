using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private Instruction _messageViewer;
    [SerializeField] private List<TutorialPart> _tutorialParts;
    [SerializeField] private RectTransform _speakerTransform;
    [SerializeField] private RectTransform _cursorTransform;
    [SerializeField] private Camera _camera;
    [SerializeField] private Transform[] _activatableObjects;

    private float _duration = 2f;
    private int _tutorialIndex;

    private void OnEnable() => 
        _messageViewer.MessagesOut += StartNextTutorial;

    private void OnDisable() =>
        _messageViewer.MessagesOut -= StartNextTutorial;

    private void Start() =>
        StartNextTutorial();

    private void StartNextTutorial()
    {
        if (_tutorialIndex < _tutorialParts.Count)
        {
            TutorialPart tutorial = _tutorialParts[_tutorialIndex];

            _messageViewer.SetTutorialPart(tutorial);

            _activatableObjects[_tutorialIndex].gameObject.SetActive(true);

            if (_tutorialIndex > 0)
            {
                _speakerTransform.DOScale(Vector3.one, _duration);
                _speakerTransform.DOAnchorPosX(tutorial.SpeakerPositionX, _duration);
                _camera.transform.DOMoveX(tutorial.CameraPositionX, _duration);
                _cursorTransform.DOAnchorPos(tutorial.CursorPosition, _duration);
                _cursorTransform.DORotateQuaternion(tutorial.CursorRotation, _duration);
            }

            _tutorialIndex++;
        }
        else
        {
            DOTween.Clear();

            CloseTutorial();
        }
    }

    //TODO
    public void CloseTutorial() =>
        SceneManager.LoadScene("MushroomLevel1");
}
