using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Allien : MonoBehaviour
{
    public int scoreValue;
    public GameObject explosion;

    public void Kill()
    {
        AllienMaster.allAlliens.Remove(gameObject);
        Instantiate(explosion,transform.position, Quaternion.identity);
        gameObject.SetActive(false);
    }
}
