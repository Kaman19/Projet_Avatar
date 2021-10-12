using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageble : MonoBehaviour
{


    public Vie vie { get; private set; }


    private void Awake()
    {
        vie = GetComponent<Vie>();
        if (!vie)
        {
            vie = GetComponentInParent<Vie>();
        }
    }

   


    public void InfligeDegat(float degat,int element)
    {
        if (vie)
        {
            vie.TakeDamage(degat, element);
        }
    }
}
