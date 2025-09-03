using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoliasIdle : MonoBehaviour {

    Animator anim;
    public float speed;
    public float limiteR, limiteL, limiteF, limiteB;
    public bool right, left, forward, backward, stop;
    public float wait =0;
    public float time;
    public bool ok, end = false;
    public bool waitL, waitR, atacou1, atacou2;
    GameObject golias;

    // Use this for initialization
    void Start () {
        anim = gameObject.GetComponentInChildren<Animator>();
        golias = GetComponentInChildren<Transform>().gameObject;

    }

    private void OnEnable()
    {
        left = true;
        Left();
        Invoke("StartMove", 3);
    }


    // Update is called once per frame
    void Update () {

        if (!end)
        {

            if (stop)
            {
                ok = false;
                wait += 0.1f;
                if (wait >= time)
                {
                    stop = false;
                    wait = 0;
                    ok = true;
                }
            }
            else
            {
                if (ok)
                {

                    if (backward)
                    {
                        backward = false;
                    }

                    if (left)
                    {
                        left = false;
                    }

                    if (right)
                    {
                        right = false;
                    }
                    if (forward)
                    {
                        forward = false;
                    }
                    ok = false;
                }



                if (transform.position.z < limiteB && transform.position.x > limiteL && !right && !forward)
                {
                    right = false;
                    if (!left)
                    {

                        Left();
                        wait = 0;
                    }
                    left = true;
                    {
                        transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
                        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, 270, transform.localEulerAngles.z);
                    }

                }
                else if (transform.position.x <= limiteL)
                {
                    left = false;

                    if (wait < 20 && !waitL)
                    {
                        if (!atacou1)
                            anim.SetTrigger("Ataque2");
                        wait += 0.1f;
                        atacou1 = true;
                        atacou2 = false;
                        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, 180, transform.localEulerAngles.z);
                    }
                    else
                    {
                        waitL = true;
                        waitR = false;
                        if (!backward)
                        {
                            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, 0, transform.localEulerAngles.z);
                            Backward();
                            wait = 0;
                        }
                        backward = true;
                        MoveB();
                    }
                }

                if (transform.position.z >= limiteB && transform.position.x < limiteR && !left && !backward)
                {

                    left = false;
                    if (!right)
                    {

                        Right();
                    }
                    right = true;
                    {
                        transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
                        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, 90, transform.localEulerAngles.z);
                    }

                }
                else if (transform.position.x >= limiteR)
                {
                    right = false;
                    if (wait < 20 && !waitR)
                    {
                        if (!atacou2)
                            anim.SetTrigger("Atacar");
                        wait += 0.1f;
                        atacou2 = true;
                        atacou1 = false;
                        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, 180, transform.localEulerAngles.z);
                    }
                    else
                    {
                        waitL = false;
                        waitR = true;

                        if (!forward)
                        {
                            Forward();
                            wait = 0;
                        }
                        forward = true;
                        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, 180, transform.localEulerAngles.z);
                        MoveF();
                    }

                }
            }
        }
        

    }

    void Right()
    {
        anim.SetTrigger("F");
        //Invoke("Left", 3);
    }

    void Left()
    {
		if(anim!=null)
        anim.SetTrigger("F");
        //Invoke("Right", 3);
    }

    void Forward()
    {
        anim.SetTrigger("F");
    }

    void Backward()
    {
        anim.SetTrigger("F");
    }

    void Move()
    {
        anim.SetTrigger("Move");
    }

    void MoveB()
    {
        if (transform.position.z < limiteB)
        {
            transform.position = new Vector3(transform.position.x , transform.position.y, transform.position.z + speed * Time.deltaTime);
        }
        else if(transform.position.z >= limiteB)
        {
            //right = true;
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, 90, transform.localEulerAngles.z);
            Right();
            backward = false;
        }
    }

    void MoveF()
    {
        if (transform.position.z > limiteF)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - speed * Time.deltaTime);
        }
        else if (transform.position.z <= limiteF)
        {
            left = true;
            Left();
            forward = false;
        }
    }

    void ResetOk()
    {
        ok = true;
    }

    void StartMove()
    {
        stop = false;
    }

}
