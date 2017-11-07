using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class Player : NetworkBehaviour
{
    public GameObject Sphere;

    void Start()
    {
    }

    void Update()
    {
        if (isLocalPlayer == true)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                CmdSphere();
            }

            Move();
        }
    }

    void Move()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += transform.forward * 0.2f;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += transform.forward * -0.2f;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += transform.right * -0.2f;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += transform.right * 0.2f;
        }
    }

    [Command]
    void CmdSphere()
    {
        GameObject obj = (GameObject)Instantiate(Sphere, transform.position, transform.rotation);
        NetworkServer.Spawn(obj);
    }
}