using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public Animator animator;

    private int buildIndex;

    void Awake() {

    }

    void Start() {
        buildIndex = SceneManager.GetActiveScene().buildIndex;
    }

    void Update() {        
        if (Input.GetMouseButton(1)) {
            LoadNextLevel(buildIndex < 2 ? buildIndex + 1 : 0);
            buildIndex = SceneManager.GetActiveScene().buildIndex;
        }

    }

    void LoadNextLevel(int sceneBuildIndex) {
        StartCoroutine(LoadLevel(sceneBuildIndex));
    }

    IEnumerator LoadLevel(int sceneBuildIndex) {
        animator.SetTrigger("fade");

        yield return new WaitForSeconds(.5f);

        SceneManager.LoadScene(sceneBuildIndex);
    }
}
