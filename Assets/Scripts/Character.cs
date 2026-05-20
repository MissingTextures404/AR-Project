using UnityEngine;
using UnityEngine.InputSystem;

public class Character : MonoBehaviour
{
    public Rigidbody rb;
    public float Speed = 5f;

    private Vector2 moveInput;
    public InputActionReference move;

    void Awake()
    {
    }
    // Update is called once per frame
    void Update()
    {
        //simplifys the InputActionReference so i dont have to type this again and again
        moveInput = move.action.ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
        //for the movement, work out the forwards and get the forward input and apply the speed
        Vector3 movement = transform.forward * moveInput.y * Speed * Time.deltaTime;
        rb.MovePosition(rb.position + movement);

        //for the turning, work out the ammont it needs to turn
        float turning = moveInput.x * 60f * Time.deltaTime;
        //makes sure the turning is only applyed to the y axis
        Quaternion TurnRotation = Quaternion.Euler (0f, turning, 0f);
        //apply the turn
        rb.MoveRotation(rb.rotation * TurnRotation);
    }
}
