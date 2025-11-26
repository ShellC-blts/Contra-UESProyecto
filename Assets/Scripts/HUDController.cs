using UnityEngine;
using UnityEngine.UI;
public class HUDController : MonoBehaviour
{
public Text textoVidas;
public Text textoArma;
public Text textoNivel;
public PlayerController jugador;
public WeaponManager wm;
void Update()
{
textoVidas.text = "Vidas: " + jugador.vidas.ToString();
textoArma.text = "Arma: " + wm.ObtenerNombreArma();
textoNivel.text = "Nivel 1: Infiltración";
}
}