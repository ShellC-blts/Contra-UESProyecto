using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelector : MonoBehaviour
{
    public GameObject[] personajes;
    public static int personajeSeleccionado = 0;

    public void SeleccionarPersonaje(int index)
    {
        personajeSeleccionado = index;
    }

    public void Jugar()
    {
        SceneManager.LoadScene("Nivel1");
    }
}
