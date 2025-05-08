using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Tutorial", menuName = "Scriptable Objects/TutorialPart")]
public class TutorialPart : ScriptableObject
{
    [SerializeField] private List<string> _textFields;

    public IReadOnlyList<string> TextFields => _textFields;
}
