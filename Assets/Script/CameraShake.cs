using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public Transform camera;
    public  static float shakeDuration =0;
    public float shakeAmount = 0;
    public float decreaseFactor = 3;
    Vector3 poscam,camelocal;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(shakeDuration > 0)
        {
            camelocal = poscam + Random.insideUnitSphere * shakeAmount;
            camelocal.z = -10;
            camera.localPosition = camelocal;
            shakeDuration -= Time.deltaTime * decreaseFactor;
        }
        else
        {
            shakeDuration = 0;
            camera.localPosition = poscam;
        }
    }
    private void OnEnable()
    {
        poscam = camera.localPosition;
    }
    
}
