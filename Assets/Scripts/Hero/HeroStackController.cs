using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class HeroStackController : MonoBehaviour
{
    public List<GameObject> blockList = new List<GameObject>();
    private GameManager gameManager;
    private GameObject lastBlockObject;
    private RaycastHit hit;

    private void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        UpdateLastBlockObject();
    }

    private void FixedUpdate() {
        if (Physics.Raycast(transform.position, Vector3.back, out hit, 1f) || Physics.Raycast(transform.position, Vector3.forward, out hit, 1f)) {
        
            if (hit.transform.name == "ObstacleCube") {
                Time.timeScale = 0;
                gameManager.gameOverPanel.SetActive(true);

            }
        }
    }

    public void IncreaseNewBlock(GameObject _gameObject)
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z);
        _gameObject.transform.position = new Vector3(lastBlockObject.transform.position.x, lastBlockObject.transform.position.y - 2f, lastBlockObject.transform.position.z);
        _gameObject.transform.SetParent(transform);
        blockList.Add(_gameObject);
        UpdateLastBlockObject();
    }


    public void DecreaseBlock(GameObject _gameObject)
    {
        _gameObject.transform.parent = null;
        blockList.Remove(_gameObject);
        //Destroy(_gameObject);
        UpdateLastBlockObject();
    }


    public void UpdateLastBlockObject()
    {
        lastBlockObject = blockList[blockList.Count - 1];
    }
    
}
