using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Runtime.InteropServices;
using System;
using System.Collections.Generic;

public class AuctionHouse : MonoBehaviour {

	// Use this for initialization
	#if UNITY_IPHONE

	[DllImport ("__Internal")]
	private static extern void _loadNativeVC(string str, string str2, string gameID);
	[DllImport ("__Internal")]
	private static extern void _loadNativeVCToUpdate(string str, string gameID);

	#endif

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// Load for required Products
	public void BtnClicked(){
		Debug.Log ("Button clicked called");
		OpenAuctionHouseWithRequiredProducts ("Stick:2:Gold:3", "Stick:2:Gold:3", "2");
	}

	public void OpenAuctionHouseWithRequiredProducts(string requiredProducts, string updateProducts, string gameId){
		Debug.Log ("OpenAuctionHouseWithRequiredProducts called");
		#if UNITY_IPHONE
		_loadNativeVC(requiredProducts, updateProducts, gameId);
		#endif

		#if UNITY_ANDROID
		androidRequiredProducts(requiredProducts, updateProducts, gameId);
		#endif
	}

	// Load for update Products
	public void UpdateBtnClicked(){
		Debug.Log ("Update Button clicked called");
		OpenAuctionHouseToUpdateProducts ("Stick:0:Gold:0", "2");
	}

	public void OpenAuctionHouseToUpdateProducts(string updateProducts, String gameId){
		Debug.Log ("OpenAuctionHouseToUpdateProducts called");
		#if UNITY_IPHONE
		_loadNativeVCToUpdate(updateProducts, gameId);
		#endif

		#if UNITY_ANDROID
		androidUpdateProducts(updateProducts, gameId);
		#endif
	}


	//Callback with updated Products
	public void updatedProducts(string updatedProducts){
		Debug.Log ("updatedProducts called");
		#if UNITY_IPHONE
		Debug.Log("Updated products are: " + updatedProducts);
		#endif

		#if UNITY_ANDROID
		Debug.Log("Android Updated products are: " + updatedProducts);
		#endif
	}

	//Android Method to call unity class of plugin
	public void androidUpdateProducts(string updateProducts, string gameId){

		using (AndroidJavaClass cls_UnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer")) {

			using (AndroidJavaObject obj_Activity = cls_UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity")) {

				AndroidJavaClass cls_CompassActivity = new AndroidJavaClass("com.geniteam.bitszer.UnityPlugin");
				object[] args= new object[]{obj_Activity,this.gameObject.name,"updatedProducts",updateProducts, gameId};
				cls_CompassActivity.CallStatic("OpenAuctionHouseToUpdateProducts",args);
			}
		}

	}

	//Android Method to call unity class of plugin
	public void androidRequiredProducts(string requiredProducts, string updateProducts, string gameId){

		using (AndroidJavaClass cls_UnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer")) {

			using (AndroidJavaObject obj_Activity = cls_UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity")) {

				AndroidJavaClass cls_CompassActivity = new AndroidJavaClass("com.geniteam.bitszer.UnityPlugin");
				object[] args= new object[]{obj_Activity,this.gameObject.name,"updatedProducts",requiredProducts, updateProducts, gameId};
				cls_CompassActivity.CallStatic("OpenAuctionHouseWithRequiredProducts",args);

			}
		}
	}
}
