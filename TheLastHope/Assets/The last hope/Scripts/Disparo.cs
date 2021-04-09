using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    public OpcionesSys os;
    public GameObject municion;
    public Transform posicionInicial;
    public float velocidad;

    AudioSource AS;
    private void Start()
    {
        AS = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        Fuego();
    }
    void Fuego()
    {
        if (!os.setPause())
        if (Input.GetKeyDown(KeyCode.Z))
        {
            AS.PlayOneShot(AS.clip);
            GameObject d = Instantiate(municion, posicionInicial.position, posicionInicial.rotation);

            Destroy(d, 5f);

            d.GetComponent<Rigidbody>().velocity = transform.forward * velocidad;
        }

    }
}
