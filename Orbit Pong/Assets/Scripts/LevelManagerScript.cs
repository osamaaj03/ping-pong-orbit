using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManagerScript : MonoBehaviour
{
    public void StartGame() {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        print("new game!");
    }
}
