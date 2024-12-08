using UnityEngine;

namespace I2.Loc
{
	public static class ScriptLocalization
	{

		public static class Achievement
		{
			public static string btn_go 		{ get{ return LocalizationManager.GetTranslation ("Achievement/btn_go"); } }
		}
	}

    public static class ScriptTerms
	{

		public static class Achievement
		{
		    public const string btn_go = "Achievement/btn_go";
		}
	}
}