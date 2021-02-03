using UnityEngine;
using System.Collections;

namespace RVP
{
    [DisallowMultipleComponent]
    [AddComponentMenu("RVP/Vehicle Controllers/Vehicle Debug", 3)]

    //Class for easily resetting vehicles
    public class VehicleDebug : MonoBehaviour
    {
        public Vector3 spawnPos;
        public Vector3 spawnRot;

        public Transform Target01;
        public Transform Target02;
        public Transform Target11;
        public Transform Target12;
        public Transform Target21;
        public Transform Target22;
        public Transform Target31;
        public Transform Target32;
        public Transform Target41;
        public Transform Target42;

        [Tooltip("Y position below which the vehicle will be reset")]
        public float fallLimit = -10;

        private void Start()
        {
            spawnPos = transform.position;
            spawnRot = transform.rotation.eulerAngles;
        }

        void Update()
        {
            if (Input.GetButtonDown("Reset Rotation"))
            {
                if (gameObject.tag == "Player")
                {
                    StartCoroutine(ResetRotation());
                }
            }

            if (Input.GetButtonDown("Reset Position"))
            {
                if (gameObject.tag == "Player")
                {
                    StartCoroutine(ResetPosition());
                }
            }
            if (transform.position.y < fallLimit)
            {
                StartCoroutine(ResetPosition());
            }
        }


        //DEVNOOB EDIT FROZEN
        public IEnumerator Frozen()
        {
            if (GetComponent<VehicleDamage>())
            {
                GetComponent<VehicleDamage>().Repair();
            }   
            yield return new WaitForFixedUpdate();
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
            transform.Translate(Vector3.up, Space.World);
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            GetComponent<Rigidbody>().isKinematic = true;
            yield return new WaitForSeconds(3);
            GetComponent<Rigidbody>().isKinematic = false;
        }

        public void ResetRotStarter()
        {
            StartCoroutine(ResetRotation());
        }

        //This waits for the next fixed update before resetting the rotation of the vehicle
        public IEnumerator ResetRotation()
        {
            if (GetComponent<VehicleDamage>())
            {
                GetComponent<VehicleDamage>().Repair();
            }

            yield return new WaitForFixedUpdate();
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
            transform.Translate(Vector3.up, Space.World);
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        }

        //This waits for the next fixed update before resetting the position of the vehicle
        IEnumerator ResetPosition()
        {
            if (GetComponent<VehicleDamage>())
            {
                GetComponent<VehicleDamage>().Repair();
            }

            transform.position = spawnPos;
            yield return new WaitForFixedUpdate();
            //transform.rotation = Quaternion.LookRotation(spawnRot, GlobalControl.worldUpDir);
            //transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
            transform.eulerAngles = spawnRot;
            transform.Translate(Vector3.up, Space.World);
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

            //SET NEW WAYPOINT TARGET
            if (tag == "Enemy")
            {
                if (GetComponent<FollowAI>().LatestCheckpoint.name == "CheckCollider0")
                {
                    float randVal = Random.value;
                    if (randVal < 0.5f)
                    {
                        GetComponent<FollowAI>().target = Target01;
                    }
                    else
                    {
                        GetComponent<FollowAI>().target = Target02;
                    }
                }
                if (GetComponent<FollowAI>().LatestCheckpoint.name == "CheckCollider1")
                {
                    float randVal = Random.value;
                    if (randVal < 0.5f)
                    {
                        GetComponent<FollowAI>().target = Target11;
                    }
                    else
                    {
                        GetComponent<FollowAI>().target = Target12;
                    }
                }
                if (GetComponent<FollowAI>().LatestCheckpoint.name == "CheckCollider2")
                {
                    float randVal = Random.value;
                    if (randVal < 0.5f)
                    {
                        GetComponent<FollowAI>().target = Target21;
                    }
                    else
                    {
                        GetComponent<FollowAI>().target = Target22;
                    }
                }
                if (GetComponent<FollowAI>().LatestCheckpoint.name == "CheckCollider3")
                {
                    float randVal = Random.value;
                    if (randVal < 0.5f)
                    {
                        GetComponent<FollowAI>().target = Target31;
                    }
                    else
                    {
                        GetComponent<FollowAI>().target = Target32;
                    }
                }
                if (GetComponent<FollowAI>().LatestCheckpoint.name == "CheckCollider4")
                {
                    float randVal = Random.value;
                    if (randVal < 0.5f)
                    {
                        GetComponent<FollowAI>().target = Target41;
                    }
                    else
                    {
                        GetComponent<FollowAI>().target = Target42;
                    }
                }
                GetComponent<FollowAI>().targetWaypoint = GetComponent<FollowAI>().targetWaypoint.nextPoint;
            }
            fallLimit = -0.8f;
        }
    }
}