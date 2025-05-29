using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TextTranslation", menuName = "Scriptable Objects/Translation")]
public class TextTranslation : ScriptableObject
{
    private const string Russian = "ru";
    private const string English = "en";
    private const string Turkey = "tr";

    [SerializeField] private string _ruText;
    [SerializeField] private string _enText;
    [SerializeField] private string _trText;

    private Dictionary<string, string> _dictionary = new Dictionary<string, string>();

    public string RuText => _ruText;
    public string EnText => _enText;
    public string TrText => _trText;
    public IReadOnlyDictionary<string, string> Dictionary => _dictionary;

    private void OnValidate() =>
        Init();

    private void Awake() =>
        Init();

    private void Init()
    {
        if (_dictionary.Count == 0)
        {
            _dictionary.Add(Russian, _ruText);
            _dictionary.Add(English, _enText);
            _dictionary.Add(Turkey, _trText);
        }
    }
}
