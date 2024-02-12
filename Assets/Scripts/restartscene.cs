using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restartscene : MonoBehaviour
{


    public void OnRestartButtonClick()
    {
        // Obtient le nom de la scène actuelle
        string currentSceneName = SceneManager.GetActiveScene().name;
        Debug.Log("Restarting " + currentSceneName);
        // Redémarre la scène actuelle
        SceneManager.LoadScene(currentSceneName);
    }
}
