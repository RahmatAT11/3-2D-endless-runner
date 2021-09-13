using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIGameOverController : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // reload game
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
