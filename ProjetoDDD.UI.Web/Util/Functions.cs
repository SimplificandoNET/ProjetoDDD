using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Web;

namespace ProjetoDDD.UI.Web.Util
{
    public static class Functions
    {
        public static string GetRandomString()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            var result = new string(
                Enumerable.Repeat(chars, 8)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());
            return result;
        }

        public static int CalculaIdade(DateTime DataNascimento)
        {

            int anos = DateTime.Now.Year - DataNascimento.Year;

            if (DateTime.Now.Month < DataNascimento.Month || (DateTime.Now.Month == DataNascimento.Month && DateTime.Now.Day < DataNascimento.Day))

                anos--;

            return anos;

        }

        public static string GetDataAtualPorExtenso()
        {
            return DateTime.Now.ToString("dddd").ToUpper() + ", " + DateTime.Now.ToString("dd").ToUpper() +
            " DE " + DateTime.Now.ToString("MMMM").ToUpper() + " DE " + DateTime.Now.ToString("yyyy").ToUpper() + " " +
            DateTime.Now.ToString("HH:mm").ToUpper();
        }

        public static string GetServerIP()
        {
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());

            foreach (IPAddress address in ipHostInfo.AddressList)
            {
                if (address.AddressFamily == AddressFamily.InterNetwork)
                    return address.ToString() + "|" + ipHostInfo.HostName;
            }

            return string.Empty;
        }

        public enum TypeString
        {
            Text,
            Numeric,
            CNPJ,
            CPF,
            Date,
            Int,
            CEP,
            Telefone,
            Currency,
            Percent,
            Milhar,
            AnoMes
        }

        public static string FormatString(string value, TypeString type)
        {
            try
            {
                NumberFormatInfo numberFormatInfo = new CultureInfo("pt-BR", false).NumberFormat;

                switch (type)
                {
                    case TypeString.Text:
                        return value;
                    case TypeString.Numeric:
                        return Convert.ToDouble(value).ToString("#,##0.00");
                    case TypeString.CNPJ:
                        value = value.PadLeft(14, '0');
                        return string.Format("{0}.{1}.{2}/{3}-{4}", value.Substring(0, 2), value.Substring(2, 3), value.Substring(5, 3), value.Substring(8, 4), value.Substring(12, 2));
                    case TypeString.CPF:
                        value = value.PadLeft(11, '0');
                        return string.Format("{0}.{1}.{2}-{3}", value.Substring(0, 3), value.Substring(3, 3), value.Substring(6, 3), value.Substring(9, 2));
                    case TypeString.Date:
                        if (Convert.ToDateTime(value) == Convert.ToDateTime("1/1/1900"))
                            return string.Empty;
                        else
                            return Convert.ToDateTime(value).ToString("dd/MM/yyyy");
                    case TypeString.CEP:
                        value = value.PadLeft(8, '0');
                        return string.Format("{0}.{1}-{2}", value.Substring(0, 2), value.Substring(2, 3), value.Substring(5, 3));
                    case TypeString.Telefone:
                        return string.Format("({0}) {1}", value.Substring(0, 2), value.Substring(2, value.Length - 2));
                    case TypeString.Currency:
                        return Convert.ToDouble(value).ToString("C");
                    case TypeString.Percent:
                        numberFormatInfo.PercentDecimalDigits = 0;
                        return Convert.ToDouble(value).ToString("P", numberFormatInfo);
                    case TypeString.Milhar:
                        return Convert.ToDouble(value).ToString("#,##0");
                    case TypeString.AnoMes:
                        return string.Format("{0}/{1}", value.Substring(value.Length - 2), value.Substring(0, 4));
                    default:
                        return value;
                }
            }
            catch
            {
                return value;
            }
        }
    }
}