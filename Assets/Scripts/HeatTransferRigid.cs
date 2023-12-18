using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class HeatTransferRigid : HeatTransferBase
{
    public int number;
    public Rigidbody RB;
    public Rigidbody rb { get; set; }
    public double Received_energy;
    public float preTemp, postTemp;
    public float dt;
    public double area;

    bool Onfire = false;

    //public CollisionInput collisionInput;
    public Udpnetwork udpnetwork;
    public CollisionCheckMGR collisionCheckMGR;

    private double GetIntersectonArea(ContactPoint[] c)
    {
        // TBD
        return 1.0;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = RB;
        m = rb.mass;
        preTemp= (float)Temp;
        postTemp = (float)Temp;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        area = 0;
        number = 0;
        if(Heaters.Count > 0)
        {
            number = Heaters.Count;
        }
        foreach (var H in Heaters)
        {
            //dq += Transfer(H.Item1, GetIntersectonArea(H
            dq += Transfer(H.Item1, 1f);
        }

        foreach ( var H2 in Heaters)
        {
            area += 1f;
        }


        var Radial = GetComponent<HeatTransferRadial>();
        if (Radial != null)
        {
            dq += Radial.EnergyFromRay;
            //복사열 받는경우 (너무 뜨거우면 EnergyFromRay remap해서 수정)
            if (Radial.EnergyFromRay > 0)
            {
                Onfire = true;
                string msg = collisionCheckMGR.leftorright + "," + collisionCheckMGR.temp_index.ToString() + "," + Radial.EnergyFromRay.ToString();
                udpnetwork.Sendmsg(msg);
            
                Debug.Log("복사열 : " + msg);
            }
            //받지 않는경우
            if (Radial.EnergyFromRay == 0 && Onfire)
            {
                Onfire = false;
                string msg = collisionCheckMGR.leftorright + "," + collisionCheckMGR.temp_index.ToString() + ",0";
                udpnetwork.Sendmsg(msg);
            }
            

        }
        /*
        var Radial = GetComponent<HeatTransferRadial>();
        if (Radial != null)
        {
            dq += Radial.EnergyFromRay;
            //복사열 받는경우
            if (Radial.EnergyFromRay > 0)
            {
                collisionInput.temp = remap(Radial.EnergyFromRay, 0, 15, 0, 0.5f);
                Debug.Log("복사열 : " + collisionInput.temp);
            }
            //받지 않는경우
            if (Radial.EnergyFromRay == 0)
            {
                collisionInput.temp = -0.1f;
            }
            

        }
        */


        preTemp = (float)Temp;
        if (dq != 0.0) 
        {
            Temp += dq * Time.deltaTime / (HeatC * m);
            dt = (float)(dq / (HeatC * m));
        }
        else if(dq == 0.0)
        {
            dt = 0.0f;
        }
        dq = 0.0;
    }

    private void OnCollisionEnter(Collision collision)
    {
        HeatTransferBase H_;
        bool success = collision.gameObject.TryGetComponent<HeatTransferBase>(out H_);
        if (success)
        {
            Heaters.Add((H_, 1.0));
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        HeatTransferBase H_;
        bool success = collision.gameObject.TryGetComponent<HeatTransferBase>(out H_);
        if (success) RemoveMember(H_);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        HeatTransferBase H_;
        bool success = other.gameObject.TryGetComponent<HeatTransferBase>(out H_);
        if (success)
        {
            Heaters.Add((H_, 1.0)); 
        }
    }

    private void OnTriggerExit(Collider other)
    {
        HeatTransferBase H_;
        bool success = other.gameObject.TryGetComponent<HeatTransferBase>(out H_);
        if (success)
        {
            var i = Heaters.FindIndex(x => x.Item1 == H_);
            if (i != -1)
            {
                var h = Heaters[i];
                Heaters.RemoveAt(i);
            }
        }
    }


        
    public static float remap(float val, float in1, float in2, float out1, float out2)  //리맵하는 함수
    {
        return out1 + (val - in1) * (out2 - out1) / (in2 - in1);
    }
}