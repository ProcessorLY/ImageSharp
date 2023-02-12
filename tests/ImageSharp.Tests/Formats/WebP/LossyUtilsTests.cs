// Copyright (c) Six Labors.
// Licensed under the Six Labors Split License.

using SixLabors.ImageSharp.Formats.Webp.Lossy;
using SixLabors.ImageSharp.Tests.TestUtilities;

namespace SixLabors.ImageSharp.Tests.Formats.Webp;

[Trait("Format", "Webp")]
public class LossyUtilsTests
{
    private static void RunTransformTwoTest()
    {
        // arrange
        short[] src = { 19, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 19, 23, 0, 0, -23, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        byte[] dst =
        {
            103, 103, 103, 103, 103, 103, 103, 103, 0, 0, 0, 0, 169, 169, 169, 169, 171, 171, 171, 171,
            171, 171, 171, 171, 0, 0, 0, 0, 103, 103, 103, 103, 103, 103, 103, 103, 103, 103, 103, 103,
            0, 0, 0, 0, 169, 169, 169, 169, 171, 171, 171, 171, 171, 171, 171, 171, 0, 0, 0, 0,
            103, 103, 103, 103, 103, 103, 103, 103, 103, 103, 103, 103, 0, 0, 0, 0, 169, 169, 169, 169,
            171, 171, 171, 171, 171, 171, 171, 171, 0, 0, 0, 0, 103, 103, 103, 103, 103, 103, 103, 103,
            103, 103, 103, 103, 0, 0, 0, 0, 169, 169, 169, 169, 171, 171, 171, 171, 171, 171, 171, 171,
            0, 0, 0, 0, 0, 0, 0, 0
        };
        byte[] expected =
        {
            105, 105, 105, 105, 105, 103, 100, 98, 0, 0, 0, 0, 169, 169, 169, 169, 171, 171, 171, 171, 171, 171,
            171, 171, 0, 0, 0, 0, 103, 103, 103, 103, 105, 105, 105, 105, 108, 105, 102, 100, 0, 0, 0, 0, 169,
            169, 169, 169, 171, 171, 171, 171, 171, 171, 171, 171, 0, 0, 0, 0, 103, 103, 103, 103, 105, 105,
            105, 105, 111, 109, 106, 103, 0, 0, 0, 0, 169, 169, 169, 169, 171, 171, 171, 171, 171, 171, 171,
            171, 0, 0, 0, 0, 103, 103, 103, 103, 105, 105, 105, 105, 113, 111, 108, 106, 0, 0, 0, 0, 169, 169,
            169, 169, 171, 171, 171, 171, 171, 171, 171, 171, 0, 0, 0, 0, 0, 0, 0, 0
        };
        int[] scratch = new int[16];

        // act
        LossyUtils.TransformTwo(src, dst, scratch);

        // assert
        Assert.True(expected.SequenceEqual(dst));
    }

    private static void RunTransformOneTest()
    {
        // arrange
        short[] src = { -176, 0, 0, 0, 29, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        byte[] dst =
        {
            128, 128, 128, 128, 128, 128, 128, 128, 0, 0, 0, 0, 0, 0, 0, 129, 128, 128, 128, 128,
            128, 128, 128, 128, 0, 0, 0, 0, 0, 0, 0, 129, 128, 128, 128, 128, 128, 128, 128, 128,
            0, 0, 0, 0, 0, 0, 0, 129, 128, 128, 128, 128, 128, 128, 128, 128, 0, 0, 0, 0,
            0, 0, 0, 129, 128, 128, 128, 128, 128, 128, 128, 128, 0, 0, 0, 0, 0, 0, 0, 129,
            128, 128, 128, 128, 128, 128, 128, 128, 0, 0, 0, 0, 0, 0, 0, 129, 128, 128, 128, 128,
            128, 128, 128, 128, 0, 0, 0, 0, 0, 0, 0, 129, 128, 128, 128, 128, 128, 128, 128, 128,
            0, 0, 0, 0, 0, 0, 0, 129
        };
        byte[] expected =
        {
            111, 111, 111, 111, 128, 128, 128, 128, 0, 0, 0, 0, 0, 0, 0, 129, 128, 128, 128, 128,
            128, 128, 128, 128, 0, 0, 0, 0, 0, 0, 0, 129, 108, 108, 108, 108, 128, 128, 128, 128,
            0, 0, 0, 0, 0, 0, 0, 129, 128, 128, 128, 128, 128, 128, 128, 128, 0, 0, 0, 0,
            0, 0, 0, 129, 104, 104, 104, 104, 128, 128, 128, 128, 0, 0, 0, 0, 0, 0, 0, 129,
            128, 128, 128, 128, 128, 128, 128, 128, 0, 0, 0, 0, 0, 0, 0, 129, 101, 101, 101, 101,
            128, 128, 128, 128, 0, 0, 0, 0, 0, 0, 0, 129, 128, 128, 128, 128, 128, 128, 128, 128,
            0, 0, 0, 0, 0, 0, 0, 129
        };
        int[] scratch = new int[16];

        // act
        LossyUtils.TransformOne(src, dst, scratch);

        // assert
        Assert.True(expected.SequenceEqual(dst));
    }

    private static void RunVp8Sse16X16Test()
    {
        // arrange
        byte[] a =
        {
            154, 154, 151, 151, 149, 148, 151, 157, 163, 163, 154, 132, 102, 98, 104, 108, 107, 104, 104, 103,
            101, 106, 123, 119, 170, 171, 172, 171, 168, 175, 171, 173, 151, 151, 149, 150, 147, 147, 146, 159,
            164, 165, 154, 129, 92, 90, 101, 105, 104, 103, 104, 101, 100, 105, 123, 117, 172, 172, 172, 168,
            170, 177, 170, 175, 151, 149, 150, 150, 147, 147, 156, 161, 161, 161, 151, 126, 93, 90, 102, 107,
            104, 103, 104, 101, 104, 104, 122, 117, 172, 172, 170, 168, 170, 177, 172, 175, 150, 149, 152, 151,
            148, 151, 160, 159, 157, 157, 148, 133, 96, 90, 103, 107, 104, 104, 101, 100, 102, 102, 121, 117,
            170, 170, 169, 171, 171, 179, 173, 175, 149, 151, 152, 151, 148, 154, 162, 157, 154, 154, 151, 132,
            92, 89, 101, 108, 104, 102, 101, 101, 103, 103, 123, 118, 171, 168, 177, 173, 171, 178, 172, 176,
            152, 152, 152, 151, 154, 162, 161, 155, 149, 157, 156, 129, 92, 87, 101, 107, 102, 100, 107, 100,
            101, 102, 123, 118, 170, 175, 182, 172, 171, 179, 173, 175, 152, 151, 154, 155, 160, 162, 161, 153,
            150, 156, 153, 129, 92, 91, 102, 106, 100, 109, 115, 99, 101, 102, 124, 120, 171, 179, 178, 172,
            171, 181, 171, 173, 154, 154, 154, 162, 160, 158, 156, 152, 153, 157, 151, 128, 86, 86, 102, 105,
            102, 122, 114, 99, 101, 102, 125, 120, 178, 173, 177, 172, 171, 180, 172, 173, 154, 152, 158, 163,
            150, 148, 148, 156, 151, 158, 152, 129, 87, 87, 101, 105, 204, 204, 204, 204, 204, 204, 204, 204,
            204, 204, 204, 204, 204, 204, 204, 204, 154, 151, 165, 156, 141, 137, 146, 158, 152, 159, 152, 133,
            90, 88, 99, 106, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204,
            154, 160, 164, 150, 126, 127, 149, 159, 155, 161, 153, 131, 84, 86, 97, 103, 204, 204, 204, 204,
            204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 157, 167, 157, 137, 102, 128, 155, 161,
            157, 159, 154, 134, 84, 82, 97, 102, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204,
            204, 204, 204, 204, 163, 163, 150, 113, 78, 132, 156, 162, 159, 160, 154, 132, 83, 78, 91, 97, 204,
            204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 163, 157, 137, 80, 78,
            131, 154, 163, 157, 159, 149, 131, 82, 77, 94, 100, 204, 204, 204, 204, 204, 204, 204, 204, 204,
            204, 204, 204, 204, 204, 204, 204, 159, 151, 108, 72, 88, 132, 156, 162, 159, 157, 151, 130, 79, 78,
            95, 102, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 151, 130,
            82, 82, 89, 134, 154, 161, 161, 157, 152, 129, 81, 77, 95, 102, 204, 204, 204, 204, 204, 204, 204,
            204, 204, 204, 204, 204, 204, 204, 204, 204
        };

        byte[] b =
        {
            150, 150, 150, 150, 146, 149, 152, 154, 164, 166, 154, 132, 99, 92, 106, 112, 204, 204, 204, 204,
            204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 150, 150, 150, 150, 146, 149, 152, 154,
            161, 164, 151, 130, 93, 86, 100, 106, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204,
            204, 204, 204, 204, 150, 150, 150, 150, 146, 149, 152, 154, 158, 161, 148, 127, 93, 86, 100, 106,
            204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 150, 150, 150, 150,
            146, 149, 152, 154, 156, 159, 146, 125, 99, 92, 106, 112, 204, 204, 204, 204, 204, 204, 204, 204,
            204, 204, 204, 204, 204, 204, 204, 204, 148, 148, 148, 148, 149, 158, 162, 159, 155, 155, 153, 129,
            94, 87, 101, 106, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204,
            151, 151, 151, 151, 152, 159, 161, 156, 155, 155, 153, 129, 94, 87, 101, 106, 204, 204, 204, 204,
            204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 154, 154, 154, 154, 156, 161, 159, 152,
            155, 155, 153, 129, 94, 87, 101, 106, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204,
            204, 204, 204, 204, 156, 156, 156, 156, 159, 162, 158, 149, 155, 155, 153, 129, 94, 87, 101, 106,
            204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 152, 153, 157, 162,
            150, 149, 149, 151, 155, 160, 150, 131, 91, 90, 104, 104, 204, 204, 204, 204, 204, 204, 204, 204,
            204, 204, 204, 204, 204, 204, 204, 204, 152, 156, 158, 157, 140, 137, 145, 159, 155, 160, 150, 131,
            89, 88, 102, 101, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204,
            153, 161, 160, 149, 118, 128, 147, 162, 155, 160, 150, 131, 86, 85, 99, 98, 204, 204, 204, 204, 204,
            204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 154, 165, 161, 144, 96, 128, 154, 159, 155,
            160, 150, 131, 83, 82, 97, 96, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204,
            204, 204, 161, 160, 149, 105, 78, 127, 156, 170, 156, 156, 154, 130, 81, 77, 95, 102, 204, 204, 204,
            204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 160, 160, 133, 85, 81, 129, 155,
            167, 156, 156, 154, 130, 81, 77, 95, 102, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204,
            204, 204, 204, 204, 204, 156, 147, 109, 76, 85, 130, 153, 163, 156, 156, 154, 130, 81, 77, 95, 102,
            204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 152, 128, 87, 83,
            88, 132, 152, 159, 156, 156, 154, 130, 81, 77, 95, 102, 204, 204, 204, 204, 204, 204, 204, 204, 204,
            204, 204, 204, 204, 204, 204, 204
        };

        int expected = 2063;

        // act
        int actual = LossyUtils.Vp8_Sse16x16(a, b);

        // assert
        Assert.Equal(expected, actual);
    }

    private static void RunVp8Sse16X8Test()
    {
        // arrange
        byte[] a =
        {
            107, 104, 104, 103, 101, 106, 123, 119, 170, 171, 172, 171, 168, 175, 171, 173, 151, 151, 149, 150,
            147, 147, 146, 159, 164, 165, 154, 129, 92, 90, 101, 105, 104, 103, 104, 101, 100, 105, 123, 117,
            172, 172, 172, 168, 170, 177, 170, 175, 151, 149, 150, 150, 147, 147, 156, 161, 161, 161, 151, 126,
            93, 90, 102, 107, 104, 103, 104, 101, 104, 104, 122, 117, 172, 172, 170, 168, 170, 177, 172, 175,
            150, 149, 152, 151, 148, 151, 160, 159, 157, 157, 148, 133, 96, 90, 103, 107, 104, 104, 101, 100,
            102, 102, 121, 117, 170, 170, 169, 171, 171, 179, 173, 175, 149, 151, 152, 151, 148, 154, 162, 157,
            154, 154, 151, 132, 92, 89, 101, 108, 104, 102, 101, 101, 103, 103, 123, 118, 171, 168, 177, 173,
            171, 178, 172, 176, 152, 152, 152, 151, 154, 162, 161, 155, 149, 157, 156, 129, 92, 87, 101, 107,
            102, 100, 107, 100, 101, 102, 123, 118, 170, 175, 182, 172, 171, 179, 173, 175, 152, 151, 154, 155,
            160, 162, 161, 153, 150, 156, 153, 129, 92, 91, 102, 106, 100, 109, 115, 99, 101, 102, 124, 120,
            171, 179, 178, 172, 171, 181, 171, 173, 154, 154, 154, 162, 160, 158, 156, 152, 153, 157, 151, 128,
            86, 86, 102, 105, 102, 122, 114, 99, 101, 102, 125, 120, 178, 173, 177, 172, 171, 180, 172, 173,
            154, 152, 158, 163, 150, 148, 148, 156, 151, 158, 152, 129, 87, 87, 101, 105
        };

        byte[] b =
        {
            103, 103, 103, 103, 101, 106, 122, 114, 171, 171, 171, 171, 171, 177, 169, 175, 150, 150, 150, 150,
            146, 149, 152, 154, 161, 164, 151, 130, 93, 86, 100, 106, 103, 103, 103, 103, 101, 106, 122, 114,
            171, 171, 171, 171, 171, 177, 169, 175, 150, 150, 150, 150, 146, 149, 152, 154, 158, 161, 148, 127,
            93, 86, 100, 106, 103, 103, 103, 103, 101, 106, 122, 114, 171, 171, 171, 171, 171, 177, 169, 175,
            150, 150, 150, 150, 146, 149, 152, 154, 156, 159, 146, 125, 99, 92, 106, 112, 103, 103, 103, 103,
            101, 106, 122, 114, 171, 171, 171, 171, 171, 177, 169, 175, 148, 148, 148, 148, 149, 158, 162, 159,
            155, 155, 153, 129, 94, 87, 101, 106, 102, 100, 100, 102, 100, 101, 120, 122, 170, 176, 176, 170,
            174, 180, 171, 177, 151, 151, 151, 151, 152, 159, 161, 156, 155, 155, 153, 129, 94, 87, 101, 106,
            102, 105, 105, 102, 100, 101, 120, 122, 170, 176, 176, 170, 174, 180, 171, 177, 154, 154, 154, 154,
            156, 161, 159, 152, 155, 155, 153, 129, 94, 87, 101, 106, 102, 112, 112, 102, 100, 101, 120, 122,
            170, 176, 176, 170, 174, 180, 171, 177, 156, 156, 156, 156, 159, 162, 158, 149, 155, 155, 153, 129,
            94, 87, 101, 106, 102, 117, 117, 102, 100, 101, 120, 122, 170, 176, 176, 170, 174, 180, 171, 177,
            152, 153, 157, 162, 150, 149, 149, 151, 155, 160, 150, 131, 91, 90, 104, 104
        };

        int expected = 749;

        // act
        int actual = LossyUtils.Vp8_Sse16x8(a, b);

        // assert
        Assert.Equal(expected, actual);
    }

    private static void RunVp8Sse4X4Test()
    {
        // arrange
        byte[] a =
        {
            27, 27, 28, 29, 29, 28, 27, 27, 27, 28, 28, 29, 29, 28, 28, 27, 129, 129, 129, 129, 129, 129, 129,
            129, 128, 128, 128, 128, 128, 128, 128, 128, 27, 27, 27, 27, 27, 27, 27, 27, 27, 28, 28, 29, 29, 28,
            28, 27, 129, 129, 129, 129, 129, 129, 129, 129, 128, 128, 128, 128, 128, 128, 128, 128, 27, 27, 26,
            26, 26, 26, 27, 27, 27, 28, 28, 29, 29, 28, 28, 27, 129, 129, 129, 129, 129, 129, 129, 129, 128,
            128, 128, 128, 128, 128, 128, 128, 28, 27, 27, 26, 26, 27, 27, 28, 27, 28, 28, 29, 29, 28, 28, 27,
            129, 129, 129, 129, 129, 129, 129, 129, 128, 128, 128, 128, 128, 128, 128, 128
        };

        byte[] b =
        {
            26, 26, 26, 26, 28, 28, 28, 28, 28, 28, 28, 28, 28, 28, 28, 28, 204, 204, 204, 204, 204, 204, 204,
            204, 204, 204, 204, 204, 204, 204, 204, 204, 26, 26, 26, 26, 28, 28, 28, 28, 28, 28, 28, 28, 28, 28,
            28, 28, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 26, 26, 26,
            26, 28, 28, 28, 28, 28, 28, 28, 28, 28, 28, 28, 28, 204, 204, 204, 204, 204, 204, 204, 204, 204,
            204, 204, 204, 204, 204, 204, 204, 26, 26, 26, 26, 28, 28, 28, 28, 28, 28, 28, 28, 28, 28, 28, 28,
            204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204
        };

        int expected = 27;

        // act
        int actual = LossyUtils.Vp8_Sse4x4(a, b);

        // assert
        Assert.Equal(expected, actual);
    }

    private static void RunMean16x4Test()
    {
        // arrange
        byte[] input =
        {
            154, 145, 102, 115, 127, 129, 126, 125, 126, 120, 133, 152, 157, 153, 119, 94, 104, 116, 111, 113,
            113, 109, 105, 124, 173, 175, 177, 170, 175, 172, 166, 164, 151, 141, 99, 114, 125, 126, 135, 150,
            133, 115, 127, 149, 141, 168, 100, 54, 110, 117, 115, 116, 119, 115, 117, 130, 174, 174, 174, 157,
            146, 171, 166, 158, 117, 140, 96, 111, 119, 119, 136, 171, 188, 134, 121, 126, 136, 119, 59, 77,
            109, 115, 113, 120, 120, 117, 128, 115, 174, 173, 173, 161, 152, 148, 153, 162, 105, 140, 96, 114,
            115, 122, 141, 173, 190, 190, 142, 106, 151, 78, 66, 141, 110, 117, 123, 136, 118, 124, 127, 114,
            173, 175, 166, 155, 155, 159, 159, 158
        };
        uint[] dc = new uint[4];
        uint[] expectedDc = { 1940, 2139, 2252, 1813 };

        // act
        LossyUtils.Mean16x4(input, dc);

        // assert
        Assert.True(dc.SequenceEqual(expectedDc));
    }

    private static void RunHadamardTransformTest()
    {
        // arrange
        byte[] a =
        {
            27, 27, 28, 29, 29, 28, 27, 27, 27, 28, 28, 29, 29, 28, 28, 27, 129, 129, 129, 129, 129, 129, 129,
            129, 128, 128, 128, 128, 128, 128, 128, 128, 27, 27, 27, 27, 27, 27, 27, 27, 27, 28, 28, 29, 29, 28,
            28, 27, 129, 129, 129, 129, 129, 129, 129, 129, 128, 128, 128, 128, 128, 128, 128, 128, 27, 27, 26,
            26, 26, 26, 27, 27, 27, 28, 28, 29, 29, 28, 28, 27, 129, 129, 129, 129, 129, 129, 129, 129, 128,
            128, 128, 128, 128, 128, 128, 128, 28, 27, 27, 26, 26, 27, 27, 28, 27, 28, 28, 29, 29, 28, 28, 27
        };

        byte[] b =
        {
            28, 28, 28, 28, 28, 28, 28, 28, 28, 28, 28, 28, 28, 28, 28, 28, 204, 204, 204, 204, 204, 204, 204,
            204, 204, 204, 204, 204, 204, 204, 204, 204, 28, 28, 28, 28, 28, 28, 28, 28, 28, 28, 28, 28, 28, 28,
            28, 28, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 28, 28, 28,
            28, 28, 28, 28, 28, 28, 28, 28, 28, 28, 28, 28, 28, 204, 204, 204, 204, 204, 204, 204, 204, 204,
            204, 204, 204, 204, 204, 204, 204, 28, 28, 28, 28, 28, 28, 28, 28, 28, 28, 28, 28, 28, 28, 28, 28
        };

        ushort[] w = { 38, 32, 20, 9, 32, 28, 17, 7, 20, 17, 10, 4, 9, 7, 4, 2 };
        int expected = 2;

        // act
        int actual = LossyUtils.Vp8Disto4X4(a, b, w, new int[16]);

        // assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void RunTransformTwo_Works() => RunTransformTwoTest();

    [Fact]
    public void RunTransformOne_Works() => RunTransformOneTest();

    [Fact]
    public void Vp8Sse16X16_Works() => RunVp8Sse16X16Test();

    [Fact]
    public void Vp8Sse16X8_Works() => RunVp8Sse16X8Test();

    [Fact]
    public void Vp8Sse4X4_Works() => RunVp8Sse4X4Test();

    [Fact]
    public void Mean16x4_Works() => RunMean16x4Test();

    [Fact]
    public void HadamardTransform_Works() => RunHadamardTransformTest();

    [Fact]
    public void TransformTwo_WithHardwareIntrinsics_Works() => FeatureTestRunner.RunWithHwIntrinsicsFeature(RunTransformTwoTest, HwIntrinsics.AllowAll);

    [Fact]
    public void TransformTwo_WithoutHardwareIntrinsics_Works() => FeatureTestRunner.RunWithHwIntrinsicsFeature(RunTransformTwoTest, HwIntrinsics.DisableHWIntrinsic);

    [Fact]
    public void TransformOne_WithHardwareIntrinsics_Works() => FeatureTestRunner.RunWithHwIntrinsicsFeature(RunTransformOneTest, HwIntrinsics.AllowAll);

    [Fact]
    public void TransformOne_WithoutHardwareIntrinsics_Works() => FeatureTestRunner.RunWithHwIntrinsicsFeature(RunTransformOneTest, HwIntrinsics.DisableHWIntrinsic);

    [Fact]
    public void Vp8Sse16X16_WithHardwareIntrinsics_Works() => FeatureTestRunner.RunWithHwIntrinsicsFeature(RunVp8Sse16X16Test, HwIntrinsics.AllowAll);

    [Fact]
    public void Vp8Sse16X16_WithoutSSE2_Works() => FeatureTestRunner.RunWithHwIntrinsicsFeature(RunVp8Sse16X16Test, HwIntrinsics.DisableSSE2);

    [Fact]
    public void Vp8Sse16X16_WithoutAVX2_Works() => FeatureTestRunner.RunWithHwIntrinsicsFeature(RunVp8Sse16X16Test, HwIntrinsics.DisableAVX2);

    [Fact]
    public void Vp8Sse16X8_WithHardwareIntrinsics_Works() => FeatureTestRunner.RunWithHwIntrinsicsFeature(RunVp8Sse16X8Test, HwIntrinsics.AllowAll);

    [Fact]
    public void Vp8Sse16X8_WithoutSSE2_Works() => FeatureTestRunner.RunWithHwIntrinsicsFeature(RunVp8Sse16X8Test, HwIntrinsics.DisableSSE2);

    [Fact]
    public void Vp8Sse16X8_WithoutAVX2_Works() => FeatureTestRunner.RunWithHwIntrinsicsFeature(RunVp8Sse16X8Test, HwIntrinsics.DisableAVX2);

    [Fact]
    public void Vp8Sse4X4_WithHardwareIntrinsics_Works() => FeatureTestRunner.RunWithHwIntrinsicsFeature(RunVp8Sse4X4Test, HwIntrinsics.AllowAll);

    [Fact]
    public void Vp8Sse4X4_WithoutSSE2_Works() => FeatureTestRunner.RunWithHwIntrinsicsFeature(RunVp8Sse4X4Test, HwIntrinsics.DisableSSE2);

    [Fact]
    public void Vp8Sse4X4_WithoutAVX2_Works() => FeatureTestRunner.RunWithHwIntrinsicsFeature(RunVp8Sse4X4Test, HwIntrinsics.DisableAVX2);

    [Fact]
    public void Mean16x4_WithHardwareIntrinsics_Works() => FeatureTestRunner.RunWithHwIntrinsicsFeature(RunMean16x4Test, HwIntrinsics.AllowAll);

    [Fact]
    public void Mean16x4_WithoutHardwareIntrinsics_Works() => FeatureTestRunner.RunWithHwIntrinsicsFeature(RunMean16x4Test, HwIntrinsics.DisableHWIntrinsic);

    [Fact]
    public void HadamardTransform_WithHardwareIntrinsics_Works() => FeatureTestRunner.RunWithHwIntrinsicsFeature(RunHadamardTransformTest, HwIntrinsics.AllowAll);

    [Fact]
    public void HadamardTransform_WithoutHardwareIntrinsics_Works() => FeatureTestRunner.RunWithHwIntrinsicsFeature(RunHadamardTransformTest, HwIntrinsics.DisableHWIntrinsic);
}
