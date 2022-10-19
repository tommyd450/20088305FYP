using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInputs))]
[RequireComponent(typeof(PlayerControls))]
public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject cam;
    Rigidbody rig;
    private PlayerControls playerControls;
    


    private void Awake()
    {
        playerControls = new PlayerControls();
        //playerControls.Controls.Movement.started += ctx => Movement();
        //playerControls.Controls.Movement.started += ctx => 
    }
    void Start()
    {
        rig = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        Vector2 movement = playerControls.Controls.Movement.ReadValue<Vector2>();
        Vector2 rotation = playerControls.Controls.Direction.ReadValue<Vector2>();
        Vector3 move = new Vector3(movement.x, 0, movement.y);
        // gameObject.transform.position += move * 5 * Time.deltaTime;
        rig.AddForce(move);
        float angle = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, -angle, 0));
        /*
        if (Input.GetKey(KeyCode.D))
        {
            Vector3 temp = transform.right;
            temp.y = 0;
            gameObject.transform.position += temp * 5 * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.W))
        {
            Vector3 temp = transform.forward;
            temp.y = 0;
            gameObject.transform.position += temp * 5 * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            Vector3 temp = transform.right;
            temp.y = 0;
            gameObject.transform.position += -temp * 5 * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            Vector3 temp = transform.forward;
            temp.y = 0;
            gameObject.transform.position += -temp * 5 * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(-Vector3.up *50 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {

            transform.Rotate(Vector3.up * 50 * Time.deltaTime);
            cam.transform.rotation = transform.rotation;
        }*/


    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }
}
