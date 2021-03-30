using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Municion : MonoBehaviour
{
    //public GameObject sprite;
    ObjetoScript os;
    //AudioSource AS;
    //public AudioClip audio;

    private void Start()
    {
        //AS = GetComponent<AudioSource>();
    }

    private void OnCollisionStay(Collision collision)
    {
        //AS.PlayOneShot(AS.clip);
        foreach (ContactPoint contacto in collision.contacts)
        {
            /*GameObject m = Instantiate(sprite, contacto.point + (contacto.normal * 0.01f), Quaternion.LookRotation(contacto.normal));
            m.transform.parent = collision.gameObject.transform;
            Destroy(m, 5f);*/
        }
        if (collision.gameObject.CompareTag("Zombie"))
        {
            //AudioSource.PlayClipAtPoint(audio, collision.gameObject.transform.position);
            os = collision.gameObject.GetComponent<ObjetoScript>();
            os.Explosion();
        }
        Destroy(this.gameObject);
    }
}
