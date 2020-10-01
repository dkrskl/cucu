/*
 * Script for "activators" used to pass the level or trigger events
 * 
 * 
 */

using UnityEngine;
using UnityEngine.SceneManagement;

public class Activator : MonoBehaviour
{
    public void ChangeScene(int sceneToGoTo)
    {

        SceneManager.LoadScene(sceneToGoTo);

    }

}
