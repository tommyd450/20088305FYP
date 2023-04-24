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

    public GameObject mapCamera;
    public GameObject playerCamera;
    public GameObject locator;
    public GameObject weaponManager;
    GameObject wep;
    WeaponSlots slots;

    private void Awake()
    {
        if (GameObject.Find("WeaponManager") == null)
        {
            wep = Instantiate(weaponManager);
            wep.name = "WeaponManager";
            print("Enabled");
        }

    }
    void Start()
    {
        
        playerCamera = GameObject.Find("CinemachineStuff");
        mapCamera = GameObject.Find("MapCam");
        locator.SetActive(false);
        mapCamera.SetActive(false);
        rig = gameObject.GetComponent<Rigidbody>();
        
        playerControls = new PlayerControls();

        if (GameObject.Find("WeaponManager") == null)
        {
            wep = Instantiate(weaponManager);
            wep.name = "WeaponManager";
            print("Found this object");
        }
        else 
        {
            wep = GameObject.Find("WeaponManager");
            //wep.GetComponent<WeaponRail>().pla
        }
        
        slots = wep.GetComponent<WeaponSlots>();
        
        playerControls.Controls.SwapWep.started += _ => slots.swap();
        playerControls.Controls.SwapWep.canceled += _ => slots.stopped();
        playerControls.Controls.Shoot.started += _ => slots.start();
        playerControls.Controls.Shoot.canceled += _ => slots.end();
        playerControls.Controls.PickUp.started += _ => slots.PickUpWeapon();
        playerControls.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale == 1) 
        {
            Movement();
            
        }
        swapView();
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

    void swapView() 
    {
        if (playerControls.Controls.MapScreen.WasReleasedThisFrame() && mapCamera != null)
        {
            
            if (playerCamera.activeSelf && Time.timeScale ==1)
            {
                playerCamera.SetActive(false);
                if (mapCamera != null)
                {
                    mapCamera.SetActive(true);
                }
                locator.SetActive(true);
                Time.timeScale = 0;
                //Render Big Sphere
            }
            else if(!playerCamera.activeSelf && Time.timeScale==0)
            {
                playerCamera.SetActive(true);
                if (mapCamera != null)
                {
                    mapCamera.SetActive(false);
                }

                locator.SetActive(false);
                Time.timeScale = 1;
                // unrender Big sphere
            }
        }
    }

    private void OnEnable()
    {
        if (GameObject.Find("WeaponManager") == null)
        {
            wep = Instantiate(weaponManager);
            wep.name = "WeaponManager";
            print("Found this object");
        }
        else
        {
            wep = GameObject.Find("WeaponManager");
        }
        slots = wep.GetComponent<WeaponSlots>();
        slots.setUi();

    }

    private void OnDestroy()
    {
        playerControls.Controls.SwapWep.started -= _ => slots.swap();
        playerControls.Controls.SwapWep.canceled -= _ => slots.stopped();
        playerControls.Controls.Shoot.started -= _ => slots.start();
        playerControls.Controls.Shoot.canceled -= _ => slots.end();
        playerControls.Controls.PickUp.started -= _ => slots.PickUpWeapon();
        playerControls.Dispose();
    }

    private void OnDisable()
    {
        playerControls.Controls.SwapWep.started -= _ => slots.swap();
        playerControls.Controls.SwapWep.canceled -= _ => slots.stopped();
        playerControls.Controls.Shoot.started -= _ => slots.start();
        playerControls.Controls.Shoot.canceled -= _ => slots.end();
        playerControls.Controls.PickUp.started -= _ => slots.PickUpWeapon();
        
        playerControls.Disable();
    }
}
