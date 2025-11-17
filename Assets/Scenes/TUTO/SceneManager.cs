using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void IniciarSimulacion()
    {
        SceneManager.LoadScene("ARM"); 
    }
    public void SalirAplicacion()
    {
        Application.Quit();
    }
}
