using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class Instruction : MonoBehaviour
{
    [SerializeField] private float _textSpeed;
    [SerializeField] private TextMeshProUGUI _text;

    private TutorialPart _currentPart;
    private WaitForSecondsRealtime _step;
    private int _index;
    private bool _isTyping;

    public event Action MessagesOut;

    private void OnEnable() =>
        _step = new WaitForSecondsRealtime(_textSpeed * Time.deltaTime);

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && _isTyping == false)
        {
            _text.text = string.Empty;

            StartCoroutine(TypeMessage());
        }
    }

    public void SetTutorialPart(TutorialPart tutorialPart)
    {
        _currentPart = tutorialPart;
        _index = 0;

        StartCoroutine(TypeMessage());
    }

    public IEnumerator TypeMessage()
    {
        if (_index < _currentPart.TextFields.Count)
        {
            _isTyping = true;

            foreach (char character in _currentPart.TextFields[_index].ToCharArray())
            {
                _text.text += character;

                yield return _step;
            }

            _isTyping = false;

            _index++;
        }
        else
        {
            MessagesOut?.Invoke();
        }
    }
}
