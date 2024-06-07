using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class ProgressBarValue : MonoBehaviour
{

    public ProgressBar Pb;
    public int value = 60;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Pb.BarValue = value;
    }
}
