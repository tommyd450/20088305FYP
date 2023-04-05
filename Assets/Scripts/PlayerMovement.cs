using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInputs))]
[RequireComponent(typeof(PlayerControls))]
public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private PlayerControls playerControls;

    Rigidbody rig;
    [SerializeField] bool stickRotation;

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

        if (playerControls.Controls.Direction.IsPressed())
        {
            stickRotation = true;
        }
        else if (!playerControls.Controls.Direction.IsPressed())
        {
            stickRotation = false;
        }

        Vector2 currentR = playerControls.Controls.Direction.ReadValue<Vector2>();

        Vector2 movement = playerControls.Controls.Movement.ReadValue<Vector2>();
        Vector3 move = new Vector3(movement.x, 0f, movement.y);
        //gameObject.transform.position += move * 5 * Time.deltaTime;
        
        
        if (!stickRotation && playerControls.Controls.Movement.IsInProgress() && movement.x != 0 && movement.y != 0)
        {
            Vector2 rotation = playerControls.Controls.Movement.ReadValue<Vector2>();
            float angle = Mathf.Atan2(rotation.x, rotation.y) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(90, angle, 0));
        }
        else if(stickRotation && playerControls.Controls.Direction.IsInProgress() && currentR.x != 0 && currentR.y != 0)
        {
            //stickRotation = true;
            Vector2 rotation = playerControls.Controls.Direction.ReadValue<Vector2>();
            float angle = Mathf.Atan2(rotation.x, rotation.y) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(90, angle, 0));
        }
        gameObject.transform.position += move * 50 * Time.deltaTime;
        //gameObject.transform.Translate(move * 50 * Time.deltaTime);
        //rig.MovePosition(gameObject.transform.position +move * 50 * Time.deltaTime);
        
    }

    void Rotation() 
    {
        
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
