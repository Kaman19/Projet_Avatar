using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;



public enum ComboSate
{
    NONE,
    POING_1,
    POING_2,
    POING_3,
    GENOU,
    PIED_1,
    PIED_2
}
public class PlayerAttack : MonoBehaviour
{
    PlayerControler control;

    Animator anim;

    bool activateTimeToReset;
    bool nextAttack = true;
    public bool IsGarding = false;

    float defaultComboTimer = 0.6f;
    float currentComboTimer;

    public float maxEnergie = 100;
    public float currentEnergie;
    
    //float defaultWaitCombo = 0.3f;
    //float currentWaitCombo;
    ComboSate currentComboState;

    ElementScript m_element;

    PlayerMouvement m_playerM;
    Rigidbody2D rb;
    Vie m_vie;
    public SpriteRenderer spR;
    CharacterAnimation m_charAnim;

    [SerializeField] GameObject chargeAttSPPrefabFeu,lanceFlammePrefab, chargeAttSPPrefabEau,GenkiPrefab;

	private void Awake()
	{
        control = new PlayerControler();

        control.Gameplay.Blocage.performed += ctx => Garde();
        control.Gameplay.Deblocage.performed += ctx => Degarde();
    }

	// Start is called before the first frame update
	void Start()
    {
        anim = GetComponent<Animator>();

        currentComboTimer = defaultComboTimer;
        currentComboState = ComboSate.NONE;
        m_playerM = GetComponent<PlayerMouvement>();
        m_vie = GetComponent<Vie>();
        m_element = GetComponent<ElementScript>();
        spR = GetComponent<SpriteRenderer>();
        m_charAnim = GetComponent<CharacterAnimation>();
        //currentEnergie = 100;
        
        //rb = GetComponent<Rigidbody2D>();
        //currentWaitCombo =defaultWaitCombo
    }

    // Update is called once per frame
    void Update()
    {
        
        ComboAttacks();
        //Garde();
        ResetComboState();
    }


    void ComboAttacks()
	{
        if(/*Input.GetKeyDown(KeyCode.Z)*/control.Gameplay.FrappeFaible.triggered && nextAttack && m_playerM.isGrounded && !m_vie.isHurting)
		{
            if(currentComboState==ComboSate.GENOU || currentComboState==ComboSate.PIED_1 || currentComboState==ComboSate.PIED_2 )
			{
                return;
			}

            currentComboState++;
            activateTimeToReset = true;
            currentComboTimer = defaultComboTimer;
            //rb.AddForce(new Vector2(100f, 0f));

            if(currentComboState==ComboSate.POING_1)
			{
                anim.SetTrigger("Poing1");
                
            }

            if(currentComboState==ComboSate.POING_2)
			{
                anim.SetTrigger("Poing2");
            }

            if(currentComboState==ComboSate.POING_3)
			{
                anim.SetTrigger("Poing3");
            }

            if(currentComboState==ComboSate.GENOU)
			{
                anim.SetTrigger("Genou");
			}

            nextAttack = false;

		}

        if (control.Gameplay.FrappeFaible.triggered && !m_playerM.isGrounded && !m_vie.isHurting)
        {
            if (currentComboState == ComboSate.POING_1)
            {
                return;
            }

            currentComboState++;
            activateTimeToReset = true;
            currentComboTimer = defaultComboTimer;
            //rb.AddForce(new Vector2(100f, 0f));

            if (currentComboState == ComboSate.POING_1)
            {

                anim.SetBool("Poing", true);

            }

            //if (currentComboState == ComboSate.POING_2)
            //{
            //    anim.SetTrigger("Poing2");
            //}

            //if (currentComboState == ComboSate.POING_3)
            //{
            //    anim.SetTrigger("Poing3");
            //}

            //if (currentComboState == ComboSate.GENOU)
            //{
            //    anim.SetTrigger("Genou");
            //}

            //nextAttack = false;

        }


        if (/*Input.GetKeyDown(KeyCode.E)*/control.Gameplay.FrappeForte.triggered && nextAttack && m_playerM.isGrounded && !m_vie.isHurting)
		{
           

            if(currentComboState==ComboSate.PIED_2 || currentComboState==ComboSate.POING_3)
			{
                return;
			}

            if(currentComboState == ComboSate.NONE || currentComboState == ComboSate.POING_1 || currentComboState == ComboSate.POING_2 || currentComboState == ComboSate.GENOU)
			{
                currentComboState = ComboSate.PIED_1;
			}
            else if (currentComboState==ComboSate.PIED_1)
			{
                currentComboState++;
			}

            activateTimeToReset = true;
            currentComboTimer = defaultComboTimer;

            if(currentComboState==ComboSate.PIED_1)
			{
                anim.SetTrigger("Pied1");
			}

            if (currentComboState == ComboSate.PIED_2)
            {
                anim.SetTrigger("Pied2");
            }
        }


        if (control.Gameplay.FrappeForte.triggered && !m_playerM.isGrounded && !m_vie.isHurting)
        {
            

            if (currentComboState == ComboSate.PIED_1)
            {
                return;
            }

            if (currentComboState == ComboSate.NONE)
            {
                currentComboState = ComboSate.PIED_1;
            }
            //else if (currentComboState == ComboSate.PIED_1)
            //{
            //    currentComboState++;
            //}

            activateTimeToReset = true;
            currentComboTimer = defaultComboTimer;

            if (currentComboState == ComboSate.PIED_1)
            {
                Debug.Log("prout");
                anim.SetBool("Pied",true);
            }

            //if (currentComboState == ComboSate.PIED_2)
            //{
            //    anim.SetTrigger("Pied2");
            //}
        }

        if (control.Gameplay.AttaqueSp.triggered && nextAttack && m_playerM.isGrounded && !m_vie.isHurting && m_playerM.ismove && (currentEnergie/maxEnergie==1) )
		{
            if(m_element.typeElement!=1)
			{
                anim.SetTrigger("AttaqueSp");
            }
            else
			{
                spR.enabled = false;
                transform.GetChild(9).gameObject.SetActive(true);

			}

            currentEnergie = 0;
            
		}


	}

