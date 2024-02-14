using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restartscene : MonoBehaviour
{


    public void OnRestartButtonClick()
    {
        // Obtient le nom de la sc�ne actuelle
        string currentSceneName = SceneManager.GetActiveScene().name;
        Debug.Log("Restarting " + currentSceneName);
        // Red�marre la sc�ne actuelle
        SceneManager.LoadScene(currentSceneName);
    }
}
