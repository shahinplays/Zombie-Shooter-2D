using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMe : MonoBehaviour
{
    public float lifeTime = 3f;
    void Start()
    {
        Destroy(this.gameObject, lifeTime);
    }


}
