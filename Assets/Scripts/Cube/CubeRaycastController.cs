using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CubeRaycastController : MonoBehaviour
{
    [SerializeField] private Transform _cameraTransform;
    [SerializeField] private HeroStackController heroStackController;
    private bool isStack = false;
    private RaycastHit hit;


    private void Start()
    {
        heroStackController = GameObject.FindObjectOfType<HeroStackController>();
    }


    void FixedUpdate()
    {
        if (Physics.Raycast(transform.position, Vector3.back, out hit, 1f) || Physics.Raycast(transform.position, Vector3.forward, out hit, 1f))
        {
            if (!isStack) {
                isStack = !isStack;
                heroStackController.IncreaseNewBlock(gameObject);
             
            }

            if (hit.transform.name == "ObstacleCube") {
                heroStackController.DecreaseBlock(gameObject);
             
                
            }
        }
        if (transform.position.z < _cameraTransform.position.z) {
           
            Destroy(gameObject);
        }


    }
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag== "Cube") {
            if (!isStack) {
                isStack = !isStack;
                heroStackController.IncreaseNewBlock(gameObject);
            }
       
        }
        //if (collision.gameObject.tag == "Obstacle") {

        //    heroStackController.DecreaseBlock(gameObject);
        //    Destroy(gameObject);
        //}
        //if (transform.position.z+3 < _cameraTransform.position.z) {
        //    Debug.Log("Destroy");
        //}

    }


}
