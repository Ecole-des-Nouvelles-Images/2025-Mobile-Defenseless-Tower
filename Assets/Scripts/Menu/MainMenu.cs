using UnityEngine;

namespace Menu
{
    public class MainMenu : MonoBehaviour
    {
        public void Quit()
        {
            Application.Quit();
            Debug.Log("quitter le jeu");
        }
    }
}
