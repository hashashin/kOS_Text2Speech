using SpeechLib;

using kOS.Safe.Encapsulation;

namespace kOS.AddOns.kOSText2Speech
{
	[kOSAddon("TTS")]
	[kOS.Safe.Utilities.KOSNomenclature("Text2SpeechAddon")]
	public class Addon : Suffixed.Addon
	{
		public Addon(SharedObjects shared) : base(shared)
		{
			InitializeSuffixes();
		}

		void InitializeSuffixes()
		{
			AddSuffix("SAY", new kOS.Safe.Encapsulation.Suffixes.OneArgsSuffix<StringValue, StringValue>(Text2Speech, "Make kOS say something"));
		}


		public override BooleanValue Available()
		{
			return true;
		}

		StringValue Text2Speech(StringValue text)
		{
			utils.Speech(text);
			return "";
		}

		static SpVoice _objSpeech = new SpVoice();

		static class utils
		{
			public static void Speech(string args)
			{
				_objSpeech.Volume = 100;
				_objSpeech.SynchronousSpeakTimeout = 30;
				_objSpeech.Rate = -1;
				_objSpeech.Speak(args, SpeechVoiceSpeakFlags.SVSFlagsAsync);
			}
		}
	}
}


