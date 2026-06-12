using UnityEngine;

[ExecuteAlways]
public class LineaDinamica : MonoBehaviour
{
    public Transform puntoA;
    public Transform puntoB;

    private LineRenderer lr;

    void Update()
    {
        if (lr == null)
            lr = GetComponent<LineRenderer>();

        if (puntoA == null || puntoB == null)
            return;

        lr.positionCount = 2;

        lr.SetPosition(0, puntoA.position);
        lr.SetPosition(1, puntoB.position);
    }
}
