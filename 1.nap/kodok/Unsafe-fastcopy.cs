﻿static unsafe void FastCopy(byte[] src, int srcIndex, byte[] dst, int dstIndex, int count)
{
    if (src == null || srcIndex < 0 || dst == null || dstIndex < 0 || count < 0)
    {
        throw new ArgumentException();
    }
    int srcLen = src.Length;
    int dstLen = dst.Length;
    if (srcLen - srcIndex < count || dstLen - dstIndex < count)
    {
        throw new ArgumentException();
    }

    // pins the location of the src and dst objects in memory 
    // so that they will not be moved by garbage collection.          
    fixed (byte* pSrc = src, pDst = dst)
    {
        byte* ps = pSrc;
        byte* pd = pDst;

        // Loop over the count in blocks of 4 bytes, copying an
        // integer (4 bytes) at a time:
        for (int n = 0; n < count / 4; n++)
        {
            *((int*)pd) = *((int*)ps);
            pd += 4;
            ps += 4;
        }

        // Complete the copy by moving any bytes that weren't
        // moved in blocks of 4:
        for (int n = 0; n < count % 4; n++)
        {
            *pd = *ps;
            pd++;
            ps++;
        }
    }
}
