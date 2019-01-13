using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndPointController : MonoBehaviour {

    float startScale;
    float changeScale;
    float speed = 0.3f;
    float scaleToChange;
    public Animator transition;

    void Start() {
        scaleToChange = speed;
        startScale = transform.localScale.x;
    }

    void Update () {
            changeScale += scaleToChange * Time.deltaTime;

        if (changeScale > 1.1f) {
            changeScale = 1.1f;
            scaleToChange = -speed;
        }
        if (changeScale < 0.9f) {
            changeScale = 0.9f;
            scaleToChange = speed;
        }

        transform.localScale = new Vector3(startScale * changeScale, startScale * changeScale, transform.localScale.z);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player") {
            collision.transform.position = new Vector3(100,100,100);
            StartCoroutine(LoadScene());
        }
    }

    IEnumerator LoadScene() {
        transition.SetTrigger("end");
        yield return new WaitForSeconds(1.5f);
        if (SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCountInBuildSettings - 1) {
            SceneManager.LoadScene(0);
        } else {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
