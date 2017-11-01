using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int x;
    private int y;
    private float speed = 0.05f;
    private Vector3 pos;
    private Transform tr;
    private bool moving;

    void Start()
    {
        pos = transform.position;
        tr = transform;        
    }

    void FixedUpdate()
    {
        //CheckButtonPresses();
        RaycastHit2D hitup = Physics2D.Raycast(transform.position, Vector2.up, 1);
        RaycastHit2D hitdown = Physics2D.Raycast(transform.position, Vector2.down, 1);
        RaycastHit2D hitright = Physics2D.Raycast(transform.position, Vector2.right, 1);
        RaycastHit2D hitleft = Physics2D.Raycast(transform.position, Vector2.left, 1);
        //==Inputs==//
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) && transform.position == pos && hitleft.collider == null)
        {           //(-1,0)
            pos += Vector3.left;// Add -1 to pos.x
        }
        if ((Input.GetKey(KeyCode.D)|| Input.GetKey(KeyCode.RightArrow)) && transform.position == pos && hitright.collider == null)
        {           //(1,0)
            pos += Vector3.right;// Add 1 to pos.x
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) && transform.position == pos && hitup.collider == null)
        {           //(0,1)
            pos += Vector3.up; // Add 1 to pos.y
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow) && transform.position == pos && hitdown.collider == null)
        {           //(0,-1)
            pos += Vector3.down;// Add -1 to pos.y
        }
        //The Current Position = Move To (the current position to the new position by the speed * Time.DeltaTime)
        transform.position = Vector3.MoveTowards(transform.position, pos, speed);
    }

    private void CheckButtonPresses()
    {
        //x = Convert.ToInt32(tr.position.x);
        //y = Math.Abs(Convert.ToInt32(tr.position.y));
        //if (Input.GetKey(KeyCode.RightArrow) && tr.position == pos)
        //{
        //    GoToNextPosition(x+1, y, Vector3.right);
        //}
        //else if (Input.GetKey(KeyCode.LeftArrow) && tr.position == pos)
        //{
        //    GoToNextPosition(x-1, y, Vector3.left);
        //}
        //else if (Input.GetKey(KeyCode.UpArrow) && tr.position == pos)
        //{
        //    GoToNextPosition(x, y - 1, Vector3.up);
        //}
        //else if (Input.GetKey(KeyCode.DownArrow) && tr.position == pos)
        //{
        //    GoToNextPosition(x, y+1, Vector3.down);
        //}

        //====RayCasts====//
        
    }
}

