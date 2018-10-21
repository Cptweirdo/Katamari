using Unity.Entities;
using UnityEngine;

namespace com.katamari.UserInput
{
    public class InputSystem : ComponentSystem
    {
        private struct Data
        {
            public readonly int Length;
            public ComponentArray<InputComponent> InputComponent;
        }

        [Inject]
        private readonly Data _data;

        protected override void OnUpdate()
        {
            float v = Input.GetAxis("Horizontal");
            float v1 = Input.GetAxis("Vertical");

            for (int i = 0; i < _data.Length; i++)
            {
                _data.InputComponent[i].Horizontal = v;
                _data.InputComponent[i].Vertical = v1;
            }
        }
    }
}
