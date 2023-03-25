using UnityEngine;

/// <summary>
/// A target for the player to fly through
/// </summary>
public class Target : MonoBehaviour {
    /// <summary>
    /// How many points the player gets for flying through this
    /// </summary>
    public int ScoreValue = 5;
    /// <summary>
    /// How fast it should tumble
    /// </summary>
    public float SpinSpeed = 25f;

    private static readonly Vector3 SpinVector = new Vector3(1f, 1f, 0f);

    private PlayerControl playerGameObj;

    /// <summary>
    /// Spin in place
    /// </summary>
    ///

    private void Start()
    {
        playerGameObj = FindObjectOfType<PlayerControl>(); 
    }
    internal void Update() {
        transform.Rotate(SpinVector * SpinSpeed * Time.deltaTime);
    }


    private void OnTriggerEnter(Collider other)
    {
 
        if (other.gameObject.name == "Player")
        {
            ScoreManager.IncreaseScore(playerGameObj.gameObject, ScoreValue);
            Destroy(this.gameObject); 
        }
    }



}
