using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class MessageViewer : MonoBehaviour
{
    [SerializeField] private float _textSpeed;
    [SerializeField] private TextMeshProUGUI _text;

    private int _index;
    private WaitForSecondsRealtime _step;
    private bool _isTyping;

    public event Action MessagesOut;

    private void OnEnable() =>
        _step = new WaitForSecondsRealtime(_textSpeed * Time.deltaTime);

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && _isTyping == false)
            _text.text = string.Empty;
    }

    public IEnumerator TypeMessage(TutorialPart tutorialPart)
    {
        if (_index < tutorialPart.TextFields.Count)
        {
            _isTyping = true;

            foreach (char character in tutorialPart.TextFields[_index].ToCharArray())
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
