namespace Atrob.Utilities.Extensions;

internal static class FileSizeConverterExtensions
{
    public static long ByteToKilobyte(this long size) => size.DivideBy1024();
    public static long ByteToMegabyte(this long size) => size.DivideBy1024(2);
    public static long ByteToGigabyte(this long size) => size.DivideBy1024(3);
    public static long ByteToTerabyte(this long size) => size.DivideBy1024(4);

    public static long KilobyteToByte(this long size) => size.MultiplyBy1024();
    public static long KilobyteToMegabyte(this long size) => size.DivideBy1024();
    public static long KilobyteToGigabyte(this long size) => size.DivideBy1024(2);
    public static long KilobyteToTerabyte(this long size) => size.DivideBy1024(3);

    public static long MegabyteToByte(this long size) => size.MultiplyBy1024(2);
    public static long MegabyteToKilobyte(this long size) => size.MultiplyBy1024(1);
    public static long MegabyteToGigabyte(this long size) => size.DivideBy1024();
    public static long MegabyteToTerabyte(this long size) => size.DivideBy1024(2);

    public static long GigabyteToByte(this long size) => size.MultiplyBy1024(3);
    public static long GigabyteToKilobyte(this long size) => size.MultiplyBy1024(2);
    public static long GigabyteToMegabyte(this long size) => size.MultiplyBy1024();
    public static long GigabyteToTerabyte(this long size) => size.DivideBy1024();

    public static long TerabyteToByte(this long size) => size.MultiplyBy1024(4);
    public static long TerabyteToKilobyte(this long size) => size.MultiplyBy1024(3);
    public static long TerabyteToMegabyte(this long size) => size.MultiplyBy1024(2);
    public static long TerabyteToGigabyte(this long size) => size.MultiplyBy1024();


    private static long MultiplyBy1024(this long number, byte Times = 1) => number * (long)Math.Pow(1024, Times);
    private static long DivideBy1024(this long number, byte Times = 1) => number / (long)Math.Pow(1024, Times);
}