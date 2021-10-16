using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coleccionable : MonoBehaviour
{
    void OnCollisionEnter(Collision obj)
    {
        //Check to see if the tag on the collider is equal to Enemy
        if (obj.collider.tag == "Player")
        {
            Debug.Log("Triggered by Enemy");
        }
    }
}