using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTime : MonoBehaviour
{
   
        public float lifeTime = 2f;

        private void Start()
        {
            Destroy(this.gameObject, lifeTime);
        }
    }

