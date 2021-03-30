using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ObjetoScript : MonoBehaviour
{
    //public static int contador;
    bool destruir;
    float timer;
    AudioSource AS;
    public AudioClip audio;

    //[Header("Textos")]
    //public TextMeshProUGUI T_contador;
    //public GameObject E_ganaste;

    //private int contador;

    private void Start()
    {
        /*E_ganaste.SetActive(false);
        contador = 0;
        SetContador();
        AS = GetComponent<AudioSource>();*/
        destruir = false;
        timer = 0;
    }
   /* private void SetContador()
    {
        T_contador.text = "Zombies: " + contador.ToString();
    }*/
    public void Explosion()
    {
        destruir = true;
        //AS.PlayOneShot(AS.clip);
        /*contador++;
        SetContador();
        if (contador == 12)
        {
            E_ganaste.SetActive(true);
        }*/

    }

    // Update is called once per frame
    void Update()
    {
      if(destruir)
       {
            timer++;
            if(timer >= 10f)
            {
                //if(!AS.isPlaying)
                AudioSource.PlayClipAtPoint(audio, this.gameObject.transform.position);
                this.gameObject.SetActive(false);
                //Destroy(this.gameObject);
            }
       }
    }
}
