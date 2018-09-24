using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouthController : MonoBehaviour
{
    private Animator anim;
    private AudioSource mouthSound;

    public GameObject playerSpawner;

    private void Start()
    {
        anim = GetComponent<Animator>();
        mouthSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            anim.SetBool("OpenMouth",true);
            mouthSound.Play();

            playerSpawner.SetActive(false);
        }
    }

    void OpenMouth()
    {
        anim.SetBool("OpenMouth", false);
    }

    void CloseMouth()
    {
        anim.SetBool("CloseMouth", false);
    }
}
