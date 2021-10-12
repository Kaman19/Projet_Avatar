using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementScript : MonoBehaviour
{

    public int typeElement = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void ChangeElement(int newElement)
	{
        typeElement = newElement;
	}
  
}
