    public static class Chaos
    {
        //文本处理
        public static byte[] Encrypt(byte[] data, double u, double x0)
        {
            byte[] res = new byte[data.Length];
            double x = logistic(u, x0, 2000);

            for (int i = 0; i < data.Length; i++)
            {
                x = logistic(u, x, 5);
                res[i] = Convert.ToByte(Convert.ToInt32(Math.Floor(x * 1000)) % 256 ^ data[i]);
            }

            return res;
        }
        private static double logistic(double u, double x, int n)
        {
            for (int i = 0; i < n; i++)
            {
                x = u * x * (1 - x);
            }
            return x;
        }
        
        //图像处理
        public static Bitmap Encrypt(Bitmap src, double u, double x0)
        {
            Bitmap dest = new Bitmap(src.Width, src.Height);

            double x = logistic(u, x0, 2000);
            int key;
            for (int i = 0; i < src.Width; i++)
            {
                for (int j = 0; j < src.Height; j++)
                {
                    Color srcColor = src.GetPixel(i, j);

                    x = logistic(u, x, 5);
                    key = Convert.ToInt32(Math.Floor(x * 1000)) % 256;
                    int r = key ^ srcColor.R;
                    x = logistic(u, x, 5);
                    key = Convert.ToInt32(Math.Floor(x * 1000)) % 256;
                    int g = key ^ srcColor.G;
                    x = logistic(u, x, 5);
                    key = Convert.ToInt32(Math.Floor(x * 1000)) % 256;
                    int b = key ^ srcColor.B;

                    dest.SetPixel(i, j, Color.FromArgb(r, g, b));
                }
            }
            return dest;
        }
    }
