using UnityEngine;
using System.Collections.Generic;
// A very simplistic car driving on the x-z plane.

public class Drive : MonoBehaviour
{
    public float speed = 10.0f;
    public float rotationSpeed = 100.0f;
    Vector3 direction = new Vector3(0, 0, 0);
    void Update()
    {
        // Get the horizontal and vertical axis.
        // By default they are mapped to the arrow keys.
        // The value is in the range -1 to 1
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        // Make it move 10 meters per second instead of 10 meters per frame...
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;
        // Move translation along the object's z-axis
        //transform.Translate(0, translation, 0);
        //Debug.Log(direction);


        //Vector3 position = HolisticMath.Translate(rotation * 0.1f, translation, 0);


        // Rotate around our y-axis
        //transform.Rotate(0, 0, -rotation);
        direction += new Vector3(rotation, 0, 0);
        //Debug.Log(direction);
        //Coords dirNormal = HolisticMath.GetNormal(new Coords(direction));

        //float a = HolisticMath.Angle(new Coords(1, 0, 0), new Coords(direction));
        float a = (direction.x % 628.66f) * 0.01f;
        //Debug.Log("Direction : " + direction +
        //" \n a : " + a + " x  : " + translation * Mathf.Sin(-transform.rotation.z));

        Debug.Log("ang:  " + -(-transform.rotation.z * 100) * Mathf.PI / 180 + "sin : " + Mathf.Sin((-transform.rotation.z * 100) * Mathf.PI / 180));    
        bool clockwise = false;
        //if (HolisticMath.Cross(new Coords(transform.up), new Coords(direction)).z < 0)
        //{
        //    clockwise = true;
        //}
        Coords newDir = HolisticMath.Rotate(new Coords(0, 1, 0), -a, clockwise);
        if (direction.x != 0)
            transform.up += new Vector3(newDir.x, newDir.y, newDir.z);



        Vector3 position = HolisticMath.Translate(0, translation, 0, -transform.rotation.z * 100);
        transform.position += position;

    }
}