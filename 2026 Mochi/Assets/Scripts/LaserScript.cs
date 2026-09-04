using System.Runtime.CompilerServices;
using UnityEngine;
using System.Collections.Generic;

public class LaserScript : MonoBehaviour
{
    [SerializeField]
    private float speedLaser;
    [SerializeField]
    private float HPtimeLaser;
   

    private float cronometre;

    private void OnEnable()
    {
        cronometre = 0;
    }
    void Start()
    {
       
    }

    
    void Update()
    {
        transform.Translate(Vector2.right * speedLaser * Time.deltaTime);

        cronometre += Time.deltaTime;
        if (this.gameObject.activeInHierarchy)
        {
            if (cronometre >= HPtimeLaser)
            {
                gameObject.SetActive(false);

            }
        }
    }
}
