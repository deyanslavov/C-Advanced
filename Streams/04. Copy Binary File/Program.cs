namespace _04.Copy_Binary_File
{
    using System.IO;

    class Program
    {
        static void Main()
        {
            using (FileStream reader = new FileStream("..//..//copyMe.png",FileMode.Open))
            {
                using (FileStream destination = new FileStream("..//..//copied.png",FileMode.Create))
                {
                    
                    byte[] buffer = new byte[10240];

                    while (true)
                    {
                        var byteread = reader.Read(buffer, 0, buffer.Length);
                        if (byteread == 0)
                        {
                            break;
                        }
                        destination.Write(buffer, 0, byteread);
                    }
                }
            }
        }
    }
}
