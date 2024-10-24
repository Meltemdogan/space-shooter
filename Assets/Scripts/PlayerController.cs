using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}


public class PlayerController : MonoBehaviour

{
    Rigidbody physic;
    [SerializeField] int speed;
    [SerializeField] int tilt;
    [SerializeField] float nextFire;
    [SerializeField] float fireRate;
    public Boundary boundary;
    public GameObject shot;
    public GameObject shotSpawn;
   
    void Start()
    {
        physic = GetComponent<Rigidbody>();
    }
     void Update()
    {
        
        if (Input.GetButton("Fire1") && Time.time>nextFire )
        {
            nextFire= Time.time + fireRate;
            Instantiate(shot, shotSpawn.transform.position, shotSpawn.transform.rotation);
        }
    }

    [SerializeField] private string m_HorizontalId;
    [SerializeField] private string m_VerticalId;

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis(m_HorizontalId);
        float moveVertical = Input.GetAxis(m_VerticalId);

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);

        physic.velocity = movement * speed;
        Vector3 position = new Vector3(Mathf.Clamp(physic.position.x, boundary.xMin, boundary.xMax), 0, Mathf.Clamp(physic.position.z, boundary.zMin, boundary.zMax));

        physic.position = position;
        physic.rotation = Quaternion.Euler(0,0,physic.velocity.x*tilt);  
    }
}
