using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackUniversel : MonoBehaviour
{

    public LayerMask collisionLayer;
    public float radius = 1f;
    public float dégat = 2f;

    public bool is_Player, is_Ennemi;

    public GameObject hit_FXPrefab;

    ElementScript m_element;

    AudioSource audioS;

    public AudioClip fxPunch;


   

    

    // Start is called before the first frame update
    void Start()
    {
        m_element = GetComponentInParent<ElementScript>();
        audioS = GetComponentInParent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
        DetectCollision();
    }


    void DetectCollision()
	{

        //Collider2D[] hits = Physics.OverlapSphere(transform.position, radius, collisionLayer);
        Collider2D[] hit = Physics2D.OverlapCircleAll(transform.position,radius,collisionLayer);


        if(hit.Length>0)
		{
             Debug.Log("on frappe le" + hit[0].gameObject.name);
            if(is_Player)
			{
               // typeElement = m_playerM.currentElement;
                hit[0].gameObject.GetComponent<Damageble>().InfligeDegat(dégat, m_element.typeElement);

                Vector3 Hit_Fix_Pos = hit[0].transform.position;
                Hit_Fix_Pos.y += 1.3f;
                if (hit[0].transform.forward.x > 0)
                {
                    Hit_Fix_Pos.x += 0.3f;
                }
                else if (hit[0].transform.forward.x > 0)
                {
                    Hit_Fix_Pos.x -= 0.3f;
                }

                GameObject fx= Instantiate(hit_FXPrefab, Hit_Fix_Pos, Quaternion.identity);
                audioS.PlayOneShot(fxPunch);

                Destroy(fx, 0.25f);
            }
            if(is_Ennemi)
			{

                hit[0].gameObject.GetComponent<Damageble>().InfligeDegat(dégat, m_element.typeElement);
            }
            

            gameObject.SetActive(false);
		}
       
	}

	private void OnDrawGizmos()
	{
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, radius);
	}
}
