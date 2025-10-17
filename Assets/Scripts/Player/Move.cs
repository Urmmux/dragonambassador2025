using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    public StateManager stateManager;

    public float moveSpeed;

    public float lerpSpeed;
    public Rigidbody2D rb;

    public bool hasBoat = true;

    public bool boatVisible = false;

    private int layermask;
    // Start is called before the first frame update
    void Start() {
        layermask = LayerMask.GetMask("Tiles");
        //put the player somewhere in the middle
        gameObject.transform.position = new Vector3(Random.Range(20, 120), Random.Range(20,80), 0);
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        //if not trying to move, or it's not playermove state, stop all movement
        if ( moveX == 0 &&  moveY == 0 || stateManager.currentGameState != StateManager.GameState.PlayerMove){
            rb.velocity = new Vector2(0f, 0f);
        }  else {
            //create movement vector
            Vector2 targetVelocity = new Vector2(moveX * moveSpeed, moveY * moveSpeed);
            //check if can walk there
            Collider2D hit = Physics2D.OverlapPoint((Vector2)transform.position + new Vector2(moveX, moveY) * 0.5f, layermask);
            if (hit == null || !(hit.CompareTag("walkable") || (hit.CompareTag("water") && hasBoat))){
                rb.velocity = new Vector2(0f, 0f);
                return;
            }

            if ((hit.CompareTag("water") && hasBoat) && !boatVisible) {
                boatVisible = true;
                //tell animator to use boat sprites
            } else if (hit.CompareTag("walkable") && boatVisible){
                boatVisible = false;
                //tell animator to use walking sprites
            }
            //add sprint
            if (Input.GetAxis("Sprint") == 1){
                rb.velocity = Vector2.Lerp(rb.velocity, targetVelocity * 2f, Time.deltaTime * lerpSpeed);
            } else {
            rb.velocity = Vector2.Lerp(rb.velocity, targetVelocity, Time.deltaTime * lerpSpeed);
            }
        }  
    }
}
