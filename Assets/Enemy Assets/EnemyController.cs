using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [HideInInspector] public GameObject player;
    EnemyStateManager sm;
    [HideInInspector] public Rigidbody rb;

    [HideInInspector] public Animator anim;
    AnimatorClipInfo[] animInfo;
    [HideInInspector] public string currAnim;

    [SerializeField] public float detectRange;
    [SerializeField] public float attackRange;
    [SerializeField] public float moveSpeed;
    [SerializeField] public float attackCD;
    [HideInInspector] public float attackTimer;
    Vector3 chargeDirection;

    // Start is called before the first frame update
    void Start()
    {
        sm = GetComponent<EnemyStateManager>();
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();

        player = GameObject.FindGameObjectWithTag("Player");

        attackTimer = attackCD;
    }

    // Update is called once per frame
    void Update()
    {
        animInfo = anim.GetCurrentAnimatorClipInfo(0);
        currAnim = animInfo[0].clip.name;

        if (attackTimer > 0) {
            attackTimer -= Time.deltaTime;
        }

        Debug.Log(GetFacingVector());
    }

    public void FaceTarget(Vector3 target){

        Vector2 direction = HelperFunctions.FlatDirection(this.transform.position, target);
        float facingDirection = Vector2.SignedAngle(direction, Vector2.right);

        var rotationVector = transform.rotation.eulerAngles;
        rotationVector.y = facingDirection;
        Quaternion finalTarget = Quaternion.Euler(rotationVector);

        transform.rotation = finalTarget;
    }

    public void MoveToTarget(Vector3 target, float speed){

        Vector2 direction = HelperFunctions.FlatDirection(this.transform.position, target);
        rb.velocity -= new Vector3(direction.x, 0, direction.y) 
                    * speed
                    * Time.deltaTime;
    }

    public Vector2 GetFacingVector(){

        float radians = ((transform.localEulerAngles.y + 45) * Mathf.Deg2Rad);
        return new Vector2(Mathf.Sin(radians), Mathf.Cos(radians));
    }

    public void SetChargeDirection(){
        chargeDirection = HelperFunctions.FlatDirection(this.transform.position, 
                                                        player.transform.position);
    }

    public void Charge(){

        // Charge at target direction
        rb.velocity = new Vector3(chargeDirection.x, 0, chargeDirection.y)
                    * -7500f
                    * Time.deltaTime;
        Invoke("Stop", 0.07f);
    }

    public void Stop(){
        rb.velocity = Vector3.zero;
    }
}
