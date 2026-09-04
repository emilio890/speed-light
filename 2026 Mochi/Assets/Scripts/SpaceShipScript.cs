using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpaceShipScript : MonoBehaviour
{
    [SerializeField]
    private InputAction inputmovement;
    [SerializeField]
    private InputAction inputshoot;
    [SerializeField]
    private float maxlimit;
    [SerializeField]
    private float minlimit;
    [SerializeField]
    Rigidbody2D rbEspaceShip;
    [SerializeField]
    private GameObject prefablaser;
    [SerializeField]
    private int ammo;
    [SerializeField]
    private List<GameObject> boollaser = new List<GameObject>();

    private void OnEnable()
    {
        inputmovement.Enable();
        inputshoot.Enable();
    }
    private void OnDisable()
    {
        inputshoot.Disable();
        inputmovement.Disable();
    }
    void FixedUpdate()
    {
        float Espacemove = inputmovement.ReadValue<float>();
        rbEspaceShip.linearVelocityY = Espacemove * 10;

        Vector2 pos = rbEspaceShip.position;
        pos.y = Mathf.Clamp(pos.y, minlimit, maxlimit);
        rbEspaceShip.position = pos;
    }

    void Start()
    {
        for (int i = 0; i < ammo; i++)
        {
            GameObject laser = Instantiate(prefablaser);
            laser.SetActive(false);
            boollaser.Add(laser);
        }
    }

    
    void Update()
    {
        if (inputshoot.triggered)
        {
            Disparar();
        }
    }
     void Disparar()
    {
        GameObject laser = Getlaser();
        laser.transform.position = transform.position;
        laser.SetActive(true);
    }
    GameObject Getlaser()
    {
        foreach (GameObject laser in boollaser)
        {
            if ( !laser.activeInHierarchy)
            {
                return laser;
            }
        }
        GameObject newlaser = Instantiate(prefablaser);
        newlaser.SetActive(false);
        boollaser.Add(newlaser);
        return newlaser;
    }
}
