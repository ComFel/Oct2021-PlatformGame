using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coleccionable : MonoBehaviour
{
    [SerializeField] GameObject heroKnightGO;
    HeroKnight heroKnight;
    private float speedRotate = 200f;

    private void Start()
    {
        heroKnight = heroKnightGO.GetComponent<HeroKnight>();
    }

    private void Update()
    {
        this.transform.Rotate(Vector3.forward * speedRotate * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Debug.Log("+1star");
            
            heroKnight.M_Stars++;
            Destroy(this.gameObject);
        }

    }
}