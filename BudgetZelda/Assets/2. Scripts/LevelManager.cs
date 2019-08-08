using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public GameObject sobre;
    public GameObject panel;
    // Carrega qualquer cena
    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void Sobre()
    {
        panel.gameObject.SetActive(false);
        sobre.gameObject.SetActive(true);
    }

    public void Voltar()
    {
        panel.gameObject.SetActive(true);
        sobre.gameObject.SetActive(false);
    }
}