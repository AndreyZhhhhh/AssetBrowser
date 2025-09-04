using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using SpatialSys.UnitySDK;

public enum ObbyPlatformActorEffect
{
    None,
    Kill,
    Force,
    Trampoline,
}

public enum ForceSpace
{
    Local,
    World,
}

[RequireComponent(typeof(Collider))]
[DefaultExecutionOrder(50)]
public class ObbyPlatform : MonoBehaviour
{
    private static int PLAYER_LAYER = 30;

    // Settings
    public SpatialMovementMaterial movementMaterial;

    //Affectors
    public ObbyPlatformActorEffect actorEffect = ObbyPlatformActorEffect.None;
    public ForceSpace forceSpace = ForceSpace.Local;
    public Vector3 force = Vector3.zero;
    public float trampolineHeight = 0;

    public UnityEvent OnPlayerEnter;
    public UnityEvent OnPlayerExit;
    public UnityEvent OnPlayerStay;

    private Collider _collider;

    private void Awake()
    {
        //Apply movement material to all colliders on this object
        if (movementMaterial != null)
        {
            List<Collider> colliders = new List<Collider>();
            gameObject.GetComponentsInChildren<Collider>(true, colliders);

            colliders.ForEach(collider =>
            {
                if (!TryGetComponent(out SpatialMovementMaterialSurface surface))
                {
                    surface = gameObject.AddComponent<SpatialMovementMaterialSurface>();
                }
                surface.movementMaterial = movementMaterial;
            });
        }

        OnPlayerEnter.AddListener(OnEnter);
        OnPlayerStay.AddListener(OnStay);
        OnPlayerExit.AddListener(OnExit);
    }

    private void OnEnter()
    {
        
    }

    private void OnStay()
    {
        switch (actorEffect)
        {
            case ObbyPlatformActorEffect.Force:
                ApplyForceToPlayer();
                break;
            case ObbyPlatformActorEffect.Trampoline:
                BouncePlayer();
                break;
        }
    }

    private void OnExit()
    {
    }

    private bool CollisionIsPlayer(Collision collision)
    {
        Debug.LogError(collision.gameObject.name);
        return collision.gameObject.layer == PLAYER_LAYER;
    }

    // * Effects
   
    private void ApplyForceToPlayer()
    {
        SpatialBridge.actorService.localActor.avatar.AddForce((forceSpace == ForceSpace.World ? force : transform.rotation * force) * Time.deltaTime);
    }
    private void BouncePlayer() {
        SpatialBridge.actorService.localActor.avatar.AddForce(Vector3.up * trampolineHeight);
        SpatialBridge.actorService.localActor.avatar.Jump();
    }

    public Bounds GetBounds()
    {
        //get the bounds by looking through all children of this object
        Bounds bounds = new Bounds(transform.position, Vector3.zero);
        foreach (Renderer renderer in GetComponentsInChildren<Renderer>())
        {
            bounds.Encapsulate(renderer.bounds);
        }
        return bounds;
    }
    public Bounds GetLocalBounds()
    {
        //get the bounds by looking through all children of this object
        Bounds bounds = new Bounds(Vector3.zero, Vector3.zero);
        foreach (Renderer renderer in GetComponentsInChildren<Renderer>())
        {
            bounds.Encapsulate(renderer.localBounds);
        }
        return new Bounds(bounds.center, new Vector3(bounds.size.x * transform.localScale.x, bounds.size.y * transform.localScale.y, bounds.size.z * transform.localScale.z));
    }

}
