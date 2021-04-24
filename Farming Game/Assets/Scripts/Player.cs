using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Player : MonoBehaviour
{
    public float AddedSpeed;
    private float ExtraSpeed;
    public float Speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        if (Input.GetButton("Run"))
        {
            ExtraSpeed = AddedSpeed;
        }
        else
        {
            ExtraSpeed = 0;
        }
        transform.position += new Vector3(x, y) * (Speed + ExtraSpeed) * Time.deltaTime;
    }

}
