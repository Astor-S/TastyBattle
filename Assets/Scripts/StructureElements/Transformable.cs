using System;
using UnityEngine;

namespace StructureElements
{
    public abstract class Transformable
    {
        public Transformable(Vector3 position = default, Quaternion rotation = default, Vector3 scale = default)
        {
            Position = position;
            Rotation = rotation;
            Scale = scale == default ? Vector3.one : scale;
        }

        public event Action Moved;

        public event Action Rotated;

        public event Action Scaled;

        public event Action Destroying;

        public Vector3 Position { get; private set; }

        public Quaternion Rotation { get; private set; }

        public Vector3 Scale { get; private set; }

        public void MoveTo(Vector3 position)
        {
            Position = position;
            Moved?.Invoke();
        }

        public void RotateOn(Quaternion rotation)
        {
            Rotation = rotation;
            Rotated?.Invoke();
        }

        public void ScaleTo(Vector3 scale)
        {
            Scale = scale;
            Scaled?.Invoke();
        }

        public void Destroy()
        {
            Destroying?.Invoke();
        }
    }
}