using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerOfRocket : MonoBehaviour
{
    // Buiten kleine aanpassingen grotendeels gebaseerd op: https://youtu.be/o9l699x_qZM?t=329

    [SerializeField] float thrusterForce = 10f;
    [SerializeField] float tiltingForce = 10f;

    bool thrust = false;

    Rigidbody rocket;



    private void Awake()
    {
        rocket = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float tilt = Input.GetAxis("Horizontal");
        thrust = Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space);

        if (!Mathf.Approximately(tilt, 0f))
        {
            rocket.freezeRotation = true;
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + (new Vector3(0f, 0f, (tilt * tiltingForce * Time.deltaTime))));
        }


        rocket.freezeRotation = false;
    }
    private void FixedUpdate()
    {
        if (thrust)
        {
            rocket.AddRelativeForce(Vector3.up * thrusterForce * Time.deltaTime);
            // Stackoverflow: https://stackoverflow.com/questions/67795616/how-do-i-enable-disable-gravity-in-a-script-in-unity (Rigidbody.useGravity)
            GetComponent<Rigidbody>().useGravity = false;
            // Werkte niet goed maar laat het erbij staan
            //Physics.gravity *= -1;
        }
        else
        {
            GetComponent<Rigidbody>().useGravity = true;
            //Physics.gravity *= -1;
        }
    }
}
