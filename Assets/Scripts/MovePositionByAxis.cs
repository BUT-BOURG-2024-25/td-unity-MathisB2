using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovePositionByAxis : MonoBehaviour
{

    [SerializeField]
    private float speed = 2f;

    [SerializeField]
    private float jumpPower = 20;

    [SerializeField]
    private Rigidbody physicsBody;
    // Start is called before the first frame update
    void Start()
    {
        InputManager.instance.registerOnJumpInput(jump);
    }


    private void OnDestroy()
    {
        InputManager.instance.unregisterOnJumpInput(jump);
    }


    private void jump(InputAction.CallbackContext callbackContext)
    {
        physicsBody.AddForce(Vector3.up * jumpPower);
    }



    // Update is called once per frame
    void Update()
    {
        //float horizontal = Input.GetAxis("Horizontal");
        //float vertical = Input.GetAxis("Vertical");

        Vector3 newVelocity = InputManager.instance.movementInput * speed;
        newVelocity.y = physicsBody.velocity.y;
        physicsBody.velocity = newVelocity;
    }
}
