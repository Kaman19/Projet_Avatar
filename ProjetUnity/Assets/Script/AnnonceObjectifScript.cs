using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnnonceObjectifScript : MonoBehaviour
{

    public Text ObjctifTxt;

    GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>();

        ObjctifTxt.text = gm.MaxEnnemi + " Monstres à éléminiés";
        Destroy(ObjctifTxt, 1f);
    }

   
}
