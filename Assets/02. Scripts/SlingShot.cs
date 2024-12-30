using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingShot : MonoBehaviour
{
    public LineRenderer line;

    public GameObject lineLeft;
    public GameObject lineRight;

    public GameObject birdPrefab;
    private Vector3 screenPos;
    private float depth = 10f;
    private GameObject bird;
    public GameObject middlePos;
    private Vector3 targetPos;
    private Vector3 currentPos;
    private Vector3 worldPos;
    private Rigidbody rb;
    private float forceValue = 10f;
    private bool gameStart;
    
    
    // Start is called before the first frame update
    void Start()
    {
        line.enabled = false;
        
        line.positionCount = 3;
        
        line.SetPosition(0, lineLeft.transform.position);
        line.SetPosition(2, lineRight.transform.position);
        
        gameStart = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            line.enabled = true;
            bird = InstantiateBird();
        }

        if (Input.GetMouseButton(0))
        {
            // 마우스 포지션
            screenPos = Input.mousePosition;
            screenPos.z = depth;
            worldPos = Camera.main.ScreenToWorldPoint(screenPos);
            
            // Line[1] 포지션을 마우스 포지션으로 설정
            line.SetPosition(1, worldPos);
            
            // 앵그리 버드를 마우스 포지션에 배치
            bird.transform.position = worldPos;
            bird.SetActive(true);
        }

        if (Input.GetMouseButtonUp(0))
        {
            // 앵그리 버드를 날려준다.
            // middlePos - currentPos = dir;
            targetPos = middlePos.transform.position;
            currentPos = worldPos;
            Vector3 dir = targetPos - currentPos;
            
            rb = bird.GetComponent<Rigidbody>();
            rb.AddForce(dir * forceValue, ForceMode.Impulse );
            
            line.enabled = false;
        }
        
    }


    public GameObject InstantiateBird()
    {
        GameObject birds = Instantiate(birdPrefab, gameObject.transform.position, Quaternion.identity);
        birds.SetActive(false);

        return birds;
    }


}
