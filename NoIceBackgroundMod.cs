using System;
using ScrollsModLoader.Interfaces;
using Mono.Cecil;
namespace NoIceBackgroundMod
{
	public class NoIceBackgroundMod : BaseMod
	{
		public NoIceBackgroundMod ()
		{
		}

		public static MethodDefinition[] GetHooks(TypeDefinitionCollection scrollsTypes, int version) {
			MethodDefinition[] m = scrollsTypes ["BackgroundData"].Methods.GetMethod ("getBackgroundIdFor");
			if (m.Length == 1)
				return m;
			return new MethodDefinition[] {};
		}
		public static string GetName() {
			return "NoIceBackground";
		}
		public static int GetVersion() {
			return 2;
		}

		public override void BeforeInvoke (InvocationInfo info) {
		}

		public override void AfterInvoke (InvocationInfo info, ref object returnValue) {
			if (returnValue.GetType().Equals(typeof(int))) {
				//Accepted: Ice,  lava, snow
				if ((int)returnValue == 3  || (int)returnValue == 4 || (int)returnValue == 5) {
					//Nothing to do
				} else {
					if ((int)returnValue == 0) // DeepForest
						returnValue = 3; //IceSnow1
					else if ((int)returnValue == 1) // GrassyMountain
						returnValue = 4; //LavaGrotto
					else if ((int)returnValue == 2) //GreenMeadow
						returnValue = 4;//LavaGrotto
					else if ((int)returnValue == 6) //YellowMeadow
						returnValue = 5;//SnowyMountain
					else
						returnValue = 5; //SnowyMountain //This should not happen
				}

			}
			//HardCoded - but yea...
		}
	}
}

