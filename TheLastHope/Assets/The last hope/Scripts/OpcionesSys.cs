using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OpcionesSys : MonoBehaviour
{

    //public AudioMixer maestroMixer;

    bool activo;
    Canvas canvas;

    public float VolumenEfectos;
    public float VolumenAmbiente;

    //public AudioMixer AM;

    //public AudioMixerSnapshot pausa;
    //public AudioMixerSnapshot nopausa;


    public bool setPause()
    {
        return activo;
    }
    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponent<Canvas>();
        canvas.enabled = false;
        activo = false;
       // VolumenAmbiente = -20f;
        //VolumenEfectos = 0f;
    }

    // Update is called once per frame
    void Update()
    {
       // AM.SetFloat("VolumenEfectos", VolumenEfectos);
        //AM.SetFloat("VolumenAmbiente", VolumenAmbiente);

        if (Input.GetKeyDown(KeyCode.P)) {
            activo = !activo;
            canvas.enabled = activo;
            Time.timeScale = (activo) ? 0 : 1f;
            /*if(!canvas.enabled)
            {
                nopausa.TransitionTo(.01f);
            }
            else
            {
                pausa.TransitionTo(.01f);
            }*/
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
