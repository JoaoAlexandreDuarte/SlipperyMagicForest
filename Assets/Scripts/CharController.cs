using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour {

    public bool IsMoving = false;
    public bool moveN;
    public bool moveW;
    public bool moveS;
    public bool moveE;
    public int keyPressed;
    public LayerMask mask;
    float distance = 0.52f;
    RaycastHit2D hitNorth;
    RaycastHit2D hitWest;
    RaycastHit2D hitSouth;
    RaycastHit2D hitEast;

    void Start() {
        Physics2D.queriesStartInColliders = false;
    }

    void FixedUpdate() {
        hitNorth = Physics2D.Raycast(transform.position, transform.up, distance, mask);
        hitWest = Physics2D.Raycast(transform.position, -transform.right, distance, mask);
        hitSouth = Physics2D.Raycast(transform.position, -transform.up, distance, mask);
        hitEast = Physics2D.Raycast(transform.position, transform.right, distance, mask);

        UpdateHit(hitNorth, ref moveN, 0);
        UpdateHit(hitWest, ref moveW, 1);
        UpdateHit(hitSouth, ref moveS, 2);
        UpdateHit(hitEast, ref moveE, 3);

        if (IsMoving) {
            if ((keyPressed >= 0) && (keyPressed <= 3)) {
                switch (keyPressed) {
                    case 0:
                        if (!moveN) {
                            IsMoving = false;
                            GetComponent<Animator>().SetBool("IsMoving", false);
                        }
                        break;
                    case 1:
                        if (!moveW) {
                            IsMoving = false;
                            GetComponent<Animator>().SetBool("IsMoving", false);
                        }
                        break;
                    case 2:
                        if (!moveS) {
                            IsMoving = false;
                            GetComponent<Animator>().SetBool("IsMoving", false);
                        }
                        break;
                    case 3:
                        if (!moveE) {
                            IsMoving = false;
                            GetComponent<Animator>().SetBool("IsMoving", false);
                        }
                        break;
                }
            }
        }
    }

    void UpdateHit(RaycastHit2D hit, ref bool moveDir, int direction) {
        if (hit) {
            moveDir = false;
            Debug.DrawLine(transform.position, hit.point, Color.red);
        } else {
            moveDir = true;
            if (direction == 0) {
                Debug.DrawLine(transform.position, transform.position + transform.up * distance, Color.green);
            } else if (direction == 1) {
                Debug.DrawLine(transform.position, transform.position - transform.right * distance, Color.green);
            } else if (direction == 2) {
                Debug.DrawLine(transform.position, transform.position - transform.up * distance, Color.green);
            } else if (direction == 3) {
                Debug.DrawLine(transform.position, transform.position + transform.right * distance, Color.green);
            }
        }
    }
}
