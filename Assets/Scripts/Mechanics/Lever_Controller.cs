using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever_Controller : MonoBehaviour
{
    [SerializeField] GameObject heroKnightGO;
    [SerializeField] GameObject hiddenShown;
    HeroKnight heroKnight;

    private void Start()
    {
        heroKnight = heroKnightGO.GetComponent<HeroKnight>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("Lever");

            //Destroy(this.gameObject);

            this.gameObject.SetActive(false);

            hiddenShown.SetActive(true);
        }

    }
}
