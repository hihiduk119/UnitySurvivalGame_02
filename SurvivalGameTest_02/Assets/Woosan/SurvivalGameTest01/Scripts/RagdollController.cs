using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Woosan.SurvivalGame
{
    public class RagdollController : MonoBehaviour
    {
        List<Rigidbody> rigidbodies;

        public Animator animator;
        public CapsuleCollider capsuleCollider;
        public Transform root;
        public Transform bullet;

        private void Awake()
        {
            rigidbodies = new List<Rigidbody>(this.transform.GetComponentsInChildren<Rigidbody>());

            //해당 리지드바지 가져오기
            //Rigidbody rd = rigidbodies[rigidbodies.FindIndex(value => value.gameObject.name.Equals("aa"))];

            Debug.Log("count = " + rigidbodies.Count);
        }

        /// <summary>
        /// 레그돌 활성화
        /// </summary>
        public void EnableRagdoll()
        {
            animator.enabled = false;
            capsuleCollider.enabled = false;

            rigidbodies.ForEach(value => {
                value.useGravity = true;
                value.isKinematic = false;
                value.detectCollisions = true;
            });
        }

        /// <summary>
        /// 레그돌 비활성화
        /// </summary>
        public void DisableRagdoll()
        {
            rigidbodies.ForEach(value => {
                value.isKinematic = true;
                value.detectCollisions = false;
            });

            animator.enabled = true;
            capsuleCollider.enabled = true;

            root.localPosition = new Vector3(0, 6f, 0);
        }

        public void Die()
        {
            Vector3 forceDir = (transform.position - bullet.position).normalized;
            float power = 500;
            forceDir = forceDir * power;
            forceDir.y = 300;

            rigidbodies.ForEach(value => {
                value.AddForce(forceDir, ForceMode.Force);
            });
        }

        public void Recall()
        {
            rigidbodies.ForEach(value => {
                value.useGravity = false;
                value.AddForce(new Vector3(0, Random.Range(200,400), 0), ForceMode.Acceleration);
            });
        }

        void OnGUI()
        {
            if (GUI.Button(new Rect(0, 0, 200, 150), "레그돌 활성화"))
            {
                EnableRagdoll();
            }

            
            if (GUI.Button(new Rect(0, 150, 200, 150), "레그돌 비활성화"))
            {
                DisableRagdoll();
            }

            if (GUI.Button(new Rect(0, 300, 200, 150), "죽음"))
            { 
                EnableRagdoll();
                Die();
            }

            if (GUI.Button(new Rect(0, 450, 200, 150), "리콜"))
            {
                Recall();
            }
        }
    }
}
