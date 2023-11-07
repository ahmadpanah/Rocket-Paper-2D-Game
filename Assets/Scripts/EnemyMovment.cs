using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovment : MonoBehaviour
{

[SerializeField] float moveSpeed;
[SerializeField] float rotationSpeed;

[SerializeField] Transform player;

Rigidbody2D rb;

void Start() {
    rb = GetComponent <Rigidbody2D> ();
}

void Update() {
   Vector2 dir = player.position - transform.position;
   float angle = Mathf.Atan2(dir.y , dir.x) * Mathf.Rad2Deg;
   Quaternion r = Quaternion.AngleAxis(angle,Vector3.forward);
    transform.rotation = Quaternion.Slerp(transform.rotation,r,rotationSpeed*Time.deltaTime);
}

void FixedUpdate() {
    rb.AddRelativeForce(new Vector3(moveSpeed*Time.fixedDeltaTime,0f,0f));
}


}
