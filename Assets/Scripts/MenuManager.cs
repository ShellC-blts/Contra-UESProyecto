using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void JugarComoSoldadoA()
    {   
        PlayerPrefs.SetInt("PersonajeSeleccionado", 0);
        Debug.Log("Este boton Funciona");
        SceneManager.LoadScene("Nivel1");
    }
    public void JugarComoSoldadoB()
    {
        PlayerPrefs.SetInt("PersonajeSeleccionado", 1);
        Debug.Log("Este boton Funciona");
        SceneManager.LoadScene("Nivel1");
    }
}