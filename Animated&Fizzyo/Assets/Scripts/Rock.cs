using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Rock : MonoBehaviour
{

    private Animator anim;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Rocket>() != null)
        {

            GameController.instance.Hit();
            AudioSource audio = GetComponent<AudioSource>();
            anim = GetComponent<Animator>();
            anim.SetTrigger("Collision");
            audio.Play();
            StartCoroutine(ResetRock());

        }


    }

    IEnumerator ResetRock()
    {
        yield return new WaitForSeconds(10);
        anim.SetTrigger("Reform");
    }


}

