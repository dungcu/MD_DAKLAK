using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DACASUCO.MDForms
{
    class Utils
    {
        #region doc so:
        public static string DocSo(double n)
        {

            string strSo = n.ToString();

            int len = (int)strSo.Length / 3;

            if (len * 3 < strSo.Length) len++;

            string[] t = new string[len];

            int i = 0;

            while (strSo != "")
            {

                if (strSo.Length > 3)
                {

                    t[i] = strSo.Substring(strSo.Length - 3, 3);

                    strSo = strSo.Substring(0, strSo.Length - 3);

                }

                else
                {

                    t[i] = strSo;

                    strSo = "";

                }

                i++;

            }

            string str = "";

            string temp;

            for (i = t.Length - 1; i >= 0; i--)
            {

                temp = Doc3(t[i]);

                if (temp.Trim() != "")
                {

                    str += temp.Trim() + " " + DonVi(i + 1) + " ";

                }

            }

            return str.Substring(0, 1).ToUpper() + str.Substring(1);

        }


        public static string DonVi(int n)
        {

            string str = "";

            switch (n.ToString())
            {

                case "0":

                    str = "VN";

                    break;

                case "1":

                    str = "đồng";

                    break;

                case "2":

                    str = "nghìn";

                    break;

                case "3":

                    str = "triệu";

                    break;

                case "4":

                    str = "tỷ";

                    break;

            }

            return str;

        }

        public static string Doc3(string n)
        {

            string tram = string.Empty, chuc = string.Empty, dv = string.Empty;

            if (n.Length == 3)
            {

                tram = n[0].ToString();

                chuc = n[1].ToString();

                dv = n[2].ToString();

            }

            if (n.Length == 2)
            {

                chuc = n[0].ToString();

                dv = n[1].ToString();

            }

            if (n.Length == 1)
            {

                dv = n[0].ToString();

            }

            if (n != "000")
            {

                if (tram != "") tram = So(int.Parse(tram)) + " trăm";

                if (chuc != "")
                {

                    switch (chuc)
                    {

                        case "0":

                            if (dv != "0")
                            {

                                chuc = "lẻ"; dv = So(int.Parse(dv));

                            }
                            else
                            {

                                dv = "";

                                chuc = "";

                            }

                            break;

                        case "1":

                            chuc = " mười";

                            if (dv != "0")
                            {

                                if (dv == "5")
                                {

                                    dv = "lăm";

                                }
                                else
                                {

                                    dv = So(double.Parse(dv));

                                }

                            }
                            else
                            {

                                dv = "";

                            }

                            break;

                        default:

                            chuc = So(int.Parse(chuc)) + " mươi";

                            if (dv == "5")
                            {

                                dv = "lăm";

                            }

                            else
                            {

                                if (dv != "0") dv = So(int.Parse(dv));

                                else dv = "";

                            }

                            //dv = So(int.Parse(dv));

                            break;

                    }

                }

                else
                {

                    if (chuc != "")
                    {

                        switch (chuc)
                        {

                            case "1":

                                chuc = " mươi";

                                if (dv != "0")
                                {

                                    if (dv == "5")
                                    {

                                        dv = "lăm";

                                    }

                                    else
                                    {

                                        dv = So(int.Parse(dv));

                                    }

                                }

                                break;

                            default:

                                chuc = So(int.Parse(chuc)) + " mươi";

                                if (dv == "5")
                                {

                                    dv = "lăm";

                                }

                                else
                                {

                                    dv = So(int.Parse(dv));

                                }

                                break;

                        }


                    }

                    else
                    {

                        dv = So(int.Parse(dv));

                    }

                }

            }

            else
            {

                tram = "";

                chuc = "";

                dv = "";

            }

            return tram + " " + chuc + " " + dv;

        }

        public static string So(double n)
        {

            string str = "";

            switch (n.ToString())
            {

                case "0":

                    str = "không";

                    break;

                case "1":

                    str = "một";

                    break;

                case "2":

                    str = "hai";

                    break;

                case "3":

                    str = "ba";

                    break;

                case "4":

                    str = "bốn";

                    break;

                case "5":

                    str = "năm";

                    break;

                case "6":

                    str = "sáu";

                    break;

                case "7":

                    str = "bẩy";

                    break;

                case "8":

                    str = "tám";

                    break;

                case "9":

                    str = "chín";

                    break;

            }

            return str;

        }
        #endregion
    }
}
