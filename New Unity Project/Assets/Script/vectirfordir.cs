using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vectirfordir : MonoBehaviour
{
    //store the position of player
    [SerializeField]
    private Transform player;
    private int speed = 1;
    
    private void Update()
    {

        //we can use vector 2 for getting the x and y values for the palyer

        Vector2 position;
        position = new Vector2(transform.position.x, transform.position.y);
        Debug.Log("postion in 2d plane : " + position);
        

        // Direction of the player
        // vector3 because its in 3d

        Vector3 direction = player.position - transform.position;
        Debug.Log("Megnitude: " + direction.magnitude);
        Debug.DrawRay(transform.position, direction, Color.black);

        //move enemy and as it reach towards the player it gets slower
        transform.Translate(direction * Time.deltaTime * speed);
    }
}
