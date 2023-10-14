using Atrob.Enums;

namespace Atrob.Utilities.Extensions;

internal static class FileSizeUnitExtensions
{
    public static long ToByte(this long size,FileSizeUnit unit) => unit switch
    {
        FileSizeUnit.Byte => size,
        FileSizeUnit.Kilobyte => size.KilobyteToByte(),
        FileSizeUnit.Megabyte => size.MegabyteToByte(),
        FileSizeUnit.Gigabyte => size.GigabyteToByte(),
        FileSizeUnit.Terabyte => size.TerabyteToByte(),
        _ => 0
    };

    public static long ToKilobyte(this long size,FileSizeUnit unit) => unit switch
    {
        FileSizeUnit.Byte => size.ByteToKilobyte(),
        FileSizeUnit.Kilobyte => size,
        FileSizeUnit.Megabyte => size.MegabyteToKilobyte(),
        FileSizeUnit.Gigabyte => size.GigabyteToKilobyte(),
        FileSizeUnit.Terabyte => size.TerabyteToKilobyte(),
        _ => 0
    };

    public static long ToMegabyte(this long size,FileSizeUnit unit) => unit switch
    {
        FileSizeUnit.Byte => size.ByteToMegabyte(),
        FileSizeUnit.Kilobyte => size.KilobyteToMegabyte(),
        FileSizeUnit.Megabyte => size,
        FileSizeUnit.Gigabyte => size.GigabyteToMegabyte(),
        FileSizeUnit.Terabyte => size.TerabyteToMegabyte(),
        _ => 0
    };

    public static long ToGigabyte(this long size,FileSizeUnit unit) => unit switch
    {
        FileSizeUnit.Byte => size.ByteToGigabyte(),
        FileSizeUnit.Kilobyte => size.KilobyteToGigabyte(),
        FileSizeUnit.Megabyte => size.MegabyteToGigabyte(),
        FileSizeUnit.Gigabyte => size,
        FileSizeUnit.Terabyte => size.TerabyteToGigabyte(),
        _ => 0
    };

    public static long ToTerabyte(this long size,FileSizeUnit unit) => unit switch
    {
        FileSizeUnit.Byte => size.ByteToTerabyte(),
        FileSizeUnit.Kilobyte => size.KilobyteToTerabyte(),
        FileSizeUnit.Megabyte => size.MegabyteToTerabyte(),
        FileSizeUnit.Gigabyte => size.GigabyteToTerabyte(),
        FileSizeUnit.Terabyte => size,
        _ => 0
    };

    public static long ByteTo(this long size,FileSizeUnit unit) => unit switch
    {
        FileSizeUnit.Byte => size,
        FileSizeUnit.Kilobyte => size.ByteToKilobyte(),
        FileSizeUnit.Megabyte => size.ByteToMegabyte(),
        FileSizeUnit.Gigabyte => size.ByteToGigabyte(),
        FileSizeUnit.Terabyte => size.ByteToTerabyte(),
        _ => 0
    };

    public static long KilobyteTo(this long size,FileSizeUnit unit) => unit switch
    {
        FileSizeUnit.Byte => size.KilobyteToByte(),
        FileSizeUnit.Kilobyte => size,
        FileSizeUnit.Megabyte => size.KilobyteToMegabyte(),
        FileSizeUnit.Gigabyte => size.KilobyteToGigabyte(),
        FileSizeUnit.Terabyte => size.KilobyteToTerabyte(),
        _ => 0
    };

    public static long MegabyteTo(this long size,FileSizeUnit unit) => unit switch
    {
        FileSizeUnit.Byte => size.MegabyteToByte(),
        FileSizeUnit.Kilobyte => size.MegabyteToKilobyte(),
        FileSizeUnit.Megabyte => size,
        FileSizeUnit.Gigabyte => size.MegabyteToGigabyte(),
        FileSizeUnit.Terabyte => size.MegabyteToTerabyte(),
        _ => 0
    };

    public static long GigabyteTo(this long size,FileSizeUnit unit) => unit switch
    {
        FileSizeUnit.Byte => size.GigabyteToByte(),
        FileSizeUnit.Kilobyte => size.GigabyteToKilobyte(),
        FileSizeUnit.Megabyte => size.GigabyteToMegabyte(),
        FileSizeUnit.Gigabyte => size,
        FileSizeUnit.Terabyte => size.GigabyteToTerabyte(),
        _ => 0
    };

    public static long TerabyteTo(this long size,FileSizeUnit unit) => unit switch
    {
        FileSizeUnit.Byte => size.TerabyteToByte(),
        FileSizeUnit.Kilobyte => size.TerabyteToKilobyte(),
        FileSizeUnit.Megabyte => size.TerabyteToMegabyte(),
        FileSizeUnit.Gigabyte => size.TerabyteToGigabyte(),
        FileSizeUnit.Terabyte => size,
        _ => 0
    };
}