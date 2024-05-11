using UnityEngine;

public class Motion : MonoBehaviour
{
    [SerializeField] private CharacterController physic;
    [SerializeField] private float speed;
    [SerializeField] private Animator animator;
    [SerializeField] new private Camera camera;
    private void Start() => camera = Camera.main;

    public void Move(Vector3 motion)
    {
        if (motion.sqrMagnitude > 0.0f)
        {
            Movement(motion);
            UpdateSpeed(physic.velocity.magnitude);
        }
        else
        {
            UpdateSpeed(0);
        }
    }

    private void Movement(Vector3 motion)
    {
        var cameraMove = camera.transform.TransformDirection(motion);
        cameraMove.y = 0;
        cameraMove.Normalize();

        transform.forward = cameraMove;
        physic.Move(cameraMove * speed * Time.deltaTime);
    }

    private void UpdateSpeed(float speed) => animator.SetFloat("Speed", speed);
}
