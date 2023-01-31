using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
	public static PlayerControler instance;

	public float moveSpeed = 10f;

	public Rigidbody2D rb;
	public Animator feetAnim;
	public ParticleSystem feetStepDust;

	private Vector2 moveInput;
	private Vector2 lookInput;

	public Weapon[] weapons;
	private int currentWeapon;

	public FixedJoystick _moveJoystick;
	public FixedJoystick _aimJoystick;

	private CameraShake shake;

    private void Awake()
    {
		instance = this;
    }


    private void Start()
	{
		shake = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShake>();
	}	


    void Update()
    {
		/*		
		moveInput.x = Input.GetAxis("Horizontal");
		moveInput.y = Input.GetAxis("Vertical");
		*/

		moveInput.x = _moveJoystick.Horizontal;
		moveInput.y = _moveJoystick.Vertical;

	}


    void FixedUpdate()
    {
		PlayerMoveAndRotate();
    }




    public void PlayerMoveAndRotate()
	{
		
		rb.MovePosition(rb.position + moveInput * moveSpeed * Time.fixedDeltaTime);	
		
		if (moveInput.magnitude == 0) 
		{ 
			feetAnim.speed = 0;
			feetStepDust.gameObject.SetActive(false);
		}
		else {
			feetAnim.speed = 1;
			feetStepDust.gameObject.SetActive(true);
		}

		/*
		// player rotate with mouse position
		Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Vector2 lookDir = mousePos - rb.position;
		float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
		rb.rotation = angle;
		*/

		
		// joystick look
		lookInput = new Vector2(_aimJoystick.Horizontal, _aimJoystick.Vertical);
		Vector2 lookDir = Vector2.up * lookInput.x + Vector2.left * lookInput.y;
		
		if (lookInput.magnitude != 0)
        {
			transform.rotation = Quaternion.LookRotation(Vector3.forward, lookDir);
		}
        if (lookInput.magnitude > 0.8f)
        {
			PlayerShoot();
        }
		

	}



	public void AddWeapon(int gunToAdd)
	{
		weapons[currentWeapon].gameObject.SetActive(false);
		weapons[currentWeapon] = weapons[gunToAdd];
		weapons[currentWeapon].gameObject.SetActive(true);

	}




    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
			GameManager.instance.UpdateScore();
        }
    }



	public void PlayerShoot()
	{
		if (Time.time > weapons[currentWeapon].nextFire)
		{
			StartCoroutine(shake.StartCamShake());
			weapons[currentWeapon].muzzleFlashAnim.SetTrigger("Shoot");
			Instantiate(weapons[currentWeapon].gunfireSmoke, weapons[currentWeapon].firePoint.position, weapons[currentWeapon].firePoint.rotation);
			Instantiate(weapons[currentWeapon].bullet, weapons[currentWeapon].firePoint.position, weapons[currentWeapon].firePoint.rotation);

			weapons[currentWeapon].nextFire = Time.time + weapons[currentWeapon].fireRate;
		}

	}



	




}
