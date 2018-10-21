using com.katamari.UserInput;
using Unity.Entities;
using UnityEngine;

namespace com.katamari.PlayerMovement
{
    public class BallMovementSystem : ComponentSystem
    {
        private struct Filter
        {
            public Rigidbody Rigidbody;
            public SphereCollider SphereCollider;
            public InputComponent InputComponent;
        }

        protected override void OnUpdate()
        {
            var deltaTime = Time.deltaTime;
            foreach (var entity in GetEntities<Filter>())
            {
                Vector3 moveVector = new Vector3(entity.InputComponent.Horizontal,0,entity.InputComponent.Vertical);
                Vector3 deltaMovement = moveVector.normalized * 1 * deltaTime;

                Vector3 movePosition = entity.Rigidbody.position + deltaMovement;
                Vector3 rotationAxis = Vector3.Cross(Vector3.up, deltaMovement.normalized);

                entity.Rigidbody.MovePosition(movePosition);
                var rotation = Quaternion.AngleAxis(deltaMovement.magnitude / entity.SphereCollider.radius * 90, rotationAxis);
                entity.Rigidbody.MoveRotation(rotation * entity.Rigidbody.rotation);
            }
        }
    }
}
