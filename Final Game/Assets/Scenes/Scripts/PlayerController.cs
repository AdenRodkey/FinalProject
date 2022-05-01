using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    public static PlayerController player { get; private set; }
    public Slider hp;
    public Slider stamina;
    public float movespeed;
    public float rotateSpeed;
    public float sprintspeed;
    private bool IsSprinting;
    private Rigidbody rb;
    public float playerangle;
    public Transform playertrans;
    public GameObject navMesh;
    private GameObject[] enemyarray;
    public Collider coll;
    private EnemyController enemy;
    private void Awake()
    {
        if (player != null && player != this)
            {
                Destroy(this);
            }
            else
            {
                player = this;
            }
        DontDestroyOnLoad(player);
    }
    // Start is called before the first frame update
    void Start()
    {
        enemyarray = GameObject.FindGameObjectsWithTag("enemy");
        foreach(GameObject obj in enemyarray)
        {
            coll = GetComponent<CapsuleCollider>();
            
        }
        Cursor.lockState = CursorLockMode.Locked;
        rotateSpeed = 500f;
        rb = GetComponent<Rigidbody>();
        movespeed = 35f;
        IsSprinting = Input.GetKeyDown(KeyCode.LeftShift);
        hp.value = 100;
        stamina.value = 100;
        Physics.IgnoreCollision(navMesh.GetComponent<MeshCollider>(), GetComponent<CapsuleCollider>());
        

    }

    // Update is called once per frame
    void Update()
    {
        PlayerDamage();
        PlayerRotation();
        if(Input.GetKeyDown(KeyCode.W))
        {
           rb.velocity = transform.forward * movespeed;
        }
        
        else if(Input.GetKeyDown(KeyCode.S))
        {
            rb.velocity = transform.forward * movespeed * -1;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            
            if(!IsSprinting)
            {
                StartCoroutine(StaminaDeplete());
            }
            //Debug.Log("Shift pressed");
            IsSprinting = true;
            //Debug.Log(IsSprinting);
            movespeed = 50f;
            //Debug.Log(movespeed);
            
            

        }
        
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            
            if(IsSprinting)
            {
                StartCoroutine(StaminaReplenish());
            }
            movespeed = 35f;
            stamina.value++;
        }
        /*else if (!Input.GetKeyDown(KeyCode.LeftShift))
        {
            movespeed = 35f;
            if(stamina.value >= 0 && stamina.value < 100)
            {
                stamina.value++;
            }
        }*/
    }

    void PlayerRotation()
    {
        playerangle += Input.GetAxis("Mouse X") * rotateSpeed * Time.deltaTime;
        
        playertrans.localRotation = Quaternion.AngleAxis(playerangle, Vector3.up);
    }
    IEnumerator StaminaDeplete()
    {
        while(Input.GetKeyDown(KeyCode.LeftShift))
        {
            Debug.Log("in loop");
            if (stamina.value >= 0)
            {
                stamina.value--; 
                yield return new WaitForSeconds(0.5f);
            }
                
            
        }
        
    }

    IEnumerator StaminaReplenish()
    {
        while (Input.GetKeyUp(KeyCode.LeftShift))
        {
            Debug.Log("in loop2");
            if (stamina.value == 0)
            {
                stamina.value++;
                yield return new WaitForSeconds(0.5f);
            }


        }
       
    }
    void PlayerDamage()
    {
        if (Input.GetMouseButton(0))
        {
            Debug.Log("In Mouse Button if");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            

            if (coll.GetComponent<CapsuleCollider>().Raycast(ray, out hit, 100.0f))
            {
                Debug.Log("In Raycast.");
                enemy.enemyhealth -= 10;
                Debug.Log(enemy.enemyhealth);
            }
        }
    }
  
}
