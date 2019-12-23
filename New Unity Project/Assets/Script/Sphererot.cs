using System.Collections;
using System.Linq; // for the select function
using System.Collections.Generic;
using UnityEngine;

public class Sphererot : MonoBehaviour
{
    private List<Vector3> spheres;
   
    public int points;
    public float lenght;
    

    public Vector3 rotationvector;

    public void Awake()
    {
        OnValidate();
    }
    

    public void Update()
    {
        // rotate the spheres around the center
        
        var matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(rotationvector * Time.deltaTime), Vector3.one); 
      
        spheres = spheres.Select
        (last =>
        {
            var current = matrix * last;
            return new Vector3(current.x, current.y, current.z);
        }).ToList(); 
    }
    


    //while we update the points to create the circle arund the center
    public void OnValidate()
    {
        spheres = new List<Vector3>();
        for (int i = 0; i< points; i++)
        {
            float ratio = (float)i / (float)points;
            ratio *= 2 * Mathf.PI;
            spheres.Add(new Vector3(Mathf.Sin(ratio), 0, Mathf.Cos(ratio)) * lenght);
        }
    }

    public void OnDrawGizmos()
    {
        if(spheres != null)
        {
            foreach (var spheres in spheres)
            {
                Gizmos.color = Color.cyan;
                Gizmos.DrawSphere(spheres, 0.5f);
            }
        }
    }
}
