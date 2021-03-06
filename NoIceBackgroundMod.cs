﻿using System;
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
				if ((int)returnValue == 3) // IceSnow1
					returnValue =  1; //GrassyMountain
				if ((int)returnValue == 5) //SnowyMountain
					returnValue =  2;//GreenMeadow
				if ((int)returnValue == 6) //YellowMeadow
					returnValue = 4;//LavaGrotto
			}
			//HardCoded - but yea...
		}
	}
}

