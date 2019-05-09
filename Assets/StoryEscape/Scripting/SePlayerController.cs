using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SePlayerController : MonoBehaviour
{
    public static SePlayerController instance = null;

    public Transform viewTransform;
    public Transform viewParent;
    public float moveSpeed;
    public float moveAcc;
	public float moveStopRatio;
    public float stickGroundForce;
    public Vector2 lookSpeed;
    public float lookAttenuation;
    public Vector2 clampedXLook;

    private CharacterController cc;
    private Vector3 desiredMove;
    private float forwardSign;
    private float xMove;
    private float yMove;
    private Vector3 moveDir;
    private Vector3 moveInput;
	private float current_MoveAcceleration;
    private bool canMove;
    private bool canLook;

    private float xRot;
    private float yRot;
    private Vector2 lookInput;

    void Awake ()
    {
        if (instance == null) instance = this;

        cc = GetComponent<CharacterController>();

        xRot = viewTransform.localEulerAngles.x;
        yRot = viewParent.localEulerAngles.y;

        Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;

        ChangeControllerState(true, true);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleLook();
        HandleMove();
    }

    void HandleLook ()
    {
        if (canLook)
        {
            lookInput = Vector2.Lerp(lookInput, new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")), lookAttenuation * Time.deltaTime);

            yRot += lookInput.x * lookSpeed.y * Time.deltaTime;
            viewParent.localRotation = Quaternion.AngleAxis(yRot, Vector3.up);

            xRot = Mathf.Clamp(xRot + lookInput.y * lookSpeed.x * Time.deltaTime, clampedXLook.x, clampedXLook.y);
            viewTransform.localRotation = Quaternion.AngleAxis(xRot, Vector3.right);
        }
    }

    void HandleMove ()
    {
        if (canMove)
        {
            moveInput.x = Input.GetAxis("Horizontal");
            moveInput.y = Input.GetAxis("Vertical");
        }
        else
        {
            moveInput = Vector3.zero;
        }

        xMove = Mathf.Lerp(xMove, moveInput.x, moveAcc * Time.deltaTime);
        yMove = Mathf.Lerp(yMove, moveInput.y, moveAcc * Time.deltaTime);

        Vector3 projectedInput = Vector3.ProjectOnPlane(viewTransform.forward, Vector3.up) * yMove + viewParent.right * xMove;
        moveDir.x = projectedInput.x * moveSpeed;
        moveDir.z = projectedInput.z * moveSpeed;


        if (cc.isGrounded) moveDir.y = -stickGroundForce;
        else
        {
            moveDir = Vector3.Project(moveDir, Vector3.up);
            moveDir += Physics.gravity * Time.deltaTime;
        }

        cc.Move(moveDir * Time.deltaTime);
    }

    public void ChangeControllerState (bool bCanMove, bool bCanLook)
    {
        canMove = bCanMove;
        canLook = bCanLook;
    }

    public void GetObject (SeObjectBase o)
    {
        int v = PlayerPrefs.GetInt(o.keyName, 0)+1;
        PlayerPrefs.SetInt(o.keyName, v);
    }
}
