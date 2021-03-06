using Photon.Pun;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class RifleScript : MonoBehaviourPun
{

    //bullet and stats
    public GameObject bullet;
    public float shootForce;
    

    //rifle stats
    public float damagePerBullet;
    public float reloadTime;
    public float timeBetweenShooting;
    public float timeBetweenShots;

    //magazine info
    public int magazineSize;
    public int bulletsPerShot;
    int bulletsLeft;
    int bulletsShot;

    //bools
    bool shooting;
    bool reloading;
    bool readyToShoot;

    //Graphics
    public ParticleSystem muzzleFlash;
    public TextMeshProUGUI ammunitionDisplay;

    //References
    public Transform attackPoint;
    public Camera fpsCam;
    public PlayerInput playerInput;

    //animation source
    public Animator animator;

    //debug
    private bool allowInvoke = true;


    private void Awake()
    {
        //fill the magazine
        bulletsLeft = magazineSize;
        readyToShoot = true;
    }


    private void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();

        //ammo display
        if (ammunitionDisplay != null)
        {
            ammunitionDisplay.SetText(bulletsLeft / bulletsPerShot + "/" + magazineSize / bulletsPerShot);
        }
    }

    private void GetInput()
    {
        //check if shooting
        shooting = playerInput.actions["Shoot"].triggered;

        //shooting
        if (readyToShoot && shooting && !reloading && bulletsLeft > 0 && photonView.IsMine)
        {
            bulletsShot = 0;
            animator.SetBool("isShooting", true);
            Shoot();
        }
        //reloading
        if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < magazineSize && !reloading)
        {
            Reload();
        }
        //reloading when you're out of ammo
        if (readyToShoot && bulletsLeft <= 0 && !reloading)
        {
            Reload();
        }
    }

    private void Shoot()
    {
        readyToShoot = false;

        Ray ray = fpsCam.ViewportPointToRay(new Vector3( 0.5f, 0.5f, 0));
        RaycastHit hit;
        Vector3 targetPoint;

        if (Physics.Raycast(ray, out hit))
        {
            targetPoint = hit.point;
        }
        else
            targetPoint = ray.GetPoint(75);

        //direction
        Vector3 direction = targetPoint - attackPoint.position;

        //shoot the bullet
        photonView.RPC("instantiateBullet", RpcTarget.All, null);
        GameObject currentBullet = Instantiate(bullet, attackPoint.position, Quaternion.identity);
        currentBullet.SendMessage("setBulletDamage", damagePerBullet);
        currentBullet.GetComponent<Rigidbody>().AddForce(direction.normalized * shootForce,ForceMode.Impulse);
        Destroy(currentBullet, 6f);

        //flash
        if (muzzleFlash != null)
        {
            muzzleFlash.Play();
        }

            bulletsShot++;
        bulletsLeft--;

        if (allowInvoke)
        {
            Invoke("ResetShot", timeBetweenShooting);

            allowInvoke = false;
        }

        //more than one bullet per shot
        if (bulletsShot < bulletsPerShot && bulletsLeft > 0)
            Invoke("Shoot", timeBetweenShots);
    }

    private void ResetShot()
    {
        readyToShoot = true;
        allowInvoke = true;
    }

    private void Reload()
    {
        reloading = true;
        Invoke("ReloadFinished", reloadTime);
    }

    private void ReloadFinished()
    {
        bulletsLeft = magazineSize;
        reloading = false;
    }

    [PunRPC]
    void instantiateBullet()
    {
        Instantiate(bullet, attackPoint.transform);
    }
}
