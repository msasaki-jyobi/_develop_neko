using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace develop_neko
{

    public class Jump : MonoBehaviour
    {
        [SerializeField] private Rigidbody Rigidbody;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
                Rigidbody.AddForce(transform.up * 5, ForceMode.Impulse);
        }
    }
}