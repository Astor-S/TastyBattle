using StructureElements;
using UnityEngine;

namespace Units
{
    public class Unit : Presenter
    {
        private float _speed = 1.35f;

        private void Start()
        {
            if (TryGetComponent(out Animator animator))
                animator.SetBool("IsWalking", true);
        }

        private void FixedUpdate()
        {
            transform.Translate(_speed * Time.fixedDeltaTime * Vector3.right, Space.World);
        }
    }
}
