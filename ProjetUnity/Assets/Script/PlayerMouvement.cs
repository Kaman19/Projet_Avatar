using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMouvement : MonoBehaviour
{

    PlayerControler control;

    public float moveSpeed,jumpForce;

    bool isJumping;
    public bool isGrounded;
    public bool ismove = true;
    bool onePlay = false;

    public Transform groundCheckLeft, groundCheckRight;
    public LayerMask collisionLayer;

    float horizontalMovement;

    bool lookRight = true;

    int currentElement;
    ElementScript m_element;


    Rigidbody2D rb;
    Animator anim;
    SpriteRenderer spR;
    AnimatorStateInfo info;
    Vector3 velocity = Vector3.zero;

    Vector2 dep;

    AudioSource audioS;

    public AudioClip fxJump,fxHitGround;


    private void Awake()
    {
        control = new PlayerControler();
        //control.Gameplay.Light.performed += ctx => LightM();
        

        control.Gameplay.Move.performed += ctx => dep = ctx.ReadValue<Vector2>();
        control.Gameplay.Move.canceled += ctx => dep = Vector2.zero;

        //control.Gameplay.DirectionLum.performed += ctx => josticPos = ctx.ReadValue<Vector2>();
        //control.Gameplay.DirectionLum.canceled += ctx => moveV = Vector2.zero;

        //control.Gameplay.PoseLum.performed += ctx => PosserLumiere();

    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
        anim = GetComponentInChildren<Animator>();
        spR = GetComponent<SpriteRenderer>();
        m_element = GetComponent<ElementScript>();
        audioS = GetComponent<AudioSource>();
        currentElement = m_element.typeElement;
    }

	private void Update()
	{

        float move;
		if (ismove)
		{
			move = dep.x;
		}
		else
		{
			move = 0f;
		}



		isGrounded = Physics2D.OverlapArea(groundCheckLeft.position, groundCheckRight.position,collisionLayer);
       // Debug.Log(isGrounded);

        horizontalMovement = move * moveSpeed * Time.fixedDeltaTime;

        if (/*Input.GetButtonDown("Jump")*/control.Gameplay.Jump.triggered && isGrounded)
        {

            isJumping = true;
        }

        if(isGrounded && !isJumping && rb.velocity.y<-0.5 && !onePlay)
		{
            audioS.PlayOneShot(fxHitGround);
            onePlay = true;
		}


        //Flip1(rb.velocity.x);

        if(move>0 && !lookRight)
		{
            Flip();
		}
        else if(move < 0 && lookRight)
		{
            Flip();
		}
        float characterVelocity = Mathf.Abs(move);
        
        anim.SetFloat("Speed", characterVelocity);
        anim.SetBool("Grounded", isGrounded);
        anim.SetFloat("Vspeed", rb.velocity.y);
        

        ChangeElement();
    }



	private void FixedUpdate()
	{



        MovePlayer(horizontalMovement);
    }


    void ChangeElement()
	{
        if (/*Input.GetKeyDown(KeyCode.Y)*/control.Gameplay.ElementSuivent.triggered)
        {
            currentElement++;
            if(currentElement>3)
			{
                currentElement = 1;
                
			}
        }
        if (/*Input.GetKeyDown(KeyCode.T)*/control.Gameplay.ElementPrecedent.triggered)
        {
            currentElement--;
            if (currentElement < 1)
            {
                currentElement = 3;
            }
        }

        if (currentElement==1)
		{
            anim.SetBool("isFireMode", false);
            anim.SetBool("isLightingMode", true);
            anim.SetBool("isWaterMode", false);
            
		}
        
        if(currentElement==2)
		{
            anim.SetBool("isFireMode", true);
            anim.SetBool("isLightingMode", false);
            anim.SetBool("isWaterMode", false);
        }

        if (currentElement == 3)
        {
            anim.SetBool("isFireMode", false);
            anim.SetBool("isLightingMode", false);
            anim.SetBool("isWaterMode", true);
        }
        //m_element.ChangeElement(currentElement);
        m_element.typeElement = currentElement;
    }


    void MovePlayer(float _horizontalMovement)
	{
        Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);

        if (isJumping==true)
		{
            audioS.volume = 0.3f;
            audioS.PlayOneShot(fxJump);
            rb.AddForce(new Vector2(0f, jumpForce));
            
            isJumping = false;
            onePlay = false;
		}

	}

 //   void Flip1(float _velacity)
	//{
 //       if(_velacity < -0.1f)
	//	{
 //           spR.flipX = false;
	//	}
 //       else if(_velacity > 0.1f)
	//	{
 //           spR.flipX = true;
	//	}
	//}


    void Flip()
	{
        lookRight = !lookRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        theScale.z = 1;
        transform.localScale = theScale;
	}


    public void OnEnable()
    {
        control.Enable();
    }

    private void OnDisable()
    {
        control.Disable();
    }
}
