using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Tutorial", menuName = "Scriptable Objects/TutorialPart")]
public class TutorialPart : ScriptableObject
{
    [SerializeField] private List<string> _textFields;
    [SerializeField] private List<string> _engTextFields;
    [SerializeField] private List<string> _trTextFields;
    [SerializeField] private float _cameraPositionX;
    [SerializeField] private float _speakerPositionX;
    [SerializeField] private Vector3 _cursorPosition;
    [SerializeField] private Quaternion _cursorRotation;

    private Dictionary<string, List<string>> _languageTextTutorials = new();

    //public IReadOnlyList<string> TextFields => _textFields;
    public float CameraPositionX => _cameraPositionX;
    public float SpeakerPositionX => _speakerPositionX;
    public Vector3 CursorPosition => _cursorPosition;
    public Quaternion CursorRotation => _cursorRotation;
    public IReadOnlyDictionary<string, List<string>> LanguageTextTutorials => _languageTextTutorials;

    private void Awake()
    {
        _languageTextTutorials.Add("ru", _textFields);  
        _languageTextTutorials.Add("en", _engTextFields);
        _languageTextTutorials.Add("tr", _trTextFields);
    }
}