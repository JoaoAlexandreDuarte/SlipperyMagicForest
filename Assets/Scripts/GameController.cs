using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public GameObject Player;
    public GameObject Spawn;
    public int speed = 5;
    public GameObject Controls;
    Vector2 move;
    bool keyPressed = false;

    void Start() {
        Controls.SetActive(true);
    }

    void FixedUpdate() {

        if (Input.GetKeyDown(KeyCode.R)) {
            Vector3 newPos = new Vector3(Spawn.transform.position.x + 0.5f, Spawn.transform.position.y + 0.5f);
            Player.transform.position = newPos;
        }

        if (!Player.GetComponent<CharController>().IsMoving) {
            if (ChangeDirection()) {
                if ((SceneManager.GetActiveScene().buildIndex == 1) && !keyPressed) {
                    keyPressed = true;
                    Controls.SetActive(false);
                }
                Player.GetComponent<CharController>().IsMoving = true;
                Player.GetComponent<Animator>().SetBool("IsMoving", true);
            }
        } else {
            Moves();
        }
    }

    void Moves() {
        Player.GetComponent<Rigidbody2D>().velocity = move * speed;
    }

    bool ChangeDirection() {
        bool returnValue = false;

        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && 
            Player.GetComponent<CharController>().moveN) {
            move = Vector2.up;
            Player.GetComponent<CharController>().keyPressed = 0;
            returnValue = true;
        }
        if ((Input.GetKeyDown(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) &&
            Player.GetComponent<CharController>().moveW) {
            move = Vector2.left;
            Player.GetComponent<CharController>().keyPressed = 1;
            returnValue = true;
        }
        if ((Input.GetKeyDown(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) &&
            Player.GetComponent<CharController>().moveS) {
            move = Vector2.down;
            Player.GetComponent<CharController>().keyPressed = 2;
            returnValue = true;
        }
        if ((Input.GetKeyDown(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) &&
            Player.GetComponent<CharController>().moveE) {
            move = Vector2.right;
            Player.GetComponent<CharController>().keyPressed = 3;
            returnValue = true;
        }

        return returnValue;
    }
}
