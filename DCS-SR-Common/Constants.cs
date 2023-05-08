namespace Ciribob.DCS.SimpleRadio.Standalone.Common;

public class Constants
{
    public static readonly string MINIMUM_PROTOCOL_VERSION = "1.9.0.0";
    public static readonly string VERSION = "2.0.8.5";
    
    public static readonly int MIC_SAMPLE_RATE = 16000;
    public static readonly int MIC_INPUT_AUDIO_LENGTH_MS = 40;
    public static readonly int MIC_SEGMENT_FRAMES = MIC_SAMPLE_RATE / 1000 * MIC_INPUT_AUDIO_LENGTH_MS;
    public static readonly int OUTPUT_SAMPLE_RATE = 48000;
    public static readonly int OUTPUT_AUDIO_LENGTH_MS = 40;
    public static readonly int OUTPUT_SEGMENT_FRAMES = OUTPUT_SAMPLE_RATE / 1000 * OUTPUT_AUDIO_LENGTH_MS;
    public static readonly int JITTER_BUFFER = 50; //in milliseconds
    public static readonly int MAX_RADIOS = 11;
}