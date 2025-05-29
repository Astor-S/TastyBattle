using UnityEngine;

namespace SaveSystems
{
    public abstract class SaveSystem : MonoBehaviour
    {
        public abstract void Load();
        public abstract void Save();
        public abstract void LoadLocal();
    }
}