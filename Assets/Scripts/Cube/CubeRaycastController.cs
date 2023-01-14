using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeRaycastController : MonoBehaviour
{
    [SerializeField] private HeroStackController heroStackController;
    
    private bool isStack = false;
    private RaycastHit hit;


    private void Start()
    {
        heroStackController = GameObject.FindObjectOfType<HeroStackController>();
    }


    void FixedUpdate()
    {
        if (Physics.Raycast(transform.position, Vector3.back, out hit, 1f)|| Physics.Raycast(transform.position, Vector3.left, out hit, 1f) || Physics.Raycast(transform.position, Vector3.right, out hit, 1f))
        {
            if (!isStack) {
                isStack = !isStack;
                heroStackController.IncreaseNewBlock(gameObject);
             
            }

            if (hit.transform.name == "ObstacleCube") {
                heroStackController.DecreaseBlock(gameObject);
                
            }
        }
        
    }

 
}