    void Garde()
	{
        if( m_playerM.isGrounded && !m_vie.isHurting && m_vie.invincible==false && m_playerM.ismove)
		{
            IsGarding = true;
            m_vie.invincible = true;
            anim.SetBool("Garde",true);
            m_playerM.ismove = false;
            

        }

		
	}

    void Degarde()
	{
        if (/*control.Gameplay.Blocage.triggered &&*/ m_playerM.isGrounded && !m_vie.isHurting && m_vie.invincible == true)
        {
            IsGarding = false;
            m_vie.invincible = false;
            m_playerM.ismove = true;
            anim.SetBool("Garde", false);
            anim.SetBool("IsGarding", false);

        }
    }

    void ResetComboState()
	{
        if(activateTimeToReset)
		{
            currentComboTimer -= Time.deltaTime;

            if(currentComboTimer<=0f)
			{
                currentComboState = ComboSate.NONE;
                activateTimeToReset = false;
                currentComboTimer = defaultComboTimer;
                nextAttack = true;
			}
		}
	}

    void AttaqueSuivante()
	{
        nextAttack = true;
        
	}

    void ResetAttSauter()
	{
        anim.SetBool("Pied", false);
        anim.SetBool("Poing", false);
    }

    void ChargeAttaqueF()
	{
        GameObject attC = Instantiate(chargeAttSPPrefabFeu);
        attC.transform.SetParent(transform.GetChild(7).transform, false);

	}

    void ChargeAttaqueEau()
	{
        GameObject attC = Instantiate(chargeAttSPPrefabEau);
        attC.transform.SetParent(transform.GetChild(8).transform, false);
    }

    void DestroyChargeF()
	{
        
        Destroy(transform.GetChild(7).transform.GetChild(0).gameObject);

	}

    void DestroyChargeEau()
    {
        Debug.Log(transform.GetChild(8).transform.GetChild(0).gameObject.name);
        Destroy(transform.GetChild(8).transform.GetChild(0).gameObject);

    }

    void ChargeAttaqueF2()
	{
        transform.GetChild(7).transform.GetChild(0).gameObject.GetComponent<Animator>().SetBool("EtapeSuivante", true);
    }

    void LanceFlamme()
	{
        GameObject lf = Instantiate(lanceFlammePrefab);
        lf.transform.SetParent(transform.GetChild(7).transform, false);
    }

    void Genki_Eau()
	{
        GameObject gk = Instantiate(GenkiPrefab);
        gk.transform.SetParent(transform.GetChild(8).transform, false);
    }

    void IsGarde()
	{
        anim.SetBool("IsGarding", true);
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
