using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatTransferBase : MonoBehaviour
{
    // heat conductivity, W m-1 K-1
    public double HeatK = .01;
    // Specific heat capacity, J K-1 g-1
    public double HeatC = 4;
    // Temperature, K
    public double Temp = 1.0;
    // mass, gram
    protected double m;
    // position, m
    public Vector3 pos => this.gameObject.transform.position;
    // Temperature will be changed
    protected double dq = 0;


    public List<(HeatTransferBase, double)> Heaters = new List<(HeatTransferBase, double)>();

    public double GetIntersectonArea((HeatTransferBase, double) _H)
    {
        if (this is HeatTransferRigid)
        {
            HeatTransferRigid T = (HeatTransferRigid)this;
            //Debug.Log(0.002 + 50 * T.rb.velocity.magnitude);
            return _H.Item2 * (0.002 + 100 * T.rb.velocity.magnitude);
        }
        else if (_H.Item1 is HeatTransferRigid)
        {
            HeatTransferRigid T = (HeatTransferRigid)_H.Item1;
            return _H.Item2 * (0.002 + 100 * T.rb.velocity.magnitude);
        }
        else return _H.Item2;
    }

    public double GetDistance(HeatTransferBase _H)
    {
        double ret = Vector3.Distance(pos, _H.pos);

        ret = Vector3.Distance(pos, _H.pos);

        ret = ret > 0.01 ? ret : 0.01;
        return ret;
    }


    public double Transfer(HeatTransferBase _H, double A)
    {
        double dist = GetDistance(_H);
        dist = dist > 0.01 ? dist : 0.01;

        if (A == 0.0) return 0.0;

        double tmp = dist / A;
        double R1 = tmp / HeatK;
        double R2 = tmp / _H.HeatK;
        double dT = Temp - _H.Temp;

        // dq = dT / R_tot
        return -dT / (R1 + R2);
    }


    public void RemoveMember(HeatTransferBase _H)
    {
        var i = Heaters.FindIndex(x => x.Item1 == _H);
        if (i != -1)
            Heaters.RemoveAt(i);
    }
}