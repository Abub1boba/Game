using UnityEngine;

public class motion : MonoBehaviour
{
    [SerializeField] private CharacterController physic;
    [SerializeField] private float speed;
    [SerializeField] private Animator animator;
    private Vector3 input;
    private Camera camera;

    private void Start()
    {
        camera = Camera.main;
    }

    void Update()
    {

        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        input = new Vector3 (horizontal, 0, vertical);

        Vector3 cameramove = camera.transform.TransformDirection(input);
        cameramove.y = 0;
        cameramove.Normalize();
        transform.forward = cameramove;

        physic.Move(cameramove * speed * Time.deltaTime);
        animator.SetFloat("Speed", physic.velocity.magnitude);
    }
}
