using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int x;
    private int y;
    private float speed = 3.0f;
    private Vector3 pos;
    private Transform tr;
    private char[,] mapTiles;
    private bool moving;

    void Start()
    {
        pos = transform.position;
        tr = transform;


        // de map moet geflipt worden, nu zit de x in de array en dat moet de y worden
        // maar het werkt voor nu!

        
        mapTiles = new char[,] {
            {'x','x','x','x','x','x','x' },
            {'x','x','x','x','x','x','x' },
            {'x','o','o','o','o','o','x' },
            {'x','o','o','o','o','o','x' },
            {'x','o','o','o','o','o','x' },
            {'x','o','o','o','o','o','o' },
            {'x','o','o','o','o','o','o' },
            {'x','o','o','o','o','o','x' },
            {'x','o','o','x','x','x','x' },
            {'x','o','o','x','x','x','x' },
            {'x','o','o','x','x','x','x' }};
        
    }

    void Update()
    {
        CheckButtonPresses();
        transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * speed);
    }

    private void CheckButtonPresses()
    {
        x = Convert.ToInt32(tr.position.x);
        y = Math.Abs(Convert.ToInt32(tr.position.y));
        if (Input.GetKey(KeyCode.RightArrow) && tr.position == pos)
        {
            GoToNextPosition(x+1, y, Vector3.right);
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && tr.position == pos)
        {
            GoToNextPosition(x-1, y, Vector3.left);
        }
        else if (Input.GetKey(KeyCode.UpArrow) && tr.position == pos)
        {
            GoToNextPosition(x, y - 1, Vector3.up);
        }
        else if (Input.GetKey(KeyCode.DownArrow) && tr.position == pos)
        {
            GoToNextPosition(x, y+1, Vector3.down);
        }
    }

    private void GoToNextPosition(int x, int y, Vector3 vector)
    {
        try
        {
            if (mapTiles[x,y] == 'o')
            {
                pos += vector;
            }
        }
        catch (IndexOutOfRangeException)
        {
            //Cannot walk there
            Debug.Log("Player cannot walk to this position");
        }
    }

}

