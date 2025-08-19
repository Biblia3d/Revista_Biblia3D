using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]

public class PlayerMoveController : MonoBehaviour {

	// PUBLIC
	public SimpleTouchController leftController;
	public SimpleTouchController rightController;
    public SimpleTouchController otherController;
	public float speedMovements = 5f;
    public float limiteR, limiteL;
	public float speedContinuousLook = 50f;
	public float speedProgressiveLook = 3000f;
	public bool continuousRightController = true, change = false;
    public GameObject JoystickBase, msg;
    
    

	// PRIVATE
	private Rigidbody _rigidbody;
	private Vector3 localEulRot;
	private Vector2 prevRightTouchPos;

	void Awake()
	{
		_rigidbody = GetComponent<Rigidbody>();
        if (rightController != null)
        {
            rightController.TouchEvent += RightController_TouchEvent;
            rightController.TouchStateEvent += RightController_TouchStateEvent;
        }
	}

	public bool ContinuousRightController
	{
		set{continuousRightController = value;}
	}

	void RightController_TouchStateEvent (bool touchPresent)
	{
		if(!continuousRightController)
		{
			prevRightTouchPos = Vector2.zero;
		}
	}

	void RightController_TouchEvent (Vector2 value)
	{
		if(!continuousRightController)
		{
			Vector2 deltaValues = value - prevRightTouchPos;
			prevRightTouchPos = value;

			transform.localEulerAngles = new Vector3(transform.localEulerAngles.y - deltaValues.y * Time.deltaTime * speedProgressiveLook, 0f,
				transform.localEulerAngles.z + deltaValues.y * Time.deltaTime * speedProgressiveLook);
		}
	}

	void Update()
	{
        // move

        if (transform.localPosition.x<limiteR && transform.localPosition.x>limiteL) {
            if (leftController.GetTouchPosition.x == 1 || leftController.GetTouchPosition.x == -1 || leftController.GetTouchPosition.y >0 || leftController.GetTouchPosition.y<0)
            {
                _rigidbody.MovePosition(transform.position - (transform.forward * leftController.GetTouchPosition.y * Time.deltaTime * speedMovements) -
                    (transform.right * leftController.GetTouchPosition.x * Time.deltaTime * speedMovements / 2));
                JoystickBase.transform.Rotate(0, 0, -leftController.GetTouchPosition.x * 200 * Time.deltaTime);
                
            }

            if (leftController.GetTouchPosition.x == 1)
            {
                MovePersonagem.instance.WalkR();
                MovePersonagem.instance.anim.ResetTrigger("Stop");
                change = false;
                if (msg !=null && msg.activeSelf)
                {
                    msg.SetActive(false);
                }
                leftController.gameObject.GetComponent<ScrollRect>().vertical = false;
            }
            if (leftController.GetTouchPosition.x == -1)
            {
                MovePersonagem.instance.WalkL();
                MovePersonagem.instance.anim.ResetTrigger("Stop");
                change = false;
                if (msg != null && msg.activeSelf)
                {
                    msg.SetActive(false);
                }
                leftController.gameObject.GetComponent<ScrollRect>().vertical = false;
            }
            if (leftController.GetTouchPosition.y <0)
            {
                MovePersonagem.instance.WalkF();
                MovePersonagem.instance.anim.ResetTrigger("Stop");
                change = false;
                if (msg != null && msg.activeSelf)
                {
                    msg.SetActive(false);
                }
                leftController.gameObject.GetComponent<ScrollRect>().horizontal = false;
            }
            if (leftController.GetTouchPosition.y >0)
            {
                MovePersonagem.instance.WalkB();
                MovePersonagem.instance.anim.ResetTrigger("Stop");
                change = false;
                if (msg != null && msg.activeSelf)
                {
                    msg.SetActive(false);
                }
                leftController.gameObject.GetComponent<ScrollRect>().horizontal = false;
            }

            if (!change)
            {
                if (leftController.GetTouchPosition.x == 0 && leftController.GetTouchPosition.y == 0 && !change)
                {

                    MovePersonagem.instance.anim.SetTrigger("Stop");
                    change = true;
                    MovePersonagem.instance.r = false;
                    MovePersonagem.instance.l = false;
                    MovePersonagem.instance.b = false;
                    MovePersonagem.instance.f = false;

                    leftController.gameObject.GetComponent<ScrollRect>().vertical = true;
                    leftController.gameObject.GetComponent<ScrollRect>().horizontal = true;

                }
            }
            
        }

        

       /* if (transform.localPosition.z < limiteR && transform.localPosition.z > limiteL)
        {
            _rigidbody.MovePosition(transform.position - (transform.forward * leftController.GetTouchPosition.y * Time.deltaTime * speedMovements) -
                (transform.right * leftController.GetTouchPosition.x * Time.deltaTime * speedMovements));
        }
        else if (transform.localPosition.z > 0)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, 0.95f);
        }
        else if (transform.localPosition.z < 0)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, -0.95f);
        }*/



        if (continuousRightController)
		{
            
                transform.localEulerAngles = new Vector3(transform.eulerAngles.x - rightController.GetTouchPosition.y*Time.deltaTime*speedContinuousLook/2, transform.localEulerAngles.y
                    - rightController.GetTouchPosition.x * Time.deltaTime * speedContinuousLook, transform.localEulerAngles.z);
            JoystickBase.transform.Rotate(0, 0, -rightController.GetTouchPosition.x * 200 * Time.deltaTime);
        
        }

	}

	void OnDestroy()
	{
        if (rightController == null) return;
        rightController.TouchEvent -= RightController_TouchEvent;
		rightController.TouchStateEvent -= RightController_TouchStateEvent;
	}

}
