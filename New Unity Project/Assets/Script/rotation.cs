using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation : MonoBehaviour


{

    public GameObject cube1;
    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        // to rotate cube towards other cube
        // its working but because i applied one more rotation it collasping so you can use this if comment the onther one
        
        /*
        Vector3 directiontoface = cube1.transform.position - transform.position;
        transform.rotation = Quaternion.LookRotation(directiontoface);
        */


        // rotate cube with the mounse pointer

        float mouseX = Input.GetAxis("Mouse X");
        transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y + mouseX, 0);

        // more optimal way to do the smae 
        Vector3 newRotation = transform.localEulerAngles; 
        newRotation.y += mouseX * 5;
        transform.localEulerAngles = newRotation;
        
    }
}
