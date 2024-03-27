using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenInventory : MonoBehaviour
{
    public Transform currentPosition;
    [SerializeField] int openPos = -10;
    [SerializeField] int closePos = 200;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OpenInv()
    {
        currentPosition.localPosition = new Vector3(openPos,0,0);
    }
    public void CloseInv()
    {
        currentPosition.localPosition = new Vector3(closePos,0,0);
    }
}
