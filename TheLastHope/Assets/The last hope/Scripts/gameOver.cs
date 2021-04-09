using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameOver : MonoBehaviour
{
    // Start is called before the first frame update
    public void restartButton()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void menuButton()
    {
        SceneManager.LoadScene("MenuScene");
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
