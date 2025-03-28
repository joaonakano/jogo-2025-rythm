using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private string gameNameLevel;
    [SerializeField] private GameObject MenuInicial;
    [SerializeField] private GameObject Opcoes;


    public void Play()
    {
        MusicManager.PlayBackgroundMusic(true);
        SceneManager.LoadScene("Main");
    }

    public void Options()
    {
        MenuInicial.SetActive(false);
        Opcoes.SetActive(true);
    }

    public void CloseOptions()
    {
        Opcoes.SetActive(false);
        MenuInicial.SetActive(true);
    }

    public void LeaveGame()
    {
        Application.Quit();
    }
}