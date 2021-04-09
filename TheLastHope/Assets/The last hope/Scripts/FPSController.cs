using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(CharacterController))]

public class FPSController : MonoBehaviour
{
    [Header("Referencias")]
    public Camera playerCamera;
    //public GameObject E_intro;
    public bool failSafe = false;

    [Header("General")]
    private float gravityScale = -20f;
    public HealthBarController healthbar;
    [Header("Sonidos")]
    public AudioSource pasos;
    public AudioSource paper;

    [Header("Salto")]
    public float jumpHeight = 1.9f;

    [Header("Velocidades")]
    public float walkspeed;
    public float runspeed;
    public float sencibilidadRotatcion = 30f;
    public int vida = 5;
    private float camaraAngVer;
    
    private Vector3 moverInput = new Vector3(0f ,0f, 0f);
    private CharacterController characterController;

    private Vector3 rotacionCamera = Vector3.zero;
    private Vector3 posin;

    private bool failSafeGanar = false;
    private bool failSafeW = false;
    private double oldZ = 0, oldX = 0;

    public TextMeshProUGUI T_contador;
    public GameObject E_ganaste;
    private int contador;
    void Start()
    {
        E_ganaste.SetActive(false);
        posin = transform.position;
        failSafe = true;
        failSafeGanar = true;
        contador = 10;
        SetContador();
        //StartCoroutine(FailSafe());
    }


    // Update is called once per frame
    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        
    }
    void Update()
    {
        Mover();
        Rotacion();
    }

    private void Mover()
    {
        if (characterController.isGrounded)
        {
            moverInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
            moverInput = Vector3.ClampMagnitude(moverInput, 1f);

            if (Input.GetButton("Sprint"))
            {
                moverInput = transform.TransformDirection(moverInput) * runspeed;
            }
            else
            {
                moverInput = transform.TransformDirection(moverInput) * walkspeed;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                moverInput.y = Mathf.Sqrt(jumpHeight * -2f * gravityScale);
            }
        }
        moverInput.y += gravityScale * Time.deltaTime;
        characterController.Move(moverInput * Time.deltaTime);

        //Sound
        double z = Mathf.Abs(transform.position.z);
        double x = Mathf.Abs(transform.position.x);
        bool zCon = (z % 2 >= 0 && z % 2 <= 0.5 && z != oldZ);
        bool xCon = (x % 2 >= 0 && x % 2 <= 0.5 && x != oldX);
        oldZ = z;
        oldX = x;

        if ((zCon || xCon) && !failSafeW)
        {
            failSafeW = true;
            pasos.PlayOneShot(pasos.clip);
            StartCoroutine(FailSafe());
        }
        if ((!zCon || !xCon) && !failSafeW)
        {
            failSafeW = true;
            StartCoroutine(FailSafe());
        }
    }

    private void Rotacion()
    {
        rotacionCamera.x = Input.GetAxis("Mouse X") * Time.deltaTime * sencibilidadRotatcion;
        rotacionCamera.y = Input.GetAxis("Mouse Y") * Time.deltaTime * sencibilidadRotatcion;

        camaraAngVer = camaraAngVer + rotacionCamera.y;
        camaraAngVer = Mathf.Clamp(camaraAngVer, -70, 70);

        transform.Rotate(Vector3.up * rotacionCamera.x);

        playerCamera.transform.localRotation = Quaternion.Euler(-camaraAngVer, 0f, 0f);
    }
    private void SetContador()
    {

        T_contador.text = "Lost documents: " + contador.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Papel"))
        {
            /*characterController.enabled = false;
            characterController.transform.position = posin;
            characterController.enabled = true;*/
            paper.PlayOneShot(paper.clip);
            other.gameObject.SetActive(false);
            contador--;
            SetContador();
            if (contador == 0) //cambiar el numero de papeles restantes para determinar cuando se acaba el juego
            {
                //E_ganaste.SetActive(true);
                StartCoroutine(FailSafeGanar());
            }
        }
        if (other.CompareTag("Zombie"))
        {
            if (healthbar)
            {
                healthbar.OnTakeDamage(10);
            }
        }

    }

    IEnumerator FailSafeGanar()
    {
        E_ganaste.SetActive(true);
        yield return new WaitForSeconds(8f);
        E_ganaste.SetActive(false);
        SceneManager.LoadScene("MenuScene");
        failSafeGanar = false;
    }
    IEnumerator FailSafe()
    {
        yield return new WaitForSeconds(0.25f);
        failSafeW = false;
    }
}
