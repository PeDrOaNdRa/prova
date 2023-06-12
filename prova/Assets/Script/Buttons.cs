using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void BotaoIniciar()
    {
        SceneManager.LoadScene("Game");
    }

    public void BotaoConfig()
    {
        SceneManager.LoadScene("configuracao");
    }

    public void BotaoVoltarStart()
    {
        SceneManager.LoadScene("Start");
    }

    public void BotaoSair()
    {
        Application.Quit();
    }
}
