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

    private void FixedUpdate()
    {
        Move();
    }

    // Update is called once per frame
    void Update()
    {
        CameraRot();
    }

    #region Move

    private Rigidbody playerRigid;
    
    [SerializeField]
    private float moveSpeed;

    private void Move()
    {
        float dirX = Input.GetAxisRaw("Horizontal");
        float dirY = Input.GetAxisRaw("Vertical");

        Vector3 moveHorizontalVector = transform.right * dirX;
        Vector3 moveVerticalVector = transform.forward * dirY;
        Vector3 dirVector = (moveHorizontalVector + moveVerticalVector).normalized;
        Vector3 movePosition = transform.position + dirVector * moveSpeed * Time.deltaTime;

        playerRigid.MovePosition(movePosition);
    }

    #endregion

    #region Camera

    [SerializeField]
    private Camera mainCam;

    [SerializeField]
    private float horizontalSensitivity;

    [SerializeField]
    private float verticalSensitivity;

    private float limitAngle = 90f;
    private float curVerticalAngle = 0;

    private void CameraRot()
    {
        HorizontalRot();
        VerticalRot();
    }

    private void HorizontalRot()
    {
        float angle = Input.GetAxis("Mouse X");
        Vector3 yRotation = new Vector3(0, angle, 0) * horizontalSensitivity;

        playerRigid.MoveRotation(transform.rotation * Quaternion.Euler(yRotation));
    }

    private void VerticalRot()
    {
        float angle = Input.GetAxisRaw("Mouse Y");
        float xRotation = angle * verticalSensitivity;
        curVerticalAngle -= xRotation;
        curVerticalAngle = Mathf.Clamp(curVerticalAngle, -limitAngle, limitAngle);

        mainCam.transform.localEulerAngles = new Vector3(curVerticalAngle, 0, 0);
    }

    #endregion
}
