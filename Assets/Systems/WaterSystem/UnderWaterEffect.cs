using System;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

/**
 * Cambia el color de la luz del sol cuando se esta bajo el agua, para dar un efecto underwater,
 * tambien aplica efectos de sonido como ingreso al agua y el efecto the estar sumergido.
 */
public class UnderWaterEffect : MonoBehaviour {

	// Public
	public GameObject planoAgua;
	public AudioClip splashSound;
	public Color colorAgua = new Color (0.0f, 0.0f, 1.0f);// Default Blue.
	public float intensidadDelSol = 10.0f;
	public float fuerzaAgua = 10.0f;
	public Light luzDeSol;
	public GameObject refPlayer;
	public float disminuirCapacidadesBajoElAgua = 0.5f;
	public Color colorFog;
	public float fogDensity = 0.01f;
	public float fogDensityBajoAgua = 0.3f;

	// Private
	private bool playSplash = false;
	private Color colorOriginalSol;
	private float alturaAgua = 0.0f;
	private AudioSource aguaCiclo;
	private float intensidadOriginal = 0.0f;

	// Valores del FPS Controller a ser disminuidos bajo el agua.
	private float JumpForce = 0.0f;
	private float JumpForceD = 0.0f;

	private float BackwardSpeed = 0.0f;
	private float BackwardSpeedD = 0.0f;

	private float ForwardSpeed = 0.0f;
	private float ForwardSpeedD = 0.0f;

	private float RunMultiplier = 0.0f;
	private float RunMultiplierD = 0.0f;

	private float StrafeSpeed = 0.0f;
	private float StrafeSpeedD = 0.0f;

	private Material skyBoxOriginal;

	void Start()
	{
		alturaAgua = planoAgua.transform.position.y;

		// Recuerde el color original que tenia el sol antes de continuar.
		this.colorOriginalSol = this.luzDeSol.color;
		this.intensidadOriginal = this.luzDeSol.intensity;

		this.skyBoxOriginal = RenderSettings.skybox;

		this.JumpForce = refPlayer.GetComponent<RigidbodyFirstPersonController> ().movementSettings.JumpForce;
		this.JumpForceD = this.JumpForce * this.disminuirCapacidadesBajoElAgua;

		this.BackwardSpeed = refPlayer.GetComponent<RigidbodyFirstPersonController> ().movementSettings.BackwardSpeed;
		this.BackwardSpeedD = this.BackwardSpeed * this.disminuirCapacidadesBajoElAgua;

		this.ForwardSpeed = refPlayer.GetComponent<RigidbodyFirstPersonController> ().movementSettings.ForwardSpeed;
		this.ForwardSpeedD = this.ForwardSpeed * this.disminuirCapacidadesBajoElAgua;

		this.RunMultiplier = refPlayer.GetComponent<RigidbodyFirstPersonController> ().movementSettings.RunMultiplier;
		this.RunMultiplierD = this.RunMultiplier * this.disminuirCapacidadesBajoElAgua;

		this.StrafeSpeed = refPlayer.GetComponent<RigidbodyFirstPersonController> ().movementSettings.StrafeSpeed;
		this.StrafeSpeedD = this.StrafeSpeed * this.disminuirCapacidadesBajoElAgua;

		aguaCiclo = GetComponent<AudioSource>();
		aguaCiclo.loop = true;
	}

	/**
	 * Aplica los valores disminuidos en el porcentaje de disminucion dado.
	 */
	void reducirSalto() {
		refPlayer.GetComponent<RigidbodyFirstPersonController> ().underwater = true;
		refPlayer.GetComponent<RigidbodyFirstPersonController> ().movementSettings.JumpForce = this.JumpForceD;
		refPlayer.GetComponent<RigidbodyFirstPersonController> ().movementSettings.BackwardSpeed = this.BackwardSpeedD;
		refPlayer.GetComponent<RigidbodyFirstPersonController> ().movementSettings.ForwardSpeed = this.ForwardSpeedD;
		refPlayer.GetComponent<RigidbodyFirstPersonController> ().movementSettings.RunMultiplier = this.RunMultiplierD;
		refPlayer.GetComponent<RigidbodyFirstPersonController> ().movementSettings.StrafeSpeed = this.StrafeSpeedD;
	}

	/**
	 * Restaura los valores originales configurados para el FPS Controller. 
	 */
	void dejarSaltoOriginal() {
		refPlayer.GetComponent<RigidbodyFirstPersonController> ().underwater = false;
		refPlayer.GetComponent<RigidbodyFirstPersonController> ().movementSettings.JumpForce = this.JumpForce;
		refPlayer.GetComponent<RigidbodyFirstPersonController> ().movementSettings.BackwardSpeed = this.BackwardSpeed;
		refPlayer.GetComponent<RigidbodyFirstPersonController> ().movementSettings.ForwardSpeed = this.ForwardSpeed;
		refPlayer.GetComponent<RigidbodyFirstPersonController> ().movementSettings.RunMultiplier = this.RunMultiplier;
		refPlayer.GetComponent<RigidbodyFirstPersonController> ().movementSettings.StrafeSpeed = this.StrafeSpeed;
	}

	// Metodo update
	void Update()
	{
		if (Camera.main.transform.position.y < this.alturaAgua ) {
			this.luzDeSol.color = this.colorAgua;
			this.luzDeSol.intensity = intensidadDelSol;
			Physics.gravity = new Vector3(0, -5.8f, 0);
		
			RenderSettings.fogColor = colorFog;
			RenderSettings.fogDensity = fogDensityBajoAgua;
			RenderSettings.skybox = null;

			reducirSalto ();

		} else {
			this.luzDeSol.color = this.colorOriginalSol;
			this.luzDeSol.intensity = this.intensidadOriginal;
			Physics.gravity = new Vector3(0, -9.8f, 0);

			RenderSettings.fogColor = Color.black;
			RenderSettings.fogDensity = fogDensity;
			RenderSettings.skybox = this.skyBoxOriginal;

			dejarSaltoOriginal ();
		}

		if (Camera.main.transform.position.y < this.alturaAgua) {
			//this.playerControllerRef.gravity = 4.0f;

			if (this.playSplash == true) {
				AudioSource.PlayClipAtPoint (splashSound,Camera.main.transform.position);

				aguaCiclo.Play ();
				//Debug.Log (Physics.gravity);

				this.playSplash = false;
			}

			Rigidbody rigidBody = refPlayer.GetComponent<Rigidbody>();
			rigidBody.AddForce(transform.up * fuerzaAgua);
			//rigidBody.useGravity = false;
			//https://answers.unity.com/questions/11754/how-to-make-water-swimmable.html

		} else {
			//this.playerControllerRef.gravity = 20.0f;// TODO: Se puede obtener la referencia original.
			this.playSplash = true;
			aguaCiclo.Stop ();
		}

	}

}
