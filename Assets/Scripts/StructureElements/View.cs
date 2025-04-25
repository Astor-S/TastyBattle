using System;
using UnityEngine;

namespace StructureElements
{
    public class View : MonoBehaviour
    {
        [SerializeField] private SoundPlayer _soundPlayer;

        protected SoundPlayer SoundPlayer => _soundPlayer;
    }
}
