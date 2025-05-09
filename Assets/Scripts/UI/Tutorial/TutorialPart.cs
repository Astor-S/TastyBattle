using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Tutorial", menuName = "Scriptable Objects/TutorialPart")]
public class TutorialPart : ScriptableObject
{
    [SerializeField] private List<string> _textFields;
    [SerializeField] private float _cameraPositionX;
    [SerializeField] private float _speakerPositionX;
    [SerializeField] private Vector3 _cursorPosition;
    [SerializeField] private Quaternion _cursorRotation;

    public IReadOnlyList<string> TextFields => _textFields;
    public float CameraPositionX => _cameraPositionX;
    public float SpeakerPositionX => _speakerPositionX;
    public Vector3 CursorPosition => _cursorPosition;
    public Quaternion CursorRotation => _cursorRotation;
}