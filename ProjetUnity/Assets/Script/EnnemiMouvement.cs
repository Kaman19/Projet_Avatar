using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemiMouvement : MonoBehaviour
{

    Rigidbody2D rb;
    CapsuleCollider2D col;
    public float speed = 5f;
    public float currentSpeed = 0f;
    float direction = 1f;
    public float powerJump = 6000, higthJump = 100, margeHauteur=5f, jumpForce=250;
    //bool isWalking = true;
    public bool playerDetecte = false;
    public bool isAdvance = false;
    bool turned = false;
    bool isJumping = false;
    bool isattacking = false;

   public Transform PlayerTarget;

    public float attackDistance = 1f;
    //float chasePlayerAftherAttck = 1f;

    float currentAttckTime;
    float defaultAttckTime = 2f;

    //bool followPlayer, attackPlayer;

    Animator anim;

    float horizontalMovement;
    bool lookRight = true;
    Vector3 velocity = Vector3.zero;


    public bool detecteSol,grouded;
    public float DSolRadius = 0.05f, groundRadius=1f;
    public Transform SolCheck,groudCheck;
    public LayerMask collisionSolMask;

    float waitTime = 0.7f;

    SpriteRenderer sp;
    [SerializeField] float champVision = 4f;
    [SerializeField] float rangeAttack = 1f;
    public float delay;
    public float delayView;
    float lastTimeAttack = Mathf.NegativeInfinity;
    float lastTimePlayerView = Mathf.NegativeInfinity;
    

    [SerializeField] LayerMask theMask;

    Vie m_vie;


    [Header("Loot")]
    [Tooltip("The object this enemy can drop when dying")]
    public GameObject lootPrefab;
    [Tooltip("The chance the object has to drop")]
    [Range(0, 1)]
    public float dropRate = 1f;

    GameManager gm;

    private void Awake()
	{
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();
        m_vie = GetComponent<Vie>();
        col = GetComponent<CapsuleCollider2D>();
        gm = FindObjectOfType<GameManager>();
        //PlayerTarget = GameObject.FindGameObjectWithTag("Player").transform;
	}

	// Start is called before the first frame update
	void Start()
    {
        if(!isAdvance)
		{
            groudCheck = null;
		}

        //followPlayer = false;
        currentAttckTime = defaultAttckTime;
        anim.SetBool("Walk", true);
        currentSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {


        //float direction = Input.GetAxis("Horizontal");
        detecteSol = Physics2D.OverlapCircle(SolCheck.position, DSolRadius, collisionSolMask);
        if(isAdvance)
		{
            grouded = Physics2D.OverlapCircle(groudCheck.position, groundRadius, collisionSolMask);
        }
        

        

        horizontalMovement = direction * currentSpeed * Time.fixedDeltaTime;
        if(!isAdvance)
		{
            if (!detecteSol && !lookRight && currentSpeed != 0f)
            {
                currentSpeed = 0f;
                anim.SetBool("Walk", false);
                StartCoroutine(WaitToFlip());

                //Flip();
            }
            else if (!detecteSol && lookRight && currentSpeed != 0f)
            {
                currentSpeed = 0f;
                anim.SetBool("Walk", false);
                StartCoroutine(WaitToFlip());
                //Flip();
            }

        }
		else
		{
            if(PlayerTarget==null)
			{
                if (!detecteSol && !lookRight && currentSpeed != 0f)
                {
                    currentSpeed = 0f;
                    anim.SetBool("Walk", false);
                    StartCoroutine(WaitToFlip());

                    //Flip();
                }
                else if (!detecteSol && lookRight && currentSpeed != 0f)
                {
                    currentSpeed = 0f;
                    anim.SetBool("Walk", false);
                    StartCoroutine(WaitToFlip());
                    //Flip();
                }
            }
			else
			{

				//Debug.Log(Mathf.Abs(PlayerTarget.position.y - transform.position.y));
				//Debug.Log(Mathf.Floor(PlayerTarget.position.y));
				//if (Mathf.Floor(transform.position.y) == Mathf.Floor(PlayerTarget.position.y) && !playerDetecte && !turned)
    //            {
                    if(((lookRight && (transform.position.x - PlayerTarget.position.x >0)) /*|| (!lookRight && (transform.position.x - PlayerTarget.position.x < 0))*/) && !turned)
					{
                        
                        currentSpeed = 0f;
                        anim.SetBool("Walk", false);
                        StartCoroutine(WaitToFlip());
                        


                        
                    }

                    if((!lookRight && (transform.position.x - PlayerTarget.position.x < 0)) && !turned)
				    {
                        currentSpeed = 0f;
                        anim.SetBool("Walk", false);
                        StartCoroutine(WaitToFlip());
                        }

				//}

				if (Mathf.Floor(transform.position.y) == Mathf.Floor(PlayerTarget.position.y) && playerDetecte && !detecteSol && grouded)
				{
					//Jump();

					isJumping = true;
				}


				if (((Mathf.Floor(PlayerTarget.position.y) > Mathf.Floor(transform.position.y)) || (Mathf.Floor(PlayerTarget.position.y) < Mathf.Floor(transform.position.y))) && grouded &&!isJumping  && !detecteSol && !isattacking )
				{

					Debug.Log("prout");
					//Jump();
					isJumping = true;
                    
				}


			}
		}



            

        

        Vector2 RayDir = lookRight ? Vector2.right : Vector2.left;
        Vector3 originChampvision = lookRight ? sp.bounds.center + new Vector3(sp.bounds.size.x / 2, 0, 0) : sp.bounds.center - new Vector3(sp.bounds.size.x / 2, 0, 0);

        RaycastHit2D hit = Physics2D.Raycast(originChampvision, RayDir, champVision,theMask);
        Debug.DrawRay(originChampvision, RayDir * champVision, Color.red);

        RaycastHit2D hite = Physics2D.Raycast(originChampvision, RayDir, rangeAttack, theMask);
        Debug.DrawRay(originChampvision, RayDir * rangeAttack, Color.blue);

        Debug.DrawRay(sp.bounds.center, Vector3.up* margeHauteur, Color.green);

        if (hit.collider!=null)
		{
            //Debug.Log("je le vois !!!!!");
            playerDetecte = true;
            gm.isFighting = true;
            //gm.ChangeMusic();
            if(isAdvance)
			{
                PlayerTarget = hit.transform;
                turned = false;
                lastTimePlayerView = Time.time;
            }
        }
        else
        {
            playerDetecte = false;


			if (lastTimePlayerView + delayView < Time.time)
			{

				PlayerTarget = null;

			}

		}

		if (hite.collider != null && !m_vie.isHurting)
        {
            
            if(isAdvance)
			{
                if ((lastTimeAttack + delay < Time.time) && grouded)
                {
                   
                    currentSpeed = 0;
                    //col.isTrigger = true;
                    Debug.Log("coucou");
                    isattacking = true;
                    anim.SetTrigger("Attack");
                    lastTimeAttack = Time.time;

                }
            }else
			{
                if ((lastTimeAttack + delay < Time.time))
                {

                    Debug.Log("coucou");
                    isattacking = true;
                    anim.SetTrigger("Attack");
                    lastTimeAttack = Time.time;

                }
            }

    //        if ((lastTimeAttack + delay < Time.time) && grouded)
    //        {
    //            if(isAdvance)
				//{
    //                currentSpeed = 0;
    //                //col.isTrigger = true;
    //            }
    //            Debug.Log("coucou");
    //            isattacking = true;
    //            anim.SetTrigger("Attack");
    //            lastTimeAttack = Time.time;

    //        }

            
        }
        
  //      if(Input.GetKeyDown(KeyCode.G))
		//{
  //          rb.AddForce(new Vector2(500, -500));
  //      }

    }

	private void FixedUpdate()
	{
        MoveEnnemi(horizontalMovement);
        
	}


	//void FollowTarget()
	//{
	//	if (!followPlayer)
	//	{
            
	//	}

 //       if(Vector3.Distance(transform.position,PlayerTarget.position)>attackDistance)
	//	{
            
	//	}

	//}

    void MoveEnnemi(float _horizontalMovement)
    {
        
        Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);

        if (isJumping == true)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
            Debug.Log("prout2");
            isJumping = false;
        }



    }

    void Flip()
    {
        lookRight = !lookRight;
        direction = -1 * direction;
        Vector2 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;

    }


    void AttackIsFinish()
	{
        if(isAdvance)
		{
            col.isTrigger = false;
            isattacking = false;
        }
       
        if(!playerDetecte)
		{
            currentSpeed = 0f;
            anim.SetBool("Walk", false);
            StartCoroutine(WaitToFlip());
        }


    }

    void HurtFinish()
	{
		if (!m_vie.isdeying)
		{
			Debug.Log("j'ai plus mal");
            currentSpeed = speed;
            anim.SetBool("Walk", true);
            m_vie.isHurting = false;
        }
       

	}


 //   void Jump()
	//{
 //       rb.AddForce(new Vector2(0, jumpForce));
	//}

    void AttackJump()
	{
        float jump = lookRight ? powerJump : -powerJump;
        rb.AddForce(new Vector2(jump, higthJump));
	}

    void Attacktriger()
	{
        col.isTrigger = true;
    }

    IEnumerator WaitToFlip()
	{
        turned = true;
        yield return new WaitForSeconds(waitTime);
        currentSpeed = speed;
        Flip();
        
        anim.SetBool("Walk", true);
        
        StopCoroutine(WaitToFlip());
    }

    public bool TryDropItem()
    {
        if (dropRate == 0 || lootPrefab == null)
            return false;
        else if (dropRate == 1)
            return true;
        else
            return (Random.value <= dropRate);

    }

    public void DropItem()
	{
        Instantiate(lootPrefab, transform.position+new Vector3(0,1,0), Quaternion.identity);
	}

    //private void OnDrawGizmos()
    //{
    //	Gizmos.color = Color.red;
    //	Gizmos.DrawSphere(groudCheck.position, groundRadius);
    //}
}
