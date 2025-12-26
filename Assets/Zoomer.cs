using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoomer : MonoBehaviour
{
    [SerializeField]
    private float ScroolSpeed = 10f;
    private Camera ZoomCamera;
    public float MaxSize = 7;
    public float MinSize = 2;
    public float StandartSize = 5;
    public string valtoztatas = "----------------";
    public float ScalePersentage = 100;
    private float backScalePersentage = 1;
    public List<GameObject> ChangeScaleObject = new List<GameObject>();
    private Vector2 FirstVector2, SecuendVector2;
    private float FirstTouchFloat, SecuendTouchFloat;
    private Vector2 Zpos = new Vector3(999999, 999999);
    float persentageZ = 0;
    public static float ZoomerPanelData;
    private Vector2 MemoriFirstPos, MemoriSecuendPos;
    private bool MemoriXYNez = false;
    void Start()
    {
        ScalePersentage = 100;
        ZoomCamera = Camera.main;

    }

    // Update is called once per frame
    void Update()
    {
        if (MENUGamobjects.kameramozgatas != 0||CameraMove.zoomszabade)
            return;
        if (Input.touchCount == 2)
        {
            Touch FirstTouch = Input.GetTouch(0);
            Touch SecuendTouch = Input.GetTouch(1);
            if (MemoriXYNez)
            {
                if (Vector3.Distance(MemoriFirstPos, FirstTouch.position) < 0.1f|| Vector3.Distance(MemoriSecuendPos, SecuendTouch.position) < 0.1f)
                {
                    return;
                }
                else
                {
                    MemoriFirstPos = FirstTouch.position;
                    MemoriSecuendPos = SecuendTouch.position;
                }
            }
            else
            {
                MemoriFirstPos = FirstTouch.position;
                MemoriSecuendPos = SecuendTouch.position;
                MemoriXYNez = true;
            }           

            FirstVector2 = FirstTouch.position - FirstTouch.deltaPosition;
            SecuendVector2 = SecuendTouch.position - SecuendTouch.deltaPosition;

            FirstTouchFloat = (FirstVector2 - SecuendVector2).magnitude;
            SecuendTouchFloat = (FirstTouch.position - SecuendTouch.position).magnitude;

            float Zooming = Vector3.Distance(FirstTouch.position,FirstTouch.deltaPosition) * ScroolSpeed/40000;

            if (FirstTouchFloat > SecuendTouchFloat)
            {
                if (ZoomCamera.orthographicSize + Zooming <= MaxSize)
                {
                    backScalePersentage = 100 * ZoomCamera.orthographicSize / StandartSize;
                    ZoomCamera.orthographicSize += Zooming;
                    ScalePersentage = 100 * ZoomCamera.orthographicSize / StandartSize;
                    SceleChange(backScalePersentage, ScalePersentage);
                }
                return;

            }
            else
            {                    
                if (ZoomCamera.orthographicSize - Zooming >= MinSize)
                {            
                    
                    Vector3 PosFirst = Camera.main.ScreenToWorldPoint(FirstTouch.position) + new Vector3(0, 0, 10);
                    Vector3 PosSecound = Camera.main.ScreenToWorldPoint(SecuendTouch.position) + new Vector3(0, 0, 10);
                    Vector2 Zpresent = new Vector2(((Mathf.Abs(PosFirst.x - PosSecound.x))) / 2 + Mathf.Min(PosFirst.x, PosSecound.x), ((Mathf.Abs(PosFirst.y - PosSecound.y)) / 2 + Mathf.Min(PosFirst.y, PosSecound.y)));
                    if(Vector2.Distance(Zpos, Zpresent)>1f)
                    {
                        persentageZ = (Zooming / (ZoomCamera.orthographicSize - MinSize));
                        Zpos = Zpresent;
                    }



                    float pluszXpos = Mathf.Abs(Zpos.x - transform.position.x)*persentageZ;
                     if((((Mathf.Abs(PosFirst.x - PosSecound.x)) / 2)+Mathf.Min(PosFirst.x , PosSecound.x)) < transform.position.x) { pluszXpos *= -1; }
                    float pluszYpos = Mathf.Abs(Zpos.y - transform.position.y) * persentageZ;
                    if ((((Mathf.Abs(PosFirst.y - PosSecound.y)) / 2) + Mathf.Min(PosFirst.y, PosSecound.y)) < transform.position.y) { pluszYpos *= -1; }
                    transform.position = new Vector3(transform.position.x+pluszXpos, transform.position.y+pluszYpos, transform.position.z);
                    backScalePersentage = 100 * ZoomCamera.orthographicSize / StandartSize;
                    ZoomCamera.orthographicSize -= Zooming;
                    ScalePersentage = 100 * ZoomCamera.orthographicSize / StandartSize;
                    SceleChange(backScalePersentage, ScalePersentage);
                }
                return;
            }


            return;
        }
        else
        {
            MemoriXYNez = false;
        }
        if (Input.GetAxis("Mouse ScrollWheel")!=0)
        {
            if (ZoomCamera.orthographic)
            {
                //Debug.Log("1");
                if (ZoomCamera.orthographicSize - Input.GetAxis("Mouse ScrollWheel") * ScroolSpeed >= MinSize && ZoomCamera.orthographicSize - Input.GetAxis("Mouse ScrollWheel") * ScroolSpeed <= MaxSize)
                {
                    backScalePersentage = 100 * ZoomCamera.orthographicSize / StandartSize;
                    ZoomCamera.orthographicSize -= Input.GetAxis("Mouse ScrollWheel") * ScroolSpeed;
                    ScalePersentage = 100 * ZoomCamera.orthographicSize / StandartSize;
                    SceleChange(backScalePersentage, ScalePersentage);
                    return;
                }
            }
            else
            {
                //Debug.Log("2");
                if (ZoomCamera.fieldOfView - Input.GetAxis("Mouse ScrollWheel") * ScroolSpeed >= MinSize && ZoomCamera.fieldOfView - Input.GetAxis("Mouse ScrollWheel") * ScroolSpeed <= MaxSize)
                {
                    backScalePersentage = 100 * ZoomCamera.fieldOfView / StandartSize;
                    ZoomCamera.fieldOfView -= Input.GetAxis("Mouse ScrollWheel") * ScroolSpeed;
                    ScalePersentage = 100 * ZoomCamera.fieldOfView / StandartSize;
                    SceleChange(backScalePersentage, ScalePersentage);
                    return;
                }
            }
        }
    }
    public void SceleChange(float BackScalePercent,float PresentScalaPercent)
    {
        gameObject.GetComponent<CameraMove>().ScalaPersentage = PresentScalaPercent / 100;
        for(int i=0;i< ChangeScaleObject.Count;i++)
        {
            if (ChangeScaleObject[i] != null)
            {
                ChangeScaleObject[i].transform.localScale = new Vector3(ChangeScaleObject[i].transform.localScale.x * PresentScalaPercent / BackScalePercent, ChangeScaleObject[i].transform.localScale.y * PresentScalaPercent / BackScalePercent, 5);
            }
        }
    }
}
