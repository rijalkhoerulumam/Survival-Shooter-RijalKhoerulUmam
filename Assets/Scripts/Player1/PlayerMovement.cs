using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{
    #region 1

    public float speed = 6f;
    Vector3 movement;
    Animator anim;
    Rigidbody playerRigibody;
    int floorMask;
    float camRayLength = 100f;

    #endregion

    private void Awake()
    {
        floorMask = LayerMask.GetMask("Floor");
        anim = GetComponent<Animator>();
        playerRigibody = GetComponent<Rigidbody>();
    }

    internal void Animating(float h, float v)
    {
        throw new NotImplementedException();
    }

    internal void Move(float h, float v)
    {
        throw new NotImplementedException();
    }

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        move(h, v);
        Turning();
        animating(h, v);
    }

    void move(float h, float v)
    {
        movement.Set(h, 0f, v);
        movement = movement.normalized * speed * Time.deltaTime;
        playerRigibody.MovePosition(transform.position + movement);
    }

    #region cam

    void Turning()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit floorHit;
        if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
        {
            Vector3 playerToMouse = floorHit.point - transform.position;
            playerToMouse.y = 0f;
            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
            playerRigibody.MoveRotation(newRotation);
        }
    }

    #endregion
    #region Animation

    void animating(float h, float v)
    {
        bool walking = h != 0f || v != 0f;
        anim.SetBool("IsWalking", walking);
    }

    #endregion

}
