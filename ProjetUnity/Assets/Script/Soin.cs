using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soin : MonoBehaviour
{

    [Header("Parameters")]
    [Tooltip("le nombre de vie recupérer en prennant le soin")]
    public float healAmount;

    // Start is called before the first frame update
    void Start()
    {
        
    }


	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.tag=="Player" )
		{
            if(collision.GetComponent<Vie>().currentVie<100)
			{
                collision.GetComponent<Vie>().Soin(healAmount);

                Destroy(gameObject);
            }
            
		}
	}
}
