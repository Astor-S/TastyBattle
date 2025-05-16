using System.Collections.Generic;
using UnityEngine;

public class UnitModelView : MonoBehaviour
{
    [SerializeField] private string _description;
    [SerializeField] private string _enDescription;
    [SerializeField] private string _trDescription;

    private Dictionary<string, string> _languageDescription = new();

    public IReadOnlyDictionary<string, string> LanguageDescription => _languageDescription;

    //TODO: Magic values
    private void Awake()
    {
        _languageDescription.Add("ru", _description);
        _languageDescription.Add("en", _enDescription);
        _languageDescription.Add("tr", _trDescription);
    }
}