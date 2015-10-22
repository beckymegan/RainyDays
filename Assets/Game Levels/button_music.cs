using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class button_music : MonoBehaviour {

	public Button musicButton;
	public Sprite unpressedMusicButtonSp, pressedMusicButtonSp;
	public Button effectButton;
	public Sprite unpressedEffectButtonSp, pressedEffectButtonSp;
	public GameObject musicPlayer, effectPlayer, musicSlider, effectSlider, objCloudL, objCloudR, objAnts;

	private AudioSource music, effect, asCloudL, asCloudR, asAnts;
	private Slider musicSlide, effectSlide;

	void Start () {

		music = GameObject.FindGameObjectWithTag ("MUSIC CONTROLLER").GetComponent<AudioSource> ();
		effect = effectPlayer.GetComponent<AudioSource> ();
		asCloudL = objCloudL.GetComponent<AudioSource> ();
		asCloudR = objCloudR.GetComponent<AudioSource> ();
		asAnts = objAnts.GetComponent<AudioSource> ();
		musicSlide = musicSlider.GetComponent<Slider> ();
		effectSlide = effectSlider.GetComponent<Slider> ();

		musicSlide.value = gVar.musicVolume;
		effectSlide.value = gVar.effectVolume;
		music.volume = gVar.musicVolume;
		effect.volume = gVar.effectVolume;

		if (gVar.musicPaused == true) {
			musicButton.image.sprite = unpressedMusicButtonSp;
		} else if (gVar.musicPaused == false) {
			musicButton.image.sprite = pressedMusicButtonSp;
		}

		if (gVar.effectsPaused == true) {
			//effect.volume = gVar.effectVolume;
			asCloudL.volume = gVar.effectVolume;
			asCloudR.volume = gVar.effectVolume;
			asAnts.volume = gVar.effectVolume;
			effectButton.image.sprite = unpressedEffectButtonSp;
		} else if (gVar.effectsPaused == false) {
			//effect.volume = gVar.effectVolume;
			effect.volume = 0;
			asCloudL.volume = 0;
			asCloudR.volume = 0;
			asAnts.volume = 0;
			effectButton.image.sprite = pressedEffectButtonSp;
		}

	}

	public void music_pause(bool vChange){
		if (gVar.musicPaused == false && vChange == false) {
			music.Play ();
			musicButton.image.sprite = unpressedMusicButtonSp;
			gVar.musicPaused = true;
		} else if (gVar.musicPaused == true && vChange == false) {
			music.Stop ();
			musicButton.image.sprite = pressedMusicButtonSp;
			gVar.musicPaused = false;
		} else if (vChange == true) {
			gVar.musicVolume = musicSlide.value;
			music.volume = gVar.musicVolume;
			vChange = false;
		}
	}

	public void effect_pause(bool vChange){
		if (gVar.effectsPaused == false && vChange == false) {
			effect.volume = gVar.effectVolume;
			asCloudL.volume = gVar.effectVolume;
			asCloudR.volume = gVar.effectVolume;
			asAnts.volume = gVar.effectVolume;
			effectButton.image.sprite = unpressedEffectButtonSp;
			gVar.effectsPaused = true;
		} else if (gVar.effectsPaused == true && vChange == false) {
			gVar.effectVolume = effect.volume;
			effect.volume = 0;
			asCloudL.volume = 0;
			asCloudR.volume = 0;
			asAnts.volume = 0;
			effectButton.image.sprite = pressedEffectButtonSp;
			gVar.effectsPaused = false;
		} else if (vChange == true) {
			gVar.effectVolume = effectSlide.value;
			effect.volume = gVar.effectVolume;
			vChange = false;
		}
	}
}
