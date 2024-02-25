using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class SceneLoadinator : MonoBehaviour
{

     void Start()
    {
        SceneManager.LoadScene("MainVRscene");
    }

}