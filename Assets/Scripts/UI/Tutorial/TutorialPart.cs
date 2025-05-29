using System.Collections.Generic;
using UnityEngine;
using YG;

namespace UI.Tutorial
{
    [CreateAssetMenu(fileName = "Tutorial", menuName = "Scriptable Objects/TutorialPart")]
    public class TutorialPart : ScriptableObject
    {
        [SerializeField] private TextTranslation[] _textTranslation;
        [SerializeField] private float _cameraPositionX;
        [SerializeField] private float _speakerPositionX;
        [SerializeField] private Vector3 _cursorPosition;
        [SerializeField] private Quaternion _cursorRotation;

        private List<string> _textFields = new ();

        public List<string> TextFields => _textFields;
        public float CameraPositionX => _cameraPositionX;
        public float SpeakerPositionX => _speakerPositionX;
        public Vector3 CursorPosition => _cursorPosition;
        public Quaternion CursorRotation => _cursorRotation;

        private void Awake() =>
            Init();

        private void OnValidate() =>
            Init();

        private void Init()
        {
            _textFields.Clear();

            if (_textFields.Count == 0)
                foreach (TextTranslation text in _textTranslation)
                    _textFields.Add(text.Dictionary[YG2.lang]);
        }
    }
}