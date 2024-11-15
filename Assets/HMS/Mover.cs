using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Mover : MonoBehaviour
{
    public void MoveSpot(Transform t)
    {
        transform.position = t.position;
    }

    public void MoveScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
