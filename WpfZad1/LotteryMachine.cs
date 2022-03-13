using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfZad1
{
    internal class LotteryMachine
    {
        List<string> coupons = new List<string>();
        public void AddNewCoupon(string coupon)
        {
            coupons.Add(coupon);
        }
        public string GetRandomCoupon()
        {
            Random random = new Random();
            int couponIndex;

            if (coupons.Count > 0)
            {
                couponIndex = random.Next(0, coupons.Count);
                string coupon = coupons[couponIndex];
                coupons.RemoveAt(couponIndex);

                return coupon;
            }

            return "No coupon available";
        }
        public bool CouponsAvailable()
        {
            return coupons.Count > 0;
        }
        public string GetAllCoupons()
        {
            string rtn = "";

            if (CouponsAvailable())
            {
                for (int i = 0; i < coupons.Count; i++)
                {
                    rtn += (i + 1) + ". " + coupons[i] + "\n";
                }

                return rtn == "" ? "Machine is empty" : rtn;
            }
            else
            {
                return "Machine is empty.";
            }
        }
    }
}
