using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using YG;

public class Instruction : MonoBehaviour
{
    [SerializeField] private float _textSpeed = 1f;
    [SerializeField] private TextMeshProUGUI _text;

    private TutorialPart _currentPart;
    private WaitForSeconds _step;
    private List<string> _textFields = new();
    private int _index;
    private bool _isTyping;

    public event Action MessagesOut;

    private void OnEnable() =>
        _step = new WaitForSeconds(_textSpeed * Time.fixedDeltaTime);

    private void Update()
    {
        if (Input.GetMouseButtonUp(0) && _isTyping == false)
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
        _textFields = _currentPart.LanguageTextTutorials[YG2.envir.language];

        if (_index < _textFields.Count)
        {
            _isTyping = true;

            foreach (char character in _textFields[_index].ToCharArray())
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
