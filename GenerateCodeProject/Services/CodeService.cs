using GenerateCodeProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenerateCodeProject.Services
{
    public class CodeService
    {
        private Context _context;
        private String characters = "ACDEFGHKLMNPRTXYZ234579";
        public CodeService(Context context)
        {
            _context = context;
        }
        public List<String> GetAllCode()
        {
            return GenerateCode();

        }

        private List<String> GenerateCode()
        {
            List<String> list = new List<string>();
            String code = "";
            for(int i1 =0; i1 < 5; i1++)
            {
                for (int i2 = 0; i2 < 5; i2++)
                {
                    for (int i3 = 0; i3 < 5; i3++)
                    {
                        for (int i4 = 0; i4 < 5; i4++)
                        {
                            for (int i5 = 0; i5 < 5; i5++)
                            {
                                for (int i6 = 0; i6 < 5; i6++)
                                {
                                    for (int i7 = 0; i7 < 5; i7++)
                                    {
                                        int val = (i1 + i2+11 + i3+1 + i4+12 + i5+2 + i6+13 + i7+3) % 10;
                                        code = characters[i1].ToString() + 
                                            characters[i2 + 11].ToString() +
                                            characters[i3+1].ToString() + 
                                            characters[i4+12].ToString() +
                                            characters[i5+2].ToString() +
                                            characters[i6+13].ToString() +
                                            characters[i7+3].ToString() +
                                            val.ToString();
                                        list.Add(code);

                                    }
                                }
                            }
                        }
                    }
                }
 
            }
            return list;
        }

        public bool CheckCode(String code)
        {
            if (code.Length != 8)
                return false;

            int value = (characters.IndexOf(code[0]) + characters.IndexOf(code[1]) + characters.IndexOf(code[2]) +
                characters.IndexOf(code[3]) + characters.IndexOf(code[4]) + characters.IndexOf(code[5])
                + characters.IndexOf(code[6])) % 10;

            if (value.ToString() != code[7].ToString())
                return false;
            int x = 0;
            for (int i = 0; i < 7; i++)
            {
                if (i % 2 != 0)
                {
                    x += 11; 
                }
                else if (x > 10)
                {
                    x -= 10;
                } 
                Console.WriteLine(x);
                char c = characters[11];
                int count = characters.Length;
                String newString = new String(characters.Skip(x).Take(9).ToArray());
                if (newString.IndexOf(code[i]) < 0 )
                    return false;

            }
            return true;

        }
    }
}
