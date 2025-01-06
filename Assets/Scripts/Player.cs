using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        playerRigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }


    #region Move

    [SerializeField]
    private float moveSpeed;

    Rigidbody playerRigid;

    private void Move()
    {
        float dirX = Input.GetAxisRaw("Horizontal");
        float dirY = Input.GetAxisRaw("Vertical");

        Vector3 moveVector = new Vector3(dirX, 0, dirY).normalized;
        Vector3 newVector = transform.position + moveVector * moveSpeed * Time.deltaTime;
        playerRigid.Move(newVector, transform.rotation);
    }

    #endregion
}
